using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarApp.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCoursePage : ContentPage
    {
        public AddCoursePage()
        {
            InitializeComponent();
            LoadPossibleTerms();
        }

        private async void LoadPossibleTerms()
        {
            
            TermPicker.ItemsSource = await App.Database.GetAvailableTerms();
        }
        private async void SaveCourseButton_Clicked(object sender, EventArgs e)
        {
            SaveTheCourseLable.Text = "Course was saved.";
            Course course = new Course()
            {
                TermID = TermPicker.SelectedIndex,
                CourseName = CourseNameEntryField.Text,
                CourseStatus = CourseStatusPicker.SelectedItem.ToString(),
                CourseStart = DateTime.Now,
                //Fix the start and end date assigments.
                CourseStartToday = CourseNotificationSwitch.IsToggled,
                CourseEnd = CourseStartDatePicker.Date,
                CourseEndToday = CourseNotificationSwitch.IsToggled,
                CourseInstructorName = CourseInstructorNameEntryField.Text,
                CourseInstructorPhone = CourseInstructorPhoneEntryField.Text,
                CourseInstructorEmail = CourseInstructorEmailEntryField.Text,
                PerformanceAssessmentName = PANameEntryField.Text,
                PerformanceAssessmentStart = PAStartDatePicker.Date,
                PaStartToday = PANotificationSwitch.IsToggled,
                PerformanceAssessmentEnd = PAEndDatePicker.Date,
                PaEndToday = PANotificationSwitch.IsToggled,
                ObjectiveAssessmentName = OANameEntryField.Text,
                ObjectiveAssessmentStart = OAStartDatePicker.Date,
                OaStartToday = OANotificationSwitch.IsToggled,
                ObjectiveAssessmentEnd = OAEndDatePicker.Date,
                OaEndToday = OANotificationSwitch.IsToggled,
                CourseNotes = CourseNotesEntryField.Text,
                
            };
            await App.Database.SaveCourseAsync(course);
        }

        private void CourseNotificationSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void PANotificationSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void OANotificationSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}