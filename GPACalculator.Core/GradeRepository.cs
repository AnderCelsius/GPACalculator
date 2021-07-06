using GPACalculator.Data;
using GPACalculator.Model;
using System;

namespace GPACalculator.Core
{
    public class GradeRepository
    {
        int count = 1;

        public string AddScore(string course, int courseUnit, int score)
        {
            var message = string.Empty;
            int previousItemCount = DataStore.GradeTable.Count;

            var courseCode = course.Insert(3, " ");
            var grade = "";
            int gradePoint;
            int weightPoint = 0;
            var remark = "";

            if (score >= 70)
            {
                gradePoint = (int)GradeModel.GradeSystem.A;
                grade += (GradeModel.GradeSystem)gradePoint;
                weightPoint += courseUnit * gradePoint;
                remark += "Excellent";
            }
            else if (score >= 60)
            {
                gradePoint = (int)GradeModel.GradeSystem.B;
                grade += (GradeModel.GradeSystem)gradePoint;
                weightPoint += courseUnit * gradePoint;
                remark += "Very Good";
            }
            else if (score >= 50)
            {
                gradePoint = (int)GradeModel.GradeSystem.C;
                grade += (GradeModel.GradeSystem)gradePoint;
                weightPoint += courseUnit * gradePoint;
                remark += "Good";
            }
            else if (score >= 45)
            {
                gradePoint = (int)GradeModel.GradeSystem.D;
                grade += (GradeModel.GradeSystem)gradePoint;
                weightPoint += courseUnit * gradePoint;
                remark += "Fair";
            }
            else if (score >= 40)
            {
                gradePoint = (int)GradeModel.GradeSystem.E;
                grade += (GradeModel.GradeSystem)gradePoint;
                weightPoint += courseUnit * gradePoint;
                remark += "Pass";
            }
            else
            {
                gradePoint = (int)GradeModel.GradeSystem.F;
                grade += (GradeModel.GradeSystem)gradePoint;
                weightPoint += courseUnit * gradePoint;
                remark += "Fail";
            }

            var record = new GradeModel(count, courseCode, courseUnit, score, grade, gradePoint, weightPoint, remark);
            DataStore.GradeTable.Add(record);
            int updatedItemCount = DataStore.GradeTable.Count;
            count++;

            if (updatedItemCount > previousItemCount)
            {
                message = "Course added succesfully!";
            }


            return message;
        }

        public string GetGPA()
        {
            var totalGradeUnitRegistered = 0;
            var totalgradeUnitPassed = 0;
            var totalWeightPoints = 0;
            var gpa = 0.00;

            foreach (var item in DataStore.GradeTable)
            {
                totalWeightPoints += item.WeightPoint;
                totalGradeUnitRegistered += item.CourseUnit;
                if (item.Grade != "F")
                {
                    totalgradeUnitPassed += item.CourseUnit;
                }
            }

            gpa += (double)totalWeightPoints / (double)totalGradeUnitRegistered;

            return $"Total Grade Unit Registered is {totalGradeUnitRegistered}\n" +
                   $"Total Grade Unit Passed is {totalgradeUnitPassed}\n" +
                   $"Total Weight Point is {totalWeightPoints}\n" +
                   $"Your GPA is = {gpa:F2} to 2 decimal places.";

        }

        public void PrintSpreadSheet()
        {
            if (DataStore.GradeTable.Count != 0)
            {
                Console.Clear();
                PrintTable.PrintLine();
                PrintTable.PrintRow("COURSE CODE", "COURSE UNIT", "GRADE", "GRADE UNIT", "WEIGHT POINT", "REMARK");
                PrintTable.PrintLine();
                foreach (var item in DataStore.GradeTable)
                {
                    PrintTable.PrintRow(item.CourseCode, item.CourseUnit.ToString(), item.Grade, item.GradePoint.ToString(), item.WeightPoint.ToString(), item.Remark);
                    PrintTable.PrintLine();
                }

                Console.WriteLine(GetGPA());
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please add courses first");
                Console.WriteLine("");
            }

        }
    }
}
