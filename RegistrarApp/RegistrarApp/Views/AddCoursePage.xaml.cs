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
                CourseStartToday = false,
                CourseEnd = DateTime.Now,
                CourseEndToday = false,
                CourseInstructorName = CourseInstructorNameEntryField.Text,
                CourseInstructorPhone = CourseInstructorPhoneEntryField.Text,
                CourseInstructorEmail = CourseInstructorEmailEntryField.Text,
                PerformanceAssessmentName = PANameEntryField.Text,
                PerformanceAssessmentStart = DateTime.Now,
                PaStartToday = false,
                PerformanceAssessmentEnd = DateTime.Now,
                PaEndToday = false,
                ObjectiveAssessmentName = OANameEntryField.Text,
                ObjectiveAssessmentStart = DateTime.Now,
                OaStartToday = false,
                ObjectiveAssessmentEnd = DateTime.Now,
                OaEndToday = false,
                CourseNotes = CourseNotesEntryField.Text
            };
            await App.Database.SaveCourseAsync(course);
        }
    }
}