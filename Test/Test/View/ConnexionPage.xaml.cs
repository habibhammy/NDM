using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Test.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnexionPage : ContentPage
    {
        ConnexionViewModel connexionviewmodel;
        public ConnexionPage()
        {
            InitializeComponent();
            connexionviewmodel = new ConnexionViewModel();
            BindingContext = connexionviewmodel;
            Checkconnectivity();
        }

        private async Task Button_Connect_Clicked(object sender, EventArgs e)
        {
            bool b = await connexionviewmodel.ConnectAsync();
            if (b)
            {
                await Navigation.PushModalAsync(new MasterdetailPage());
            }
            else
            {
                await this.DisplayAlert("ERROR", "Le nom d'utilisateur ou le mots de passe sont incorrectes ! Veuillez réessayer !", "cancel");
            }
                
        }

        private void Button_Sign_Up_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void Checkconnectivity()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                ShowMessage("CONNEXION ERROR", "Impossible d'atteindre le serveur source ! Veuillez vérifier votre connexion internet !", "Retry", Checkconnectivity).Wait();

            }

        }

        private async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            await DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }
    }
}