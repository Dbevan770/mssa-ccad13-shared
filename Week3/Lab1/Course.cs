namespace Lab1
{
    public class Course(Enums.CourseNames name, Dictionary<string, Student> students)
    {
        public Enums.CourseNames Name { get; } = name;
        private Dictionary<string, Student> _students = students;

        public void PrintStudents()
        {
            foreach (var key in _students.Keys)
            {
                var student = _students[key];
                Console.WriteLine($"Student ID: {key}");
                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Student Age: {student.Age}");
                // Other student properties
            }
        }

        public void AddStudent(string studentId, Student student)
        {
            _students.Add(studentId, student);
        }

        public void RemoveStudent(string studentId)
        {
            _students.Remove(studentId);
        }
    }
}