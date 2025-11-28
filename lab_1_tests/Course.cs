using Xunit;
using Lab1;

public class CourseTests
{
    [Fact]
    public void Course_Constructor_Sets_Name_And_Id()
    {
        var course = new Course("История", 5555);

        Assert.Equal("История", course.Name);
        Assert.Equal(5555, course.CourseId);
        Assert.True(course.IsActive);
    }

    [Fact]
    public void Remove_Deactivates_Course_And_Student_Loses_It()
    {
        var course = new Course("Биология", 6666);
        var student = new Student("Пётр", "Петров", "Петрович", 1);
        var teacher = new Teacher("Ольга", "Ольгова", "Ольговна", 100);

        student.EnrollInCourse(course);
        teacher.EnrollInCourse(course);

        course.Remove();

        Assert.False(course.IsActive);
        Assert.DoesNotContain(6666, student.GetEnrolledCourses());
        Assert.DoesNotContain(6666, teacher.GetEnrolledCourses());
    }

    [Fact]
    public void GetTeachers()
    {
        var course = new Course("ОШИБКА", 777);
        var teacher = new Teacher("Препод", "Тестов", "Тестович", 200);
        teacher.EnrollInCourse(course);

        var result = course.GetTeachers();
        Assert.Single(result); 
    }
}