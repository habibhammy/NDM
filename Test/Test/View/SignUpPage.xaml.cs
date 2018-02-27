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
    public partial class SignUpPage : ContentPage
    {
        InscriptionViewModel inscriptionViewModel;
        public SignUpPage()
        {
            inscriptionViewModel = new InscriptionViewModel();
            InitializeComponent();
            BindingContext = inscriptionViewModel;
        }

        private async void Button_Sign_Up_Clicked(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("picker.SelectedItem = " + picker.SelectedItlem);

            if (inscriptionViewModel.SignUp( picker.SelectedItem==null?false : (bool)picker.SelectedItem ))
            {
                try
                {
                    await inscriptionViewModel.SaveUser(picker.SelectedItem == null ? false : (bool)picker.SelectedItem);
                    await this.DisplayAlert("Félicitation", "Votre inscription a été prise en compte. Veuillez vérifier votre email pour conformation", "OK");
                }catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("signup error = " + ex.Message);
                    await this.DisplayAlert("ERROR", ex.Message, "OK");
                }
            }
            else
            {
                await this.DisplayAlert("ERROR", "Le fromulaire d'inscription contient des erreurs. Veuillez corriger les informations en rouge!", "OK");
            }
        }
    }
}