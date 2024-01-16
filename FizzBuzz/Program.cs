const int STARTING_NUMBER = 1;
bool validInput = false;
string input = string.Empty;
int validatedInput = 0;

while (!validInput)
{
    input = GetUserInput("How many numbers would you like to FizzBuzz today?: ");
    validatedInput = ValidateUserInput(input) ? int.Parse(input) : -1;

    if (validatedInput == -1)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    else if (validatedInput <= STARTING_NUMBER)
    {
        Console.WriteLine($"Invalid input. Please enter a number greater than {STARTING_NUMBER}.");
    }
    else
    {
        validInput = true;
    }
}

// Normal version
Console.WriteLine("FizzBuzz -- Normal Version");
for (int i = STARTING_NUMBER; i <= validatedInput; ++i)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

// Ternary version
Console.WriteLine("FizzBuzz -- Ternary Version");
for (int t = STARTING_NUMBER; t <= validatedInput; ++t) Console.WriteLine(t % 5 == 0 && t % 3 == 0 ? "FizzBuzz" : t % 5 == 0 ? "Buzz" : t % 3 == 0 ? "Fizz" : t.ToString());

string GetUserInput(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}

bool ValidateUserInput(string input)
{
    return int.TryParse(input, out int _);
}
