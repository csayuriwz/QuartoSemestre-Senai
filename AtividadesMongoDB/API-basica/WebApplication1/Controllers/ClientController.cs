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

    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;

        public  ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("Client");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            try
            {
                var clients = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(clients);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {

            try
            {
                Client newClient = new Client();
                newClient.UserId = client.UserId;
                newClient.Cpf = client.Cpf;
                newClient.Phone = client.Phone;
                newClient.Address = client.Address;

                newClient.AdditionalAttributs = client.AdditionalAttributs;


                _client.InsertOne(newClient);

                return Ok(newClient);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(string id)
        {

            try
            {
                var client = await _client.Find(x => x.Id == id).FirstOrDefaultAsync();

                //var filter = Builders<Client>.Filter.Eq(x.Id, id);

                return client is not null ? Ok(client) : NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Client c)
        {
            try
            {
                //buscar pelo id(filtro)
                var filter = Builders<Client>.Filter.Eq(x => x.Id, c.Id);

                if (filter != null)
                {
                    //substitui o obj buscado pelo novo
                    await _client.ReplaceOneAsync(filter, c);

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
                var filter = Builders<Client>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _client.DeleteOneAsync(filter);

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
