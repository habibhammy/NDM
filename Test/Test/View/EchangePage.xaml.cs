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
    public partial class EchangePage : ContentPage
    {
        public ListView ListEchanges;

        public EchangePageViewModel epvm;
        public EchangePage()
        {
            InitializeComponent();
            ListEchanges = listEchanges;
            ListEchanges.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
            MessagingCenter.Subscribe<EchangePageViewModel, string>(this, "Error 500", (sender, arg) => {
                this.DisplayAlert("Error", arg, "OK");
            });
        }

        public static async Task<EchangePage> GetInstance()
        {
            EchangePage ep = new EchangePage();
            EchangePageViewModel gcvm = await EchangePageViewModel.GetInstanceAsync();
            ep.BindingContext = gcvm;
            ep.listEchanges.BindingContext = gcvm;
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
                this.listEchanges.BeginRefresh();
                this.listEchanges.ItemsSource = null;
                var pin = ((TappedEventArgs)e).Parameter;
                success = await this.epvm.DeleteEchangesAsync((EchangeViewModel)pin);
                //this.ListPins.BeginRefresh();
                this.listEchanges.ItemsSource = epvm.Echanges;

                this.listEchanges.EndRefresh();
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

        private void Button_Ajouter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddEventPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await epvm.RefreshlistAsync();
            this.listEchanges.BeginRefresh();
            this.listEchanges.ItemsSource = null;
            this.listEchanges.ItemsSource = epvm.Echanges;
            this.listEchanges.EndRefresh();


        }
    }
}