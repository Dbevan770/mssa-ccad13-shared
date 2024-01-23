namespace MortgageCalculator
{
    public class Constants
    {
        public static readonly string[] DENIAL_MESSAGES = [
            "You are too young to buy a house.",
            "You do not make enough money to buy a house.",
            "You do not have enough money saved to buy a house.",
            "You cannot afford this house.",
            "Pull yourself up by your bootstraps and try again."
        ];

        public const double LOAN_INSURANCE_RATE = 0.01;
        public const double CLOSING_COSTS = 2500.00;
        public const double ORIGINATION_FEE_RATE = 0.01;
        public const double LOAN_INSURANCE_THRESHOLD = 0.1;
        public const double PROPERTY_TAX_RATE = 0.0125;
        public const double HOMEOWNERS_INSURANCE_RATE = 0.0075;
        public const double LOAN_APPROVAL_THRESHOLD = 0.25;
        public const double MIN_MONTHLY_INCOME = 0.01;
        public const double MAX_MONTHLY_INCOME = 1000000000.00;
        public const double MIN_HOME_COST = 0.01;
        public const double MAX_HOME_COST = 10000000.00;

        public const int MONTHS_IN_YEAR = 12;
        public const int MIN_NAME_LENGTH = 2;
        public const int MAX_NAME_LENGTH = 50;
        public const int MIN_AGE = 18;
        public const int MAX_AGE = 120;
    }
}