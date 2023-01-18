using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Data;
using API.Models;

namespace API.Controllers
{
    public class ProductsController : ApiController
    {
        private ApiContext db = new ApiContext();

        // GET /api/v1/products Retorna todos os produtos em lista
        public IQueryable<ProductDTO> GetProducts()
        {
            var products = from p in db.Products
                        select new ProductDTO() {
                            ID = p.ID,
                            Name = p.Name,
                            Price = p.Price,
                            Brand = p.Brand,
                            CreatedAt = p.CreatedAt,
                            UpdatedAt = p.UpdatedAt
                        };

            return products;

        }

        // GET /api/v1/products/:productId Retorna apenas o produto do productId
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = await db.Products.Select(
                p => new ProductDTO()
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Brand = p.Brand,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }
                ).SingleOrDefaultAsync(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST /api/v1/products Salva o produto e retorna ele
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Products.Add(product);
            await db.SaveChangesAsync();

            var dto = new ProductDTO()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Brand = product.Brand,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            return CreatedAtRoute("DefaultApi", new { id = product.ID }, dto);
        }

        // PUT /api/v1/products/:productId Modifica o produto e retorna o novo produto
        [ResponseType(typeof(ProductDTO))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = db.Products.Where(p => p.ID == id).FirstOrDefault<Product>();
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Brand = product.Brand;
                existingProduct.Price = product.Price;
                existingProduct.UpdatedAt = DateTime.Now;

                await db.SaveChangesAsync();
                
            }
            else 
            {
                return NotFound();
            }

            var dto = new ProductDTO()
            {
                ID = existingProduct.ID,
                Name = existingProduct.Name,
                Price = existingProduct.Price,
                Brand = existingProduct.Brand,
                CreatedAt = existingProduct.CreatedAt,
                UpdatedAt = existingProduct.UpdatedAt
            };


            return Ok(dto);
        }


        // DELETE /api/v1/products/:productId
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}