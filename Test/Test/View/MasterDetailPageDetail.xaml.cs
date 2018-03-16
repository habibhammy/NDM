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
        private void Button_ECHANGE_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EchangePage());
        }
        private void Button_LE_MARCHE_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeMarchePage());
        }
        private async void Button_CARTE_Clicked(object sender, EventArgs e)
        {
            CartePage page = await CartePage.GetInstance();
            await Navigation.PushAsync(page);
        }
        private async void Button_EVENEMENT_Clicked(object sender, EventArgs e)
        {
            EvenementPage evp = await EvenementPage.GetInstance();
            await Navigation.PushAsync(evp);
        }

        
    }
}