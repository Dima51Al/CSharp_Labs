namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Student student1 = new Student("Иван", "Иванов", "Иванович", 1);
            Student student2 = new Student("Петр", "Петров", "Петрович", 2);

            Teacher teacher = new Teacher("Сергей", "Сергеев", "Сергеевич", 101);

            Course course = new Course("Математика", 1001);

            Course course2 = new Course("Математика", 2003);

            student1.EnrollInCourse(course);

            student2.EnrollInCourse(course2);
            teacher.EnrollInCourse(course);

            foreach (var item in teacher.GetEnrolledCourses())
            {
                Console.WriteLine(teacher.GetName());
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var item in student1.GetEnrolledCourses())
            {
                Console.WriteLine(student1.GetName());
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var item in student2.GetEnrolledCourses())
            {
                Console.WriteLine(student2.GetName());
                Console.WriteLine(item);
                Console.WriteLine();
            }

            
        }
    }
}