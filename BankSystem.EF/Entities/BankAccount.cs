namespace BankSystem.EF.Entities;

public class BankAccount
{
    public int Id { get; set; }

    public int AccountOwnerId { get; set; }

    public string Number { get; set; }

    public decimal Balance { get; set; }

    public int CurrencyCodeId { get; set; }

    public int BonusPoints { get; set; }

    public decimal Overdraft { get; set; }

    public AccountOwner AccountOwner { get; set; }

    public CurrencyCode CurrencyCode { get; set; }
}

