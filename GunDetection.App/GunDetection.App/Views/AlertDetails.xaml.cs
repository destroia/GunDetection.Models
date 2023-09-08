using GunDetection.App.Models;
using GunDetection.App.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GunDetection.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertDetails : ContentPage
    {
        static Alert Alerta;
        public AlertDetails(Alert item)
        {
            InitializeComponent();
            Alerta = item;
            if (Alerta == null)
            {
                 App.Current.MainPage.Navigation.PopAsync( true);
            }
            img.Source = Alerta.Full_photo;
            date.Text = Alerta.Date.ToString();
        }

        private static async void Button_ClickedTrue(object sender, EventArgs e)
        {
            Alerta.IdAccount = Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f");
            Alerta.IdUser = Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f");
            Alerta.Status = "true";
            var alert = await AlertServices.UpdateAler(Alerta);

            if (alert.StatusCode == 200)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Be selected positive"),true);
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected has happened"));
            }
        }

        private async void Button_ClickedFalse(object sender, EventArgs e)
        {
            Alerta.IdAccount = Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f");
            Alerta.IdUser = Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f");
            Alerta.Status = "false";
            var alert = await AlertServices.UpdateAler(Alerta);

            if (alert.StatusCode == 200)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Be selected false"), true);
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected has happened"));
            }
        }
    }
}