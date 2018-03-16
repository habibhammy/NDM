using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;

namespace Test.ViewModel
{
    public class MapsPinViewModel
    {
        public long Id
        {
            get;
            set;
        }
        public String Titre { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public String Description { get; set; }

        public String SomeofDescription { get; set; }

        public String Image { get; set; }

        public String moreminus { get; set; }

        public MapsPinViewModel()
        {
            
        }

        public string GetJson()
        {
            /*
             {
                "id": 1,
                "titre": "Centre Pompidou",
                "longitude": 6.176792,
                "latitude": 49.11031,
                "description": "Le plus grand centre commercial au centre ville de Metz !!"
              }
             */

            return "{" +
                        "\"titre\" : " + "\"" + Titre + "\" ," +
                        "\"longitude\" : " + "\"" + Longitude + "\" ," +
                        "\"latitude\" : " + "\"" + Latitude + "\" ," +
                        "\"description\" : " + "\"" + Description + "\" ," +
                    "}";
        }

        internal MapsPin GetMapPin()
        {
            return new MapsPin
            {
                Titre = Titre,
                Id = Id,
                Description = Description,
                Latitude = Latitude,
                Longitude = Longitude
            };
        }
    }
}
