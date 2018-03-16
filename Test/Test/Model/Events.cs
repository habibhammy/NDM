using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Events
    {
        public long Id { get; set; }
        public String Nom { get; set; }

        public DateTime Date { get; set; }

        public Users Responsable { get; set; }

        public String Description { get; set; }

        public Events()
        {

        }

        public string GetJson()
        {
            /*
            {
        "id": 1,
        "nom": "ECOMAINS",
        "date": 1527890400000,
        "responsable": {
            "password": "Admin",
            "nom": "Admin",
            "prenom": "Admin",
            "email": "Admin@exmple.com",
            "birthdate": null,
            "emailuniversitaire": null,
            "login": "Admin"
        },
        "description": "Imaginé par des étudiants messins, ce projet vise à réunir des acteurs de la transition écologique en Lorraine autour d’un événement festif propice à la rencontre avec les citoyens.\n    Il aura la forme d’un « village » et comprendra :\no\tDes stands d’exposition animés par les différents acteurs afin d’informer et d’échanger sur leurs actions et les thématiques abordées par le festival :\n-\tEcogestes et écocitoyenneté\n-\tGestion et réduction des déchets\n-\tBiodiversité et environnement\n-\tEquitable et éthique\n-\tSanté et alimentation\no\tDes ateliers permettant d’apprendre des techniques pour réduire ses déchets, ou leur donner une seconde vie grâce au recyclage,\no\tUn« marché » regroupant des artisans et restaurateurs,\no\tUne « place publique » accueillant conférences et débats,\no\tUn point collecte de déchets électroniques,\no\tDes zones de gratuité pour échanger des objets, plantes, graines…\no\tDes espaces d’expression artistique (tissage sur barrières etc.) et d’animations ludiques (spectacles, artistes de rue, musiciens…)"
    }
             */

            return "{" +
                        "\"nom\" : " + "\"" + Nom + "\" ," +
                        "\"date\" : " + "\"" + Date + "\" ," +
                        "\"responsable\" : " + "\"" + Responsable.GetJSON() + "\" ," +
                        "\"description\" : " + "\"" + Description + "\" ," +
                    "}";
        }
    }
}
