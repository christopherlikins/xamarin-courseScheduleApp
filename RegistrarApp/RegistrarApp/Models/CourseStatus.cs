using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class CourseStatus
    {
        public int CourseStatusID { get; set; }
        public string CourseStatusName { get; set; }
        public CourseStatus(int courseStatusId, string courseStatusName)
        {
            CourseStatusID = courseStatusId;
            CourseStatusName = courseStatusName;
        }
        public CourseStatus()
        {

        }
    }
}