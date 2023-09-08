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
    public partial class UpdateLocationView : ContentPage
    {
        static Location i;
        public UpdateLocationView(Models.Location item)
        {
            InitializeComponent();
            i = item;
            txtLocation.Text = i.Name;
        }
       
        private async void Button_Save(object sender, EventArgs e)
        {
            string txt = txtLocation.Text;

            if (txt.Length == 0)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The Location name field is required"));
                return;
            }
            btn.IsEnabled = false;

            var res = await LocationServices.UpdateLocation(new Models.Location()
            {
                Name = txt,
                Id = i.Id,
                IdUser = i.IdUser
            });

            if (res.StatusCode == 200)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The location has been update successfully"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when update the location"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
        }
    }
}