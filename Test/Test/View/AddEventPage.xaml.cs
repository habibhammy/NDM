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
    public partial class AddEventPage : ContentPage
    {
        private AddEventViewModel apvm;
        public AddEventPage()
        {
            InitializeComponent();
            apvm = new AddEventViewModel();
            BindingContext = apvm;
        }

        private async void Button_Ajouter_Clicked(object sender, System.EventArgs e)
        {
            apvm.AddEvents();
            await Navigation.PopModalAsync();
        }
    }
}