using System;

namespace GPACalculator.Model
{
    public class GradeModel
    {
        public int CourseId { get; private set; }
        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public string Grade { get; private set; }
        public int GradePoint { get; set; }
        public int Score { get; set; }
        public int WeightPoint { get; private set; }
        public string Remark { get; private set; }

        public enum GradeSystem
        {
            A = 5,
            B = 4,
            C = 3,
            D = 2,
            E = 1,
            F = 0
        }

        public GradeModel(int CourseId, string CourseCode, int CourseUnit, int Score, string Grade, int GradePoint, int WeightPoint, string Remark)
        {
            this.CourseId = CourseId;
            this.CourseCode = CourseCode;
            this.CourseUnit = CourseUnit;
            this.Score = Score;
            this.Grade = Grade;
            this.GradePoint = GradePoint;
            this.WeightPoint = WeightPoint;
            this.Remark = Remark;
        }
    }
}
