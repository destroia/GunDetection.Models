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
    public partial class PopUpView
    {
        string Texto = "";
        public PopUpView()
        {
            InitializeComponent();
        }
        public PopUpView(string text)
        {
            InitializeComponent();
            Texto = text;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            textInfo.Text = Texto;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}