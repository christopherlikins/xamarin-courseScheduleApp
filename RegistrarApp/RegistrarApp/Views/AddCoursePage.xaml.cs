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
        }

        private async void SaveCourseButton_Clicked(object sender, EventArgs e)
        {
            SaveTheCourseLable.Text = "Course was saved.";
            Course course = new Course()
            {
                TermID = TermPicker.SelectedIndex,
                CourseName = CourseNameEntryField.Text,
                CourseStatus = CourseStatusPicker.SelectedItem.ToString(),
                CourseStart = DateTime.Parse(CourseStartDatePicker.ToString()),
                CourseStartToday = false,
                CourseEnd = DateTime.Parse(CourseEndDatePicker.ToString()),
                CourseEndToday = false,
                CourseInstructorName = CourseInstructorNameEntryField.Text,
                CourseInstructorPhone = CourseInstructorPhoneEntryField.Text,
                CourseInstructorEmail = CourseInstructorEmailEntryField.Text,
                PerformanceAssessmentName = PANameEntryField.Text,
                PerformanceAssessmentStart = DateTime.Parse(PAStartDatePicker.ToString()),
                PaStartToday = false,
                PerformanceAssessmentEnd = DateTime.Parse(PAEndDatePicker.ToString()),
                PaEndToday = false,
                ObjectiveAssessmentName = OANameEntryField.Text,
                ObjectiveAssessmentStart = DateTime.Parse(OAStartDatePicker.ToString()),
                OaStartToday = false,
                ObjectiveAssessmentEnd = DateTime.Parse(OAEndDatePicker.ToString()),
                OaEndToday = false,
                CourseNotes = CourseNotesEntryField.Text
            };
            await App.Database.SaveCourseAsync(course);
        }
    }
}