using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesCalculos;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        //Notation q especifica o metodo como metodo de teste
        [Fact]
        public void SomarDoisNumeros()
        {
            var n1 = 3.3;
            var n2 = 2.2;
            var valorEsperado = 5.5;

            var soma = Calculo.Somar(n1, n2);

            //assert eh um conjunto de metodos usados para comparacoes
            Assert.Equal(valorEsperado, soma);

        }

        [Fact]
        public void SubtrairDoisNumeros()
        {
            var n1 = 3;
            var n2 = 2;
            var valorEsperado = 1;

            var subtracao = Calculo.Subtrair(n1, n2);

            //assert eh um conjunto de metodos usados para comparacoes
            Assert.Equal(valorEsperado, subtracao);

        }

        [Fact]
        public void MultiplicarDoisNumeros()
        {
            var n1 = 3;
            var n2 = 2;
            var valorEsperado = 6;

            var multiplicacao = Calculo.Multiplicar(n1, n2);

            //assert eh um conjunto de metodos usados para comparacoes
            Assert.Equal(valorEsperado, multiplicacao);

        }

        [Fact]
        public void DividirDoisNumeros()
        {
            var n1 = 10;
            var n2 = 2;
            var valorEsperado = 5;

            var divisao = Calculo.Dividir(n1, n2);

            //assert eh um conjunto de metodos usados para comparacoes
            Assert.Equal(valorEsperado, divisao);

        }

        [Fact]
        public void Modulo()
        {
            var n1 = -12;
            
            var valorEsperado = 12;

            var modular = Calculo.Modulo(n1);

            //assert eh um conjunto de metodos usados para comparacoes
            Assert.Equal(valorEsperado, modular);

        }

    }
}
