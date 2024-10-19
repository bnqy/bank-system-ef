using System.Collections.ObjectModel;
using BankSystem.Services.Models.Accounts;
using BankSystem.Services.Helpers;
namespace BankSystem.Services.Models;

/// <summary>
/// Represents a bank account owner, including their personal details and associated bank accounts.
/// </summary>
public class AccountOwner
{
    /// <summary>
    /// Gets the first name of the account owner.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the last name of the account owner.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the email address of the account owner.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Gets the list of bank accounts associated with the account owner.
    /// </summary>
    public Collection<BankAccount> _accounts { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountOwner"/> class with the specified details.
    /// </summary>
    /// <param name="firstName">The first name of the account owner.</param>
    /// <param name="lastName">The last name of the account owner.</param>
    /// <param name="email">The email address of the account owner.</param>
    public AccountOwner(string firstName, string lastName, string email)
    {
        VerifyString(firstName, lastName, email);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _accounts = new Collection<BankAccount>();
    }

    /// <summary>
    /// Returns a string representation of the account owner, including their name and email.
    /// </summary>
    /// <returns>A string that describes the account owner.</returns>
    public override string ToString()
    {
        return $"{FirstName} {LastName}, {Email}.";
    }

    /// <summary>
    /// Adds a new bank account to the list of accounts owned by this account owner.
    /// </summary>
    /// <param name="account">The bank account to be added.</param>
    public void Add(BankAccount account)
    {
        _accounts.Add(account);
    }

    /// <summary>
    /// Returns the list of bank accounts associated with this account owner.
    /// </summary>
    /// <returns>A list of bank accounts.</returns>
    public Collection<BankAccount> Accounts()
    {
        return this._accounts;
    }

    public void VerifyString(string firstName, string lastName, string email)
    {
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        ArgumentException.ThrowIfNullOrEmpty(firstName);

        if (!ValidatorService.IsEmailValid(email))
        {
            throw new ArgumentException(email);
        }
    }

    private static void VerifyString(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("String cannot be null or empty.", paramName);
        }
    }
}
