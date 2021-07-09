using GPACalculator.Utility;
using System;

namespace GPACalculator.Model
{
    public class Grade
    {
        public int CourseId { get; private set; }
        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public string CourseGrade { get; set; }
        public int GradePoint { get; set; }
        public int Score { get; set; }
        public int WeightPoint { get; set; }
        public string Remark { get; set; }


        public Grade(int CourseId, string CourseCode, int CourseUnit, int Score, string CourseGrade, int GradePoint, int WeightPoint, string Remark)
        {
            this.CourseId = CourseId;
            this.CourseCode = CourseCode;
            this.CourseUnit = CourseUnit;
            this.Score = Score;
            this.CourseGrade = CourseGrade;
            this.GradePoint = GradePoint;
            this.WeightPoint = WeightPoint;
            this.Remark = Remark;
        }
            
    }
}
