using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using validate_email;

namespace Emails.Test
{
    public class ValidateEmail
    {
        [Theory]
        [InlineData("exemplo@dominio.com", true)]
        [InlineData("exemplo.dominio.com", false)] // Não contém "@"
        [InlineData("@dominio.com", false)] // Não contém "."
        [InlineData("exemplo@", false)] // Não contém "."
        [InlineData("", false)] // String vazia
        public void ValidateEmailTest(string email, bool expected)
        {
            var validator = new Email();
  
            bool result = validator.EmailValidate(email);

            Assert.Equal(expected, result);
        }
    }
}
