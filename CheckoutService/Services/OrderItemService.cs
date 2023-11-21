using CheckoutService.Model;

namespace CheckoutService.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOFWork unitOFWork;
        public OrderItemService(IUnitOFWork unitOFWork)
        {
            this.unitOFWork = unitOFWork;

        }
        public async Task<OrderItem> AddOrdersAsync(OrderItem ordersitem)
        {
            try
            {

                var result = await unitOFWork.orderitem.AddData(ordersitem);
                unitOFWork.commit();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        /*public async Task<bool> AddMultipleItem(IEnumerable<FoodDto> foods, int id)
        {
            try
            {
                foreach (var item in foods)
                {
                    var orderitemresult = await unitOFWork.orderitem.AddData(
                     new OrderItem()
                     { FoodId = item.Id, Price = item.Price, OrdersId = id, Quantity = item.Quantity });
                    await unitOFWork.commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }*/

        public Task<OrderItem> DeleteOrdersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItem>> GetdataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> UpdateOrdersAsync(OrderItem ordersitem, int id)
        {
            throw new NotImplementedException();
        }
    }
}
