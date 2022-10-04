namespace DemoMVC.Repositories
{
    /// <summary>
    /// Imformation of IBaseRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// CreatedBy: ThiepTT(30/09/2022)
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>List T</returns>
        /// CreatedBy: ThiepTT(30/09/2022)
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        /// CreatedBy: ThiepTT(30/09/2022)
        T GetById(Guid id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Number record create success</returns>
        /// CreatedBy: ThiepTT(30/09/2022)
        bool Create(T t);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Number record delete success</returns>
        /// CreatedBy: ThiepTT(30/09/2022)
        bool Delete(Guid id);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Number record update success</returns>
        /// CreatedBy: ThiepTT(30/09/2022)
        bool Update(Guid id, T t);
    }
}