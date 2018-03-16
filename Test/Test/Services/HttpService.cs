using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Xamarin.Forms.Maps;

namespace Test.Services
{
    public class HttpService
    {
        private static string adduser = "users/add";
        private static string getuser = "users/";
        private static string deleteuser = "users/delete/";
        private static string updateuser = "users/update";

        private static string addmappin = "maps/add";
        private static string getmappin = "maps/";
        private static string deletemappin = "maps/delete/";

        private static string addevent = "events/add";
        private static string getevent = "events/";
        private static string deleteevent = "events/delete/";

        private static string addechange = "echange/add";
        private static string getechange = "echange/";
        private static string deleteechange = "echange/delete/";

        private static string addarticle = "article/add";
        private static string getarticle = "article/";
        private static string deletearticle = "article/delete/";


        private static string URL = "http://" + Properties.Resources.HostName + ":" + Properties.Resources.HostPort + "/xamarin/";
        private HttpClient http;

        private static HttpService instance;

        private HttpService()
        {
             http = new HttpClient();
            
        }

        public static HttpService GetHttpService()
        {
            if (instance == null)
                instance = new HttpService();

            return instance;
        }

        public async Task SaveUser(Users user)
        {
            http.BaseAddress = new Uri(URL+adduser);
            var values = new Dictionary<string, string>
                {
                   { "username", user.Login },
                   { "password", user.Password },
                   { "email", user.Email }
                };

            var content = new FormUrlEncodedContent(values);
            var response = await http.PostAsync(http.BaseAddress, content);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine("SaveUser : response code after post = " + response.StatusCode);
            string value = user.GetJSON();
            var contents = new StringContent(value, Encoding.UTF8,"application/JSON");
            System.Diagnostics.Debug.WriteLine("save : content sent="+contents.ReadAsStringAsync().Result);
            http.BaseAddress = new Uri(URL + updateuser);
            response = await http.PutAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine("SaveUser : response code after put = " + response.StatusCode);
        }

