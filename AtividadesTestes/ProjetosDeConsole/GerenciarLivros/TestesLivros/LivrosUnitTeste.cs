using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livros.Teste
{
    public class LivrosUnitTeste
    {
        [Fact]
        public void AdicionarLivro()
        {
            List<Livro> biblioteca = new List<Livro>();
            var livro = new Livro("livro teste", "autor teste");

            biblioteca.Add(livro);

            Assert.Contains(livro, biblioteca);
        }
    }
}
