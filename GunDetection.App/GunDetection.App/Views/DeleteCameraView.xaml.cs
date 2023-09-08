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
    public partial class DeleteCameraView : ContentPage
    {
        private Camera item;
        public DeleteCameraView(Camera item)
        {
            InitializeComponent();
            this.item = item;
            txtCamera.Text = "The " + this.item.Name + " Camera will be removed";
        }
        private async void Button_ClickedDelete(object sender, EventArgs e)
        {
            try
            {
                var res = await CamerasServices.Delete(item);

                if (res.StatusCode == 200)
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("The Camera has been removed successfully"));
                    await App.Current.MainPage.Navigation.PopAsync(true);
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when removed the Camera"));
                    await App.Current.MainPage.Navigation.PopAsync(true);
                }
            }
            catch (Exception)
            {

                await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when removed the Camera"));
                await App.Current.MainPage.Navigation.PopAsync(true);
            }


        }

        private void Button_ClickedGoBack(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync(true);
        }
    }
}