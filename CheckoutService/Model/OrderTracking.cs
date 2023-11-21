namespace CheckoutService.Model
{
    public class OrderTracking
    {
        public string Id { get; set; }
        public Orders? orders { get; set; }
        public int ordersId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
