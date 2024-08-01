using ConversaoDeTemperatura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversoes.Test
{
    public class ConversaoUnitTest
    {
        [Fact]
        public void ConverterTemperatura()
        {
            var t1 = 30;
            var tempEsperada = 86;

            var temperatura = Conversao.ConverterCelsiusParaFahrenheit(t1);

            Assert.Equal(tempEsperada, temperatura);
        }
    }
}
