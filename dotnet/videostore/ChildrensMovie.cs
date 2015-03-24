namespace videostore
{
    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title, int priceCode)
            : base(title, priceCode)
        {
        }

        public override double DetermineAmount(int daysRented)
        {
            var amount = 1.5;
            if (daysRented > 3)
                amount += (daysRented - 3) * 1.5;
            return amount;
        }

        public override int DetermineFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
