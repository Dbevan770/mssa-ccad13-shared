namespace MortgageCalculator
{
    public class LoanTerm(int years, double interestRate)
    {
        public int Years { get; private set; } = years;
        public double InterestRate { get; private set; } = interestRate;

        public static readonly LoanTerm FifteenYear = new(15, 0.035); // Default FifteenYear LoanTerm with the current average 6.41% fixed interest rate
        public static readonly LoanTerm ThirtyYear = new(30, 0.035); // Default ThirtyYear LoanTerm with the current average 7.1% fixed interest rate
    }
}