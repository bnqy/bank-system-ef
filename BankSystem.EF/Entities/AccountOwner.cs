/*using System.Security.Principal;

namespace BankSystem.EF.Entities;

public class AccountOwner
{
    /// <summary>
    /// represents account owner's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// represents account owner's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// represents account owner's email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// represents a list of bank accounts associated with the account owner
    /// </summary>
    public List<BankAccount> AccountOwners { get; set; }

    public AccountOwner(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {FirstName}, Email: {Email}";
    }

    public void Add(BankAccount account)
    {
        AccountOwners.Add(account);
    }

    public List<BankAccount> Accounts() => AccountOwners;

}
*/

/*using System;
using System.Collections.Generic;

namespace BankSystem.EF.Entities;

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
    public List<BankAccount> _accounts { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountOwner"/> class with the specified details.
    /// </summary>
    /// <param name="firstName">The first name of the account owner.</param>
    /// <param name="lastName">The last name of the account owner.</param>
    /// <param name="email">The email address of the account owner.</param>
    public AccountOwner(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _accounts = new List<BankAccount>();
    }

    /// <summary>
    /// Returns a string representation of the account owner, including their name and email.
    /// </summary>
    /// <returns>A string that describes the account owner.</returns>
    public override string ToString()
    {
        return $"{FirstName} {LastName}, Email: {Email}";
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
    public List<BankAccount> GetAccounts()
    {
        return _accounts;
    }
}
*/


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities
{
    /// <summary>
    /// Represents the owner of a bank account.
    /// </summary>
    [Table("account_owner")] // Specify the database table name
    public class AccountOwner
    {
        /// <summary>
        /// Gets or sets the unique identifier for the account owner.
        /// </summary>
        [Key] // Indicates this property is the primary key
        [Column("account_owner_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the account owner.
        /// </summary>
        [Column("first_name")] // Specify the database column name
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the account owner.
        /// </summary>
        [Column("last_name")] // Specify the database column name
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the account owner.
        /// </summary>
        [Column("email")] // Specify the database column name
        public string Email { get; set; }

        /// <summary>
        /// Navigation property to the list of bank accounts owned by the account owner.
        /// </summary>
        public virtual List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>(); // Initialize the list to avoid null references
    }
}
