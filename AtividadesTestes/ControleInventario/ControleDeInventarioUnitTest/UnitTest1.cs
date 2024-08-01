using ControleDeInventario;

namespace ControleDeInventarioUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Produto produto = new Produto();
            produto.Nome = "Chocochilli";
            produto.Quantidade = 1;

            var listaProdutos = new List<Produto>();
            var res = Produto.AdicionarProduto(produto, listaProdutos);
            var verificacao1 = listaProdutos.FirstOrDefault(x => x.Nome == "Chocochilli");

            Assert.NotNull(verificacao1);

            Produto prod1 = new Produto();
            prod1.Nome = "Chocochilli";

            res = Produto.AdicionarProduto(prod1, listaProdutos);
            var verificacao2 = listaProdutos.FirstOrDefault(x => x.Nome == "Chocochilli");

            Assert.Equal(2, verificacao2.Quantidade);

            var ver3 = listaProdutos.FirstOrDefault(x => x.Nome == "Chocochilli");

            Assert.NotNull(ver3);
        }
    }
}