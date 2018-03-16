using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Article
    {
        public long Id { get; set; }
        public String Nom { get; set; }

        public Users Vendeur { get; set; }

        public String Description { get; set; }

        public int Prix { get; set; }

        public Article() { }

        public string GetJson()
        {
            /*
            {
                "id": 1,
                "nom": "Application Mobile",
                "vendeur": {
                    "password": "Admin",
                    "nom": "Admin",
                    "prenom": "Admin",
                    "email": "Admin@exmple.com",
                    "birthdate": null,
                    "emailuniversitaire": null,
                    "login": "Admin"
                },
                "description": "Une application mobile chouwétte et sympa :p",
                "prix": 1000
            }
             */

            return "{" +
                        "\"nom\" : " + "\"" + Nom + "\" ," +
                        "\"vendeur\" : " + "\"" + Vendeur.GetJSON() + "\" ," +
                        "\"prix\" : " + "\"" + Prix + "\" ," +
                        "\"description\" : " + "\"" + Description + "\" ," +
                    "}";
        }
    }
}
