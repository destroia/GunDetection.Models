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
    public partial class UpdateCameraView : ContentPage
    {

        bool activado = false;
        public UpdateCameraView(Camera item)
        {
            InitializeComponent();
            c = item;
            txtCamera.Text = c.Name;

        }
        
        List<Location> ll = new List<Location>();
        List<SubLocation> ls = new List<SubLocation>();
        Location loca = new Location();
        Camera c = new Camera();
        private Camera item;

        protected override void OnAppearing()
        {
            c.Name = "";
            Load();

        }

        private async void Load()
        {
            try
            {
                ll = await LocationServices.GetLocationsAsync(Guid.Parse("600095e5-9049-472e-a7c6-5cb0ca34ab2f"));

                location.ItemsSource = ll.Select(x => x.Name).ToList();

                if (activado == false)
                {
                    var lo = ll.Where(x => x.Id == c.IdLocation).FirstOrDefault();
                    int i = ll.IndexOf(lo);
                    location.SelectedIndex = i;


                    ls = await LocationServices.GetSubLocationsAsync(lo.Id);

                    var s = ls.Where(x => x.Id == c.IdSubLocation).FirstOrDefault();
                    int j = ls.IndexOf(s);

                    subLocation.SelectedIndex = j;
                    activado = true;
                }
            }
            catch (Exception)
            {

               
            }
            
        }
        private async void btn_ClickedSave(object sender, EventArgs e)
        {
            c.Name = txtCamera.Text;
            if (c.IdLocation != null && c.IdSubLocation != null && c.Name != "" && c.IdSubLocation != Guid.Empty)
            {
                var res = await CamerasServices.Update(c);
                if (res.StatusCode == 200)
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("The Camera has been updatin successfully"));
                    await App.Current.MainPage.Navigation.PopAsync(true);
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpView("Something unexpected happened when Updatin the location"));
                }

            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new PopUpView("The location, the sub location and the name of the camera are required fields"));
            }
        }

        private async void location_SelectedIndexChanged(object sender, EventArgs e)
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
