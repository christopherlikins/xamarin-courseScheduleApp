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
            CourseNotificationSwitch.IsToggled = Globals.CurrentCourse.CourseStartToday;
            PANotificationSwitch.IsToggled = Globals.CurrentCourse.PaStartToday;
            OANotificationSwitch.IsToggled = Globals.CurrentCourse.OaStartToday;
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
                CourseStart = CourseStartDatePicker.Date,
                //Fix the start and end date assigments.
                CourseStartToday = CourseNotificationSwitch.IsToggled,
                CourseEnd = CourseEndDatePicker.Date,
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
            CourseSavedOrDeleted.Text = "Course Deleted.";
            await App.Database.DeleteCourseAsync();
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