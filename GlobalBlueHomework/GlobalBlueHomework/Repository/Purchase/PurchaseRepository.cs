using GlobalBlueHomework.AppContext;
using GlobalBlueHomework.Models;

namespace GlobalBlueHomework.Repository
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(GlobalBlueContext context) : base(context)
        {
        }
    }
}
