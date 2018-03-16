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
    public partial class LeMarchePage : ContentPage
    {
        public ListView ListArticles;

        public ArticlePageViewModel epvm;

        public LeMarchePage()
        {
            InitializeComponent();
            ListArticles = listArticles;
            ListArticles.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null; // de-select the row
            };
            MessagingCenter.Subscribe<ArticlePageViewModel, string>(this, "Error 500", (sender, arg) => {
                this.DisplayAlert("Error", arg, "OK");
            });
        }

        public static async Task<LeMarchePage> GetInstance()
        {
            LeMarchePage ep = new LeMarchePage();
            ArticlePageViewModel gcvm = await ArticlePageViewModel.GetInstanceAsync();
            ep.BindingContext = gcvm;
            ep.listArticles.BindingContext = gcvm;
            ep.epvm = gcvm;

            return ep;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            bool success = false;
            var answer = await DisplayAlert("Question?", "Êtes vous sur de vouloir supprimer ce Pin ? ", "Oui", "Non");
            System.Diagnostics.Debug.WriteLine("answer = " + answer);
            if (answer)
            {
                this.listArticles.BeginRefresh();
                this.listArticles.ItemsSource = null;
                var pin = ((TappedEventArgs)e).Parameter;
                success = await this.epvm.DeleteArticlesAsync((ArticleViewModel)pin);
                //this.ListPins.BeginRefresh();
                this.listArticles.ItemsSource = epvm.Articles;

                this.listArticles.EndRefresh();
                //this.ListPins.RefreshCommand = new Command<MapsPin>( () => )
            }
            if (success)
            {
                await this.DisplayAlert("Success", "Item bien supprimer", "OK");
            }
            else
            {
                await this.DisplayAlert("ERROR", "Item non supprimer", "OK");
            }
            System.Diagnostics.Debug.WriteLine("finished and should be updated !! ");
        }

        private void More_Clicked(object sender, EventArgs e)
        {

            ArticleViewModel pin = (ArticleViewModel)((TappedEventArgs)e).Parameter;
            if (pin.Moreminus.Equals("minus.png"))
            {
                pin.SomeofDescription = pin.Description.Substring(0, 5) + "...";
                pin.Moreminus = "more.png";
            }
            else
            {
                pin.SomeofDescription = pin.Description;
                pin.Moreminus = "minus.png";
            }


            this.listArticles.BeginRefresh();
            this.listArticles.ItemsSource = null;
            this.listArticles.ItemsSource = epvm.Articles;
            this.listArticles.EndRefresh();
        }

        private void Button_Ajouter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddEventPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await epvm.RefreshlistAsync();
            this.listArticles.BeginRefresh();
            this.listArticles.ItemsSource = null;
            this.listArticles.ItemsSource = epvm.Articles;
            this.listArticles.EndRefresh();


        }
    }
}