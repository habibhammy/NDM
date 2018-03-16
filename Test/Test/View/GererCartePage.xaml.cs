using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GererCartePage : ContentPage
    {
        public ListView ListPins;

        public GererCarteViewModel gcvm;
        private  GererCartePage()
        {
            InitializeComponent();
            ListPins = listPins;
            ListPins.ItemTapped += (object sender, ItemTappedEventArgs e) =>
{
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
            MessagingCenter.Subscribe<GererCarteViewModel, string>(this, "Error 500", (sender, arg) => {
                this.DisplayAlert("Error", arg, "OK");
            });
        }

        public static async Task<GererCartePage> GetInstance()
        {
            GererCartePage gcp = new GererCartePage();
            GererCarteViewModel gcvm = await GererCarteViewModel.GetInstanceAsync();
            gcp.BindingContext = gcvm;
            gcp.listPins.BindingContext = gcvm;
            gcp.gcvm = gcvm;
            
            return gcp;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool success = false ;
            var answer = await DisplayAlert("Question?", "Êtes vous sur de vouloir supprimer ce Pin ? ", "Oui", "Non");
            System.Diagnostics.Debug.WriteLine("answer = " + answer);
            if (answer)
            {
                this.listPins.BeginRefresh();
                this.listPins.ItemsSource = null;
                var pin = ((TappedEventArgs)e).Parameter;
                success = await this.gcvm.DeletePinAsync((MapsPinViewModel)pin);
                //this.ListPins.BeginRefresh();
                this.listPins.ItemsSource = gcvm.Pins;

                this.listPins.EndRefresh();
                //this.ListPins.RefreshCommand = new Command<MapsPin>( () => )
            }
            if (success)
            {
                await this.DisplayAlert("Success", "Item bien supprimer", "OK");
            }
            else
            {
                await this.DisplayAlert("ERROR", "Item non supprimer", "OK");
            }
            System.Diagnostics.Debug.WriteLine("finished and should be updated !! ");
        }

        private void More_Clicked(object sender, EventArgs e)
        {
          
            MapsPinViewModel pin = (MapsPinViewModel)((TappedEventArgs)e).Parameter;
            if (pin.moreminus.Equals("minus.png"))
            {
                pin.SomeofDescription = pin.Description.Substring(0,5)+"...";
                pin.moreminus = "more.png";
            }
            else
            {
                pin.SomeofDescription = pin.Description;
                pin.moreminus = "minus.png";
            }

            
            this.listPins.BeginRefresh();
            this.listPins.ItemsSource = null;
            this.listPins.ItemsSource = gcvm.Pins;
            this.listPins.EndRefresh();
        }

        private void Button_Ajouter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPinPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await gcvm.RefreshlistAsync();
            this.listPins.BeginRefresh();
            this.listPins.ItemsSource = null;
            this.listPins.ItemsSource = gcvm.Pins;
            this.listPins.EndRefresh();
           
           
        }
    }
}