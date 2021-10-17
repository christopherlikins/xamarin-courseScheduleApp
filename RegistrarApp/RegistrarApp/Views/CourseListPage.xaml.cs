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

    public partial class CourseListPage : ContentPage
    {
        public CourseListPage()
        {
            InitializeComponent();
            
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCourseList();
        }
        async void LoadCourseList()
        {
            CourseListListView.ItemsSource = await App.Database.GetCoursesAsync();
        }

        private async void AddCourseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCoursePage());
        }



        private async void CourseListListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Globals.CurrentCourse = (Course)e.Item;
            await Navigation.PushAsync(new EditCoursePage());
        }
    }
}