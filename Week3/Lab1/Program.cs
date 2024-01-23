namespace Lab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = [];

            for (int i = 0; i < 2; i++)
            {
                Student student = CreateStudent();
                students.Add(student);
            }


            foreach (Student student in students)
            {
                Console.WriteLine(student.PrintStudent());
            }
        }

        public static string GetValidString(string prompt)
        {
            string? input = null;
            do
            {
                Console.Write(prompt);
                input = $"{Console.ReadLine()}";
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public static string GetValidString(string prompt, int minLength, int maxLength)
        {
            string input = GetValidString(prompt);
            while (input.Length < minLength && input.Length > maxLength)
            {
                input = $"{Console.ReadLine()}";
            }

            return input;
        }

        public static int GetValidInt(string prompt, int min, int max)
        {
            bool IsValid = false;
            int result = 0;
            while (!IsValid)
            {
                string input = GetValidString(prompt);

                if (int.TryParse(input, out result))
                {
                    if (result >= min && result <= max)
                    {
                        IsValid = true;
                    }
                }
            }

            return result;
        }

        public static Student CreateStudent()
        {
            // Construct student object with empty values
            // Name, Age, Social Security, Address
            Student student = new("", 0, "", "");
            foreach (var prop in typeof(Student).GetProperties())
            {
                if (prop.Name == "StudentID")
                {
                    continue;
                }

                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(student, GetValidString($"Enter {prop.Name}: ", Constants.MIN_LENGTH, Constants.MAX_LENGTH));
                }

                if (prop.PropertyType == typeof(int))
                {
                    prop.SetValue(student, GetValidInt($"Enter {prop.Name}: ", Constants.MIN_AGE, Constants.MAX_AGE));
                }
            }

            return student;
        }
    }
}
