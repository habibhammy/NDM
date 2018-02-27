using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using Test.View;

namespace Test.Services
{
    public class HttpService
    {
        private static string add = "/add";
        private static string get = "/";
        private static string delete = "/delete/";
        private static string update = "/update";
        private static string URL = "http://" + Properties.Resources.HostName + ":" + Properties.Resources.HostPort + "/xamarin/users";
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
            http.BaseAddress = new Uri(URL+add);
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
            http.BaseAddress = new Uri(URL + update);
            response = await http.PutAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine("SaveUser : response code after put = " + response.StatusCode);
        }

        public async Task UpdateUser(Users user)
        {
            string value = user.GetJSON();
            var contents = new StringContent(value, Encoding.UTF8, "application/JSON");
            http.BaseAddress = new Uri(URL + update);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.PutAsync(http.BaseAddress, contents);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(Users user)
        {
            http.BaseAddress = new Uri(URL + delete+user.Login);
            //System.Diagnostics.Debug.WriteLine("request = "+ http.r(http.BaseAddress, content).);
            var response = await http.DeleteAsync(http.BaseAddress);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            http.BaseAddress = new Uri(URL +get);
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
            http.BaseAddress = new Uri(URL + get + login);
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
    }
}
