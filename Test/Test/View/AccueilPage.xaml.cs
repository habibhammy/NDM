using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.View;
using Xamarin.Forms;

namespace Test
{
    public partial class AccueilPage : ContentPage
    {
        public AccueilPage()
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
        private void Button_CARTE_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(CartePage.GetInstance().Result);
        }
        private void Button_EVENEMENT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EvenementPage());
        }
    }
}
