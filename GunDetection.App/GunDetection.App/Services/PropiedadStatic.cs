using GunDetection.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.App.Services
{
    public static class PropiedadStatic
    {
        static string Aler = "Alert";
        public static async void InsertAlert(Alert item)
        {
            string AlertStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            App.Current.Properties[Aler] = AlertStr;
            await App.Current.SavePropertiesAsync();
        }
        public static Alert GetAler()
        {
            string AlerStr = App.Current.Properties[Aler].ToString();
            var alert = JsonConvert.DeserializeObject<Alert>(AlerStr);

            return alert;
        }
    }
}
