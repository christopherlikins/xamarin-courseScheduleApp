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
            DateTime Start = TermStartDatePicker.Date;
            DateTime End = TermEndDatePicker.Date;
            int result = DateTime.Compare(Start, End);
            if (string.IsNullOrWhiteSpace(TermNameEntryField.Text) || result > 0 )
            {
                await DisplayAlert("Check data fields", "Please ensure a name is entered for this term, and that the term end date comes after the start date. Thank you.", "OK");
            }
            else
            {
                SaveTheTermLable.Text = "Term Saved";
                Term term = new Term()
                {

                    TermName = TermNameEntryField.Text,
                    TermStart = TermStartDatePicker.Date,
                    TermEnd = TermEndDatePicker.Date

                };
                await App.Database.SaveTermAsync(term);
            }
            

        }
    }
}