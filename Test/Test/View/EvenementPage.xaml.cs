using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvenementPage : ContentPage
    {
        public ListView ListEvents;

        public EventsPageVIewModel epvm;

        private EvenementPage()
        {
            InitializeComponent();
            ListEvents = listEvents;
            ListEvents.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
            MessagingCenter.Subscribe<EventsPageVIewModel, string>(this, "Error 500", (sender, arg) => {
                this.DisplayAlert("Error", arg, "OK");
            });
        }

        public static async Task<EvenementPage> GetInstance()
        {
            EvenementPage ep = new EvenementPage();
            EventsPageVIewModel gcvm = await EventsPageVIewModel.GetInstanceAsync();
            ep.BindingContext = gcvm;
            ep.listEvents.BindingContext = gcvm;
            ep.epvm = gcvm;

            return ep;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool success = false;
            var answer = await DisplayAlert("Question?", "Êtes vous sur de vouloir supprimer ce Pin ? ", "Oui", "Non");
            System.Diagnostics.Debug.WriteLine("answer = " + answer);
            if (answer)
            {
                this.listEvents.BeginRefresh();
                this.listEvents.ItemsSource = null;
                var pin = ((TappedEventArgs)e).Parameter;
                success = await this.epvm.DeleteEventsAsync((EventsViewModel)pin);
                //this.ListPins.BeginRefresh();
                this.listEvents.ItemsSource = epvm.Events;

                this.listEvents.EndRefresh();
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

            EventsViewModel pin = (EventsViewModel)((TappedEventArgs)e).Parameter;
            if (pin.Moreminus.Equals("minus.png"))
            {
                pin.SomeofDescription = pin.Description.Substring(0, 5) + "...";
                pin.Moreminus = "more.png";
            }
            else
            {
                pin.SomeofDescription = pin.Description;
                pin.Moreminus = "minus.png";
            }


            this.listEvents.BeginRefresh();
            this.listEvents.ItemsSource = null;
            this.listEvents.ItemsSource = epvm.Events;
            this.listEvents.EndRefresh();
        }

        private void Button_Ajouter_Clicked(object sender, EventArgs e)
        {
           Navigation.PushModalAsync(new AddEventPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await epvm.RefreshlistAsync();
            this.listEvents.BeginRefresh();
            this.listEvents.ItemsSource = null;
            this.listEvents.ItemsSource = epvm.Events;
            this.listEvents.EndRefresh();


        }
    }
}