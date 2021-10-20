using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Globals
    {
        public static Course CurrentCourse { get; set; }
        public static Term CurrentTerm { get; set; }
        public static int CurrentCourseID { get; set; }
        public static int CurrentTermID { get; set; }
        public static int TermIDToCourseCount { get; set; }
        public static Term TermAssignedToCourse { get; set; }
        public static Course CourseToSave { get; set; }
    }
}
