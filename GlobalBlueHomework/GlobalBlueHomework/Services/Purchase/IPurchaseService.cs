using GlobalBlueHomework.DataStructures;
using GlobalBlueHomework.Models;

namespace GlobalBlueHomework.Services
{
    public interface IPurchaseService
    {
        /// <summary>
        /// Return all purchases
        /// </summary>
        /// <returns></returns>
        IEnumerable<Purchase> GetPurchases();

        /// <summary>
        /// Return purchase by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Purchase GetPurchase(long id);

        /// <summary>
        /// Validate Save Purchase input values
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
        void ValidateSaveInput(SavePurchaseInput input);

        /// <summary>
        /// Save a net purchase
        /// </summary>
        /// <param name="purchaseValue"></param>
        /// <param name="vatRate"></param>
        /// <returns></returns>
        Purchase SaveNetPurchase(decimal purchaseValue, int vatRate);

        /// <summary>
        /// Save a gross purchase
        /// </summary>
        /// <param name="purchaseValue"></param>
        /// <param name="vatRate"></param>
        /// <returns></returns>
        Purchase SaveGrossPurchase(decimal purchaseValue, int vatRate);

        /// <summary>
        /// Save a Vat Purchase
        /// </summary>
        /// <param name="purchaseValue"></param>
        /// <param name="vatRate"></param>
        /// <returns></returns>
        Purchase SaveVatPurchase(decimal purchaseValue, int vatRate);

        /// <summary>
        /// Save a purchase
        /// </summary>
        /// <param name="purchase"></param>
        void SavePurchase(Purchase purchase);
    }
}