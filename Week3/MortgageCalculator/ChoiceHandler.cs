namespace MortgageCalculator
{
    public static class ChoiceHandler
    {
        public static int GetUserChoice(int choices)
        {
            int userChoice = -1;
            while (userChoice < 0 || userChoice > choices)
            {
                try
                {
                    userChoice = Validation.GetValidInt("Please enter your choice: ", 0, choices, "Invalid choice. Please try again.", "Invalid choice. Please try again.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                if (userChoice < 0 || userChoice > choices)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            return userChoice;
        }
    }
}