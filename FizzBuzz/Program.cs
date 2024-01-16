// Normal version
Console.WriteLine("FizzBuzz -- Normal Version");
for (int i = 1; i <= 100; ++i)
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
for (int t = 1; t <= 100; ++t) Console.WriteLine(t % 5 == 0 && t % 3 == 0 ? "FizzBuzz" : t % 5 == 0 ? "Buzz" : t % 3 == 0 ? "Fizz" : t.ToString());
