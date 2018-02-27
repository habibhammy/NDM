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
    class ConnexionViewModel : INotifyPropertyChanged
    {
        private string login = "Login";
        public string Login {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyCHanged();
            }
        }

        private string password = "Password";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyCHanged();
            }
        }

        internal async Task<bool> ConnectAsync()
        {
            return await Verify();
        }

        private async Task<bool> Verify()
        {
            Users u = await HttpService.GetHttpService().GetUser(login);
            if (u != null && u.Password.Equals(password))
            {
                CurrentUser.Initcurrentuser(u);
                return true;
            }
            return false;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCHanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }



        
    }
}
