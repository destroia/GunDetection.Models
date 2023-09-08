using GunDetection.App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GunDetection.App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}