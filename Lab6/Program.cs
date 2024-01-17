struct CourseStruct
{
    public string title;
    public string creditHours;
    public string program;
    public string instructor;

    public CourseStruct(string title, string creditHours, string instructor, string program)
    {
        this.title = title;
        this.creditHours = creditHours;
        this.instructor = instructor;
        this.program = program;
    }
}
class Program
{



    public static void Main(string[] args)
    {
        CourseStruct c1 = new CourseStruct("CS101", "6", "Mr. Smith", "Computer Science");
        CourseStruct c2 = new CourseStruct("CS201", "6", "Mrs. Jones", "Computer Science");

        Console.WriteLine($"Course 1: {c1.title} {c1.creditHours} {c1.instructor} {c1.program}");
        Console.WriteLine($"Course 2: {c2.title} {c2.creditHours} {c2.instructor} {c2.program}");

        CourseDerived abstractCourse = new CourseDerived("CS101", "6", "Mr. Smith", "Computer Science");
        abstractCourse.Display();
        CourseDerived abstractCourse2 = new CourseDerived("CS201", "6", "Mrs. Jones", "Computer Science");
        abstractCourse.Display();
    }

}