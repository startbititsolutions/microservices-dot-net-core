using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TrackingService.Model;

namespace TrackingService.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TrackController(ApplicationDbContext application)
        {
            _context = application;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {

            var Orders = await _context.orderTrackings.ToListAsync();
            return Ok(Orders);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Getbyid(string id)
        {
            try
            {

            var order = await _context.orderTrackings.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(order);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Edit/{id}/{status}")]
        public async Task<IActionResult> Edit(string id, OrderStatus status)
        {
            try
            {

            var order = await _context.orderTrackings.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound ();
            }
            else
            {
                order.OrderStatus = status;
                _context.orderTrackings.Update(order);
                _context.SaveChanges();
                return Ok(order);
            }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create/{orderid}")]
        public  IActionResult Create(int orderid)
        {
            try
            {

                Guid uniqueId = Guid.NewGuid();
                string orderTrackingId = $"{orderid}_{uniqueId}";
                OrderTracking orderTracking = new OrderTracking() { Id = orderTrackingId, ordersId = orderid, OrderStatus = OrderStatus.Pending };


                _context.orderTrackings.Add(orderTracking);
                _context.SaveChanges();
                return Ok(orderTracking);
               
            }catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {

           var orderTrack= await _context.orderTrackings.FirstOrDefaultAsync(x => x.Id == id);
            if(orderTrack == null)
            {
                return NotFound();
            }
            else
            {
            _context.orderTrackings.Remove(orderTrack);
                return Ok(orderTrack+ "deleted successfully");
            }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }


        }
     
    }
}
