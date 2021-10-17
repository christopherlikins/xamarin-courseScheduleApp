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
    public partial class EditTermPage : ContentPage
    {
        public EditTermPage()
        {
            InitializeComponent();
            PopulateEditTermFrom();
        }
        private void PopulateEditTermFrom()
        {
            TermNameEntryField.Text = Globals.CurrentTerm.TermName;
        }

        private async void EditTermCoursesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesThisTermPage());
        }

        private void SaveTermButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}