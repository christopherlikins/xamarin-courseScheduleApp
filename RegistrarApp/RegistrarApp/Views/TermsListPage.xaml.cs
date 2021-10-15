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
        }

        private async void TermOneButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesThisTermPage());
            
        }

        private async void TermTwoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesThisTermPage());
        }

        private async void TermThreeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesThisTermPage());
        }

        private async void TermFourButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesThisTermPage());
        }
    }
}