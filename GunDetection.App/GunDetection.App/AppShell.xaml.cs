using GunDetection.App.ViewModels;
using GunDetection.App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GunDetection.App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // Routing.RegisterRoute(nameof(TabbedView), typeof(TabbedView));
          //  Routing.RegisterRoute(nameof(SegurityWallView), typeof(SegurityWallView));
          Routing.RegisterRoute(nameof(ReportsView), typeof(ReportsView));
           Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
        //    Routing.RegisterRoute(nameof(ActivateServicesView), typeof(ActivateServicesView)); 
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void Shell_Navigating(object sender, ShellNavigatingEventArgs e)
        {

        }
    }
}
