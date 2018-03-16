using System.Threading.Tasks;
using Test.Model;
using Test.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPinPage : ContentPage
    {
        private AddPinViewModel apvm;
        public AddPinPage()
        {
            InitializeComponent();
            apvm = new AddPinViewModel();
            BindingContext = apvm;
        }

        private async void Button_Ajouter_Clicked(object sender, System.EventArgs e)
        {
            apvm.AddPin();
            await Navigation.PopModalAsync();
        }
        
    }
}