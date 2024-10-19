namespace BankSystem.Services.Models;
/// <summary>
/// Represents the total balance model for an account owner.
/// </summary>
public class AccountOwnerTotalBalanceModel
{
    /// <summary>
    /// Gets or sets the account owner ID.
    /// </summary>
    public int AccountOwnerId { get; set; }

    /// <summary>
    /// Gets or sets the first name of the account owner.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the account owner.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the account owner.
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the total balance of the account owner.
    /// </summary>
    public decimal Total { get; set; }
}
