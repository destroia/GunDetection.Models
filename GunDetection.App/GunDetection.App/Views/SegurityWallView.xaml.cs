
using MediaManager.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GunDetection.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegurityWallView : ContentPage
    { public class s
        {
            public string sou { get; set; }
            public int soud { get; set; }
            public bool visible { get; set; }
            public bool Streaming { get; set; }
        }
        List<s> ls;
        
        public SegurityWallView()
        {
            InitializeComponent();

          

        }

        protected override void OnAppearing()
        {
            ls = new List<s>();
            ls.Add(new s() { sou = "https://archive.org/download/BigBuckBunny_328/BigBuckBunny_512kb.mp4", visible = true, Streaming = false });
            ls.Add(new s() { sou = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4", visible = false, soud = 1, Streaming = true });
            ls.Add(new s() { sou = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4", visible = true, soud = 1, Streaming = false }) ;
            ls.Add(new s() { sou = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/Sintel.mp4", visible = false, soud = 1, Streaming = true });

            

            lss.ItemsSource = ls;

           
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            
            App.Current.MainPage.Navigation.PushAsync(new SecurityWallAlertsView(), true);

        }
        protected override void OnDisappearing()
        {
            ls = null;
            lss.ItemsSource = null;
            base.OnDisappearing();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (s)layout.BindingContext;
            await Browser.OpenAsync(item.sou);


          
        }
    }
}