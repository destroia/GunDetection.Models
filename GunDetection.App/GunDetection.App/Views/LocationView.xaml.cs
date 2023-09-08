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
    public partial class LocationView : ContentPage
    {
        List<Location> ll;
        public LocationView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Load();
          
        }

        private async void Load()
        {
            ll = await LocationServices.GetLocationsAsync(Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f"));
            lisLocation.ItemsSource = ll;

        }

        private void ToolbarItem_AddLocation(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateLocationView(), true);
        }

        private void TapGestureRecognizer_TappedLocation(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Location)layout.BindingContext;

            App.Current.MainPage.Navigation.PushAsync(new SubLocationView(item), true);
        }

        private void Button_ClickedDelete(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Location)layout.BindingContext;

            App.Current.MainPage.Navigation.PushAsync(new DeleteLocationView(item), true);
        }

        private void Button_ClickedUpdate(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Location)layout.BindingContext;

            App.Current.MainPage.Navigation.PushAsync(new UpdateLocationView(item), true);
        }
    }
}