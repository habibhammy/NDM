using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Test.Model;
using Test.Services;
using Test.View;
using Xamarin.Forms;

namespace Test.ViewModel
{
    
    class InscriptionViewModel : INotifyPropertyChanged
    {
        char[] caractereSpeciaux = { '@', '\\', '&', '"', '+', '-', '_', ')', '=' };
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                if(login.Length>=5 )
                {
                    Login_color = Color.Green;
                }
                else
                {
                    Login_color = Color.Red;
                }
                RaisePropertyCHanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                if(!confirme_Password.Equals(password))
                    Comfirme_Password_error = Color.Red;
                if (password.Length>=10 && password.IndexOfAny(caractereSpeciaux) != -1)
                {
                    Password_color = Color.Green;
                }
                else
                {
                    Password_color = Color.Red;
                }
                RaisePropertyCHanged();
            }
        }

        private string confirme_Password;
        public string Confirme_Password
        {
            get { return confirme_Password; }
            set
            {
                Comfirme_Password_error = Color.Default;
                confirme_Password = value;
                if (confirme_Password.Equals(password))
                {
                    Comfirme_Password_error = Color.Green;
                }
                else
                {
                    Comfirme_Password_error = Color.Red;
                }
                
                RaisePropertyCHanged();
            }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                RaisePropertyCHanged();
            }
        }

        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                RaisePropertyCHanged();
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                if (IsEmail(email))
                {
                    Email_color = Color.Green;
                }
                else
                {
                    Email_color = Color.Red;
                }
                RaisePropertyCHanged();
            }
        }

        private DateTime birthDate;
        
        public DateTime BirthDate
        {
            get { return birthDate.Date; }
            set
            {
                birthDate = value;
                RaisePropertyCHanged();
            }
        }

        private string email_Universitaire;
        public string Email_Universitaire
        {
            get { return email_Universitaire; }
            set
            {
                email_Universitaire = value;
                if (email_Universitaire.Substring(email_Universitaire.Length - 22).Equals("@etu.univ-lorraine.com")
                    && Email_Universitaire.Length >= 27)
                {
                    Email_Universitaire_color = Color.Green;
                }
                else
                {
                    Email_Universitaire_color = Color.Red;
                }
                RaisePropertyCHanged();
            }
        }

        private Color comfirme_Password_error;
        public Color Comfirme_Password_error
        {
            get { return comfirme_Password_error; }
            set
            {
                comfirme_Password_error = value;
                RaisePropertyCHanged();
            }
        }
        private Color login_color = Color.Default;
        public Color Login_color
        {
            get { return login_color; }
            set
            {
                login_color = value;
                RaisePropertyCHanged();

            }
        }

        private Color password_color;
        public Color Password_color {
            get
            {
                return password_color;
            }
            set
            {
                password_color = value;
                RaisePropertyCHanged();
            }
        }


        private Color email_Universitaire_color;
        public Color Email_Universitaire_color {
            get { return email_Universitaire_color; }
            set
            {
                email_Universitaire_color = value;
                RaisePropertyCHanged();
            }
        }

        private Color email_color;
        public Color Email_color {
            get { return email_color; }
            set
            {
                email_color = value;
                RaisePropertyCHanged();
            }
        }

        internal bool SignUp(bool v)
        {
            System.Diagnostics.Debug.WriteLine("*************************************************");
            System.Diagnostics.Debug.WriteLine(Comfirme_Password_error);
            System.Diagnostics.Debug.WriteLine("*************************************************");
            System.Diagnostics.Debug.WriteLine(email_Universitaire != null ? email_Universitaire.Substring(email_Universitaire.Length - 22) : "");
            System.Diagnostics.Debug.WriteLine("*************************************************");
            if (login_color != Color.Red  && password_color != Color.Red && comfirme_Password_error != Color.Red && email_color != Color.Red)
            {

                if(email_Universitaire_color == Color.Red && v == true)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private bool IsEmail(string str)
        {
           return  Regex.IsMatch(str, @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyCHanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        public async Task SaveUser(bool eu)
        {
            Users u = new Users();
            u.Login = login;
            u.Password = password;
            u.Nom = nom;
            u.Prenom = prenom;
            u.Birthdate = birthDate;
            u.Email = email;
            u.Emailuniversitaire = eu?email_Universitaire:null;
            bool b = await UserexistAsync(u);
            if (!b)
            {
                await HttpService.GetHttpService().SaveUser(u);
            }
            else
            {
                throw new Exception("Ce  login existe déjà ! Veuillez réessayer avec un autre login !");
            }
        }

        private async Task<bool> UserexistAsync(Users u)
        {
            List<Users> alluser = await HttpService.GetHttpService().GetAllUsersAsync();
            foreach(Users us in alluser)
            {
                if (us.Login.Equals(u.Login))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
