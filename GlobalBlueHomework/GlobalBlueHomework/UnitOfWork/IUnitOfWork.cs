using GlobalBlueHomework.Repository;

namespace GlobalBlueHomework.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Purchase Repository to Init
        /// </summary>
        IPurchaseRepository Purchases { get; }

        /// <summary>
        /// Complete transaction
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
