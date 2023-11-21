using CheckoutService.Model;

namespace CheckoutService.Services
{
    public interface IUnitOFWork
    {
        public IRepository<Orders> Orders { get; }
        public IRepository<OrderItem> orderitem { get; }
        Task commit();
    }
}
