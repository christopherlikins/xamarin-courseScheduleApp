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

        private async void PopDatabaseButton_Clicked(object sender, EventArgs e)
        {
            Term term = new Term()
            {
                TermName = "Term 01",
                TermStart = new DateTime(2022, 01, 05),
                TermEnd = new DateTime(2022, 06, 20)
            };
            await App.Database.SaveTermAsync(term);
            Term term2 = new Term()
            {
                TermName = "Term 02",
                TermStart = new DateTime(2022, 01, 05),
                TermEnd = new DateTime(2022, 06, 20)
            };
            await App.Database.SaveTermAsync(term2);
            Term term3 = new Term()
            {
                TermName = "Term 03",
                TermStart = new DateTime(2022, 08, 31),
                TermEnd = new DateTime(2022, 12, 15)
            };
            await App.Database.SaveTermAsync(term3);
            Term term4 = new Term()
            {
                TermName = "Term 04",
                TermStart = new DateTime(2023, 01, 05),
                TermEnd = new DateTime(2023, 06, 20)
            };
            await App.Database.SaveTermAsync(term4);
            Course course = new Course()
            {
                TermID = 2,
                CourseName = "SQL 101",
                CourseStatus = "Completed",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseInstructorName = "Anita Allen",
                CourseInstructorPhone = "555-555-5555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "SQL PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                ObjectiveAssessmentName = "SQL OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course);
            Course course2 = new Course()
            {
                TermID = 3,
                CourseName = "C# 101",
                CourseStatus = "Completed",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseInstructorName = "Bell Hooks",
                CourseInstructorPhone = "555-555-5555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "C# PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                ObjectiveAssessmentName = "C# OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course2);
            Course course3 = new Course()
            {
                TermID = 4,
                CourseName = "Xamarin 101",
                CourseStatus = "In Progress",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseInstructorName = "Olaudah Equiano",
                CourseInstructorPhone = "555-555-5555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "Xamarin PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                ObjectiveAssessmentName = "Xamarin OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course3);
            Course course4 = new Course()
            {
                TermID = 3,
                CourseName = "Ethics of Code",
                CourseStatus = "In Progress",
                CourseStart = new DateTime(2021, 08, 31),
                CourseEnd = new DateTime(2021, 12, 15),
                CourseInstructorName = "Sojourner Truth",
                CourseInstructorPhone = "555-555-5555",
                CourseInstructorEmail = "email@domain.com",
                PerformanceAssessmentName = "Ethics of Code PA",
                PerformanceAssessmentStart = new DateTime(2021, 12, 15),
                PerformanceAssessmentEnd = new DateTime(2021, 12, 15),
                ObjectiveAssessmentName = "Ethics of Code OA",
                ObjectiveAssessmentStart = new DateTime(2021, 12, 15),
                ObjectiveAssessmentEnd = new DateTime(2021, 12, 15),
                CourseNotes = "This is a note"
            };
            await App.Database.SaveCourseAsync(course4);

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