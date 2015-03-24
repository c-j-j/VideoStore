namespace videostore
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

        public override double DetermineAmount(int daysRented)
        {
            return daysRented * 3;
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
