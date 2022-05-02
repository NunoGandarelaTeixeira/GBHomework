using GlobalBlueHomework.AppContext;

namespace GlobalBlueHomework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GlobalBlueContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(GlobalBlueContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Generic Create Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}
