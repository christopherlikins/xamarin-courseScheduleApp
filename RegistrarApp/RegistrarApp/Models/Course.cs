using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public int TermID { get; set; }
        public string CourseName { get; set; }
        public string CourseStatus { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
        public string CourseInstructorName { get; set; }
        public string CourseInstructorPhone { get; set; }
        public string CourseInstructorEmail { get; set; }
        public string PerformanceAssessmentName { get; set; }
        public DateTime PerformanceAssessmentStart { get; set; }
        public DateTime PerformanceAssessmentEnd { get; set; }
        public string ObjectiveAssessmentName { get; set; }
        public DateTime ObjectiveAssessmentStart { get; set; }
        public DateTime ObjectiveAssessmentEnd { get; set; }
        public string CourseNotes { get; set; }
        public Course (int courseId, int termId, string courseName, string courseStatus, DateTime courseStart, DateTime courseEnd, string courseInstructorName, string courseInstructorPhone, string courseInstructorEmail, string performanceAssessmentName, DateTime performanceAssessmentStart, DateTime performanceAssessmentEnd, string objectiveAssessmentName, DateTime objectiveAssessmentStart, DateTime objectiveAssessmentEnd, string courseNotes)
        {
            CourseID = courseId;
            TermID = termId;
            CourseName = courseName;
            CourseStatus = courseStatus;
            CourseStart = courseStart;
            CourseEnd = courseEnd;
            CourseInstructorName = courseInstructorName;
            CourseInstructorPhone = courseInstructorPhone;
            CourseInstructorEmail = courseInstructorEmail;
            PerformanceAssessmentName = performanceAssessmentName;
            PerformanceAssessmentStart = performanceAssessmentStart;
            PerformanceAssessmentEnd = performanceAssessmentEnd;
            ObjectiveAssessmentName = objectiveAssessmentName;
            ObjectiveAssessmentStart = objectiveAssessmentStart;
            ObjectiveAssessmentEnd = objectiveAssessmentEnd;
            CourseNotes = courseNotes;
        }
        public Course ()
        {

        }
    }
}
