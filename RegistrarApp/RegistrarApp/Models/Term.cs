using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Term
    {
        public int TermID { get; set; }
        public int CourseListID { get; set; }
        public string TermName { get; set; }
        public DateTime TermStartDate { get; set; }
        public DateTime TermEndDate { get; set; }

        public Term(int termId, int courseListId, string termName, DateTime termStartDate, DateTime termEndDate)
        {
            TermID = termId;
            CourseListID = courseListId;
            TermName = termName;
            TermStartDate = termStartDate;
            TermEndDate = termEndDate;
        }
        public Term()
        {

        }
    }
}