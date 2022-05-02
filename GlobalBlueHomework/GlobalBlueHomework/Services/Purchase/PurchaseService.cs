using GlobalBlueHomework.DataStructures;
using GlobalBlueHomework.Models;
using GlobalBlueHomework.UnitOfWork;

namespace GlobalBlueHomework.Services
{
    public class PurchaseService : IPurchaseService
    {
        /// <summary>
        /// Unit of Work used to access the repositories
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Return all purchases
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Purchase> GetPurchases()
        {
            return _unitOfWork.Purchases.GetAll();
        }

        /// <summary>
        /// Return purchase by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Purchase GetPurchase(long id)
        {
            return _unitOfWork.Purchases.GetById(id);
        }

        /// <summary>
        /// Validate Save Purchase input values
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
        public void ValidateSaveInput(SavePurchaseInput input)
        {
            if (input == null || input.PurchaseValue == 0 || input.VatRate == 0)
            {
                throw new Exception("Invalid input: PurchaseValue and VatRate must be different than 0");
            }

            if (input.VatRate != 10 && input.VatRate != 13 && input.VatRate != 20)
            {
                throw new Exception($"A VAT Rate of {input.VatRate}% is not valid");
            }
        }

        /// <summary>
        /// Save a net purchase
        /// </summary>
        /// <param name="purchaseValue"></param>
        /// <param name="vatRate"></param>
        /// <returns></returns>
        public Purchase SaveNetPurchase(decimal purchaseValue, int vatRate)
        {
            Purchase purchase = new NetPurchase()
            {
                NetAmmount = purchaseValue,
                VatRate = vatRate,
            };

            purchase.CalculateMissingValues();

            this.SavePurchase(purchase);

            return purchase;
        }

        /// <summary>
        /// Save a gross purchase
        /// </summary>
        /// <param name="purchaseValue"></param>
        /// <param name="vatRate"></param>
        /// <returns></returns>
        public Purchase SaveGrossPurchase(decimal purchaseValue, int vatRate)
        {
            Purchase purchase = new GrossPurchase()
            {
                GrossAmmount = purchaseValue,
                VatRate = vatRate,
            };

            purchase.CalculateMissingValues();

            this.SavePurchase(purchase);

            return purchase;
        }

        /// <summary>
        /// Save a Vat Purchase
        /// </summary>
        /// <param name="purchaseValue"></param>
        /// <param name="vatRate"></param>
        /// <returns></returns>
        public Purchase SaveVatPurchase(decimal purchaseValue, int vatRate)
        {
            Purchase purchase = new VatPurchase()
            {
                VatAmmount = purchaseValue,
                VatRate = vatRate,
            };

            purchase.CalculateMissingValues();

            this.SavePurchase(purchase);

            return purchase;
        }

        /// <summary>
        /// Save a purchase
        /// </summary>
        /// <param name="purchase"></param>
        public void SavePurchase(Purchase purchase)
        {
            _unitOfWork.Purchases.Add(purchase);
            _unitOfWork.Complete();
        }
    }
}