namespace GlobalBlueHomework.Models
{
    public class VatPurchase : Purchase
    {
        /// <summary>
        /// Calculate missing values for each purchase
        /// </summary>
        public override void CalculateMissingValues()
        {
            decimal vatValue = (decimal)this.VatRate / 100;
            this.NetAmmount = this.VatAmmount / vatValue;
            this.GrossAmmount = this.NetAmmount + this.VatAmmount;
        }
    }
}