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
            gcp.ListPins.BindingContext = gcvm;
            return gcp;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }
    }
}