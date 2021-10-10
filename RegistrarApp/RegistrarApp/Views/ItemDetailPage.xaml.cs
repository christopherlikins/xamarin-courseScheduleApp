using RegistrarApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RegistrarApp.Views
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