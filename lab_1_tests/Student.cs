using Xunit;
using Lab1;

public class StudentTests
{
    [Fact]
    public void EnrollInCourse_Adds_Course_To_Student()
    {
        var student = new Student("Алексей", "Петров", "Иванович", 10);
        var course = new Course("Математика", 1001);

        student.EnrollInCourse(course);

        Assert.Contains(1001, student.GetEnrolledCourses());
    }

    [Fact]
    public void DropCourse_Removes_Course_From_Student()
    {
        var student = new Student("Мария", "Сидорова", "Петровна", 20);
        var course = new Course("Физика", 2002);

        student.EnrollInCourse(course);
        student.DropCourse(course);

        Assert.DoesNotContain(2002, student.GetEnrolledCourses());
    }

    [Fact]
    public void Student_ID_Is_Set_Correctly()
    {
        var student = new Student("Кто-то", "Кто-тов", "Кто-тович", 999);
        Assert.Equal(999, student.ID);
    }
}