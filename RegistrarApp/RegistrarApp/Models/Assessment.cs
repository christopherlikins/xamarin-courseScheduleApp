using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarApp.Models
{
    public class Assessment
    {
        public int AssessmentID { get; set; }
        public string AssessmentName { get; set; }
        public bool PerformanceAssessment { get; set; }
        public bool ObjectiveAssessment { get; set; }
        public Assessment(int assessmentId, string assessmentName, bool performanceAssessment, bool objectiveAssessment)
        {
            AssessmentID = assessmentId;
            AssessmentName = assessmentName;
            PerformanceAssessment = performanceAssessment;
            ObjectiveAssessment = objectiveAssessment;
        }
        public Assessment()
        {

        }
    }
}