using GunDetection.App.Models;
using GunDetection.App.Services;
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
    public partial class CameraView : ContentPage
    {
        List<Camera> lc;

        public CameraView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Load();

        }

        private async void Load()
        {
            lc = await CamerasServices.Get(Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f"));
            listCameras.ItemsSource = lc;

        }
        private void ToolbarItem_ClickedAddCamera(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateCameraView(), true);
        }

        private void Button_ClickedDelete(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Camera)layout.BindingContext;
            

            App.Current.MainPage.Navigation.PushAsync(new DeleteCameraView(item), true);
        }

        private void Button_ClickedUpdate(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Camera)layout.BindingContext;
           

            App.Current.MainPage.Navigation.PushAsync(new UpdateCameraView(item), true);
        }
    }
}