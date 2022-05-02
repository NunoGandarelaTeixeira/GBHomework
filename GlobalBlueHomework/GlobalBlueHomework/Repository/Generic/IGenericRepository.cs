namespace GlobalBlueHomework.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get all entities of a type
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(long id);

        /// <summary>
        /// Create Entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
    }
}