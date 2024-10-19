using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

/// <summary>
/// Represents a gold bank account in a banking system.
/// </summary>
public class GoldAccount : BankAccount
{
    // Constants that determine the reward point calculation.
    private const int GoldDepositCostPerPoint = 10;
    private const int GoldWithdrawCostPerPoint = 5;
    private const int GoldBalanceCostPerPoint = 5;

    /// <summary>
    /// Initializes a new instance of the <see cref="GoldAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    public GoldAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
        : base(owner, currencyCode, uniqueNumberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GoldAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    public GoldAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
        : base(owner, currencyCode, numberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GoldAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    public GoldAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GoldAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    public GoldAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Gets the overdraft limit for the account.
    /// </summary>
    public override decimal Overdraft => 3 * BonusPoints; // Overdraft equals to 3 * BonusPoints for GoldAccount.

    /// <summary>
    /// Calculates reward points earned on deposit based on the account balance and deposit amount.
    /// </summary>
    /// <param name="amount">The amount deposited.</param>
    /// <returns>The bonus points earned.</returns>
    protected override int CalculateDepositRewardPoints(decimal amount)
    {
        // DepositRewardPoints = max( 「(Balance / GoldBalanceCostPerPoint)⌉+ 「(Deposit / GoldDepositCostPerPoint)⌉, 0)

        // Calculate deposit reward points based on current balance and deposit amount.
        return (int)Math.Max(Math.Ceiling((Balance / GoldBalanceCostPerPoint) + (amount / GoldDepositCostPerPoint)), 0);
       // return (int)(amount * 2);
    }

    /// <summary>
    /// Calculates reward points earned on withdrawal based on the account balance and withdrawal amount.
    /// </summary>
    /// <param name="amount">The amount withdrawn.</param>
    /// <returns>The bonus points earned.</returns>
    protected override int CalculateWithdrawRewardPoints(decimal amount)
    {
        // Calculate withdrawal reward points based on current balance and withdrawal amount.
        return (int)Math.Max(Math.Ceiling((Balance / GoldBalanceCostPerPoint) + (amount / GoldWithdrawCostPerPoint)), 0);
        // return (int)(amount * 1);
    }
}
