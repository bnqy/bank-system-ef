/*using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace BankSystem.EF.Entities;

public class AccountCashOperation
{
    private DateTime date;

    public int Id { get; set; }

    public int BankAccountId { get; set; }

    public decimal Amount { get; set; }

    public string OperationDateTime { get; set; }

    public string Note { get; set; }

    public BankAccount BankAccount { get; set; }

    public AccountCashOperation(decimal amount, string date, string note)
    {
        Amount = amount;
        OperationDateTime = date;
        Note = note;
    }

    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        this.Amount = amount;
        this.date = date;
        this.Note = note;
    }

    public override string ToString()
    {
        return $$"""
The account amount: {{Amount}},
OperationDateTime: {{OperationDateTime}},
Note: {{Note}}
""";
    }
    //The class overrides the ToString() method to return a string that provides a detailed description of the operation, including amount, the date and time, note, and whether the operation was a credit or a debit.
}

*/

/*using System;

namespace BankSystem.EF.Entities;

/// <summary>
/// Represents a bank account cash operation, including the amount, date, and any associated notes.
/// </summary>
public class AccountCashOperation
{
    /// <summary>
    /// Gets the amount of the bank operation.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets the date and time of the bank operation.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets the note associated with the bank operation.
    /// </summary>
    public string Note { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountCashOperation"/> class with the specified amount, date, and note.
    /// </summary>
    /// <param name="amount">The amount of the operation.</param>
    /// <param name="date">The date and time when the operation occurred.</param>
    /// <param name="note">A note describing the operation.</param>
    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Note = note;
    }

    /// <summary>
    /// Returns a string representation of the operation, including amount, date, note, and whether it's a credit or debit.
    /// </summary>
    /// <returns>A string that describes the cash operation.</returns>
    public override string ToString()
    {
        // Determine if the operation is a credit or debit based on the amount
        string operationType = Amount >= 0 ? "Credit" : "Debit";
        return $"{operationType}: Amount = {Amount:C}, Date = {Date}, Note = {Note}";
    }
}*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities
{
    /// <summary>
    /// Represents a cash operation on a bank account.
    /// </summary>
    [Table("account_cash_operation")] // Specify the database table name
    public class AccountCashOperation
    {
        /// <summary>
        /// Gets or sets the unique identifier for the operation.
        /// </summary>
        [Key] // Indicates this property is the primary key
        [Column("account_cash_operation_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the bank account identifier associated with the operation.
        /// </summary>
        [ForeignKey("BankAccount")] // Specifies this property as a foreign key
        [Column("bank_account_id")]
        public int BankAccountId { get; set; }

        /// <summary>
        /// Gets or sets the amount involved in the operation.
        /// </summary>
        [Column("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the operation.
        /// </summary>
        [Column("operation_date_time")] // Specify the database column name if different
        public string OperationDateTime { get; set; }

        /// <summary>
        /// Gets or sets any notes related to the operation.
        /// </summary>
        [Column("note")]
        public string Note { get; set; }

        /// <summary>
        /// Navigation property to the associated bank account.
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }
}
