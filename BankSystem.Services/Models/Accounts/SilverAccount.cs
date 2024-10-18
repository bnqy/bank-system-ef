/*using BankSystem.EF.Entities;

namespace BankSystem.Services.Models.Accounts;

public class SilverAccount : BankAccount
{
    private const int SilverDepositCostPerPoint = 5;
    private const int SilverWithdrawCostPerPoint = 2;
    private const int SilverBalanceCostPerPoint = 100;

    public SilverAccount(AccountOwner owner, string currencyCode) : base(owner, currencyCode)
    {
        SilverAccount(Owner owner, string currencyCode,
         *IUniqueNumberGenerator uniqueNumberGenerator)
         * constructor initializes a new SilverAccount with
         * the specified owner, currency code, and a number
         * generator.
    }

    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    {
    }

    public SilverAccount(AccountOwner owner, string currencyCode, decimal initialBalance) : base(owner, currencyCode, initialBalance)
    {
    }

    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance) : base(owner, currencyCode, numberGenerator, initialBalance)
    {
    }

    public override decimal Overdraft { get; set; } = 2 * BonusPoints;

    // DepositRewardPoints = max( ⌊(Balance / SilverBalanceCostPerPoint)」+ ⌊ (Deposit / SilverDepositCostPerPoint)」, 0)

    public override void CalculateDepositRewardPoints(decimal amount)
    {
        throw new NotImplementedException();
    }

    // WithdrawRewardPoints = max(⌊(Balance / SilverBalanceCostPerPoint)」 + ⌊(Deposit / SilverDepositCostPerPoint)」, 0)

    public override void CalculateWithdrawRewardPoints(decimal amount)
    {
        throw new NotImplementedException();
    }
}
*/


using BankSystem.Services.Generators;
using BankSystem.Services.Models.Accounts;

using BankSystem.Services.Models;

namespace BankSystem.Services.Models.Accounts;

/// <summary>
/// Represents a silver bank account in a banking system.
/// </summary>
public class SilverAccount : BankAccount
{
    // Constants that determine the reward point calculation.
    private const int SilverDepositCostPerPoint = 5;
    private const int SilverWithdrawCostPerPoint = 2;
    private const int SilverBalanceCostPerPoint = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
        : base(owner, currencyCode, uniqueNumberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
        : base(owner, currencyCode, numberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Gets the overdraft limit for the account.
    /// </summary>
    public override decimal Overdraft => 2 * BonusPoints; // Overdraft equals to 2 * BonusPoints for SilverAccount.

    /// <summary>
    /// Calculates reward points earned on deposit based on the account balance and deposit amount.
    /// </summary>
    /// <param name="amount">The amount deposited.</param>
    /// <returns>The bonus points earned.</returns>
    public override int CalculateDepositRewardPoints(decimal amount)
    {
        // Calculate deposit reward points based on current balance and deposit amount.
        return (int)Math.Max(Math.Floor(Balance / SilverBalanceCostPerPoint) + Math.Floor(amount / SilverDepositCostPerPoint), 0);
    }

    /// <summary>
    /// Calculates reward points earned on withdrawal based on the account balance and withdrawal amount.
    /// </summary>
    /// <param name="amount">The amount withdrawn.</param>
    /// <returns>The bonus points earned.</returns>
    public override int CalculateWithdrawRewardPoints(decimal amount)
    {
        // Calculate withdrawal reward points based on current balance and withdrawal amount.
        return (int)Math.Max(Math.Floor(Balance / SilverBalanceCostPerPoint) + Math.Floor(amount / SilverWithdrawCostPerPoint), 0);
    }
}
