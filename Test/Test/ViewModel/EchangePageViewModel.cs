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
    public class EchangePageViewModel
    {
        private List<EchangeViewModel> echanges;
        private bool firsttime;

        public List<EchangeViewModel> Echanges
        {
            get { return echanges; }
            set
            {
                echanges = value;
                RaisePropertyCHanged();
            }
        }

        public EchangePageViewModel() { firsttime = true; }

        public static async Task<EchangePageViewModel> GetInstanceAsync()
        {
            EchangePageViewModel gcvm = new EchangePageViewModel();
            await gcvm.GetEchangesAsync();
            return gcvm;
        }

        private async Task GetEchangesAsync()
        {
            List<Echange> ps = await HttpService.GetHttpService().GetAllEchangesAsync();
            echanges = new List<EchangeViewModel>();
            foreach (Echange p in ps)
            {
                EchangeViewModel pi = new EchangeViewModel
                {
                    Moreminus = "more.png",
                    Id = p.Id,
                    Offre = p.Offre,
                    Posteur = p.Posteur,
                    Demande = p.Demande,
                    Statut = p.Statut,
                    NomPosteur = p.Posteur.Nom + " " + p.Posteur.Prenom + " (#" + p.Posteur.Login + ")",
                    NomStatut = p.Statut==1?"Active":"Non Active"
                };
                echanges.Add(pi);
            }
        }

        public async Task AddEchanges()
        {
            EchangeViewModel p = new EchangeViewModel
            {
                //Titre = Pintitre,
                //Latitude = Latitude,
                //Longitude = Longitude,
                //Description = Description
            };
            Echanges.Add(p);
            await HttpService.GetHttpService().AddEchangesAsync(p.GetEchange());
            RaisePropertyCHanged();
        }

        public async Task<bool> DeleteEchangesAsync(EchangeViewModel p)
        {
            echanges.Remove(p);
            try
            {
                await HttpService.GetHttpService().DeleteEchangesAsync(p.GetEchange());
                RaisePropertyCHanged();
                return true;
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<EchangePageViewModel, string>(this, "Error 500", "Cet item a déjà était supprimé");
                RaisePropertyCHanged();
                return false;
            }


        }

        public async Task RefreshlistAsync()
        {
            if (firsttime)
            {
                firsttime = false;
            }else
                await GetEchangesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCHanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
