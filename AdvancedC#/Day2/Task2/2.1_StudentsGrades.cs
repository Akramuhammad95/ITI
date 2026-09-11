using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Task2
{
    public class StudentsGrades
    {
        public Dictionary<string, List<int>> _studentGrades { get; private set; }

        
        public void AddGrades(string studentName, List<int> grades)
        {
            if (_studentGrades == null)
            {
                _studentGrades = new Dictionary<string, List<int>>();
            }
            if (_studentGrades.ContainsKey(studentName))
            {
                _studentGrades[studentName].AddRange(grades);
            }
            else
            {
                _studentGrades[studentName] = new List<int>(grades);
            }
        }

        public double GetAverageGrade(string studentName)
        {
            if (_studentGrades == null || !_studentGrades.ContainsKey(studentName))
            {
                throw new ArgumentException("Student not found");
            }
            List<int> grades = _studentGrades[studentName];
            if (grades.Count == 0)
            {
                throw new InvalidOperationException("No grades available for this student");
            }
            double average = (double)grades.Sum() / grades.Count;
            return average;
        }
    }
}
