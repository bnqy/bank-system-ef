using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;


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
    public AccountOwner AccountOwner { get; private set; }

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
        AccountOwner = owner ?? throw new ArgumentNullException(nameof(owner));
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
        AccountOwner = owner ?? throw new ArgumentNullException(nameof(owner));
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
        Deposit(initialBalance, DateTime.Now, "Hello Epam, pls hire me");
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
        Deposit(initialBalance, DateTime.Now, "Hello Epam, pls hire me");
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
    /*public void Deposit(decimal amount, DateTime dateTime, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }

        // Update the balance
        Balance += amount;

        // Create a new cash operation
        var operation = new AccountCashOperation(amount, dateTime, note);

        // Add the operation to the operations list
        Operations.Add(operation);

        // Optionally calculate bonus points (if implemented)
        BonusPoints += CalculateDepositRewardPoints(amount);
    }*/
    public void Deposit(decimal amount, DateTime dateTime, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }

        // Update the balance
        Balance += amount;

        // Create a new cash operation
        var operation = new AccountCashOperation(amount, dateTime, note);

        // Add the operation to the operations list
        Operations.Add(operation);

        // Calculate bonus points (make sure this method is public/protected)
        BonusPoints += CalculateDepositRewardPoints(amount);
    }
    /// <summary>
    /// Withdraws the specified amount from the account.
    /// </summary>
    /// <param name="amount">The amount to withdraw.</param>
    public void Withdraw(decimal amount, DateTime dateTime, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }

        // Check if there are sufficient funds (considering overdraft)
        if (Balance + Overdraft < amount)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        // Update the balance
        Balance -= amount;

        // Create a new cash operation
        var operation = new AccountCashOperation(-amount, dateTime, note);

        // Add the operation to the operations list
        Operations.Add(operation);

        // Optionally calculate bonus points
        BonusPoints += CalculateWithdrawRewardPoints(amount);
    }

    /// <summary>
    /// Calculates bonus points earned on deposit. Must be implemented in derived classes.
    /// </summary>
    /// <param name="amount">The amount deposited.</param>
    /// <returns>The bonus points earned.</returns>
    protected abstract int CalculateDepositRewardPoints(decimal amount);

    /// <summary>
    /// Calculates bonus points earned on withdrawal. Must be implemented in derived classes.
    /// </summary>
    /// <param name="amount">The amount withdrawn.</param>
    /// <returns>The bonus points earned.</returns>
    protected abstract int CalculateWithdrawRewardPoints(decimal amount);
}
