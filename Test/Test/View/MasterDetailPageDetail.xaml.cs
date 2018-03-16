using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageDetail : ContentPage
    {
        public MasterDetailPageDetail()
        {
            InitializeComponent();
        }
        private async void Button_ECHANGE_Clicked(object sender, EventArgs e)
        {
            EchangePage ev = await EchangePage.GetInstance();
            await Navigation.PushAsync(ev);
        }
        private async void Button_LE_MARCHE_Clicked(object sender, EventArgs e)
        {
            LeMarchePage ev = await LeMarchePage.GetInstance();
            await Navigation.PushAsync(ev);
        }
        private async void Button_CARTE_Clicked(object sender, EventArgs e)
        {
            CartePage ev = await CartePage.GetInstance();
            await Navigation.PushAsync(ev);
        }
        private async void Button_EVENEMENT_Clicked(object sender, EventArgs e)
        {
            EvenementPage ev = await EvenementPage.GetInstance();
            await Navigation.PushAsync(ev);
        }
    }
}