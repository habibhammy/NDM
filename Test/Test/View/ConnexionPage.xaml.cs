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
    public partial class ConnexionPage : ContentPage
    {
        ConnexionViewModel connexionviewmodel;
        public ConnexionPage()
        {
            InitializeComponent();
            connexionviewmodel = new ConnexionViewModel();
            BindingContext = connexionviewmodel;
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
    }
}