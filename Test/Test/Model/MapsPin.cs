﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class MapsPin
    {
        public long Id { get; set; }
        public String Titre { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public String Description { get; set; }

        public MapsPin()
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
                        "\"description\" : " + "\"" + Description + "\"" +
                    "}";
        }
    }
}
