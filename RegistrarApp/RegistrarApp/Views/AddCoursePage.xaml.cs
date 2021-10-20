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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadTermList();
        }
        private async void LoadTermList()
        {
            TermsToAssignListListView.ItemsSource = await App.Database.GetTermsAsync();
        }
        
        private async void SaveCourseButton_Clicked(object sender, EventArgs e)
        {
            
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
                string.IsNullOrWhiteSpace(CourseInstructorPhoneEntryField.Text) ||
                CourseDateResult > 0 || PADateResult > 0 || OADateResult > 0 )
            {
                await DisplayAlert("Check Values", "Please ensure all fields have values, and there are only numbers for the phone number. Also Confirm that your end dates come after your start dates. Thank you.", "OK");
            }
            
            
            else
            {
                SaveTheCourseLable.Text = "Course was saved.";
                try
                {


                    Globals.CourseToSave = new Course()
                    {
                        TermID = Globals.TermAssignedToCourse.TermID,
                        CourseName = CourseNameEntryField.Text,
                        CourseStatus = CourseStatusPicker.SelectedItem.ToString(),
                        CourseStart = CourseStartDatePicker.Date,
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
                }
                catch
                {
                    await DisplayAlert("Error", "Please either select a term for this course or tap Unassigned.", "OK");
                }
                try
                {
                    await App.Database.SaveCourseAsync(Globals.CourseToSave);
                }
                catch
                {
                    await DisplayAlert("Error", "Not saved to database properly", "OK");
                }
            }
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

        

        private async void TermsToAssignListListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string CourseAssignedToMessage = "ASSIGNED. Finish and Save to Confirm.";
            CourseAssignedToTermLabel.Text =  CourseAssignedToMessage;
            Globals.TermAssignedToCourse = (Term)e.Item;
            List<Course> CoursesThisTermCheck = await App.Database.GetCoursesAssignedThisTerm();

            int CoursesInThisTerm = CoursesThisTermCheck.Count;

            if (CoursesInThisTerm >= 6)
            {
                await DisplayAlert("Term is Full", "This Term already has six Courses. Please assign this course to another term. Thank you", "OK");
            }

        }

        private void UnnassignTermButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void UnnassignTermButtonAddCoursePage_Clicked(object sender, EventArgs e)
        {
            string CourseAssignedToMessage = "Unassigned. Finish and Save to Confirm.";
            CourseAssignedToTermLabel.Text = CourseAssignedToMessage;
            Globals.TermAssignedToCourse.TermID = 99999;
        }
    }
}