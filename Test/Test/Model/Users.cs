using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Users
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Emailuniversitaire { get; set; }

        public Users()
        {
        }

        public String GetJSON()
        {
            /* format
              {
                    "login": "h@bib",
                    "password": "azerty123@",
                    "nom": null,
                    "prenom": null,
                    "email": "email@exemple.com",
                    "birthdate": null,
                    "emailuniversitaire": null
               }
             */
            return
                "{" +
                   "\"login\" : \""+this.Login+"\","+
                   " \"password\" : \"" + this.Password + "\"," +
                   " \"nom\" : \"" + this.Nom + "\"," +
                   " \"prenom\" : \"" + this.Prenom + "\" ," +
                   " \"email\" : \"" + this.Email + "\"," +
                   " \"birthdate\" : \"" + this.Birthdate.Year+"-"+this.Birthdate.Month+"-"+this.Birthdate.Day+ "\"," +// yyyy - MM - dd
                   " \"emailuniversitaire\" : \"" + this.Emailuniversitaire + "\" " +
                "}";
        }

    }
}
