using CheckoutService.Model;

namespace CheckoutService.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetdataAsync();
        Task<Orders> AddOrdersAsync(Orders orders);
        Task<Orders> UpdateOrdersAsync(Orders orders, int id);
        Task<Orders> DeleteOrdersAsync(int id);
    }
}
