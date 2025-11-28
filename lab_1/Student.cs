using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Student : Person
    {
        public int ID { get; private set; }
        private List<int> Ids_courses = new List<int>();

        public Student(string name, string secondName, string fatherName, int id) 
            : base(name, secondName, fatherName)
        {
            ID = id;
        }

        public void EnrollInCourse(Course course)
        {
            Ids_courses.Add(course.CourseId);
            course.AddStudent(this);
        }

        public void DeleteCourse(Course course)
        {
            Ids_courses.Remove(course.CourseId);
        }

        public void DropCourse(Course course)
        {
            DeleteCourse(course);
            course.RemoveStudent(this);
        }

        public List<int> GetEnrolledCourses()
        {
            return Ids_courses;
        }
    }
}
