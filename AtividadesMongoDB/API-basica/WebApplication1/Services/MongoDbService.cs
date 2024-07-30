using MongoDB.Driver;

namespace WebApplication1.Services
{
    public class MongoDbService
    {
        // armazenar a configuracao da aplicacao
        private readonly IConfiguration _configuration;

        // armazena uma ref ao mongodb
        private readonly IMongoDatabase _database;


        //contem a config necessaria para o acesso ao mongodb
        public MongoDbService(IConfiguration configuration)
        {
            //atribui a config em _configuration
            _configuration = configuration;

            //obtem a string de conexao
            var connectionString = _configuration.GetConnectionString("DbConnection");

            //var connectionString - "mongodb://localhost:27017/ProductDatabase_Tarde"


            //transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //cria um client
            var mongoClient = new MongoClient(mongoUrl);

            //obtem a ref do mongodb
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        //prop p acessar o bd => retorna os dados em _database
        public IMongoDatabase GetDatabase => _database;

    }
}
