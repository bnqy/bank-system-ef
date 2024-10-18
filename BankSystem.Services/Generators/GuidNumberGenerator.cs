using System;
using BankSystem.Services.Generators;
using BankSystem.Services.Helpers; // Assuming CryptoHelper is in this namespace

namespace BankSystem.Services.Generators
{
    /// <summary>
    /// GuidGenerator generates a unique string based on a globally unique identifier (GUID).
    /// </summary>
    public class GuidNumberGenerator : IUniqueNumberGenerator
    {
        /// <summary>
        /// Generates a unique string based on a GUID and hashes it using the CryptoHelper.
        /// </summary>
        /// <returns>A hashed string representation of a GUID.</returns>
        public string Generate()
        {
            // Generate a new GUID
            var guid = Guid.NewGuid().ToString();

            // Use CryptoHelper to hash the GUID
            return guid.GenerateHash(); // Assuming CryptoHelper has an extension method 'GenerateHash'
        }
    }
}
