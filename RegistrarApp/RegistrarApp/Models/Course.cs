using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseStatusID { get; set; }
        public int CourseInstructorID { get; set; }
        public int AssessmentListID { get; set; }
        public string CourseNoteOne { get; set; }
        public string CourseNoteTwo { get; set; }
        public string CourseNoteThree { get; set; }
        public Course(int courseId, string courseName, int courseStatusId, int courseInstructorId, int assessmentListId, string courseNoteOne, string courseNoteTwo, string courseNoteThree)
        {
            CourseID = courseId;
            CourseName = courseName;
            CourseStatusID = courseStatusId;
            CourseInstructorID = courseInstructorId;
            AssessmentListID = assessmentListId;
            CourseNoteOne = courseNoteOne;
            CourseNoteTwo = courseNoteTwo;
            CourseNoteThree = courseNoteThree;
        }
        public Course()
        {

        }
    }
}