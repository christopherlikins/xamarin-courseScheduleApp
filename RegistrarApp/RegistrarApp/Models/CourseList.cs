using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class CourseList
    {
        public int CourseListID { get; set; }
        public int CourseID { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public CourseList(int courseListId, int courseId, DateTime courseStartDate, DateTime courseEndDate)
        {
            CourseListID = courseListId;
            CourseID = courseId;
            CourseStartDate = courseStartDate;
            CourseEndDate = courseEndDate;
        }
        public CourseList()
        {

        }
    }
}