namespace GlobalBlueHomework.Models
{
    public class GrossPurchase : Purchase
    {
        /// <summary>
        /// Calculate missing values for each purchase
        /// </summary>
        public override void CalculateMissingValues()
        {
            decimal vatValue = (decimal)this.VatRate / 100;
            this.NetAmmount = this.GrossAmmount / (1 + vatValue);
            this.VatAmmount = this.GrossAmmount - this.NetAmmount;
        }
    }
}