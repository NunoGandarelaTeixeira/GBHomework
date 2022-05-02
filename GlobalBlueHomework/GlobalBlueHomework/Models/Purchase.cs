namespace GlobalBlueHomework.Models
{
    public abstract class Purchase
    {
        /// <summary>
        /// Purchase primary key - Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Purchase Net Ammount
        /// </summary>
        public decimal NetAmmount { get; set; }

        /// <summary>
        /// Purchase Gross Ammount
        /// </summary>
        public decimal GrossAmmount { get; set; }

        /// <summary>
        /// Purchase VAT Ammount
        /// </summary>
        public decimal VatAmmount { get; set; }

        /// <summary>
        /// VAT Rate applied
        /// </summary>
        public int VatRate { get; set; }

        /// <summary>
        /// Calculate missing values for each purchase
        /// </summary>
        public abstract void CalculateMissingValues();
    }
}