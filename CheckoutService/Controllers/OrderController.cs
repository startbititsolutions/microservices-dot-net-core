using CheckoutService.Model;
using CheckoutService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckoutService.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly IOrderItemService orderItemService;
        private readonly IOrderService orderService;

        public OrderController(ApplicationDbcontext dbcontext, IOrderItemService orderItemService, IOrderService orderService)
        {
            _dbcontext = dbcontext;
            this.orderItemService = orderItemService;
            this.orderService = orderService;

        }

        [HttpGet]
        [Route("Order/AllOrders")]
        public IActionResult Index()
        {
            try
            {

                var orders = _dbcontext.orders.ToList();
                if (orders.Any())
                {

                    return Ok(orders);
                }
                else
                {
                    return BadRequest("NO order Found");
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("OrderItem/All")]
        public IActionResult GetOrdetitem()
        {

            try
            {

                var orders = _dbcontext.orderItems.Include(x=>x.Order).Include(p=>p.products).ToList();
                if (orders.Any())
                {

                    return Ok(orders);
                }
                else
                {
                    return BadRequest("NO order Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("OrderItem/byorderid/{id}")]
        public IActionResult GetOrdetitembuorderid(int id)
        {

            try
            {

                var orders = _dbcontext.orderItems.Include(x => x.Order).Include(p => p.products).Where(x=>x.OrderId==id).ToList();
                if (orders.Any())
                {

                    return Ok(orders);
                }
                else
                {
                    return BadRequest("NO order Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Order/GetOrder/{id}")]
        public IActionResult Details(int id)
        {
            try
            {

               var order= _dbcontext.orders.FirstOrDefault(x => x.Id == id);
                if(order == null)
                {
                    return NotFound();
                }
                else
                {

                return Ok(order);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Order/add")]
        public async Task<IActionResult> Add(Orderviewmodel orders)
        {
            try
            {
                    var order = new Orders()
                    {
                        CreatedOn = DateTime.Now,
                        TransactionId = orders.TransactionId,
                        UserId = orders.UserId
                    };
                var addedorder = await orderService.AddOrdersAsync(order);
                if (addedorder != null)
                {

                foreach(var item in orders.products)
                {
                        var product = GetProduct(item.ProductId);
                        if(product != null)
                        {

                    var orderitem = new OrderItem()
                    {
                        ItemPrice = product.Result.Price * item.Quantity,
                        Quantity = item.Quantity,
                        OrderId = addedorder.Id,
                        ProductId = item.ProductId,

                    };
                  var result=await  orderItemService.AddOrdersAsync(orderitem);
                        }
                }
                    var ordertracker = CreateOrderTracker(addedorder.Id);
                }
                return Ok("Order is saved Succesfully");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Order/Edit/{id}")]
        public IActionResult Edit(Orders orders,int id)
        {
            try
            {
                var order=_dbcontext.orders.FirstOrDefault(orders=>orders.Id == id);
                if( order == null)
                {
                    return NotFound();
                }
                else
                {
                    orders.CreatedOn=orders.CreatedOn;
                    
                    order.UserId=orders.UserId;
                    order.TransactionId=orders.TransactionId;
                  
                    _dbcontext.orders.Update(order);
                    return Ok("Order Updated Successfully");
                }

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Order/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var orders = _dbcontext.orders.FirstOrDefault(o=>o.Id==id);
                _dbcontext.orders.Remove(orders);
                _dbcontext.SaveChanges();
                return Ok("order is delted");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [ApiExplorerSettings(IgnoreApi =true)]
        public async Task<Product> GetProduct(int id)
        {
            string accountServiceUrl = "https://localhost:7157/product/" + id;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(accountServiceUrl);

                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadFromJsonAsync<Product>();
                    return product;
                }
                else
                {
                    // Handle error
                    return null;
                }
            }
        }
        public async Task<OrderTracking> CreateOrderTracker(int orderid)
        {
            try
            {
                string accountServiceUrl = "https://localhost:7157/Track/create/" + orderid;
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(accountServiceUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var product = await response.Content.ReadFromJsonAsync<OrderTracking>();
                        return product;
                    }
                    else
                    {
                        // Handle error
                        return null;
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
       
        }
       
    }
}
