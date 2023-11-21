using CheckoutService.Model;

namespace CheckoutService.Services
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetdataAsync();
        Task<OrderItem> AddOrdersAsync(OrderItem ordersitem);
        Task<OrderItem> UpdateOrdersAsync(OrderItem ordersitem, int id);
        Task<OrderItem> DeleteOrdersAsync(int id);
 /*       Task<bool> AddMultipleItem(IEnumerable<FoodDto> food, int id);*/
    }
}
