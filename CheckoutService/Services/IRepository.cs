namespace CheckoutService.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetData();
        Task<T> GetDataById(int id);
        Task<T> EditData(T value);
        Task<T> DeleteData(int id);
        Task<T> AddData(T entity);
        void save();
    }
}
