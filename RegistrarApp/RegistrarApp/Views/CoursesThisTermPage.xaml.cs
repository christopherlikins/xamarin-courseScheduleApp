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
    public partial class CoursesThisTermPage : ContentPage
    {
        public CoursesThisTermPage()
        {
            InitializeComponent();
            LoadCourseList();
            PopulateCourseThisTermFields();
        }
        private void PopulateCourseThisTermFields()
        {
            CurrentTermTitle.Text = Globals.CurrentTerm.TermName;
        }
        async void LoadCourseList()
        {
            CourseThisTermListListView.ItemsSource = await App.Database.GetCoursesThisTerm();
        }

        private void TermEndDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void TermStartDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private async void AddCourseToTermButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseListPage());
            //onclick assign the courseid to populate the edit course page.
        }

        private async void CourseThisTermListListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Globals.CurrentCourse = (Course)e.Item;
            await Navigation.PushAsync(new EditCoursePage());
        }
    }
}