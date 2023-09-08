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
    public partial class DeleteLocationView : ContentPage
    {
        private Location item;
        public DeleteLocationView(Location item)
        {
            InitializeComponent();
            this.item = item;
            txtlocation.Text = "The " + this.item.Name + " location will be removed";
        }

        private async void Button_ClickedDelete(object sender, EventArgs e)
        {
            try
            {
                var res = await LocationServices.DeleteLocation(item);

                if (res.StatusCode == 200)
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("The location has been removed successfully"));
                    await App.Current.MainPage.Navigation.PopAsync(true);
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when removed the location"));
                    await App.Current.MainPage.Navigation.PopAsync(true);
                }
            }
            catch (Exception)
            {

                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when removed the location"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }
            
          
        }

        private void Button_ClickedGoBack(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}