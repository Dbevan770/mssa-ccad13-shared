namespace MortgageCalculator
{
    public sealed class Calculator
    {
        Calculator() { }
        private static readonly object lockObject = new();
        private static Calculator? _instance = null;
        public static Calculator Instance
        {
            get
            {
                lock (lockObject)
                {
                    _instance ??= new Calculator();
                    return _instance;
                }
            }
        }

        public static double CalculateLoanPrinciple(double purchasePrice, double downPayment, double originationFee, double closingCosts)
        {
            return purchasePrice - downPayment + originationFee + closingCosts;
        }

        public static double CalculateTotalInterest(double loanPrinciple, double annualInterestRate, int loanTerm)
        {
            return loanPrinciple * annualInterestRate * loanTerm;
        }

        public static double CalculateEquity(double marketValue, double loanPrinciple)
        {
            return marketValue - loanPrinciple;
        }

        public static double CalculateEquityPercentage(double marketValue, double equity)
        {
            return equity / marketValue;
        }

        public static bool DetermineLoanInsuranceRequirement(double equityPercentage, double loanInsuranceThreshold = Constants.LOAN_INSURANCE_THRESHOLD)
        {
            return equityPercentage < loanInsuranceThreshold;
        }

        public static double CalculateLoanInsurance(double loanPrinciple, double loanInsuranceRate = Constants.LOAN_INSURANCE_RATE)
        {
            return loanPrinciple * loanInsuranceRate;
        }

        public static double CalculatePropertyTaxPerAnnum(double marketValue, double propertyTaxRate = Constants.PROPERTY_TAX_RATE)
        {
            return marketValue * propertyTaxRate;
        }

        public static double CalculateHomeownersInsurancePerAnnum(double marketValue, double homeownersInsuranceRate = Constants.HOMEOWNERS_INSURANCE_RATE)
        {
            return marketValue * homeownersInsuranceRate;
        }

        public static double CalculateEscrow(double propertyTaxPerAnnum, double homeownersInsurancePerAnnum)
        {
            return propertyTaxPerAnnum + homeownersInsurancePerAnnum;
        }

        public static bool DetermineApprovalRecommendation(double monthlyIncome, double monthlyPayment, double loanApprovalThreshold = Constants.LOAN_APPROVAL_THRESHOLD)
        {
            return monthlyPayment / monthlyIncome < loanApprovalThreshold;
        }

        public static double CalculateOriginationFee(double baseAmount, double originationFeeRate = 0.0)
        {
            return baseAmount * originationFeeRate;
        }

        public static double ConvertToMonthlyRate(double value, int months = Constants.MONTHS_IN_YEAR)
        {
            return value / months;
        }

        public static string GetDenialMessage()
        {
            string[] denialMessages = Constants.DENIAL_MESSAGES;
            Random rnd = new();
            int index = rnd.Next(0, denialMessages.Length);
            return denialMessages[index];
        }

        public static double CalculateMonthlyPayment(double loanPrinciple, double monthlyInterestRate, int paymentsPerYear, int loanTerm, double monthlyHOAFees, double monthlyEscrow, double monthlyLoanInsurance)
        {
            double basePayment = loanPrinciple * monthlyInterestRate * (Math.Pow(1 + monthlyInterestRate, paymentsPerYear * loanTerm) / (Math.Pow(1 + monthlyInterestRate, paymentsPerYear * loanTerm) - 1));
            return basePayment + monthlyHOAFees + monthlyEscrow + monthlyLoanInsurance;
        }

        public static double CalculateTotalCost(double monthlyPayment, int paymentsPerYear, int loanTerm)
        {
            return monthlyPayment * paymentsPerYear * loanTerm;
        }
    }
}