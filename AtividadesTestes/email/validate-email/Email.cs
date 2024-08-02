using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validate_email
{
    public class Email
    {
        public bool EmailValidate(string email)
        {
            // Verifica se o endereço de e-mail contém "@" e "."
            return email.Contains("@") && email.Contains(".");
        }
    }
}
