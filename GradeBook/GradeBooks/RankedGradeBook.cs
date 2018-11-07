using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var percentStudents = (int)Math.Ceiling(Students.Count * 0.2); //will choose the number of students that conform the 20% and round to up
            //Uses expression lambda (pointer to a function)... First order object student by field AverageGrade, then of the object select the column AverageGrade and it put in a list
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[percentStudents - 1] <= averageGrade)
                return 'A';
            else if (grades[(percentStudents * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(percentStudents * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(percentStudents * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            var students = Students.Where(e => e.Grades != null).Select(e => e.Name);
            var numberOfStudents = students.Count(); 

            if (numberOfStudents < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}