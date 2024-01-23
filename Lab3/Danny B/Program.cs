namespace Lab3
{
    public class Course
    {
        // Private properties
        private string _title;
        private string _instructorName;
        private bool _isRequired;
        private bool _inProgram;
        private bool _isElective;
        Dictionary<string, string> _reminders = new();

        // Getters and Setters
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string InstructorName
        {
            get { return _instructorName; }
            set { _instructorName = value; }
        }

        public bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }

        public bool InProgram
        {
            get { return _inProgram; }
            set { _inProgram = value; }
        }

        public bool IsElective
        {
            get { return _isElective; }
            set { _isElective = value; }
        }

        public Dictionary<string, string> Reminders
        {
            get { return _reminders; }
            set { _reminders = value; }
        }

        public Course()
        {
            this._title = "";
            this._instructorName = "";
            this._isRequired = false;
            this._inProgram = false;
            this._isElective = false;

            this._reminders.Add("Monday", "You have class today");
            this._reminders.Add("Tuesday", "You have underwater basket weaving today");
            this._reminders.Add("Wednesday", "You have golf today");
            this._reminders.Add("Thursday", "You have class today");
            this._reminders.Add("Friday", "You have class today");
            this._reminders.Add("Saturday", "You have a party today");
            this._reminders.Add("Sunday", "You have nothing today");
        }

        public bool ValidateCourseTitle(string title)
        {
            return title.Length > 0;
        }
    }

    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Course myCourse = new();

            SetInstructorName(myCourse, "Danny Bevan");
            SetCourseTitle(myCourse, "C# Programming");
            SetCourseProgram(myCourse, true);
            SetCourseRequired(myCourse, true);
            SetCourseElectiveState(myCourse, false);

            Console.WriteLine(myCourse.IsRequired ? "Course is required" : "Course is not required");

            Console.WriteLine(myCourse.IsElective ? "Course is elective" : "Course is not elective");

            Console.WriteLine(myCourse.InProgram ? "Course is in program" : "Course is not in program");

            string currentDay = DateTime.Now.DayOfWeek.ToString();

            Console.WriteLine("Today is " + currentDay);
            Console.WriteLine("Reminder: " + GetReminderMessage(myCourse, (DayOfWeek)Enum.Parse(typeof(DayOfWeek), currentDay)));

            string userInput = "";
            double[] grades = Array.Empty<double>();

            while (!Equals(userInput.ToLower(), "q"))
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                userInput = Console.ReadLine()!;
                if (Equals(userInput.ToLower(), "q")) break;

                try
                {
                    double grade = double.Parse(userInput);
                    if (grade < 0 || grade > 100) throw new Exception("Grade must be between 0 and 100");
                    Array.Resize(ref grades, grades.Length + 1);
                    grades[^1] = grade;
                    Console.WriteLine("Average grade is: " + CalculateAverageGrade(grades));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        private static void SetInstructorName(Course course, string name)
        {
            Console.WriteLine("Instructor name is: " + name);
            course.InstructorName = name;
        }

        private static void SetCourseTitle(Course course, string title)
        {
            if (course.ValidateCourseTitle(title))
            {
                Console.WriteLine("Course title is: " + title);
                course.Title = title;
            }
            else
            {
                Console.WriteLine("Invalid course title");
            }
        }

        private static void SetCourseProgram(Course course, bool inProgram)
        {
            Console.WriteLine("Course is in program: " + inProgram);
            course.InProgram = inProgram;
        }

        private static void SetCourseRequired(Course course, bool isRequired)
        {
            Console.WriteLine("Course is required: " + isRequired);
            course.IsRequired = isRequired;
        }

        private static void SetCourseElectiveState(Course course, bool isElective)
        {
            Console.WriteLine("Course is elective: " + isElective);
            course.IsElective = isElective;
        }

        private static string GetReminderMessage(Course course, DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return course.Reminders["Monday"];
                    }
                case DayOfWeek.Tuesday:
                    {
                        return course.Reminders["Tuesday"];
                    }
                case DayOfWeek.Wednesday:
                    {
                        return course.Reminders["Wednesday"];
                    }
                case DayOfWeek.Thursday:
                    {
                        return course.Reminders["Thursday"];
                    }
                case DayOfWeek.Friday:
                    {
                        return course.Reminders["Friday"];
                    }
                case DayOfWeek.Saturday:
                    {
                        return course.Reminders["Saturday"];
                    }
                case DayOfWeek.Sunday:
                    {
                        return course.Reminders["Sunday"];
                    }
                default:
                    {
                        return "Invalid day of week";
                    }
            }
        }

        private static double CalculateAverageGrade(double[] grades)
        {
            double total = 0;
            foreach (double grade in grades)
            {
                total += grade;
            }
            return Math.Round(total / grades.Length, 2);
        }
    }
}
