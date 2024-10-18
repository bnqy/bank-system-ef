using System;
using System.Security.Cryptography;
using System.Text;

namespace BankSystem.Services.Generators
{
    /// <summary>
    /// BasedOnTickUniqueNumberGenerator generates a unique number based on the elapsed time in ticks from a starting point.
    /// </summary>
    public class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
    {
        /// <summary>
        /// Represents the starting point in time from which the ticks are counted.
        /// </summary>
        public DateTime StartingPoint { get; }

        /// <summary>
        /// Initializes a new instance of the BasedOnTickUniqueNumberGenerator class with a specified starting point.
        /// </summary>
        /// <param name="startingPoint">The starting point in time to calculate the ticks.</param>
        public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
        {
            StartingPoint = startingPoint;
        }

        /// <summary>
        /// Generates a unique number based on the elapsed ticks from the starting point, hashes it, and returns it as a string.
        /// </summary>
        /// <returns>A hashed string representing the unique number based on elapsed ticks.</returns>
        public string Generate()
        {
            // Calculate the number of ticks from the starting point to the current time
            var elapsedTicks = (DateTime.UtcNow - StartingPoint).Ticks;

            // Convert the tick value to a string
            var ticksAsString = elapsedTicks.ToString();

            // Hash the tick value using MD5
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(ticksAsString));

                // Convert the hash bytes to a hexadecimal string
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
