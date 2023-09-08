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
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void Button_ClickedSettings(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LocationView(), true);
        }

        private void Button_ClickedCamera(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CameraView(), true);
        }
    }
}