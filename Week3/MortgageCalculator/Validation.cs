namespace MortgageCalculator
{
    public class Validation
    {
        public static string GetValidString(string prompt, string invalidInputException = "Input is not valid")
        {
            string? result = null;
            while (string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    Console.Write(prompt);
                    result = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        throw new Exception(invalidInputException);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static string GetValidString(string prompt, int minLength, int maxLength, string tooShortException = "Input is too short", string tooLongException = "Input is too long")
        {
            string input = GetValidString(prompt);
            while (input.Length < minLength || input.Length > maxLength)
            {
                try
                {
                    if (input.Length < minLength)
                    {
                        throw new Exception(tooShortException);
                    }
                    else if (input.Length > maxLength)
                    {
                        throw new Exception(tooLongException);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                input = GetValidString(prompt);
            }
            return input;
        }

        public static int GetValidInt(string prompt, int min, int max, string tooLowException = "Input is below min value", string tooHighException = $"Input is higher than maximum allowed value", string invalidInputException = "Input is not a valid integer")
        {
            bool IsValid = false;
            int result = 0;
            while (!IsValid)
            {
                try
                {
                    string input = GetValidString(prompt);

                    if (int.TryParse(input, out result))
                    {
                        if (result >= min && result <= max)
                        {
                            IsValid = true;
                        }
                        else if (result < min)
                        {
                            throw new Exception(tooLowException);
                        }
                        else if (result > max)
                        {
                            throw new Exception(tooHighException);
                        }
                    }
                    else
                    {
                        throw new Exception(invalidInputException);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

        public static double GetValidDouble(string prompt, double min, double max, string tooLowException = "Input is below min value", string tooHighException = "Input is higher than maximum allowed value", string invalidInputException = "Input is not a valid double")
        {
            bool IsValid = false;
            double result = 0;
            while (!IsValid)
            {
                try
                {
                    string input = GetValidString(prompt);

                    if (double.TryParse(input, out result))
                    {
                        if (result >= min && result <= max)
                        {
                            IsValid = true;
                        }
                        else if (result < min)
                        {
                            throw new Exception(tooLowException);
                        }
                        else if (result > max)
                        {
                            throw new Exception(tooHighException);
                        }
                    }
                    else
                    {
                        throw new Exception(invalidInputException);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }
    }
}