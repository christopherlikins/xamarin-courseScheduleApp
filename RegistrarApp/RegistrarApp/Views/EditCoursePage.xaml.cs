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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadTermList();
        }
        private async void LoadTermList()
        {
            TermsToAssignListListView.ItemsSource = await App.Database.GetTermsAsync();
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
            //This is how I can check how many courses are assigned to the term.
            //Compare the TermID grabbed from the term picker throw that into the globals.termIDToCourseCount variable
            //get the output int from the checknumberofcourses function
            //check to see if it is six or lower, if it is higher alert and dont save and recomend a different config.
            //Globals.TermIDToCourseCount = 1;
            //int CoursesThisTerm = await App.Database.CheckNumberOfCourses();
            //await DisplayAlert("Courses This term", "There are " + CoursesThisTerm, "OK");
            int number;
            DateTime CourseStart = CourseStartDatePicker.Date;
            DateTime CourseEnd = CourseEndDatePicker.Date;
            int CourseDateResult = DateTime.Compare(CourseStart, CourseEnd);
            DateTime PAStart = CourseStartDatePicker.Date;
            DateTime PAEnd = CourseEndDatePicker.Date;
            int PADateResult = DateTime.Compare(PAStart, PAEnd);
            DateTime OAStart = CourseStartDatePicker.Date;
            DateTime OAEnd = CourseEndDatePicker.Date;
            int OADateResult = DateTime.Compare(OAStart, OAEnd);
            

            if (string.IsNullOrWhiteSpace(CourseNameEntryField.Text) ||
                string.IsNullOrWhiteSpace(CourseInstructorNameEntryField.Text) ||
                string.IsNullOrWhiteSpace(CourseInstructorEmailEntryField.Text) ||
                
                CourseDateResult > 0 || PADateResult > 0 || OADateResult > 0)
            {
                await DisplayAlert("Check Values", "Please ensure all fields have values, and there are only numbers for the phone number. Also Confirm that your end dates come after your start dates. Thank you.", "OK");
            }
            
            else
            {
                CourseSavedOrDeleted.Text = "Course record updated";
                Course course = new Course()
                {
                    CourseID = Globals.CurrentCourse.CourseID,
                    TermID = Globals.TermAssignedToCourse.TermID,
                    CourseName = CourseNameEntryField.Text,
                    CourseStatus = CourseStatusPicker.SelectedItem.ToString(),
                    CourseStart = CourseStartDatePicker.Date,                    
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

        private void UnnassignTermButton_Clicked(object sender, EventArgs e)
        {
            string CourseAssignedToMessage = "Unassigned. Finish and Save to Confirm.";
            CourseAssignedToTermLabel.Text = CourseAssignedToMessage;
            
            Globals.TermAssignedToCourse.TermID = 99999;
        }

        private async void TermsToAssignListListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string CourseAssignedToMessage = "ASSIGNED. Finish and Save to Confirm.";
            CourseAssignedToTermLabel.Text = CourseAssignedToMessage;
            Globals.TermAssignedToCourse = (Term)e.Item;
            List<Course> CoursesThisTermCheck = await App.Database.GetCoursesAssignedThisTerm();

            int CoursesInThisTerm = CoursesThisTermCheck.Count;
            
            if (CoursesInThisTerm >= 6)
            {
                await DisplayAlert("Term is Full", "This Term already has six Courses. Please assign this course to another term. Thank you" + CoursesInThisTerm, "OK");
            }
            
        }
    }
}