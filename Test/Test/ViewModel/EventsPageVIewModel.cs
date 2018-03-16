using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Services;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class EventsPageVIewModel
    {
        private List<EventsViewModel> events;
        public List<EventsViewModel> Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyCHanged();
            }
        }

        private EventsPageVIewModel()
        {
        }

        public static async Task<EventsPageVIewModel> GetInstanceAsync()
        {
            EventsPageVIewModel gcvm = new EventsPageVIewModel();
            await gcvm.GetEventsAsync();
            return gcvm;
        }

        private async Task GetEventsAsync()
        {
            List<Events> ps = await HttpService.GetHttpService().GetAllEventsAsync();
            events = new List<EventsViewModel>();
            foreach (Events p in ps)
            {
                EventsViewModel pi = new EventsViewModel
                {
                    Image = p.Nom + ".png",
                    SomeofDescription = p.Description.Substring(0, 5) + "...",
                    Moreminus = "more.png",
                    Id = p.Id,
                    Nom = p.Nom,
                    Responsable = p.Responsable,
                    Date = p.Date,
                    Description = p.Description,
                    NomResponsable = p.Responsable.Nom + " " + p.Responsable.Prenom + " (#" + p.Responsable.Login + ")"
                };
                events.Add(pi);
            }
        }

        public async Task AddEvents()
        {
            EventsViewModel p = new EventsViewModel
            {
                //Titre = Pintitre,
                //Latitude = Latitude,
                //Longitude = Longitude,
                //Description = Description
            };
            Events.Add(p);
            await HttpService.GetHttpService().AddEventsAsync(p.GetEvents());
            RaisePropertyCHanged();
        }

        public async Task<bool> DeleteEventsAsync(EventsViewModel p)
        {
            events.Remove(p);
            try
            {
                await HttpService.GetHttpService().DeleteEventsAsync(p.GetEvents());
                RaisePropertyCHanged();
                return true;
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<EventsPageVIewModel, string>(this, "Error 500", "Cet item a déjà était supprimé");
                RaisePropertyCHanged();
                return false;
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCHanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        private void DeleteMapsPin(object s)
        {
            System.Diagnostics.Debug.WriteLine("parameter: " + s);
        }

        internal async Task RefreshlistAsync()
        {
            await GetEventsAsync();
        }
    }
}
