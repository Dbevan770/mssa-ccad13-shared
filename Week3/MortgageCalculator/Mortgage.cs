namespace MortgageCalculator
{
    public class Mortgage
    {
        // Instance of Calculator
        private readonly Calculator _calculator; // Uses Singleton Pattern to ensure only one instance of Calculator is created

        // Home
        public Home Home { get; } // Represents the home that the buyer is purchasing

        // Buyer
        public Buyer Buyer { get; } // Represents the buyer that is purchasing the home

        // Utility Values
        public LoanTerm LoanTerm { get; } // Represents the enum of the loan term, i.e. 30 year, 15 year, etc.

        // Qualifying Properties, this is booleans that represent whether or not the buyer qualifies for the loan
        public bool IsLoanInsuranceRequired { get; private set; } // Determines if the buyer needs to pay for loan insurance
        public bool RecommendApproval { get; private set; } // Determines if the buyer is recommended for approval


        // Full Term Costs, i.e. the origination fee, closing costs, etc.
        private readonly double _baseAmount; // This is the amount the house cost minus fees and taxes, i.e. $450,000
        public double OriginationFee { get; } // This is the base amount multiplied by the origination fee rate in this case 1% of $450,000 = $4,500
        public double DownPayment { get; set; } // The down payment made by the buyer, i.e. $50,000
        public double ClosingCosts { get; } = Constants.CLOSING_COSTS; // The closing costs, in this case it is a fixed amount of $2,500
        public double PrincipleLoanAmount { get; } // LoanAmount is the base amount minus the downpayment and adding the closing costs + origination fee, i.e. $450,000 - $50,000 + $2,500 + $4,500 = $407,000
        public double TotalInterest { get; private set; } // This is the total interest paid over the life of the loan, i.e. $407,000 * 3.5% * 30 years = $427,350
        public double InterestRate { get; private set; } // i.e. 3.5% -- Will also be based on length of loan term
        public double Equity { get; } // This is the market value of the home minus the loan amount, i.e. $500,000 - $407,000 = $93,000
        public double EquityPercentage { get; } // This is the equity divided by the market value, i.e. $93,000 / $500,000 = 18.6%
        public double LoanInsurance { get; private set; } // This is the loan insurance amount, i.e. $4,070
        public double Escrow { get; private set; } // This is the escrow amount, i.e. $5,000
        public double TotalCost { get; } // This is the total cost of the home, i.e. $407,000 + $427,350 + $4,070 + $5,000 = $843,420


        // Annual Costs, i.e. the annual interest rate, annual HOA fees, annual property tax, etc.
        public double HOAFeePerAnnum { get; set; } // Annual HOA fees, i.e. $1,000
        public double PropertyTaxPerAnnum { get; private set; } // Annual property tax, i.e. $5,000
        public double InterestPerAnnum { get; private set; } // Annual interest rate, i.e. $2,000


        // Monthly Values, i.e. the monthly interest rate, monthly HOA fees, monthly property tax, etc.
        public double MonthlyInterest { get; private set; } // Monthly interest rate, i.e. $166.67
        public double MonthlyHOAFees { get; private set; } // Monthly HOA fees, i.e. $83.33
        public double MonthlyEscrow { get; private set; } // Monthly escrow, i.e. $416.67
        public double MonthlyLoanInsurance { get; private set; } // Monthly loan insurance, i.e. $339.17 -- Only if loan insurance is required
        public double MonthlyPayment { get; private set; } // This is the monthly payment the buyer will have to pay, i.e. $2,000


        // Constructor
        public Mortgage(Home home, Buyer buyer, LoanTerm loanTerm, double downPayment)
        {
            // Store instance references to all objects
            _calculator = Calculator.Instance;
            Home = home;
            Buyer = buyer;

            // Calculate all values
            LoanTerm = loanTerm;
            _baseAmount = home.PurchasePrice;
            OriginationFee = Calculator.CalculateOriginationFee(_baseAmount, Constants.ORIGINATION_FEE_RATE);
            DownPayment = downPayment;
            PrincipleLoanAmount = Calculator.CalculateLoanPrinciple(_baseAmount, DownPayment, OriginationFee, ClosingCosts);
            InterestRate = LoanTerm.InterestRate;
            TotalInterest = Calculator.CalculateTotalInterest(PrincipleLoanAmount, InterestRate, LoanTerm.Years);
            Equity = Calculator.CalculateEquity(Home.MarketValue, PrincipleLoanAmount);
            EquityPercentage = Calculator.CalculateEquityPercentage(Home.MarketValue, Equity);

            // Determine if loan insurance is required and calculate loan insurance
            IsLoanInsuranceRequired = Calculator.DetermineLoanInsuranceRequirement(EquityPercentage, Constants.LOAN_INSURANCE_THRESHOLD);
            LoanInsurance = IsLoanInsuranceRequired ? Calculator.CalculateLoanInsurance(PrincipleLoanAmount, Constants.LOAN_INSURANCE_RATE) : 0;

            // Calculate additional values
            HOAFeePerAnnum = Home.AnnualHOAFees;
            PropertyTaxPerAnnum = Calculator.CalculatePropertyTaxPerAnnum(Home.MarketValue, Constants.PROPERTY_TAX_RATE);
            InterestPerAnnum = Calculator.CalculateHomeownersInsurancePerAnnum(Home.MarketValue, Constants.HOMEOWNERS_INSURANCE_RATE);
            Escrow = Calculator.CalculateEscrow(PropertyTaxPerAnnum, InterestPerAnnum);

            // Use all previous information plus Buyers monthly income to determine if the buyer is recommended for approval
            RecommendApproval = Calculator.DetermineApprovalRecommendation(Buyer.MonthlyIncome, MonthlyPayment, Constants.LOAN_APPROVAL_THRESHOLD);

            // Calculate monthly values
            MonthlyInterest = Calculator.ConvertToMonthlyRate(InterestRate);
            MonthlyHOAFees = Calculator.ConvertToMonthlyRate(HOAFeePerAnnum);
            MonthlyEscrow = Calculator.ConvertToMonthlyRate(Escrow);
            MonthlyLoanInsurance = IsLoanInsuranceRequired ? Calculator.ConvertToMonthlyRate(LoanInsurance) : 0;

            // Calculate the monthly payment
            MonthlyPayment = Calculator.CalculateMonthlyPayment(PrincipleLoanAmount, MonthlyInterest, Constants.MONTHS_IN_YEAR, LoanTerm.Years, MonthlyHOAFees, MonthlyEscrow, MonthlyLoanInsurance);

            // Calculate the total cost of the home
            TotalCost = Calculator.CalculateTotalCost(MonthlyPayment, Constants.MONTHS_IN_YEAR, LoanTerm.Years);
        }

        // Methods
        public void ModifyDownPayment(double downPayment)
        {
            DownPayment = downPayment;
        }
    }
}