using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Services;

namespace Test.ViewModel
{
    public class AddEventViewModel
    {
        public long Id { get; set; }

        public String Nom { get; set; }

        public DateTime Date { get; set; }

        public String Description { get; set; }

        public AddEventViewModel() { }

        public async void AddEvents()
        {
            await HttpService.GetHttpService().AddEventsAsync(new Events
            {
                Nom = Nom,
                Date = Date,
                Responsable = CurrentUser.currentuser,
                Description = Description
            });
        }

    }
}
