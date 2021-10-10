using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class CourseInstructor
    {
        public int CourseInstructorID { get; set; }
        public string CourseInstructorName { get; set; }
        public string CourseInstructorPhone { get; set; }
        public string CourseInstructorEmail { get; set; }
        public CourseInstructor(int courseInstructorId, string courseInstructorName, string courseInstructorPhone, string courseInstructorEmail)
        {
            CourseInstructorID = courseInstructorId;
            CourseInstructorName = courseInstructorName;
            CourseInstructorPhone = courseInstructorPhone;
            CourseInstructorEmail = courseInstructorEmail;
        }
        public CourseInstructor()
        {

        }
    }
}
