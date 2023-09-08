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
    public partial class AlertsView : ContentPage
    {
        List<Alert> listA;
        public AlertsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            acty.IsRunning = true;
            Load();
            acty.IsRunning = false;
        }
        async Task Load()
        {
            try
            {
                var res = await AlertServices.GetAler();
                if (res.Count() != 0)
                {
                    listA = res;
                    listAlerts.ItemsSource = res;
                }
            }
            catch (Exception)
            {

              
            }
           
          
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Alert)layout.BindingContext;
            PropiedadStatic.InsertAlert(item);

            App.Current.MainPage.Navigation.PushAsync(new AlertDetails(item), true);
           
        }
    }
}