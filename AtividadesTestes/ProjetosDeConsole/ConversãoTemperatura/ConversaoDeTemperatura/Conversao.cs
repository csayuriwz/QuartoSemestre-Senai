using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoDeTemperatura
{
    public static class Conversao
    {
        public static double ConverterCelsiusParaFahrenheit(double X)
        {
            return ((X * 1.8) + 32);
        }
    }
}
