using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Course
    {
        public bool Is_active = true; // удаление курса -> false
        public int CourseId = 0;
        private List<Student> IncludedStudents = new List<Student>();
        private List<Teacher> IncludedTeachers = new List<Teacher>();
        public string Name = "";

        public Course(string name, int id)
        {
            Name = name;
            CourseId = id;
        }

        public void Remove()
        {
            this.Is_active = false;
            foreach (Student student in IncludedStudents)
            {
                student.DropCourse(this);
            }
            foreach (Teacher teacher in IncludedTeachers)
            {
                teacher.DropCourse(this);
            }
        }

        public void AddStudent(Student student)
        {
            IncludedStudents.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            IncludedStudents.Remove(student);
            student.DropCourse(this);
        }

        public void AddTeacher(Teacher teacher)
        {
            IncludedTeachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            IncludedTeachers.Remove(teacher);
            teacher.DropCourse(this);
        }

        public List<Teacher> GetStudents()
        {
            return IncludedTeachers;
        }
        
    }
}
