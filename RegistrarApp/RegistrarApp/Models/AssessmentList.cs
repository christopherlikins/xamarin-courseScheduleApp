using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class AssessmentList
    {
        public int AssessmentListID { get; set; }
        public int AssessmentID { get; set; }
        public DateTime AssessmentStartDate { get; set; }
        public DateTime AssessmentEndDate { get; set; }
        public AssessmentList(int assessmentListId, int assessmentId, DateTime assessmentStartDate, DateTime assessmentEndDate)
        {
            AssessmentListID = assessmentListId;
            AssessmentID = assessmentId;
            AssessmentStartDate = assessmentStartDate;
            AssessmentEndDate = assessmentEndDate;
        }
        public AssessmentList()
        {
        }
    }
}