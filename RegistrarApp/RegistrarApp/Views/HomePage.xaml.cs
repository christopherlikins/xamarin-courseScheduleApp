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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            
            
        }

        private void PopDatabaseButton_Clicked(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                TermID = 0,
                CourseName = "Studying Sisyphus",
                CourseStatus = "In Progress",
                CourseStart = DateTime.Now,
                CourseStartToday = true,
                CourseEnd = DateTime.Now.AddDays(7),
                CourseEndToday = false,
                CourseInstructorName = "WGU",
                CourseInstructorPhone = "555-555-5555",
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