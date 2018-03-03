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
    class GererCarteViewModel : INotifyPropertyChanged
    {
        private ICommand tapCommand;
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }

        private List<MapsPin> pins ;
        public List<MapsPin> Pins
        {
            get { return pins; }
            set
            {
                pins = value;
                RaisePropertyCHanged();
            }
        }

        private long id;
        public long Id
        {
            get { return id; }
        }

        private string pintitre;
        public string Pintitre
        {
            get { return pintitre; }
            set
            {
                pintitre = value;
                RaisePropertyCHanged();
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                RaisePropertyCHanged();
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                RaisePropertyCHanged();
            }
        }


        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyCHanged();
            }
        }
        private GererCarteViewModel()
        {
            tapCommand = new Command<MapsPin>(async (MapsPin pin) => await DeletePinAsync(pin));
            
        }

        public static async Task<GererCarteViewModel> GetInstanceAsync()
        {
            GererCarteViewModel gcvm = new GererCarteViewModel();
            await gcvm.GetPinsAsync();
            return gcvm;
        }

        private async Task GetPinsAsync()
        {
            pins = await HttpService.GetHttpService().GetAllMapsPinsAsync();
        }

        public async Task AddPin()
        {
            MapsPin p = new MapsPin
            {
                Titre = Pintitre,
                Latitude = Latitude,
                Longitude = Longitude,
                Description = Description
            };
            Pins.Add(p);
            await HttpService.GetHttpService().AddMapsPinAsync(p);
            RaisePropertyCHanged();
        }

        public async Task DeletePinAsync(MapsPin p)
        {
            pins.Remove(p);
            try
            {
                await HttpService.GetHttpService().DeleteMapsPinAsync(p);
            }catch(Exception ex)
            {
                MessagingCenter.Send<GererCarteViewModel, string>(this, "Error 500", "Cet item a déjà était supprimé");
            }
           
            RaisePropertyCHanged();
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
    }
}
