using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.View;

namespace Test.ViewModel
{

    class MasterDetailPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

        public MasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
            {
                    new MasterDetailPageMenuItem { Id = 0, Title = "Accueil",Onlyadmin =(false==CurrentUser.Isadmin()) , TargetType = typeof(AccueilPage) },
                    new MasterDetailPageMenuItem { Id = 1, Title = "Profil",Onlyadmin =(false==CurrentUser.Isadmin()) , TargetType = typeof(ProfilPage) },
                    new MasterDetailPageMenuItem { Id = 2, Title = "Partenaire", Onlyadmin =(false==CurrentUser.Isadmin()) , TargetType = typeof(PartenairePage) },
                    new MasterDetailPageMenuItem { Id = 3, Title = "Gérer La Carte" , Onlyadmin =true/*(true==CurrentUser.Isadmin())*/ , TargetType = typeof(GererCartePage) },
                    new MasterDetailPageMenuItem { Id = 4, Title = "Ou jeter mes dechets a Metz?" , Onlyadmin =(false==CurrentUser.Isadmin()) , TargetType = typeof(DechetPage) },
                    new MasterDetailPageMenuItem { Id = 5, Title = "Définitions", Onlyadmin =(false==CurrentUser.Isadmin()) , TargetType = typeof(DefinitionPage) },
                    new MasterDetailPageMenuItem { Id = 6, Title = "Nous Contacter", Onlyadmin =(false==CurrentUser.Isadmin()) , TargetType = typeof(ContactPage) },
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
