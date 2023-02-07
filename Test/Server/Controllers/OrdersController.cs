using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Server.Data;
using Test.Server.IRepository;
using Test.Shared.Domain;

namespace Test.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public OrdersController(ApplicationDbContext context)
        public OrdersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Orders
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        public async Task<IActionResult> GetOrders()
        {
            //return await _context.Order.ToListAsync();
            var orders = await _unitOfWork.Orders.GetAll(includes: q => q.Include(x => x.Customer).Include(x => x.Restaurant));
            
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Order>> GetOrder(int id)
        public async Task<IActionResult> GetOrders(int id)
        {
            //var order = await _context.Order.FindAsync(id);
            var order = await _unitOfWork.Orders.Get(q => q.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            //return order;
            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            //_context.Entry(order).State = EntityState.Modified;
            _unitOfWork.Orders.Update(order);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderExists(id))
                if (!await OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            //_context.Order.Add(order);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Orders.Insert(order);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            //var order = await _context.Order.FindAsync(id);
            var order = await _unitOfWork.Orders.Get(q => q.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            //_context.Order.Remove(order);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Orders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> OrderExists(int id)
        {
            //return _context.Order.Any(e => e.Id == id);
            var order = await _unitOfWork.Orders.Get(q => q.Id == id);
            return order != null;
        }
    }
}
