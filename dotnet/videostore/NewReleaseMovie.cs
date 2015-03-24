namespace videostore
{
    public class NewReleaseMovie : Movie
    {

        public NewReleaseMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

        public override double DetermineAmount(int daysRented)
        {
            double amount = 0;
            switch (_priceCode)
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    amount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3) * 1.5;
                    break;
            }
            return amount;
        }

        public override int DetermineFrequentRenterPoints(int daysRented)
        {
            return QualifiesForFrequentRenterBonus(daysRented) ? 2 : 1;
        }

        bool QualifiesForFrequentRenterBonus(int daysRented)
        {
            return IsMovieNewRelease() && daysRented > 1;
        }

        bool IsMovieNewRelease()
        {
            return _priceCode == Movie.NEW_RELEASE;
        }
    }
}
