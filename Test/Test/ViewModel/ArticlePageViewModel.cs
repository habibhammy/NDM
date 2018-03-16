using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.Services;
using Xamarin.Forms;

namespace Test.ViewModel
{
    public class ArticlePageViewModel
    {
        private List<ArticleViewModel> articles;
        private bool firsttime;

        public List<ArticleViewModel> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                RaisePropertyCHanged();
            }
        }

        public ArticlePageViewModel() { firsttime = true; }

        public static async Task<ArticlePageViewModel> GetInstanceAsync()
        {
            ArticlePageViewModel gcvm = new ArticlePageViewModel();
            await gcvm.GetArticlesAsync();
            return gcvm;
        }

        private async Task GetArticlesAsync()
        {
            List<Article> ps = await HttpService.GetHttpService().GetAllArticlesAsync();
            articles = new List<ArticleViewModel>();
            foreach (Article p in ps)
            {
                ArticleViewModel pi = new ArticleViewModel
                {
                    SomeofDescription = p.Description.Substring(0, 5) + "...",
                    Moreminus = "more.png",
                    Id = p.Id,
                    Nom = p.Nom,
                    Vendeur = p.Vendeur,
                    Prix=p.Prix,
                    Description = p.Description,
                    NomVendeur = p.Vendeur.Nom + " " + p.Vendeur.Prenom + " (#" + p.Vendeur.Login + ")"
                };
                articles.Add(pi);
            }
        }

        public async Task AddArticles()
        {
            ArticleViewModel p = new ArticleViewModel
            {
                //Titre = Pintitre,
                //Latitude = Latitude,
                //Longitude = Longitude,
                //Description = Description
            };
            Articles.Add(p);
            await HttpService.GetHttpService().AddArticlesAsync(p.GetArticle());
            RaisePropertyCHanged();
        }

        public async Task<bool> DeleteArticlesAsync(ArticleViewModel p)
        {
            articles.Remove(p);
            try
            {
                await HttpService.GetHttpService().DeleteArticlesAsync(p.GetArticle());
                RaisePropertyCHanged();
                return true;
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<ArticlePageViewModel, string>(this, "Error 500", "Cet item a déjà était supprimé");
                RaisePropertyCHanged();
                return false;
            }


        }

        public async Task RefreshlistAsync()
        {
            if (firsttime)
            {
                firsttime = false;
            }
            else
                await GetArticlesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCHanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
