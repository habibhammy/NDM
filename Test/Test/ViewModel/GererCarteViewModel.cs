using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test.Model;
using Test.Services;
using Test.View;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class GererCarteViewModel : INotifyPropertyChanged
    {
        private bool firstappear;
        /*
        private ICommand tapCommand;
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        */
        private List<MapsPinViewModel> pins ;
        public List<MapsPinViewModel> Pins
        {
            get { return pins; }
            set
            {
                pins = value;
                RaisePropertyCHanged();
            }
        }

        private GererCarteViewModel()
        {
            //tapCommand = new Command<MapsPinViewModel>(async (MapsPinViewModel pin) => await DeletePinAsync(pin));
            
        }

        public static async Task<GererCarteViewModel> GetInstanceAsync()
        {
            GererCarteViewModel gcvm = new GererCarteViewModel();
            await gcvm.RefreshlistAsync();
            gcvm.firstappear = true;
            return gcvm;
        }

        private async Task GetPinsAsync()
        {
            List<MapsPin>ps = await HttpService.GetHttpService().GetAllMapsPinsAsync();
            pins = new List<MapsPinViewModel>();
            foreach (MapsPin p in ps)
            {
                MapsPinViewModel pi = new MapsPinViewModel
                {
                    Image = "pin" + ((p.Id % 5) + 1) + ".png",
                    SomeofDescription = p.Description.Substring(0, 5) + "...",
                    moreminus = "more.png",
                    Id = p.Id,
                    Titre = p.Titre,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Description = p.Description
                };
                pins.Add(pi);
            }
               

        }

        public async Task AddPin()
        {
            MapsPinViewModel p = new MapsPinViewModel
            {
                //Titre = Pintitre,
                //Latitude = Latitude,
                //Longitude = Longitude,
                //Description = Description
            };
            Pins.Add(p);
            await HttpService.GetHttpService().AddMapsPinAsync(p.GetMapPin());
            RaisePropertyCHanged();
        }

        public async Task<bool> DeletePinAsync(MapsPinViewModel p)
        {
            pins.Remove(p);
            try
            {
                await HttpService.GetHttpService().DeleteMapsPinAsync(p.GetMapPin());
                RaisePropertyCHanged();
                return true;
            }catch(Exception ex)
            {
                MessagingCenter.Send<GererCarteViewModel, string>(this, "Error 500", "Cet item a déjà était supprimé");
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
            if (firstappear)
            {
                firstappear = false;
            }
            else
            {
                await GetPinsAsync();
            }
        }
    }
}
