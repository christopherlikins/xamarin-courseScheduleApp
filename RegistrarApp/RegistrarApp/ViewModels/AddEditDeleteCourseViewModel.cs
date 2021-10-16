using RegistrarApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using RegistrarApp.Services;

namespace RegistrarApp.ViewModels
{
    public class AddEditDeleteCourseViewModel : BindableObject
    {
        public ObservableCollection<Term> Term { get; set; }
        public ObservableCollection<Course> Course { get; set; }
        
        public AddEditDeleteCourseViewModel ()
        {
            DeleteCourse = new Command(OnUserChooseDelete);
            SaveCourse = new Command(OnUserChooseSave);
            Term = new ObservableCollection<Term>();
            Term.Add(new Term { TermID = 0, TermName = "Term 01", TermStart = new DateTime(2021, 08, 31), TermEnd = new DateTime(2021, 12, 15) });
            Term.Add(new Term { TermID = 1, TermName = "Term 02", TermStart = new DateTime(2022, 01, 05), TermEnd = new DateTime(2022, 06, 20) });
            Term.Add(new Term { TermID = 2, TermName = "Term 03", TermStart = new DateTime(2022, 08, 31), TermEnd = new DateTime(2022, 12, 15) });
            Term.Add(new Term { TermID = 3, TermName = "Term 04", TermStart = new DateTime(2023, 01, 05), TermEnd = new DateTime(2023, 06, 20) });

            Course = new ObservableCollection<Course>();
            Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "SQL 101", CourseStatus = "Completed", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Anita Allen", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "SQL PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "SQL OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "C# 101", CourseStatus = "Completed", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Bell Hooks", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "C# PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "C# OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Xamarin 101", CourseStatus = "In Progress", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Olaudah Equiano", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Xamarin PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Xamarin OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Ethics of Code", CourseStatus = "In Progress", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Sojourner Truth", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Ethics of Code PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Ethics of Code OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Philosophy of Science", CourseStatus = "Dropped", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Stuart Hall", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Philosophy of Science PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Philosophy of Science OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            Course.Add(new Course { CourseID = 1, TermID = 0, CourseName = "Historical Writing", CourseStatus = "Dropped", CourseStart = new DateTime(2021, 08, 31), CourseEnd = new DateTime(2021, 12, 15), CourseInstructorName = "Sophie Bosede Oluwole", CourseInstructorPhone = "555-555-5555", CourseInstructorEmail = "email@domain.com", PerformanceAssessmentName = "Historical Writing PA", PerformanceAssessmentStart = new DateTime(2021, 12, 15), PerformanceAssessmentEnd = new DateTime(2021, 12, 15), ObjectiveAssessmentName = "Historical Writing OA", ObjectiveAssessmentStart = new DateTime(2021, 12, 15), ObjectiveAssessmentEnd = new DateTime(2021, 12, 15), CourseNotes = "This is a note" });
            

        }

        string TestPopulateNoteFieldPlaceholder = "Content Loaded";
        public string TestPopulateNoteFieldDisplay
        {
            get => TestPopulateNoteFieldPlaceholder;
            set
            {
                if (value == TestPopulateNoteFieldPlaceholder)
                    return;
                TestPopulateNoteFieldPlaceholder = value;
                OnPropertyChanged(nameof(TestPopulateNoteFieldDisplay));
            }
        }

        string DeletedAddedDisplayPlaceholder = "Course Deleted/Added";
        public string DeletedAddedDisplay
        {
            get => DeletedAddedDisplayPlaceholder;
            set
            {
                if (value == DeletedAddedDisplayPlaceholder)
                    return;
                DeletedAddedDisplayPlaceholder = value;
                OnPropertyChanged(nameof(DeletedAddedDisplay));
            }
        }

        public ICommand DeleteCourse { get; }
        void OnUserChooseDelete()
        {
            DeletedAddedDisplay = "Class Deleted";
        }
        public ICommand SaveCourse { get; }
        void OnUserChooseSave()
        {
            DeletedAddedDisplay = "Class Saved";
        }

    }
   
}
