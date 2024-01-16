using System;
Console.WriteLine("04 -> Algorithms and Data Structures");

// #TODO: Task 1.2 Create an array here called gradesArray
float[] gradesArray = new float[5];


// #TODO: Task 1.3 Call the addGrades method, passing it the gradesArray
addGrades(gradesArray);

// #TODO: Task 1.4 After adding grades to the array, call the displayGrades method
// to print out the grades to the console window
// Use the foreach construct to iterate over the array
displayGrades(gradesArray);

// #TODO: Task 2.1 Create a new Stack object called myStack
Stack<float> myStack = new Stack<float>();


// #TODO: Task 2.2 Call the pushStack() method passing in the grades array for values
pushStack(gradesArray, myStack);

// #TODO: Task 2.3 Call the peekStack() method passing in the grades array for values
peekStack(myStack);

// #TODO: Task 2.4 Call the popStack() method twice to remove the top two items from stack
// The popStack method will display each popped item to the console window
popStack(myStack);
popStack(myStack);

// #TODO: Task 3.1 Create a new SortedList object called myCourses
SortedList<string, string> myCourses = new SortedList<string, string>();



// #TODO: Task 3.2 Call the populateList() method
populateList(myCourses);



// #TODO: Task 3.4 Remove an item from the myCourses list using the key
removeListItem(myCourses, "CS102");


static void addGrades(float[] grdArray)
{
    Random rnd = new Random();
    for(int i = 0; i < grdArray.Length; i++)
    {
        int random = rnd.Next(0, 100);
        float.TryParse(random.ToString(), out float result);
        grdArray[i] = result;
    }
}

static void displayGrades(float[] grdArray)
{
    Console.WriteLine("Grades: ");
    foreach (float grade in grdArray)
    {
        Console.WriteLine(grade);
    }
}


static void pushStack(float[] grdArray, Stack<float> stack)
{
    foreach (float grade in grdArray)
    {
        stack.Push(grade);
    }
}

static void popStack(Stack<float> stack)
{
    Console.WriteLine("Item removed from the stack: ");
    Console.WriteLine(stack.Pop());
}

static void peekStack(Stack<float> stack)
{
    Console.WriteLine("Item at the top of the stack: ");
    Console.WriteLine(stack.Peek());
}

static void populateList(SortedList<string, string> list)
{
    Console.WriteLine("Populating List with data...");
    list.Add("CS101", "Introduction to Computer Science");
    list.Add("CS102", "Data Structures and Algorithms");
    list.Add("CS201", "Introduction to Databases");
    list.Add("CS301", "Introduction to Object-Oriented Programming");
    displayList(list);
}

static void displayList(SortedList<string, string> list)
{
    Console.WriteLine("Displaying myCourses list: ");
    foreach (KeyValuePair<string, string> entry in list)
    {
        Console.WriteLine(entry);
    }
}

static void removeListItem(SortedList<string, string> list, string filter)
{
    Console.WriteLine($"Removing {filter} from list.");
    list.Remove(filter);
    Console.WriteLine("Item removed from list.");
    displayList(list);
}
