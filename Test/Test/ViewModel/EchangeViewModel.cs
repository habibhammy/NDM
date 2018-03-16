using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.ViewModel
{
    public class EchangeViewModel
    {
        public long Id { get; set; }
        public String Offre { get; set; }

        public Users Posteur { get; set; }

        public String Demande { get; set; }

        public int Statut { get; set; }

        public String Moreminus { get; set; }

        public string NomPosteur { get; internal set; }

        public string NomStatut { get; internal set; }

        public EchangeViewModel() { }

        public Echange GetEchange()
        {
            return new Echange
            {
                Id = Id,
                Offre = Offre,
                Demande = Demande,
                Posteur = Posteur,
                Statut = Statut
            };
        }


        public string GetJson()
        {
            /*
             {
                 "id": 1,
                 "offre": "Développement Android",
                 "posteur": {
                     "password": "Admin",
                     "nom": "Admin",
                     "prenom": "Admin",
                     "email": "Admin@exmple.com",
                     "birthdate": null,
                     "emailuniversitaire": null,
                     "login": "Admin"
                 },
                 "demande": "Bonne note",
                 "staut": 1
             }
              */

            return "{" +
                        "\"offre\" : " + "\"" + Offre + "\" ," +
                        "\"demande\" : " + "\"" + Demande + "\" ," +
                        "\"posteur\" : " + "\"" + Posteur.GetJSON() + "\" ," +
                        "\"staut\" : " + "\"" + Statut + "\" ," +
                    "}";
        }
    }
}
