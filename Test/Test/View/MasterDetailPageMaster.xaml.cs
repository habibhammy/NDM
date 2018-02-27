using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

            public MasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
                {
                    new MasterDetailPageMenuItem { Id = 0, Title = "Accueil", Onlyconnected=false ,Onlyadmin =false , TargetType = typeof(AccueilPage) },
                    new MasterDetailPageMenuItem { Id = 1, Title = "Profil", Onlyconnected=true ,Onlyadmin =false , TargetType = typeof(ProfilPage) },
                    new MasterDetailPageMenuItem { Id = 2, Title = "Partenaire", Onlyconnected=false,Onlyadmin =false , TargetType = typeof(PartenairePage) },
                    new MasterDetailPageMenuItem { Id = 3, Title = "Gérer La Carte" , Onlyconnected=true,Onlyadmin =true , TargetType = typeof(GererCartePage) },
                    new MasterDetailPageMenuItem { Id = 4, Title = "Ou jeter mes dechets a Metz?" , Onlyconnected=false,Onlyadmin =false , TargetType = typeof(DechetPage) },
                    new MasterDetailPageMenuItem { Id = 5, Title = "Définitions", Onlyconnected=false,Onlyadmin =false , TargetType = typeof(DefinitionPage) },
                    new MasterDetailPageMenuItem { Id = 6, Title = "Nous Contacter", Onlyconnected=false,Onlyadmin =false , TargetType = typeof(ContactPage) },
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
}