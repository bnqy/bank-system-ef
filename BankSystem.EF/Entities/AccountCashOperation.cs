namespace BankSystem.EF.Entities;

public class AccountCashOperation
{
    public int Id { get; set; }

    public int BankAccountId { get; set; }

    public decimal Amount { get; set; }

    public string OperationDateTime { get; set; }

    public string Note { get; set; }

    public BankAccount BankAccount { get; set; }
}

