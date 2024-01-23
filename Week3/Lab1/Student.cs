namespace Lab1;

public class Student(string name, int age, string socialSecurity, string address) : Person(name, age)
{
    // public string CourseScore { get; private set; } = course;
    // public string Grade { get; private set; } = grade;
    // public bool IsRegistered { get; private set; } = isRegistered;
    public string Address { get; set; } = address;
    public string StudentID { get; private set; } = CreateStudentID();
    public string SocialSecurity { private get; set; } = socialSecurity;


    private static string CreateStudentID()
    {
        Guid studemtId = Guid.NewGuid();
        return studemtId.ToString();
    }

    public string PrintStudent()
    {
        return $"{this.Name}\n" +
               $"{StudentID}\n" +
               $"{Address}\n";
    }
}