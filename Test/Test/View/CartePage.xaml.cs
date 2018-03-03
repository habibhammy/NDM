using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartePage : ContentPage
    {
        private Map Map { get; set; }
        private CartePage()
        {
            InitializeComponent();
            Map = new Map(MapSpan.FromCenterAndRadius(new Position(49.110310, 6.176792), Distance.FromMiles(10)));
            this.Content = Map;
        }


        public static Task<CartePage> GetInstance()
        {
            CartePage page = new CartePage();
            return page.AddPinsAsync();
        }
        public async Task<CartePage> AddPinsAsync()
        {
            List<Pin> pins = await HttpService.GetHttpService().GetAllPinsAsync();
            foreach (Pin p in pins)
                Map.Pins.Add(p);

            this.Content = Map;

            return this;
        }
    }
}