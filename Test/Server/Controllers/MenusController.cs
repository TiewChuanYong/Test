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
    public class MenusController : ControllerBase
    {

        //private readonly applicationdbcontext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MenusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<IActionResult> GetMenus()
        {
            var menus = await _unitOfWork.Menus.GetAll(includes: q => q.Include(x => x.Restaurant));
            return Ok(menus);

        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _unitOfWork.Menus.Get(q => q.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Menus.Update(menu);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await MenuExists(id))
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

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            await _unitOfWork.Menus.Insert(menu);
            await _unitOfWork.Save(HttpContext);


            return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _unitOfWork.Menus.Get(q => q.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            await _unitOfWork.Menus.Delete(id);
            await _unitOfWork.Save(HttpContext);


            return NoContent();
        }

        private async Task<bool> MenuExists(int id)
        {
            var menu = await _unitOfWork.Menus.Get(q => q.Id == id);
            return menu != null;
        }
    }
}

