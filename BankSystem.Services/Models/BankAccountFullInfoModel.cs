namespace BankSystem.Services.Models;


/// <summary>
/// Represents the full information model for a bank account.
/// </summary>
public class BankAccountFullInfoModel
{
    /// <summary>
    /// Gets or sets the bank account ID.
    /// </summary>
    public int BankAccountId { get; set; }

    /// <summary>
    /// Gets or sets the first name of the account owner.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the account owner.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the bank account number.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the balance of the bank account.
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the bank account.
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Gets or sets the bonus points associated with the bank account.
    /// </summary>
    public int BonusPoints { get; set; }
}
