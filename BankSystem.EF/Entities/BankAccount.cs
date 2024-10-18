/*//using BankSystem.Services.Generators;

namespace BankSystem.EF.Entities;

Because BankAccount is an abstract class,
 * you'll need to create a subclass in o
 * rder to use most of this functionality.
 * This ensures that the specific details
 * associated with a given bank
 * account type can be handled appropriately.
public abstract class BankAccount
{
    public int Id { get; set; }

    public int AccountOwnerId { get; set; }

    public string Number { get; set; }

    public decimal Balance { get; set; }

    public int CurrencyCodeId { get; set; }

    public static int BonusPoints { get; set; }

    public abstract decimal Overdraft { get; set; }

    public AccountOwner AccountOwner { get; set; }

    //public CurrencyCode CurrencyCode { get; set; }

    public BankAccount(AccountOwner owner, string currencyCode IUniqueNumberGenerator uniqueNumberGenerator)
    {
    }

    public BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
    {
    }

    public BankAccount(AccountOwner owner, string currencyCode IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
    {
    }

    public BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
    {
    }

    public void Deposit()
    {

    }

    public void Withdraw()
    {

    }
    public abstract void CalculateDepositRewardPoints(decimal amount);
    public abstract void CalculateWithdrawRewardPoints(decimal amount);
    GetAllOperations() method returns all operations performed on the account.

    Deposit() method allows depositing money to account.

    Withdraw() method allows withdrawing money from the account.

    CalculateDepositRewardPoints() is abstract method, it should be implemented in subclass to specify how bonus points should be calculated upon deposit.

    CalculateWithdrawRewardPoints() is abstract method, it should be implemented in subclass to specify how bonus points should be calculated upon withdrawal.
}

*/

///

/*using System;
using System.Collections.Generic;
using BankSystem.Services.Generators;


namespace BankSystem.EF.Entities;

/// <summary>
/// Represents a bank account. This is an abstract class and cannot be instantiated directly.
/// </summary>
public abstract class BankAccount
{
    /// <summary>
    /// Gets the bank account number.
    /// </summary>
    public string Number { get; private set; }

    /// <summary>
    /// Gets the balance of the account.
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Gets the ISO currency code for the account.
    /// </summary>
    public string CurrencyCode { get; private set; }

    /// <summary>
    /// Gets the owner of the bank account.
    /// </summary>
    public AccountOwner Owner { get; private set; }

    /// <summary>
    /// Gets or sets the bonus points associated with the account.
    /// </summary>
    public int BonusPoints { get; private set; }

    /// <summary>
    /// Gets the overdraft limit for the account. Must be implemented in derived classes.
    /// </summary>
    public abstract decimal Overdraft { get; }

    /// <summary>
    /// Stores all operations performed on the account.
    /// </summary>
    protected List<AccountCashOperation> Operations { get; } = new List<AccountCashOperation>();

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
    {
        Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        Number = uniqueNumberGenerator.Generate();
        Balance = 0m;
        BonusPoints = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
    {
        Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        CurrencyCode = currencyCode ?? throw new ArgumentNullException(nameof(currencyCode));
        Number = numberGenerator();
        Balance = 0m;
        BonusPoints = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : this(owner, currencyCode, uniqueNumberGenerator)
    {
        Deposit(initialBalance);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : this(owner, currencyCode, numberGenerator)
    {
        Deposit(initialBalance);
    }

    /// <summary>
    /// Returns all operations performed on the account.
    /// </summary>
    /// <returns>A list of all cash operations.</returns>
    public List<AccountCashOperation> GetAllOperations()
    {
        return Operations;
    }

    /// <summary>
    /// Deposits the specified amount into the account.
    /// </summary>
    /// <param name="amount">The amount to deposit.</param>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));

        Balance += amount;
        BonusPoints += CalculateDepositRewardPoints(amount);
        Operations.Add(new AccountCashOperation(amount, DateTime.Now, "Deposit"));
    }

    /// <summary>
    /// Withdraws the specified amount from the account.
    /// </summary>
    /// <param name="amount">The amount to withdraw.</param>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));

        if (Balance + Overdraft < amount)
            throw new InvalidOperationException("Insufficient funds for withdrawal.");

        Balance -= amount;
        BonusPoints += CalculateWithdrawRewardPoints(amount);
        Operations.Add(new AccountCashOperation(-amount, DateTime.Now, "Withdraw"));
    }

    /// <summary>
    /// Calculates bonus points earned on deposit. Must be implemented in derived classes.
    /// </summary>
    /// <param name="amount">The amount deposited.</param>
    /// <returns>The bonus points earned.</returns>
    public abstract int CalculateDepositRewardPoints(decimal amount);

    /// <summary>
    /// Calculates bonus points earned on withdrawal. Must be implemented in derived classes.
    /// </summary>
    /// <param name="amount">The amount withdrawn.</param>
    /// <returns>The bonus points earned.</returns>
    public abstract int CalculateWithdrawRewardPoints(decimal amount);
}
*/


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    [Table("BankAccounts")] // Specify the database table name
    public class BankAccount
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bank account.
        /// </summary>
        [Key] // Indicates this property is the primary key
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the account owner identifier associated with the bank account.
        /// </summary>
        [ForeignKey("AccountOwner")] // Specifies this property as a foreign key
        public int AccountOwnerId { get; set; }

        /// <summary>
        /// Gets or sets the unique number of the bank account.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the current balance of the bank account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the currency code identifier for the bank account.
        /// </summary>
        [ForeignKey("CurrencyCode")] // Specifies this property as a foreign key
        public int CurrencyCodeId { get; set; }

        /// <summary>
        /// Gets or sets the bonus points associated with the bank account.
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Gets or sets the overdraft limit for the bank account.
        /// </summary>
        public decimal Overdraft { get; set; }

        /// <summary>
        /// Navigation property to the account owner associated with this bank account.
        /// </summary>
        public virtual AccountOwner AccountOwner { get; set; }

        /// <summary>
        /// Navigation property to the currency code associated with this bank account.
        /// </summary>
        public virtual CurrencyCode CurrencyCode { get; set; }
    }
}
