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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            //CheckForNotifications();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
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

                    CrossLocalNotifications.Current.Show("Your Course " + CourseNotificationCheck[i].CourseName.ToString() + " starts today!", "Good Luck");
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
        

        private async void PopDatabaseButton_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteAllTermsAsync();
            await App.Database.DeleteAllCoursesAsync();
            Term term = new Term()
            {
                TermID = 0,
                TermName = "Term 01",
                TermStart = new DateTime(2022, 01, 05),
                TermEnd = new DateTime(2022, 06, 20),
                TermStartToday = false,
                TermEndToday = false
            };
            await App.Database.SaveTermAsync(term);
            Term term2 = new Term()
            {
                TermID = 1,
                TermName = "Term 02",
                TermStart = new DateTime(2022, 01, 05),
                TermEnd = new DateTime(2022, 06, 20),
                TermStartToday = false,
                TermEndToday = false
            };
            await App.Database.SaveTermAsync(term2);
            Term term3 = new Term()
            {
                TermID = 2,
                TermName = "Term 03",
                TermStart = new DateTime(2022, 08, 31),
                TermEnd = new DateTime(2022, 12, 15),
                TermStartToday = false,
                TermEndToday = false
            };
            await App.Database.SaveTermAsync(term3);
            Term term4 = new Term()
            {
                TermID = 3,
                TermName = "Term 04",
                TermStart = new DateTime(2023, 01, 05),
                TermEnd = new DateTime(2023, 06, 20),
                TermStartToday = false,
                TermEndToday = false
            };
            await App.Database.SaveTermAsync(term4);
            Course course = new Course()
            {
                TermID = 47,
                CourseName = "SQL 101",
                CourseStatus = "Completed",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseStartToday = false,
                CourseEndToday = false,
                CourseInstructorName = "Anita Allen",
                CourseInstructorPhone = "3334445555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "SQL PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "SQL OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course);
            Course course2 = new Course()
            {
                TermID = 47,
                CourseName = "C# 101",
                CourseStatus = "Completed",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseStartToday = false,
                CourseEndToday = false,
                CourseInstructorName = "Bell Hooks",
                CourseInstructorPhone = "3334445555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "C# PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "C# OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course2);
            Course course3 = new Course()
            {
                TermID = 47,
                CourseName = "Xamarin 101",
                CourseStatus = "In Progress",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseStartToday = false,
                CourseEndToday = false,
                CourseInstructorName = "Olaudah Equiano",
                CourseInstructorPhone = "3334445555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "Xamarin PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "Xamarin OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course3);
            Course course4 = new Course()
            {
                TermID = 47,
                CourseName = "Ethics of Code",
                CourseStatus = "In Progress",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseStartToday = false,
                CourseEndToday = false,
                CourseInstructorName = "Sojourner Truth",
                CourseInstructorPhone = "3334445555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "Ethics of Code PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "Ethics of Code OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course4);
            Course course5 = new Course()
            {
                TermID = 47,
                CourseName = "Study in Sisyphus",
                CourseStatus = "In Progress",
                CourseStart = DateTime.Now,
                CourseEnd = DateTime.Now.AddDays(7),
                CourseStartToday = true,
                CourseEndToday = false,
                CourseInstructorName = "Chris Likins",
                CourseInstructorPhone = "2069667717",
                CourseInstructorEmail = "clikin2@my.wgu.edu",
                PerformanceAssessmentName = "Study in Sisyphus PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "Study in Sisyphus OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course5);
            Course course6 = new Course()
            {
                TermID = 48,
                CourseName = "Philosophy of Science",
                CourseStatus = "In Progress",
                CourseStart = DateTime.Now,
                CourseEnd = DateTime.Now.AddDays(7),
                CourseStartToday = true,
                CourseEndToday = false,
                CourseInstructorName = "Stuart Hall",
                CourseInstructorPhone = "3334445555",
                CourseInstructorEmail = "email@Domain.com",
                PerformanceAssessmentName = "Philosophy of Science PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "Philosophy of Science OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course6);
            Course course7 = new Course()
            {
                TermID = 48,
                CourseName = "Historical Writing",
                CourseStatus = "In Progress",
                CourseStart = DateTime.Now,
                CourseEnd = DateTime.Now.AddDays(7),
                CourseStartToday = true,
                CourseEndToday = false,
                CourseInstructorName = "Sophie Bosede Oluwole",
                CourseInstructorPhone = "3334445555",
                CourseInstructorEmail = "email@Domain.com",
                PerformanceAssessmentName = "Historical Writing PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                PaStartToday = false,
                PaEndToday = false,
                ObjectiveAssessmentName = "Historical Writing OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                OaStartToday = false,
                OaEndToday = false,
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course7);
        }
    }
//    Term = new ObservableCollection<Term>();
//            Term.Add(new Term { TermID = 0, TermName = "Term 01", TermStart = new DateTime(2021, 08, 31), TermEnd = new DateTime(2021, 12, 15) });
//Term.Add(new Term { TermID = 1, TermName = "Term 02", TermStart = new DateTime(2022, 01, 05), TermEnd = new DateTime(2022, 06, 20) });
//Term.Add(new Term { TermID = 2, TermName = "Term 03", TermStart = new DateTime(2022, 08, 31), TermEnd = new DateTime(2022, 12, 15) });
//Term.Add(new Term { TermID = 3, TermName = "Term 04", TermStart = new DateTime(2023, 01, 05), TermEnd = new DateTime(2023, 06, 20) });

//Course = new ObservableCollection<Course>();
//Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "SQL 101", CourseStatus = "Completed", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Anita Allen", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "SQL PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "SQL OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
//Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "C# 101", CourseStatus = "Completed", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Bell Hooks", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "C# PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "C# OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
//Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Xamarin 101", CourseStatus = "In Progress", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Olaudah Equiano", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Xamarin PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Xamarin OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
//Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Ethics of Code", CourseStatus = "In Progress", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Sojourner Truth", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Ethics of Code PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Ethics of Code OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
//Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Philosophy of Science", CourseStatus = "Dropped", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Stuart Hall", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Philosophy of Science PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Philosophy of Science OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
//Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Historical Writing", CourseStatus = "Dropped", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Sophie Bosede Oluwole", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Historical Writing PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Historical Writing OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            
}