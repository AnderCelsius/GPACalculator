using GPACalculator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GPACalculator.UI
{
    public class UserInterface
    {
        public void RunApp()
        {
            var myScore = new GradeRepository();

            Console.WriteLine("***********UNIVERSITY OF PORT HARCOURT***********\n*********OFFICE OF THE REGISTRAR*********\n*********EXAMINATIONS AND RECORDS DIVISION********");
            Console.WriteLine("");
            Console.WriteLine("Welcome to your GPA Calculator Portal");
            Console.WriteLine("");
            Console.WriteLine("Press enter to start or any other key to exit");
            Console.Write(">>>");
            string begin = Console.ReadLine();
            Console.Clear();

            while (string.IsNullOrWhiteSpace(begin))
            {

                int numRegisteredCourse = 0;
                var message = string.Empty;

                Console.WriteLine("Press 1 to Add Scores");
                Console.WriteLine("Press 2 to Get SpreadSheet");
                Console.WriteLine("Press 3 to exit app");
                Console.WriteLine("");
                Console.Write(">>>");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        // Make score entry in a single process
                        Console.Clear();

                        var check = true;
                        while (check)
                        {
                            Console.WriteLine("Enter the number of registered courses");
                            Console.WriteLine("");
                            Console.Write(">>>");
                            var response = Console.ReadLine();
                            Console.Clear();

                            if (!Regex.IsMatch(response, @"^([1-5])$")) //Limit number of single registration to 5
                            {
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("Note: You can only register 5 courses at a time");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                numRegisteredCourse += int.Parse(response);
                                check = false;
                            }

                        }

                        // Course code Entry & Valididty
                        for (var i = 0; i < numRegisteredCourse; i++)
                        {
                            // Input variables needed to AddScore
                            var courseCode = string.Empty;
                            var score = 0;
                            var courseUnit = 0;

                            // Course code validation
                            var isCourse = true;
                            while (isCourse)
                            {
                                Console.Write("Enter course code (e.g MTH101): ");
                                var course_ = Console.ReadLine();
                                var course = course_.Substring(0, 3).ToUpper();
                                var code = course_.Substring(3);
                                courseCode = course + code;

                                if (!Regex.IsMatch(courseCode, "[A-Z]{3}[0-9]{3}"))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid course code");
                                    continue;
                                }

                                // Course Unit Valididty
                                Console.Clear();
                                var isCourseUnit = true;
                                while (isCourseUnit)
                                {
                                    Console.Write("Enter course unit: ");
                                    var input = Console.ReadLine();
                                    Console.Clear();
                                    if (!Regex.IsMatch(input, @"^([1-6])$"))
                                    {
                                        Console.WriteLine("invalid input. Please try again");
                                        continue;
                                    }
                                    else
                                    {
                                        courseUnit = int.Parse(input);
                                        break;
                                    }

                                }

                                // Score Validity
                                Console.Clear();
                                var isScore = true;
                                while (isScore)
                                {
                                    //Console.Clear();
                                    Console.Write("Enter score: ");
                                    var input = Console.ReadLine();
                                    Console.Clear();
                                    if (!(Regex.IsMatch(input, "[0-9]")))
                                    {
                                        Console.WriteLine("invalid input. Please try again");
                                        continue;
                                    }
                                    else
                                    {
                                        score = int.Parse(input);
                                        if (score >= 0 && score <= 100)
                                            break;
                                        else
                                        {
                                            Console.WriteLine("invalid score");
                                            continue;
                                        }
                                    }

                                }
                                Console.Clear();
                                break;
                            }
                            message = myScore.AddScore(courseCode, courseUnit, score); //Add entries to DataStore
                            Console.WriteLine(message);
                        }

                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        myScore.PrintSpreadSheet();
                    }
                    else if (choice == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a valid option");
                }

            }

        }

    }
}

