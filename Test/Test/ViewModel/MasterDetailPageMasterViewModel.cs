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
                    new MasterDetailPageMenuItem { Id = 0, Title = "Accueil",Onlyadmin =true , TargetType = typeof(AccueilPage) },
                    new MasterDetailPageMenuItem { Id = 1, Title = "Profil",Onlyadmin =true , TargetType = typeof(ProfilPage) },
                    new MasterDetailPageMenuItem { Id = 2, Title = "Partenaire", Onlyadmin =true , TargetType = typeof(PartenairePage) },
                    new MasterDetailPageMenuItem { Id = 3, Title = "Gérer La Carte" , Onlyadmin =(true==CurrentUser.Isadmin()) , TargetType = typeof(GererCartePage) },
                    new MasterDetailPageMenuItem { Id = 4, Title = "Ou jeter mes dechets a Metz?" , Onlyadmin =true , TargetType = typeof(DechetPage) },
                    new MasterDetailPageMenuItem { Id = 5, Title = "Définitions", Onlyadmin =true , TargetType = typeof(DefinitionPage) },
                    new MasterDetailPageMenuItem { Id = 6, Title = "Mentions Légales", Onlyadmin =true , TargetType = typeof(MentionLegalPage) },
                    new MasterDetailPageMenuItem { Id = 7, Title = "Nous Contacter", Onlyadmin =true , TargetType = typeof(ContactPage) },
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
