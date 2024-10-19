using System.Globalization;

namespace BankSystem.Services.Models;


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
    /*public override string ToString()
    {
        // Determine if the operation is a credit or debit based on the amount
        string operationType = Amount >= 0 ? "Credit" : "Debit";
        return $"{operationType}: Amount = {Amount:C}, Date = {Date}, Note = {Note}";
    }*/

    public override string ToString()
    {
        // Determine if the operation is a credit or debit based on the amount
        string operationType = Amount >= 0 ? "Credited to account" : "Debited from account";

        // Format the date as MM/dd/yyyy HH:mm:ss
        //string formattedDate = DateTime.Parse(this.Date).ToString("MM/dd/yyyy HH:mm:ss");
        string formattedDate = Date.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        // Format the amount without the currency symbol
        string formattedAmount = (Amount).ToString("F0", CultureInfo.InvariantCulture); // Remove decimal places, commas, and currency symbol

        // Construct the string in the expected format
        return $"{formattedDate} {Note} : {operationType} {formattedAmount}.";
    }

}
