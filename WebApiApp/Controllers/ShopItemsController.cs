using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp.Data;
using WebApiApp.Entities;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public ShopItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopItem>>> GetShopItems()
        {
            return await _context.ShopItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItem>> GetShopItem(int id)
        {
            var shopItem = await _context.ShopItems.FindAsync(id);

            if (shopItem == null)
            {
                return NotFound();
            }

            return shopItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopItem(int id, ShopItem shopItem)
        {
            if (id != shopItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(shopItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopItemExists(id))
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

        [HttpPost]
        public async Task<ActionResult<ShopItem>> PostShopItem(ShopItem shopItem)
        {
            var shop = _context.Shops.FirstOrDefault(i => i.Id == shopItem.Id);

            if(shop == null)
            {
                return NotFound(shopItem.ShopId);
            }

            _context.ShopItems.Add(shopItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopItem", new { id = shopItem.Id }, shopItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopItem(int id)
        {
            var shopItem = await _context.ShopItems.FindAsync(id);
            if (shopItem == null)
            {
                return NotFound();
            }

            _context.ShopItems.Remove(shopItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopItemExists(int id)
        {
            return _context.ShopItems.Any(e => e.Id == id);
        }
    }
}
