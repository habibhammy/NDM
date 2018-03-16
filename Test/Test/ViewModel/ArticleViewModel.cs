using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.ViewModel
{
    public class ArticleViewModel
    {
        public long Id { get; set; }

        public String Nom { get; set; }

        public Users Vendeur { get; set; }

        public String NomVendeur { get; set; }

        public String Description { get; set; }

        public String SomeofDescription { get; set; }

        public int Prix { get; set; }

        public String Moreminus { get; set; }

        public ArticleViewModel()
        {
            
        }

        public Article GetArticle()
        {
            return new Article
            {
                Id = Id,
                Nom = Nom,
                Description=Description,
                Vendeur = Vendeur,
                Prix = Prix
            };
        }


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
