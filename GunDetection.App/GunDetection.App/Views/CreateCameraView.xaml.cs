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
    public partial class CreateCameraView : ContentPage
    {
        List<Location> ll = new List<Location>();
        List<SubLocation> ls = new List<SubLocation>();
        Location loca = new Location();
        Camera c = new Camera();
        public CreateCameraView()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            c.Name= "";
            Load();

        }

        private async void Load()
        {
            ll = await LocationServices.GetLocationsAsync(Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f"));
            location.ItemsSource = ll.Select(x => x.Name).ToList(); 

        }
        private async void btn_ClickedSave(object sender, EventArgs e)
        {
            c.Name = txtCamera.Text;
            if (c.IdLocation != null && c.IdSubLocation != null && c.Name != ""  && c.IdSubLocation != Guid.Empty)
            {
                c.Id = Guid.NewGuid();
                c.IdUser = Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f");
                var res = await CamerasServices.Create(c);
                if (res.StatusCode == 200)
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("The Camera has been created successfully"));
                    await App.Current.MainPage.Navigation.PopAsync(true); 
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when creating the location"));
                }

            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The location, the sub location and the name of the camera are required fields"));
            }
        }

        private async  void location_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loca = ll[location.SelectedIndex];
                c.IdLocation = loca.Id;
                ls = await LocationServices.GetSubLocationsAsync(loca.Id);

                subLocation.ItemsSource = ls.Select(x => x.Name).ToList();

            }
            catch (Exception)
            {

                
            }
           

        }

        private void subLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var i = ls[subLocation.SelectedIndex];
                c.IdSubLocation = i.Id;

            }
            catch (Exception)
            {
                c.IdSubLocation = Guid.Empty; 

            }
           

        }

        private async void Button_ClickedCreateLocation(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new CreateLocationView());
        }

        private async void Button_ClickedCreateSubLocation(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new CreateSubLocationView(loca));
        }
    }
}