using GlobalBlueHomework.AppContext;
using GlobalBlueHomework.Repository;

namespace GlobalBlueHomework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Injeted App Context
        /// </summary>
        private readonly GlobalBlueContext _context;

        /// <summary>
        /// Purchase Repository to Init
        /// </summary>
        public IPurchaseRepository Purchases { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(GlobalBlueContext context)
        {
            _context = context;

            Purchases = new PurchaseRepository(_context);
        }

        /// <summary>
        /// Complete transaction
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
