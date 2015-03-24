namespace videostore
{
    public class ChildrensMovie : Movie
    {

        public ChildrensMovie(string title)
            : base(title)
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
