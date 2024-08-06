using Moq;
using ProductsApiTest.Domains;
using ProductsApiTest.Interfaces;
using ProductsApiTest.Repositories;


namespace TestProject1
{
    public class UnitTest1
    {
        /// <summary>
        /// teste p ffuncionalidade de listar todos os produtos
        /// </summary>
        [Fact]
        public void Get()
        {
            //Arrange

            //criar uma lista de produtos
            List<Products> productList = new List<Products>
            {
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 1", Price = 78},
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 2", Price = 780},
                new Products { IdProduct = Guid.NewGuid(), Name = "Produto 3", Price = 708},
            };


            //cria um objeto de simulacao do tipo ProductRepository
            var mockRepository = new Mock<IProductsRepository>();


            //configura o metodo "GetProducts" p quando for acionado retorne a lista mocada
            mockRepository.Setup(x => x.Get()).Returns(productList);


            //Act

            var result = mockRepository.Object.Get();

            //Assert

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Post()
        {
            Products product = new Products { IdProduct = Guid.NewGuid(), Name = "chocochilli", Price = 42 };

            List<Products> productList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Post(product)).Callback<Products>(x =>
            {
                productList.Add(product);
            });

            mockRepository.Object.Post(product);

            Assert.Contains(product, productList);

        }
        [Fact]

        public void GetById()
        {
            //Arrange

            //criar uma lista de produtos

            var productId = Guid.NewGuid();

            List<Products> productList = new List<Products>
            {
              new Products { IdProduct = productId, Name = "Produto 1", Price = 78}
            };


            //cria um objeto de simulacao do tipo ProductRepository
            var mockRepository = new Mock<IProductsRepository>();


            //configura o metodo "GetProducts" p quando for acionado retorne a lista mocada
            mockRepository.Setup(x => x.GetById(productId)).Returns(productList.FirstOrDefault(x => x.IdProduct == productId));


            //Act

            var result = mockRepository.Object.GetById(productId);

            //Assert

            Assert.Equal(productId, result.IdProduct);
        }

        [Fact]
        public void Delete()
        {
            //Arrange

            //criar uma lista de produtos

            var productId = Guid.NewGuid();

            List<Products> productList = new List<Products>();

            Products product = new Products { IdProduct = productId, Name = "Produto 1", Price = 78 };
            

           

            //cria um objeto de simulacao do tipo ProductRepository
            var mockRepository = new Mock<IProductsRepository>();


            //configura o metodo "GetProducts" p quando for acionado retorne a lista mocada
            mockRepository.Setup(x => x.Delete(productId)).Callback<Guid>(
                x =>
                {
                    var item = productList.FirstOrDefault(x => x.IdProduct == productId);

                    if (item != null)
                    {
                        productList.Remove(item);
                    }
                }
                );


            //Act

            mockRepository.Object.Delete(productId);

            //Assert

            Assert.DoesNotContain(product, productList);
        }

        [Fact]
        public void Put()
        {

            var productId = Guid.NewGuid();

            Products product = new Products { IdProduct = productId, Name = "chocochilli", Price = 42 };

            List<Products> productList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Put(productId, product)).Callback<Guid, Products>((id, p)
               =>
               {
                   var item = productList.FirstOrDefault(x => x.IdProduct == id);

                   if (item != null)
                   {
                       p.Name = "chocochilli";
                       p.Price = 42;
                       productList.Add(product);
                   }
               }
               );
               


            mockRepository.Object.Put(productId,product);

            Assert.Equal(product.Name, "chocochilli");

        }

    }
}