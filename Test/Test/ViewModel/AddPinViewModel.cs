using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Services;

namespace Test.ViewModel
{
    public class AddPinViewModel
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

        public AddPinViewModel() { }

        public async void AddPin()
        {
            await HttpService.GetHttpService().AddMapsPinAsync(new MapsPin
            {
                Titre = Titre,
                Latitude = Latitude,
                Longitude = Longitude,
                Description = Description
            });
        }
    }
}
