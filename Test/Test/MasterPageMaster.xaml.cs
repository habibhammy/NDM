using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterPageMenuItem> MenuItems { get; set; }
            
            public MasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterPageMenuItem>(new[]
                {
                    new MasterPageMenuItem { Id = 0, Title = "Accueil", Icon ="@drawable/image.png", TargetType=typeof(MainPage)},
                    new MasterPageMenuItem { Id = 1, Title = "Partenaire", Icon ="@drawable/image.png", TargetType=typeof(MainPage) },
                    new MasterPageMenuItem { Id = 2, Title = "Gestion et administration", Icon ="@drawable/image.png", TargetType=typeof(MainPage) },
                    new MasterPageMenuItem { Id = 3, Title = "Nous contacter", Icon ="@drawable/image.png" , TargetType=typeof(MainPage)},
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