using Plugin.LocalNotifications;
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
            
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCourseList();
            PopulateCourseThisTermFields();
            
            CourseStartCheck();
            CourseEndCheck();
            PAStartCheck();
            PAEndCheck();
            OAStartCheck();
            OAEndCheck();
        }
        public async void CourseStartCheck()
        {
            List<Course> CourseNotificationCheck = await App.Database.GetCoursesAsync();
            for (int i = 0; i < CourseNotificationCheck.Count; i++)
            {
                string CourseDate = CourseNotificationCheck[i].CourseStart.ToString("MM/dd/yyyy");
                string NowDate = DateTime.Now.ToString("MM/dd/yyyy");
                if (CourseDate == NowDate && CourseNotificationCheck[i].CourseStartToday == true)
                {

                    CrossLocalNotifications.Current.Show("Your Course " + CourseNotificationCheck[i].CourseName.ToString() + " with " + CourseNotificationCheck[i].CourseInstructorName.ToString() + " starts today!", "Good Luck");
                }
            }
        }
        public async void CourseEndCheck()
        {
            List<Course> CourseNotificationCheck = await App.Database.GetCoursesAsync();
            for (int i = 0; i < CourseNotificationCheck.Count; i++)
            {
                string CourseEndDate = CourseNotificationCheck[i].CourseEnd.ToString("MM/dd/yyyy");
                string NowEndDate = DateTime.Now.ToString("MM/dd/yyyy");
                if (CourseEndDate == NowEndDate && CourseNotificationCheck[i].CourseEndToday == true)
                {

                    CrossLocalNotifications.Current.Show("Your Course " + CourseNotificationCheck[i].CourseName.ToString() + " ends today!", "Congratulations!");
                }
            }
        }
        public async void PAStartCheck()
        {
            List<Course> CourseNotificationCheck = await App.Database.GetCoursesAsync();
            for (int i = 0; i < CourseNotificationCheck.Count; i++)
            {
                string PADate = CourseNotificationCheck[i].PerformanceAssessmentStart.ToString("MM/dd/yyyy");
                string PANowDate = DateTime.Now.ToString("MM/dd/yyyy");
                if (PADate == PANowDate && CourseNotificationCheck[i].PaStartToday == true)
                {

                    CrossLocalNotifications.Current.Show("Your Performance Assessment " + CourseNotificationCheck[i].PerformanceAssessmentName.ToString() + " starts today!", "Good Luck");
                }
            }
        }
        public async void PAEndCheck()
        {
            List<Course> CourseNotificationCheck = await App.Database.GetCoursesAsync();
            for (int i = 0; i < CourseNotificationCheck.Count; i++)
            {
                string PAEndDate = CourseNotificationCheck[i].PerformanceAssessmentEnd.ToString("MM/dd/yyyy");
                string PANowEndDate = DateTime.Now.ToString("MM/dd/yyyy");
                if (PAEndDate == PANowEndDate && CourseNotificationCheck[i].PaEndToday == true)
                {

                    CrossLocalNotifications.Current.Show("Your Performance Assessment " + CourseNotificationCheck[i].PerformanceAssessmentName.ToString() + " is due today!", "Good Luck");
                }
            }
        }
        public async void OAStartCheck()
        {
            List<Course> CourseNotificationCheck = await App.Database.GetCoursesAsync();
            for (int i = 0; i < CourseNotificationCheck.Count; i++)
            {
                string OADate = CourseNotificationCheck[i].ObjectiveAssessmentStart.ToString("MM/dd/yyyy");
                string OANowDate = DateTime.Now.ToString("MM/dd/yyyy");
                if (OADate == OANowDate && CourseNotificationCheck[i].OaStartToday == true)
                {

                    CrossLocalNotifications.Current.Show("Your Objective Assessment " + CourseNotificationCheck[i].ObjectiveAssessmentName.ToString() + " starts today!", "Good Luck");
                }
            }
        }
        public async void OAEndCheck()
        {
            List<Course> CourseNotificationCheck = await App.Database.GetCoursesAsync();
            for (int i = 0; i < CourseNotificationCheck.Count; i++)
            {
                string OAEndDate = CourseNotificationCheck[i].ObjectiveAssessmentStart.ToString("MM/dd/yyyy");
                string OANowEndDate = DateTime.Now.ToString("MM/dd/yyyy");
                if (OAEndDate == OANowEndDate && CourseNotificationCheck[i].OaStartToday == true)
                {

                    CrossLocalNotifications.Current.Show("Your Objective Assessment " + CourseNotificationCheck[i].ObjectiveAssessmentName.ToString() + " is due today!", "Good Luck");
                }
            }
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