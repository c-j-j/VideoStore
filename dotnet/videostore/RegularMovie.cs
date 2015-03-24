namespace videostore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title, int priceCode)
            : base(title, priceCode)
        {
        }

        public override double DetermineAmount(int daysRented)
        {
            double amount = 2;
            if (daysRented > 2)
                amount += (daysRented - 2) * 1.5;
            return amount;
        }

        public override int DetermineFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
