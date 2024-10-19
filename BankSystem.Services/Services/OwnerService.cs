using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;

/*public class OwnerService
{
    private readonly BankContext _context;

    public OwnerService(BankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets the total balance of all account owners.
    /// </summary>
    /// <returns>A read-only list of account owner total balance models.</returns>
    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        var ownersTotalBalance = _context.AccountOwners
            .Select(owner => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                CurrencyCode = owner.BankAccounts.FirstOrDefault().CurrencyCode.Code, // Assumes the first account's currency is representative
                Total = (decimal)owner.BankAccounts.Sum(account => (double)account.Balance) // Explicit conversion
            })
            .OrderByDescending(owner => (double)owner.Total) // Explicit conversion
            .ToList();
        return ownersTotalBalance.AsReadOnly();
    }
}*/

public class OwnerService : IDisposable
{
    private readonly BankContext _context;
    private bool _disposed; // Track whether Dispose has been called

    public OwnerService(BankContext context)
    {
        this._context = context;
    }

    /// <summary>
    /// Gets total balance for all account owners.
    /// </summary>
    /// <returns>A read-only list of account owner total balance models.</returns>
    /*public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        var totalBalances = _context.AccountOwners
            .Select(owner => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                CurrencyCode = owner.BankAccounts.FirstOrDefault().CurrencyCode.CurrenciesCode,
                Total = (decimal)owner.BankAccounts.Sum(account => account.Balance)
            })
            .OrderByDescending(model => model.Total)
            .ToList();

        return totalBalances.AsReadOnly();
    }*/
    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return this._context.AccountOwners
            .Select(owner => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                CurrencyCode = owner.BankAccounts.FirstOrDefault().CurrencyCode.CurrenciesCode,
                Total = (decimal)this._context.BankAccounts
                    .Where(account => account.AccountOwnerId == owner.Id)
                    .Sum(account => (double)account.Balance) // Convert to double here
            })
            .OrderByDescending(x => (double)x.Total)
            .ToList()
            .AsReadOnly();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }


    // Implement IDisposable.
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
                this._context.Dispose();
            }

            // Dispose unmanaged resources here if any.

            this._disposed = true;
        }
    }

    // Destructor (finalizer).
    ~OwnerService()
    {
        this.Dispose(false);
    }
}
