/*using BankSystem.EF.Entities;

namespace BankSystem.Services.Models.Accounts;

StandardAccount is a class
 * representing a standard bank
 * account in a banking system.
 * It is derived from the base class
 * BankAccount, and it overrides
 * some properties and methods from it.
public class StandardAccount : BankAccount
{
    /// <summary>
    /// determine the reward point calculation
    /// </summary>
    private const int StandardBalanceCostPerPoint = 100;
    public StandardAccount(AccountOwner owner, string currencyCode) : base(owner, currencyCode)
    {
        StandardAccount(AccountOwner owner,
         *string currencyCode, IUniqueNumberGenerator
         * uniqueNumberGenerator) constructor initializes
         *a new StandardAccount with the specified
         * owner, currency code, and a number generator.
    }

    public StandardAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    {
        StandardAccount(AccountOwner owner,
         *string currencyCode, Func<string>
         * numberGenerator): constructor initializes
         *a new StandardAccount with the specified owner,
         *currency
         * code, and a function type number generator.
    }

    public StandardAccount(AccountOwner owner, string currencyCode, decimal initialBalance) : base(owner, currencyCode, initialBalance)
    {
        StandardAccount(AccountOwner owner,
         *string currencyCode, IUniqueNumberGenerator
         * uniqueNumberGenerator, decimal initialBalance)
         * constructor initializes a new StandardAccount
         * with the specified owner, currency code,
         *a number generator, and an initial balance.
    }

    public StandardAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance) : base(owner, currencyCode, numberGenerator, initialBalance)
    {
    }

    The StandardAccount class overrides the absract
     * Overdraft property of the base BankAccount class:
    Overdraft: for the StandardAccount, overdraft is always 0.
    public override decimal Overdraft { get; set; } = 0;

    CalculateDepositRewardPoints(decimal amount) method
     * calculates reward points based on balance only, using
     * pre-defined calculation constant according to the formula:
    DepositRewardPoints = max(⌊(Balance / StandardBalanceCostPerPoint)」, 0)

    ⌊ x 」 rounds a specified Decimal number to the closest integer toward negative infinity(see Decimal.Floor(Decimal) Method);

max(x, y) gives the maximum of x and y.
    public override void CalculateDepositRewardPoints(decimal amount)
{
    throw new NotImplementedException();
}

CalculateWithdrawRewardPoints(decimal amount) :
     * Calculates reward points based on balance only,
     * using pre-defined
     * calculation constant according to the formula:
     WithdrawRewardPoints = max(⌊(Balance / StandardBalanceCostPerPoint)」, 0)

    public override void CalculateWithdrawRewardPoints(decimal amount)
{
    throw new NotImplementedException();
}
}
*/

using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;
/// <summary>
/// Represents a standard bank account in a banking system.
/// </summary>
public class StandardAccount : BankAccount
{
    // Constant that determines the reward point calculation.
    private const int StandardBalanceCostPerPoint = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="StandardAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    public StandardAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
        : base(owner, currencyCode, uniqueNumberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StandardAccount"/> class with the specified details.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    public StandardAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
        : base(owner, currencyCode, numberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StandardAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    public StandardAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StandardAccount"/> class with the specified details and an initial balance.
    /// </summary>
    /// <param name="owner">The account owner.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A function that generates unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit amount.</param>
    public StandardAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Gets the overdraft limit for the account.
    /// </summary>
    public override decimal Overdraft => 0; // Overdraft is always 0 for StandardAccount.

    /// <summary>
    /// Calculates reward points earned on deposit based on the account balance.
    /// </summary>
    /// <param name="amount">The amount deposited.</param>
    /// <returns>The bonus points earned.</returns>
    protected override int CalculateDepositRewardPoints(decimal amount)
    {
        // Calculate deposit reward points based on current balance.
        return (int)Math.Max(Math.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }

    /// <summary>
    /// Calculates reward points earned on withdrawal based on the account balance.
    /// </summary>
    /// <param name="amount">The amount withdrawn.</param>
    /// <returns>The bonus points earned.</returns>
    protected override int CalculateWithdrawRewardPoints(decimal amount)
    {
        // Calculate withdrawal reward points based on current balance.
        return (int)Math.Max(Math.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }
}
