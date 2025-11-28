using System;

namespace Lab1
{
    public class Teacher: Person
    {
        public int ID { get; private set; }
        private List<int> Ids_courses = new List<int>();

        public Teacher(string name, string secondName, string fatherName, int id) 
            : base(name, secondName, fatherName)
        {
            ID = id;
        }

        public void EnrollInCourse(Course course)
        {
            Ids_courses.Add(course.CourseId);
            course.AddTeacher(this);
        }

        public void DropCourse(Course course)
        {
            Ids_courses.Remove(course.CourseId);
            course.RemoveTeacher(this);
        }

        public List<int> GetEnrolledCourses()
        {
            return Ids_courses;
        }
    }
}