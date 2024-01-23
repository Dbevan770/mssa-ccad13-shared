using System.IO.Compression;

namespace MortgageCalculator
{
    public static class Dialogue
    {
        // Define app properties
        private static readonly int _appWidth = 80;
        private static readonly int _horizontalPadding = 2;
        private static readonly int _verticalPadding = 2;
        private static readonly Printer _printer = new(_appWidth, _horizontalPadding, _verticalPadding);

        // Define the safe area of the app where text can be displayed within the boundaries

        private static string CreateHeader(string header)
        {
            header = $"//[-- {header} --]\\\\";

            return header;
        }

        public static void Welcome()
        {
            _printer.Print(["Welcome to the Mortgage Calculator!", "Created by: Danny B."], Justify.Center, Align.Middle, ' ', '#');
        }

        public static void MainMenu()
        {
            string title = CreateHeader("MAIN MENU");
            string[] menuOptions = [
                "[1]. Calculate Mortgage",
                "[2]. View Loan Terms",
                "[3]. Exit"
            ];
            _printer.Print(menuOptions, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void ShowLoanTerms()
        {
            string title = CreateHeader("LOAN TERMS");
            string[] terms = [
                "15 YEAR FIXED",
                $"Interest Rate: {LoanTerm.FifteenYear.InterestRate * 100:0.00}%",
                $"Years: {LoanTerm.FifteenYear.Years}",
                "",
                "30 YEAR FIXED",
                $"Interest Rate: {LoanTerm.ThirtyYear.InterestRate * 100:0.00}%",
                $"Years: {LoanTerm.ThirtyYear.Years}",
            ];
            _printer.Print(terms, Justify.Center, Align.Middle, ' ', ' ', title);
        }

        public static void CreateOrLoadProfile()
        {
            string title = CreateHeader("CREATE OR LOAD PROFILE");
            string[] options = [
                "[1]. Create Profile",
                "[2]. Load Profile",
                "[3]. Return to Main Menu",
                "[4]. Exit",
            ];
            _printer.Print(options, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetBuyerName()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[ ] Enter Personal Information",
                "|-- [ ] Name",
                "|-- [ ] Age",
                "|-- [ ] Annual Combined Income",
                "[ ] Enter Home Information",
                "|-- [ ] Purchase Price",
                "|-- [ ] Market Value",
                "|-- [ ] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetBuyerAge()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[ ] Enter Personal Information",
                "|-- [X] Name",
                "|-- [ ] Age",
                "|-- [ ] Annual Combined Income",
                "[ ] Enter Home Information",
                "|-- [ ] Purchase Price",
                "|-- [ ] Market Value",
                "|-- [ ] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetBuyerCombinedIncome()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[ ] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [ ] Annual Combined Income",
                "[ ] Enter Home Information",
                "|-- [ ] Purchase Price",
                "|-- [ ] Market Value",
                "|-- [ ] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetPurchasePrice()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[ ] Enter Home Information",
                "|-- [ ] Purchase Price",
                "|-- [ ] Market Value",
                "|-- [ ] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetMarketValue()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[ ] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [ ] Market Value",
                "|-- [ ] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete",
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetAnnualHOAFees()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[ ] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [ ] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void ChooseTermLength()
        {
            string title = CreateHeader("CHOOSE TERM LENGTH");
            string[] options = [
                "[1]. 15 Year Fixed",
                "[2]. 30 Year Fixed",
                "[3]. Return to Main Menu",
                "[4]. Exit",
            ];
            _printer.Print(options, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void CalculateMortgageStepSeven()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[X] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [X] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetDownPayment()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[X] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [X] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [ ] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void GetTermLength()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[X] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [X] Annual HOA Fees",
                "[ ] Additional Mortgage Details",
                "|-- [X] Enter Down Payment",
                "|-- [ ] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void LoanInsuranceRequired(double loanInsuranceCost, double equityPercentage, double equity)
        {
            string title = CreateHeader("LOAN INSURANCE REQUIRED");
            string[] msg = [
                "You do not meet the minimum equity threshold and will need to pay for loan insurance.",
                $"Loan Insurance Cost: {loanInsuranceCost}",
                $"Your Equity: {equity}",
                $"Equity %: {equityPercentage * 100:0.00}",
            ];
            _printer.Print(msg, Justify.Center, Align.Middle, ' ', ' ', title);
        }

        public static void LoanInsuranceNotRequired(double equityPercentage, double equity)
        {
            string title = CreateHeader("LOAN INSURANCE NOT REQUIRED");
            string[] msg = [
                "You meet the minimum equity threshold and will not need to",
                "pay for loan insurance.",
                $"Your Equity: {equity}",
                $"Equity %: {equityPercentage * 100:0.00}",
            ];
            _printer.Print(msg, Justify.Center, Align.Middle, ' ', ' ', title);
        }

        public static void NotApproved(double monthlyIncome, double monthlyPayment, double loanApprovalThreshold)
        {
            string title = CreateHeader("NOT APPROVED");
            string[] msg = [
                "Unfortunately, you have not been approved for a mortgage.",
                $"Your Monthly Income: {monthlyIncome}",
                $"Your Monthly Payment: {monthlyPayment}",
                $"Your Monthly Payment %: {monthlyPayment / monthlyIncome * 100:0.00}",
                $"Loan Approval Threshold: {loanApprovalThreshold * 100:0.00}",
            ];
            _printer.Print(msg, Justify.Center, Align.Middle, ' ', ' ', title);
        }

        public static void Approved(double monthlyIncome, double monthlyPayment, double loanApprovalThreshold)
        {
            string title = CreateHeader("APPROVED");
            string[] msg = [
                "Congratulations! You have been approved for a mortgage.",
                $"Your Monthly Income: {monthlyIncome}",
                $"Your Monthly Payment: {monthlyPayment}",
                $"Your Monthly Payment %: {monthlyPayment / monthlyIncome * 100:0.00}",
                $"Loan Approval Threshold: {loanApprovalThreshold * 100:0.00}",
            ];
            _printer.Print(msg, Justify.Center, Align.Middle, ' ', ' ', title);
        }

        public static void ApprovalCheck()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[X] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [X] Annual HOA Fees",
                "[X] Additional Mortgage Details",
                "|-- [X] Enter Down Payment",
                "|-- [X] Choose Term Length",
                "|-- [ ] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete"
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void MortgageDetails()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[X] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [X] Annual HOA Fees",
                "[X] Additional Mortgage Details",
                "|-- [X] Enter Down Payment",
                "|-- [X] Choose Term Length",
                "|-- [X] Approval Check",
                "|-- [ ] View Mortgage Details",
                "[ ] Complete",
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }

        public static void DisplayMortgageDetails(Mortgage mortgage)
        {
            string title = CreateHeader("YOUR MORTGAGE DETAILS");
            string[] details = [
                "[-- Personal Information --]",
                $"Name: {mortgage.Buyer.Name}",
                $"Age: {mortgage.Buyer.Age}",
                $"Annual Combined Income: {mortgage.Buyer.AnnualCombinedIncome}",
                "",
                "[-- Home Information --]",
                $"Base Cost of Home: {mortgage.Home.PurchasePrice}",
                $"Principle Cost of Home: {mortgage.PrincipleLoanAmount}",
                $"Market Value: {mortgage.Home.MarketValue}",
                $"Total Interest: {mortgage.TotalInterest}",
                $"HOA Fees (Annual): {mortgage.HOAFeePerAnnum}",
                $"Origination Fee: {mortgage.OriginationFee}",
                $"Closing Costs: {mortgage.ClosingCosts}",
                $"Equity: {mortgage.Equity}",
                $"Equity %: {mortgage.EquityPercentage * 100:0.00}",
                "",
                "[-- Mortgage Information --]",
                $"Approval Recommendation: {(mortgage.RecommendApproval ? "Approved" : "Not Approved")}",
                $"Down Payment: {mortgage.DownPayment}",
                $"Loan Term: {mortgage.LoanTerm.Years} Years",
                $"Interest Rate %: {mortgage.InterestRate * 100:0.00}",
                $"Monthly Payment: {mortgage.MonthlyPayment}",
                $"Monthly Interest: {mortgage.MonthlyInterest}",
                $"Monthly HOA Fees: {mortgage.MonthlyHOAFees}",
                $"Monthly Taxes & Escrow: {mortgage.MonthlyEscrow}",
                $"Total Amount Financed: {mortgage.TotalCost}",
            ];
            _printer.Print(details, Justify.Center, Align.Middle, ' ', ' ', title);
        }

        public static void CalculateMortgageStepFinal()
        {
            string title = CreateHeader("CALCULATE MORTGAGE");
            string[] stepTracker = [
                "[X] Enter Personal Information",
                "|-- [X] Name",
                "|-- [X] Age",
                "|-- [X] Annual Combined Income",
                "[X] Enter Home Information",
                "|-- [X] Purchase Price",
                "|-- [X] Market Value",
                "|-- [X] Annual HOA Fees",
                "[X] Additional Mortgage Details",
                "|-- [X] Enter Down Payment",
                "|-- [X] Choose Term Length",
                "|-- [X] Approval Check",
                "|-- [X] View Mortgage Details",
                "[ ] Complete",
            ];
            _printer.Print(stepTracker, Justify.Left, Align.Middle, ' ', '*', title);
        }
    }
}