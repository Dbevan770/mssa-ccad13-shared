namespace MortgageCalculator
{
    public class Buyer(string name, int age, double annualCombinedIncome)
    {
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
        public double AnnualCombinedIncome { get; set; } = annualCombinedIncome;
        public double MonthlyIncome { get; set; } = annualCombinedIncome / 12;
    }
}