        public async Task UpdateUser(Users user)
        {
            string value = user.GetJSON();
            var contents = new StringContent(value, Encoding.UTF8, "application/JSON");
            http.BaseAddress = new Uri(URL + updateuser);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.PutAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(Users user)
        {
            http.BaseAddress = new Uri(URL + deleteuser+user.Login);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.DeleteAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            http.BaseAddress = new Uri(URL +getuser);
            var response = await http.GetAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
            string resultat = response.Content.ReadAsStringAsync().Result;
           // System.Diagnostics.Debug.WriteLine("GetAllUsersAsync : response.Content=" +resultat);
            List<Users> allusers = JsonConvert.DeserializeObject<List<Users>>(resultat,
                new JsonSerializerSettings{
                                            NullValueHandling = NullValueHandling.Ignore,
                                            MissingMemberHandling = MissingMemberHandling.Ignore
                                          });
           // List<Users> allusers = new List<Users>();
           // System.Diagnostics.Debug.WriteLine("GetAllUsersAsync : allusers=" + allusers);
            return allusers;
        }

        public async Task<Users> GetUser(string login)
        {
            http.BaseAddress = new Uri(URL + getuser + login);
            var response = await http.GetAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
            string resultat = response.Content.ReadAsStringAsync().Result;
            Users users = JsonConvert.DeserializeObject<Users>(resultat,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
           
            return users;
        }

        public async Task<List<Pin>> GetAllPinsAsync()
        {
           List<MapsPin> allPins = await this.GetAllMapsPinsAsync();
           return GetPins(allPins);
        }

        public async Task<List<MapsPin>> GetAllMapsPinsAsync()
        {
            System.Diagnostics.Debug.WriteLine("Here we start ");
            http.BaseAddress = new Uri(URL + getmappin);
            System.Diagnostics.Debug.WriteLine("URI = " + URL + getmappin);
            var response = await http.GetAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
            string resultat = response.Content.ReadAsStringAsync().Result;
            System.Diagnostics.Debug.WriteLine("resultat = " + resultat);

            /*
             new Pin
            {
                Position = new Position(49.108223, 6.181507),
                Label = "Centre Pompidou!",
                Address ="Le plus grand centre commercial au centre ville de Metz !! "
            };
             */
            List<MapsPin> allPins = JsonConvert.DeserializeObject<List<MapsPin>>(resultat,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });


            return allPins;
        }

        public async Task AddMapsPinAsync(MapsPin p)
        {
            string value = p.GetJson();
            var contents = new StringContent(value, Encoding.UTF8, "application/JSON");
            http.BaseAddress = new Uri(URL + addmappin);
            System.Diagnostics.Debug.WriteLine("request = "+value);
            var response = await http.PostAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMapsPinAsync(MapsPin p)
        {
            http.BaseAddress = new Uri(URL + deletemappin + p.Id);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.DeleteAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

        private List<Pin> GetPins(List<MapsPin> allPins)
        {
            List<Pin> list = new List<Pin>();
            foreach(MapsPin pin in allPins)
            {
                list.Add( new Pin
                {
                    Position = new Position(pin.Latitude,pin.Longitude),
                    Label = pin.Titre,
                    Address = pin.Description
                }
                    );
            }

            return list;
        }

        public async Task<List<Events>> GetAllEventsAsync()
        {
            System.Diagnostics.Debug.WriteLine("Here we start ");
            http.BaseAddress = new Uri(URL + getevent);
            System.Diagnostics.Debug.WriteLine("URI = " + URL + getevent);
            var response = await http.GetAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
            string resultat = response.Content.ReadAsStringAsync().Result;
            System.Diagnostics.Debug.WriteLine("resultat = " + resultat);

            /*
             new Pin
            {
                Position = new Position(49.108223, 6.181507),
                Label = "Centre Pompidou!",
                Address ="Le plus grand centre commercial au centre ville de Metz !! "
            };
             */
            List<Events> allPins = JsonConvert.DeserializeObject<List<Events>>(resultat,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });


            return allPins;
        }

        public async Task DeleteEventsAsync(Events events)
        {

            http.BaseAddress = new Uri(URL + deleteevent + events.Id);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.DeleteAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddEventsAsync(Events events)
        {
            string value = events.GetJson();
            var contents = new StringContent(value, Encoding.UTF8, "application/JSON");
            http.BaseAddress = new Uri(URL + addevent);
            System.Diagnostics.Debug.WriteLine("request = " + value);
            var response = await http.PostAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Echange>> GetAllEchangesAsync()
        {
            System.Diagnostics.Debug.WriteLine("Here we start ");
            http.BaseAddress = new Uri(URL + getechange);
            System.Diagnostics.Debug.WriteLine("URI = " + URL + getechange);
            var response = await http.GetAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
            string resultat = response.Content.ReadAsStringAsync().Result;
            System.Diagnostics.Debug.WriteLine("resultat = " + resultat);

            /*
             new Pin
            {
                Position = new Position(49.108223, 6.181507),
                Label = "Centre Pompidou!",
                Address ="Le plus grand centre commercial au centre ville de Metz !! "
            };
             */
            List<Echange> allPins = JsonConvert.DeserializeObject<List<Echange>>(resultat,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });


            return allPins;
        }

        public async Task DeleteEchangesAsync(Echange events)
        {

            http.BaseAddress = new Uri(URL + deleteechange + events.Id);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.DeleteAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddEchangesAsync(Echange events)
        {
            string value = events.GetJson();
            var contents = new StringContent(value, Encoding.UTF8, "application/JSON");
            http.BaseAddress = new Uri(URL + addechange);
            System.Diagnostics.Debug.WriteLine("request = " + value);
            var response = await http.PostAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            System.Diagnostics.Debug.WriteLine("Here we start ");
            http.BaseAddress = new Uri(URL + getarticle);
            System.Diagnostics.Debug.WriteLine("URI = " + URL + getarticle);
            var response = await http.GetAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
            string resultat = response.Content.ReadAsStringAsync().Result;
            System.Diagnostics.Debug.WriteLine("resultat = " + resultat);

            /*
             new Pin
            {
                Position = new Position(49.108223, 6.181507),
                Label = "Centre Pompidou!",
                Address ="Le plus grand centre commercial au centre ville de Metz !! "
            };
             */
            List<Article> allPins = JsonConvert.DeserializeObject<List<Article>>(resultat,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });


            return allPins;
        }

        public async Task DeleteArticlesAsync(Article events)
        {

            http.BaseAddress = new Uri(URL + deletearticle + events.Id);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.DeleteAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddArticlesAsync(Article events)
        {
            string value = events.GetJson();
            var contents = new StringContent(value, Encoding.UTF8, "application/JSON");
            http.BaseAddress = new Uri(URL + addarticle);
            System.Diagnostics.Debug.WriteLine("request = " + value);
            var response = await http.PostAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
        }

    }
}
