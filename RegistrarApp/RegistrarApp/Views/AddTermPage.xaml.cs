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
    public partial class AddTermPage : ContentPage
    {
        public AddTermPage()
        {
            InitializeComponent();
        }

        private async void SaveTermButton_Clicked(object sender, EventArgs e)
        {
            SaveTheTermLable.Text = "Term Saved";
            Term term = new Term()
            {
                TermName = TermNameEntryField.Text,
                TermStart = DateTime.Now,
                TermEnd = DateTime.Now.AddDays(7)

        };
            await App.Database.SaveTermAsync(term);

        }
    }
}