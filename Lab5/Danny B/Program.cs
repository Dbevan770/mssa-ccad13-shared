namespace _05_DebuggingAndExceptionHandling
{
    public class Program
    {
        struct course
        {
            public string courseName;
            public int creditHours;
            public int gradePoints;
        };

        public static async Task Main(string[] args)
        {
            Console.WriteLine("05 -> Debugging And Exception Handling");

            course[] courseList = PopulateTranscript();
            double GPA = GetGPA(courseList);
            Console.WriteLine("Your GPA is currently: " + GPA);
        }

        private static course[] PopulateTranscript()
        {
            course[] courseList = new course[5];

            for (int counter = 0; counter < courseList.Length; counter++)
            {
                course newCourse = new course();
                Console.WriteLine("Enter a course name");
                newCourse.courseName = Console.ReadLine();

                Console.WriteLine("Enter the credit hours for this course");

                try
                {
                    if (int.TryParse(Console.ReadLine(), out int credits))
                    {
                        newCourse.creditHours = credits;
                    }
                    else
                    {
                        throw new Exception("Invalid input, please enter a number");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



                // var success = int.TryParse(Console.ReadLine(), out int credits);
                // if (success)
                // {
                //     newCourse.creditHours = credits;
                // }

                // Console.WriteLine("Enter your grade points for this course");
                // success = int.TryParse(Console.ReadLine(), out int points);
                // if (success)
                // {
                //     newCourse.gradePoints = points;
                // }
                // courseList[counter] = newCourse;
            }

            return courseList;
        }

        private static double GetGPA(course[] courseList)
        {
            double result = 0.0;
            int totalCredHours = 0;
            int totalGradePoints = 0;

            foreach (course currentCourse in courseList)
            {
                totalCredHours += currentCourse.creditHours;
                totalGradePoints += currentCourse.gradePoints;
            }

            result = totalGradePoints / totalCredHours;

            return result;
        }
    }
}
