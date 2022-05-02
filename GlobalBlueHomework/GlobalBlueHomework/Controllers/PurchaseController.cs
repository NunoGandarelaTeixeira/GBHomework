using GlobalBlueHomework.DataStructures;
using GlobalBlueHomework.Models;
using GlobalBlueHomework.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBlueHomework.Controllers
{
    [ApiController]
    [Route("api/purchase")]
    public class PurchaseController : ControllerBase
    {
        /// <summary>
        /// Purchase Service
        /// </summary>
        private readonly IPurchaseService _purchaseService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="globalBlueService"></param>
        public PurchaseController(IPurchaseService globalBlueService)
        {
            this._purchaseService = globalBlueService;
        }

        /// <summary>
        /// Gets all Purchases
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("purchases")]
        public ActionResult<IEnumerable<Purchase>> GetPurchases()
        {
            return Ok(this._purchaseService.GetPurchases());
        }

        /// <summary>
        /// Gets a Purchase by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("purchase/{id}")]
        public ActionResult<Purchase> GetPurchase(long id)
        {
            Purchase purchase = this._purchaseService.GetPurchase(id);
            if (purchase == null)
            {
                return NotFound($"No Purchase with id = {id} was found.");
            }

            return Ok(purchase);
        }

        /// <summary>
        /// Saves a Net Purchase
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NetPurchase")]
        public ActionResult<Purchase> SaveNetPurchase(SavePurchaseInput input)
        {
            Purchase purchase = null;

            try
            {
                this._purchaseService.ValidateSaveInput(input);

                purchase = this._purchaseService.SaveNetPurchase(input.PurchaseValue, input.VatRate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(SaveNetPurchase), purchase);
        }

        /// <summary>
        /// Saves a Gross Purchase
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GrossPurchase")]
        public ActionResult<Purchase> SaveGrossPurchase(SavePurchaseInput input)
        {
            Purchase purchase = null;

            try
            {
                this._purchaseService.ValidateSaveInput(input);

                purchase = this._purchaseService.SaveGrossPurchase(input.PurchaseValue, input.VatRate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(SaveGrossPurchase), purchase);
        }

        /// <summary>
        /// Saves a VAT Purchase
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("VatPurchase")]
        public ActionResult<Purchase> SaveVatPurchase(SavePurchaseInput input)
        {
            Purchase purchase = null;

            try
            {
                this._purchaseService.ValidateSaveInput(input);

                purchase = this._purchaseService.SaveVatPurchase(input.PurchaseValue, input.VatRate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(SaveVatPurchase), purchase);
        }
    }
}