public abstract class CourseBase
{
    // Private properties
    protected string? _title;
    protected int _creditHours;
    protected string? _program;
    protected string? _instructor;

    // Getters and Setters
    public abstract string Title { get; set; }
    public abstract string CreditHours { get; set; }
    public abstract string Program { get; set; }
    public abstract string Instructor { get; set; }

    // Methods

    public abstract void Display();
}