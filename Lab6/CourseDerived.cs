using System;

public class CourseDerived : CourseBase
{
    // Private properties
    protected new string _title;
    protected new string _creditHours;
    protected new string _program;
    protected new string _instructor;

    // Getters and Setters
    public override string Title { get => _title; set => _title = value; }
    public override string CreditHours { get => _creditHours; set => _creditHours = value; }
    public override string Program { get => _program; set => _program = value; }
    public override string Instructor { get => _instructor; set => _instructor = value; }

    // Constructors
    public CourseDerived(string title, string creditHours, string instructor, string program)
    {
        _title = title;
        _creditHours = creditHours;
        _instructor = instructor;
        _program = program;
    }

    // Methods
    public override void Display()
    {
        Console.WriteLine($"Derived Course: {Title} {CreditHours} {Instructor} {Program}");
    }
}