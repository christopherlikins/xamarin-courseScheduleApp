using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }
        [Indexed]
        public int TermID { get; set; }
        public string CourseName { get; set; }
        public string CourseStatus { get; set; }
        public DateTime CourseStart { get; set; }
        public bool CourseStartToday { get; set; }
        public DateTime CourseEnd { get; set; }
        public bool CourseEndToday { get; set; }
        public string CourseInstructorName { get; set; }
        public string CourseInstructorPhone { get; set; }
        public string CourseInstructorEmail { get; set; }
        public string PerformanceAssessmentName { get; set; }
        public DateTime PerformanceAssessmentStart { get; set; }
        public bool PaStartToday { get; set; }
        public DateTime PerformanceAssessmentEnd { get; set; }
        public bool PaEndToday { get; set; }
        public string ObjectiveAssessmentName { get; set; }
        public DateTime ObjectiveAssessmentStart { get; set; }
        public bool OaStartToday { get; set; }
        public DateTime ObjectiveAssessmentEnd { get; set; }
        public bool OaEndToday { get; set; }
        public string CourseNotes { get; set; }
        public Course(int courseId, int termId, string courseName, string courseStatus, DateTime courseStart, bool courseStartToday, DateTime courseEnd, bool courseEndToday, string courseInstructorName, string courseInstructorPhone, string courseInstructorEmail, string performanceAssessmentName, DateTime performanceAssessmentStart, bool paStartToday, DateTime performanceAssessmentEnd, bool paEndToday, string objectiveAssessmentName, DateTime objectiveAssessmentStart, bool oaStartToday, DateTime objectiveAssessmentEnd, bool oaEndToday, string courseNotes)
        {
            CourseID = courseId;
            TermID = termId;
            CourseName = courseName;
            CourseStatus = courseStatus;
            CourseStart = courseStart;
            CourseStartToday = courseStartToday;
            CourseEnd = courseEnd;
            CourseEndToday = courseEndToday;
            CourseInstructorName = courseInstructorName;
            CourseInstructorPhone = courseInstructorPhone;
            CourseInstructorEmail = courseInstructorEmail;
            PerformanceAssessmentName = performanceAssessmentName;
            PerformanceAssessmentStart = performanceAssessmentStart;
            PaStartToday = paStartToday;
            PerformanceAssessmentEnd = performanceAssessmentEnd;
            PaEndToday = paEndToday;
            ObjectiveAssessmentName = objectiveAssessmentName;
            ObjectiveAssessmentStart = objectiveAssessmentStart;
            OaStartToday = oaStartToday;
            ObjectiveAssessmentEnd = objectiveAssessmentEnd;
            OaEndToday = oaEndToday;
            CourseNotes = courseNotes;
        }
        public Course()
        {

        }


    }
}
