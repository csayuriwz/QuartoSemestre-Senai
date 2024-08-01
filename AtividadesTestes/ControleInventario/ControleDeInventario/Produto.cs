using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ControleDeInventario
{
    public class Produto
    {
        public string? Nome { get; set; }
        public int? Quantidade { get; set; }

        public static List<Produto> AdicionarProduto(Produto produto, List<Produto> produtos)
        {
            var busca = produtos.FirstOrDefault(x => x.Nome == produto.Nome);

            if (busca == null)
            {
                produtos.Add(produto);
            }
            else
            {
                busca.Quantidade += 1;
            }

            return produtos;
        }

    }
}
