using System;

namespace Lab1
{
    public class Course
    {
        public bool IsActive = true; // удаление курса делает false 
        public int CourseId{ get; private   set; }
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
            this.IsActive = false;
            foreach (Student student in IncludedStudents)
            {
                student.DeleteCourse(this);
            }
            foreach (Teacher teacher in IncludedTeachers)
            {
                teacher.DeleteCourse(this);
            }
            IncludedStudents.Clear();
            IncludedTeachers.Clear();
        }

        public void AddStudent(Student student)
        {
            IncludedStudents.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            IncludedStudents.Remove(student);
            student.DeleteCourse(this);
        }

        public void AddTeacher(Teacher teacher)
        {
            IncludedTeachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            IncludedTeachers.Remove(teacher);
            teacher.DeleteCourse(this);
        }

        public List<Teacher> GetTeachers()
        {
            return IncludedTeachers;
        }

        public List<Student> GetStudents()
        {
            return IncludedStudents;
        }
        
    }
}
