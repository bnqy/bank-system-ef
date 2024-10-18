using Microsoft.EntityFrameworkCore;

namespace BankSystem.EF.Entities;

/// <summary>
/// Represents the database context for the bank system.
/// </summary>
public class BankContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BankContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public BankContext(DbContextOptions<BankContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet of account cash operations.
    /// </summary>
    public DbSet<AccountCashOperation> AccountCashOperations { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of bank accounts.
    /// </summary>
    public DbSet<BankAccount> BankAccounts { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of account owners.
    /// </summary>
    public DbSet<AccountOwner> AccountOwners { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of currency codes.
    /// </summary>
    public DbSet<CurrencyCode> CurrencyCodes { get; set; }

    /// <summary>
    /// Configures the model creating options.
    /// </summary>
    /// <param name="modelBuilder">The model builder to configure.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships, constraints, etc.
        modelBuilder.Entity<BankAccount>()
            .HasOne(b => b.AccountOwner)
            .WithMany(a => a.BankAccounts)
            .HasForeignKey(b => b.AccountOwnerId);

        modelBuilder.Entity<AccountCashOperation>()
            .HasOne(a => a.BankAccount)
            .WithMany() // Removed the reference from BankAccount
            .HasForeignKey(a => a.BankAccountId);

        // Additional configurations can be added here
    }
}
