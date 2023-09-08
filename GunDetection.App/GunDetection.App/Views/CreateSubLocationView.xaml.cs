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
    public partial class CreateSubLocationView : ContentPage
    {
        private Models.Location item;

    

        public CreateSubLocationView(Models.Location item)
        {
            InitializeComponent();
            this.item = item;
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

            var res = await LocationServices.CreateSubLocation(new Models.SubLocation()
            {
                Name = txt,
                Id = Guid.NewGuid(),
                IdLocation = item.Id
            });

            if (res.StatusCode == 200)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The Sub location has been created successfully"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when creating the Sub location"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
        }
    }
}