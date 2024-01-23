namespace MortgageCalculator
{
    public class Home(double marketValue, double listPrice, double purchasePrice, double annualHOAFees)
    {
        public double MarketValue { get; set; } = marketValue;
        public double ListPrice { get; set; } = listPrice;
        public double PurchasePrice { get; set; } = purchasePrice;
        public double AnnualHOAFees { get; set; } = annualHOAFees;
    }
}