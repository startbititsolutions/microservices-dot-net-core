using CheckoutService.Model;
using Microsoft.EntityFrameworkCore;

namespace CheckoutService.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly DbSet<T> dbset;
        public Repository(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            this.dbset = _dbcontext.Set<T>();
        }
        public async Task<T> AddData(T entity)
        {
            try
            {
                var result = await dbset.AddAsync(entity);
                return result.Entity;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<T> DeleteData(int id)
        {
            try
            {

                var exist = await dbset.FindAsync(id);
                if (exist != null)
                {
                    dbset.Remove(exist);
                    return exist;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<T> EditData(T value)
        {
            try
            {
                if (value != null)
                {
                    await Task.Yield();
                    var pp = value;
                    dbset.Update(pp);
                    return value;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<IEnumerable<T>> GetData()
        {

            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<T> GetDataById(int id)
        {
            try
            {
                return await dbset.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
