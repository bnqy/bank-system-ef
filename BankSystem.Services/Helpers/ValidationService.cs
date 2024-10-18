using System.Globalization;

namespace BankSystem.Services.Helpers;

public static class ValidatorService
{
    /// <summary>
    /// Validates if the provided currency code is valid for any known culture.
    /// </summary>
    /// <param name="currencyCode">The currency code to validate (e.g., "USD", "EUR").</param>
    /// <returns>True if the currency code is valid, otherwise false.</returns>
    public static bool IsCurrencyValid(string currencyCode)
    {
        if (string.IsNullOrEmpty(currencyCode))
        {
            return false;
        }

        // Loop through all cultures to check if the provided currency matches any culture's region
        foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            var region = new RegionInfo(culture.Name);
            if (region.ISOCurrencySymbol.Equals(currencyCode, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false; // No match found, so return false.
    }

#pragma warning disable CA1307 // Specify StringComparison for clarity
    public static bool IsEmailValid(string email)
    {
        return email.Contains('@');
    }
#pragma warning restore CA1307 // Specify StringComparison for clarity
}
