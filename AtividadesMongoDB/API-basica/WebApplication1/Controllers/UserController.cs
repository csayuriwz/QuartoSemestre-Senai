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

    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("Users");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                var users = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(users);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {

            try
            {
                User newUser = new User();
                newUser.Name = user.Name;
                newUser.Email = user.Email;
                newUser.Password = user.Password;
                newUser.AdditionalAttributs = user.AdditionalAttributs;


                _user.InsertOne(newUser);

                return Ok(newUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {

            try
            {
                var user = await _user.Find(x => x.Id == id).FirstOrDefaultAsync();

                //var filter = Builders<User>.Filter.Eq(x.Id, id);

                return user is not null ? Ok(user) : NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(User u)
        {
            try
            {
                //buscar pelo id(filtro)
                var filter = Builders<User>.Filter.Eq(x => x.Id, u.Id);

                if (filter != null)
                {
                    //substitui o obj buscado pelo novo
                    await _user.ReplaceOneAsync(filter, u);

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
                var filter = Builders<User>.Filter.Eq(x => x.Id, id);

                if (filter != null)
                {
                    await _user.DeleteOneAsync(filter);

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
