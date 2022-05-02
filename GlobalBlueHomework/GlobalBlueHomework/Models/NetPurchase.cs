namespace GlobalBlueHomework.Models
{
    public class NetPurchase : Purchase
    {
        /// <summary>
        /// Calculate missing values for each purchase
        /// </summary>
        public override void CalculateMissingValues()
        {
            decimal vatValue = (decimal)this.VatRate / 100;
            this.VatAmmount = this.NetAmmount * vatValue;
            this.GrossAmmount = this.NetAmmount + this.VatAmmount;
        }
    }
}