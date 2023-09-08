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
    public partial class SubLocationView : ContentPage
    {
        private Location item;
        List<SubLocation> lsl;
       
        public SubLocationView(Location item)
        {
            InitializeComponent();
            this.item = item; 
        }

        protected override void OnAppearing()
        {
            Load();

        }

        private async void Load()
        {
            lsl = await LocationServices.GetSubLocationsAsync(item.Id);
            listSubLocation.ItemsSource = lsl;

        }
        private void ToolbarItem_ClickedSubLocation(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateSubLocationView(item), true);
        }

        private void Button_ClickedDelete(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var i = (SubLocation)layout.BindingContext;

            App.Current.MainPage.Navigation.PushAsync(new DeleteSubLocationView(i), true);
        }

        private void Button_ClickedUpdate(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var i = (SubLocation)layout.BindingContext;

            App.Current.MainPage.Navigation.PushAsync(new UpdateSubLocationView(i), true);
        }
    }
}