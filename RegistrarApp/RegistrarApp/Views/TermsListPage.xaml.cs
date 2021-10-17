using RegistrarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsListPage : ContentPage
    {
        public TermsListPage()
        {
            InitializeComponent();
            LoadTermList();
        }

        async void LoadTermList()
        {
            TermListListView.ItemsSource = await App.Database.GetTermsAsync();
        }
        private async void AddTermButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTermPage());
        }

        private async void RefreshTermsButton_Clicked(object sender, EventArgs e)
        {
            TermListListView.ItemsSource = await App.Database.GetTermsAsync();
        }

        private async void TermListListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Globals.CurrentTerm = (Term)e.Item;
            await Navigation.PushAsync(new EditTermPage());
        }
    }
}