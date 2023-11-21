using CheckoutService.Model;
using Microsoft.EntityFrameworkCore;

namespace CheckoutService.Services
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly ApplicationDbcontext _dbcontext;
        private Repository<Orders> _orders;
        private Repository<OrderItem> _orderitem;
    
        public UnitOfWork(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IRepository<Orders> Orders
        {
            get
            {
                return _orders ??
                    (_orders = new Repository<Orders>(_dbcontext));
            }
        }
        public IRepository<OrderItem> orderitem
        {
            get
            {
                return _orderitem ??
                    (_orderitem = new Repository<OrderItem>(_dbcontext));
            }
        }
        

        public async Task commit()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
