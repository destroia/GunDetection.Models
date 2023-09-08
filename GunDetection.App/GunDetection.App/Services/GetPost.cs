using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GunDetection.App.Services
{
    public static class GetPost
    {
        static async Task<bool> IsConnection()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {

                return true;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Verifique conexión a internet.", "Ok");
                return false;
            }
        }
        public static async Task<T> Get<T>(string url)
        {
            bool Internet = await IsConnection();
            if (Internet)
            {
                var client = new HttpClient();
                var respo = await client.GetAsync(url);
                if (respo.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var jsonStr = await respo.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                }
                return default(T);
            }
            return default;

        }


        public static async Task<T> Post<T>(string url, object obj)
        {
            bool Internet = await IsConnection();
            if (Internet)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var client = new HttpClient();

                var response = await client.PostAsync(url, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) { }
                {
                    var jsonStr = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                }
                return default(T);
            }
            return default;

        }
    }
}
