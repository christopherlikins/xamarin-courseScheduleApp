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
    public partial class TermsListPage : ContentPage
    {
        public TermsListPage()
        {
            InitializeComponent();
            
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadTermList();
            CourseStartCheck();
            CourseEndCheck();
            PAStartCheck();
            PAEndCheck();
            OAStartCheck();
            OAEndCheck();
        }

        async void LoadTermList()
        {
            TermListListView.ItemsSource = await App.Database.GetTermsAsync();
        }
        private async void AddTermButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTermPage());
        }

        private async void RefreshTermsButton_Clicked(object sender, EventArgs e)
        {
            TermListListView.ItemsSource = await App.Database.GetTermsAsync();
        }

        private async void TermListListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Globals.CurrentTerm = (Term)e.Item;
            await Navigation.PushAsync(new EditTermPage());
        }
    }
}