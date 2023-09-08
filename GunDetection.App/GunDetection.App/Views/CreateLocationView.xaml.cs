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
    public partial class CreateLocationView : ContentPage
    {
        public CreateLocationView()
        {
            InitializeComponent();
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

            var res = await LocationServices.CreateLocation(new Models.Location()
            {
                Name = txt,
                Id = Guid.NewGuid(),
                IdUser = Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f")
            });

            if (res.StatusCode == 200)
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The location has been created successfully"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            else
            {
                   await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when creating the location"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
        }
    }
}