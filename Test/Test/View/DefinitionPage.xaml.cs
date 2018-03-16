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
    public partial class DefinitionPage : ContentPage
    {
        public ListView ListView;
        public DefinitionPage()
        {
            InitializeComponent();

            BindingContext = new DefintionVIewModel();
            ListView = listDefs;
        }

        private void More_Clicked(object sender, EventArgs e)
        {

        }
    }
}