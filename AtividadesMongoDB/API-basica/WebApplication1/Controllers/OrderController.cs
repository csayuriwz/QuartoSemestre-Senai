using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApplication1.Domains;
using WebApplication1.Services;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;


        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("Order");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("Client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("Product");
        }


        [HttpPost]
        public async Task<ActionResult<Order>> Post(OrderViewModel orderViewModel)
        {

            try
            {
                Order newOrder = new Order();

                newOrder.Id = orderViewModel.Id;
                newOrder.Date = orderViewModel.Date;
                newOrder.Status = orderViewModel.Status;

                newOrder.ProductId = orderViewModel.ProductId;
                newOrder.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == newOrder.ClientId).FirstOrDefaultAsync();

                if (client != null)
                {
                    return NotFound("O cliente nao existe!");
                }

                newOrder.Client = client;

                await _order!.InsertOneAsync(newOrder);

                return StatusCode(201, newOrder);

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        public async Task<ActionResult> Update(Order o)
        {
            try
            {
                //buscar pelo id(filtro)
                var filter = Builders<Order>.Filter.Eq(x => x.Id, o.Id);

                if (filter != null)
                {
                    //substitui o obj buscado pelo novo
                    await _order.ReplaceOneAsync(filter, o);

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
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _order.DeleteOneAsync(filter);

                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("id")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
