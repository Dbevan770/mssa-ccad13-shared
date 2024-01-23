namespace MortgageCalculator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Dialogue.Welcome();
            MainMenu();
        }

        public static void MainMenu()
        {
            int choice = -1;
            do
            {
                Dialogue.MainMenu();
                choice = Validation.GetValidInt("Please enter your choice: ", 1, 3, "Invalid choice. Please try again.", "Invalid choice. Please try again.");
                switch (choice)
                {
                    case 1:
                        // Will come back to this if I have time
                        // Dialogue.CreateOrLoadProfile();
                        MortgageTool();
                        break;
                    case 2:
                        Dialogue.ShowLoanTerms();
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 3);
        }

        public static void MortgageTool()
        {
            Dialogue.GetBuyerName();
            string name = Validation.GetValidString("Please enter your name: ", Constants.MIN_NAME_LENGTH, Constants.MAX_NAME_LENGTH, "Your name must be atleast 2 characters long.", "Your name cannot be longer than 50 characters.");
            Dialogue.GetBuyerAge();
            int age = Validation.GetValidInt("Please enter your age: ", Constants.MIN_AGE, Constants.MAX_AGE, "You must be atleast 18 years old to buy a house.", "There is no way you are older than 120 years old.");
            Dialogue.GetBuyerCombinedIncome();
            double annualCombinedIncome = Validation.GetValidDouble("Please enter your annual combined income: ", Constants.MIN_MONTHLY_INCOME, Constants.MAX_MONTHLY_INCOME, "You must make atleast $0.01 per year to buy a house.", "You cannot make more than $1,000,000,000.00 per year.");
            Buyer buyer = new(name, age, annualCombinedIncome);
            Dialogue.GetPurchasePrice();
            double homeCost = Validation.GetValidDouble("Please enter the cost of the home: ", Constants.MIN_HOME_COST, Constants.MAX_HOME_COST, "The home must cost atleast $0.01.", "The home cannot cost more than $10,000,000.00.");
            Dialogue.GetMarketValue();
            double marketValue = Validation.GetValidDouble("Please enter the market value of the home: ", Constants.MIN_HOME_COST, Constants.MAX_HOME_COST, "The market value of the home must be atleast $0.01.", "The market value of the home cannot be more than $10,000,000.00.");
            Dialogue.GetAnnualHOAFees();
            double annualHoaFees = Validation.GetValidDouble("Please enter the annual HOA fees: ", 0, homeCost, "The annual HOA fees cannot be less than $0.00.", "The annual HOA fees cannot be more than the cost of the home.");
            Home home = new(marketValue, homeCost, homeCost, annualHoaFees);
            Dialogue.GetDownPayment();
            double downPayment = Validation.GetValidDouble("Please enter your down payment: ", 0, homeCost, "Your down payment cannot be less than $0.00.", "Your down payment cannot be more than the cost of the home.");
            Dialogue.GetTermLength();
            Dialogue.ChooseTermLength();
            LoanTerm term = GetTermChoice();
            double originationFee = Calculator.CalculateOriginationFee(home.PurchasePrice);
            double closingCosts = Constants.CLOSING_COSTS;
            double principle = Calculator.CalculateLoanPrinciple(home.PurchasePrice, downPayment, originationFee, closingCosts);
            double totalInterest = Calculator.CalculateTotalInterest(principle, term.InterestRate, term.Years);
            double interestPerAnnum = totalInterest / term.Years;
            double monthlyInterestPayment = Calculator.ConvertToMonthlyRate(interestPerAnnum);
            double monthlyInterestRate = Calculator.ConvertToMonthlyRate(term.InterestRate);
            int payments = Constants.MONTHS_IN_YEAR;
            double monthlyHOAFees = Calculator.ConvertToMonthlyRate(home.AnnualHOAFees);
            double monthlyEscrow = Calculator.ConvertToMonthlyRate(Calculator.CalculateEscrow(Calculator.CalculatePropertyTaxPerAnnum(home.MarketValue), Calculator.CalculateHomeownersInsurancePerAnnum(home.MarketValue)));
            double equity = Calculator.CalculateEquity(home.MarketValue, principle);
            double equityPercentage = Calculator.CalculateEquityPercentage(home.MarketValue, equity);
            bool isLoanInsuranceRequired = Calculator.DetermineLoanInsuranceRequirement(equityPercentage);
            double monthlyLoanInsurance = 0;
            if (isLoanInsuranceRequired)
            {
                monthlyLoanInsurance = Calculator.CalculateLoanInsurance(principle);
                Dialogue.LoanInsuranceRequired(monthlyLoanInsurance, equityPercentage, equity);
                Console.Write("Press any key to continue: ");
                Console.ReadKey();
            }
            else
            {
                Dialogue.LoanInsuranceNotRequired(equityPercentage, equity);
                Console.Write("Press any key to continue: ");
                Console.ReadKey();
            }
            double monthlyPayment = Calculator.CalculateMonthlyPayment(principle, monthlyInterestRate, payments, term.Years, monthlyHOAFees, monthlyEscrow, monthlyLoanInsurance);
            Dialogue.ApprovalCheck();
            bool IsApproved = Calculator.DetermineApprovalRecommendation(buyer.MonthlyIncome, monthlyPayment);
            if (!IsApproved)
            {
                Dialogue.NotApproved(buyer.MonthlyIncome, monthlyPayment, Constants.LOAN_APPROVAL_THRESHOLD);
                Console.Write("Press any key to return to the main menu: ");
                Console.ReadKey();
                return;
            }
            Dialogue.Approved(buyer.MonthlyIncome, monthlyPayment, Constants.LOAN_APPROVAL_THRESHOLD);
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            Dialogue.MortgageDetails();
            Mortgage mortgage = new(home, buyer, term, downPayment);
            Dialogue.DisplayMortgageDetails(mortgage);
            Console.Write("When you are ready to continue, press any key: ");
            Console.ReadKey();
            Dialogue.CalculateMortgageStepFinal();
            Console.Write("Congrats again on your new home! Press any key to return to the main menu: ");
            Console.ReadKey();
            return;
        }


        private static LoanTerm GetTermChoice()
        {
            int choice = -1;
            do
            {
                choice = Validation.GetValidInt("Please enter your choice: ", 1, 2, "Invalid choice. Please try again.", "Invalid choice. Please try again.");
                switch (choice)
                {
                    case 1:
                        return LoanTerm.FifteenYear;
                    case 2:
                        return LoanTerm.ThirtyYear;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 2);
            return LoanTerm.ThirtyYear;
        }
    }
}