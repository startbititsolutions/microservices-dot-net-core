using CheckoutService.Model;
using Microsoft.EntityFrameworkCore;

namespace CheckoutService.Services
{
    public class OrdersService : IOrderService
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly IUnitOFWork _unitOFWork;
        public OrdersService(ApplicationDbcontext dbcontext, IUnitOFWork unitOFWork)
        {
            _dbcontext = dbcontext;
            _unitOFWork = unitOFWork;
        }
        public async Task<Orders> AddOrdersAsync(Orders orders)
        {
            var result = await _unitOFWork.Orders.AddData(orders);
            _unitOFWork.Orders.save();
            return result;
        }

        public Task<Orders> DeleteOrdersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Orders>> GetdataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Orders> UpdateOrdersAsync(Orders orders, int id)
        {
            throw new NotImplementedException();
        }
    }
}
