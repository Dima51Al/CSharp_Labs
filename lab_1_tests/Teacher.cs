using Xunit;
using Lab1;

public class TeacherTests
{
    [Fact]
    public void Teacher_EnrollInCourse_Adds_Course()
    {
        var teacher = new Teacher("Сергей", "Сергеев", "Сергеевич", 101);
        var course = new Course("Алгебра", 3003);

        teacher.EnrollInCourse(course);

        Assert.Contains(3003, teacher.GetEnrolledCourses());
    }

    [Fact]
    public void Teacher_DropCourse_Removes_Course()
    {
        var teacher = new Teacher("Анна", "Иванова", "Петровна", 102);
        var course = new Course("Геометрия", 4004);

        teacher.EnrollInCourse(course);
        teacher.DropCourse(course);

        Assert.Empty(teacher.GetEnrolledCourses());
    }
}