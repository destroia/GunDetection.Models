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
    public partial class UpdateSubLocationView : ContentPage
    {
        private SubLocation item;
        public UpdateSubLocationView(SubLocation item)
        {
            InitializeComponent();
            this.item = item;
            txtSubLocation.Text = this.item.Name;
        }

        private async void Button_Save(object sender, EventArgs e)
        {
            string txt = txtSubLocation.Text;

            if (txt.Length == 0)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The Sub Location name field is required"));
                return;
            }
            btn.IsEnabled = false;

            var res = await LocationServices.UpdateSubLocation(new SubLocation()
            {
                Name = txt,
                Id = item.Id,
                IdLocation = item.IdLocation
            });

            if (res.StatusCode == 200)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The location has been update successfully"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when update the Sub location"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
        }
    }
}