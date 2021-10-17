using RegistrarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegistrarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCoursePage : ContentPage
    {
        public EditCoursePage()
        {
            InitializeComponent();
            PopulateEditCourseFields();

        }

        private void PopulateEditCourseFields ()
        {
            CourseNameEntryField.Text = Globals.CurrentCourse.CourseName;
            //TermPicker.ItemsSource = await App.Database.GetTermsAsync();
            CourseStatusPicker.SelectedItem = Globals.CurrentCourse.CourseStatus.ToString();
            CourseStartDatePicker.Date = Globals.CurrentCourse.CourseStart;
            CourseEndDatePicker.Date = Globals.CurrentCourse.CourseEnd;
            CourseInstructorNameEntryField.Text = Globals.CurrentCourse.CourseInstructorName;
            CourseInstructorPhoneEntryField.Text = Globals.CurrentCourse.CourseInstructorPhone;
            CourseInstructorEmailEntryField.Text = Globals.CurrentCourse.CourseInstructorEmail;
            PANameEntryField.Text = Globals.CurrentCourse.PerformanceAssessmentName;
            PAStartDatePicker.Date = Globals.CurrentCourse.PerformanceAssessmentStart;
            PAEndDatePicker.Date = Globals.CurrentCourse.PerformanceAssessmentEnd;
            OANameEntryField.Text = Globals.CurrentCourse.ObjectiveAssessmentName;
            OAStartDatePicker.Date = Globals.CurrentCourse.ObjectiveAssessmentStart;
            OAEndDatePicker.Date = Globals.CurrentCourse.ObjectiveAssessmentEnd;
            CourseNotesEntryField.Text = Globals.CurrentCourse.CourseNotes;
        }
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            CourseSavedOrDeleted.Text = "Course record updated";
            Course course = new Course()
            {
                CourseID = Globals.CurrentCourse.CourseID,
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
            await App.Database.UpdateCourseAsync(course);
        }

        private async void DeleteCourseButton_Clicked(object sender, EventArgs e)
        {
            CourseNameEntryField.Text = string.Empty;
            CourseInstructorNameEntryField.Text = string.Empty;
            CourseInstructorPhoneEntryField.Text = string.Empty;
            CourseInstructorEmailEntryField.Text = string.Empty;
            OANameEntryField.Text = string.Empty;
            PANameEntryField.Text = string.Empty;
            CourseNotesEntryField.Text = string.Empty;
            CourseSavedOrDeleted.Text = "Course Deleted. Go back and refresh Course List Page.";
            await App.Database.DeleteCourseAsync();
        }
    }
}