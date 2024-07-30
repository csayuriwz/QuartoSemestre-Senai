using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApplication1.Domains;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("Product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {

            try
            {
                Product newProduct = new Product();
                newProduct.Name = product.Name;
                newProduct.Price = product.Price;
                newProduct.AdditionalAttributs= product.AdditionalAttributs;


                 _product.InsertOne(newProduct);

                return Ok(newProduct);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {

            try
            {
                var product = await _product.Find(x => x.Id == id).FirstOrDefaultAsync();

                //var filter = Builders<Product>.Filter.Eq(x.Id, id);

                return product is not null? Ok(product) : NotFound();
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product p)
        {
            try
            {
                //buscar pelo id(filtro)
                var filter = Builders<Product>.Filter.Eq(x => x.Id, p.Id);

                if (filter != null)
                {
                    //substitui o obj buscado pelo novo
                    await _product.ReplaceOneAsync(filter, p);

                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _product.DeleteOneAsync(filter);

                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
       





    }
}
