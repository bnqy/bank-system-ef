using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities
{
    /// <summary>
    /// Represents a currency code used in bank accounts.
    /// </summary>
    [Table("currency_code")] // Specify the database table name
    public class CurrencyCode
    {
        /// <summary>
        /// Gets or sets the unique identifier for the currency code.
        /// </summary>
        [Key] // Indicates this property is the primary key
        [Column("currency_code_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ISO code for the currency (e.g., USD, EUR).
        /// </summary>
        [Column("currency_code")] // Specify the database column name
        [MaxLength(3)] // ISO currency codes are typically 3 characters long
        [Required] // This property is required
        public string CurrenciesCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency (e.g., US Dollar).
        /// </summary>
        [Column("Name")] // Specify the database column name
        [MaxLength(50)] // Set a reasonable maximum length for currency names
        [Required] // This property is required
        public string Name { get; set; }
    }
}
