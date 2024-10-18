using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;


/*public class AccountService
{
    private readonly BankContext _context;

    public AccountService(BankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets full information of all bank accounts.
    /// </summary>
    /// <returns>A read-only list of bank account full information models.</returns>
    public IReadOnlyList<BankAccountFullInfoModel> GetBankAccountsFullInfo()
    {
        var accountsFullInfo = _context.BankAccounts
            .Select(account => new BankAccountFullInfoModel
            {
                BankAccountId = account.Id,
                FirstName = account.AccountOwner.FirstName,
                LastName = account.AccountOwner.LastName,
                AccountNumber = account.Number,
                Balance = account.Balance,
                CurrencyCode = account.CurrencyCode.Code,
                BonusPoints = account.BonusPoints
            })
            .ToList();

        return accountsFullInfo.AsReadOnly();
    }
}*/

public class AccountService : IDisposable
{
    private readonly BankContext _context;
    private bool _disposed = false; // Track whether Dispose has been called

    public AccountService(BankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets full information of all bank accounts.
    /// </summary>
    /// <returns>A read-only list of bank account full information models.</returns>
    public IReadOnlyList<BankAccountFullInfoModel> GetBankAccountsFullInfo()
    {
        var accountsFullInfo = _context.BankAccounts
            .Select(account => new BankAccountFullInfoModel
            {
                BankAccountId = account.Id,
                FirstName = account.AccountOwner.FirstName,
                LastName = account.AccountOwner.LastName,
                AccountNumber = account.Number,
                Balance = account.Balance,
                CurrencyCode = account.CurrencyCode.Code,
                BonusPoints = account.BonusPoints
            })
            .ToList();

        return accountsFullInfo.AsReadOnly();
    }

    // Implement IDisposable.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
                _context.Dispose();
            }

            // Dispose unmanaged resources here if any.

            _disposed = true;
        }
    }

    // Destructor (finalizer).
    ~AccountService()
    {
        Dispose(false);
    }
}
