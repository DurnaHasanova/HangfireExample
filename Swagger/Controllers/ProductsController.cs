using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swagger.Models;

namespace Swagger.Controllers
{/// <summary>
 /// Productla ilgili controller
 /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly ProductShopDbContext _context;
        /// <summary>
        /// Productla ilgili controller
        /// </summary>
        public ProductsController(ProductShopDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Bu endpoint tum urunleri geri doner Geriye json donuyor
        /// </summary>
        /// <returns></returns>
        // GET: api/Products
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        /// <summary>
        /// Bu endpoint id ile getproduct eder
        /// </summary>
        /// <param name="id">urunun Id-si</param>
        /// <returns></returns>
        /// <response code="404">verilen id-ye sahib urun bulunamadi</response>
        /// <response code="200">product bulundu</response>
        // GET: api/Products/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Urun ekmelek icin
        /// </summary>
        /// 
        /// <returns></returns>
        /// <remarks>
        /// ornek: 
        /// {
        /// "name":"Apple",
        /// "Price": 13.3,
        /// "Category":1
        ///
        /// }
        /// 
        /// </remarks>
        /// <param name="product">json product</param>
        ///
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
