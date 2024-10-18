using System.Security.Cryptography;
using System.Text;

namespace BankSystem.Services.Generators;


/// <summary>
/// SimpleGenerator class is a singleton responsible for generating unique sequential numbers.
/// </summary>
public sealed class SimpleGenerator : IUniqueNumberGenerator
{
    private static readonly SimpleGenerator _instance;
    private int _lastNumber;


#pragma warning disable format
    /// <summary>
    /// Gets the singleton instance of SimpleGenerator.
    /// </summary>
    public static SimpleGenerator Instance => _instance;
#pragma warning restore format

    // Static constructor to initialize the singleton instance.
    static SimpleGenerator()
#pragma warning disable format
    {
            _instance = new SimpleGenerator();
        }
#pragma warning restore format

    // Private constructor for Singleton pattern.
    private SimpleGenerator()
#pragma warning disable format
    {
            _lastNumber = 1234567890; // Initial value for number generation
        }
#pragma warning restore format

    /// <summary>
    /// Generates and returns a unique sequential number, hashed using MD5 for security.
    /// </summary>
    /// <returns>A hashed unique sequential number as a string.</returns>
    public string Generate()
        {
            _lastNumber++; // Increment the last number for a new unique value

            // Convert the new number to a string and compute its MD5 hash
            var numberAsString = _lastNumber.ToString();
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(numberAsString));

                // Convert the byte array to a hexadecimal string
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
            {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
}
