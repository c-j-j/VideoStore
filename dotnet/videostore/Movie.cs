namespace videostore
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        private readonly string title;
        private int priceCode;

        public Movie(string title, int priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public double DetermineAmount(int daysRented)
        {
            double amount = 0;
            switch (priceCode)
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

        public int DetermineFrequentRenterPoints(int daysRented)
        {
            return QualifiesForFrequentRenterBonus(daysRented) ? 2 : 1;
        }

        bool QualifiesForFrequentRenterBonus(int daysRented)
        {
            return IsMovieNewRelease() && daysRented > 1;
        }

        bool IsMovieNewRelease()
        {
            return priceCode == Movie.NEW_RELEASE;
        }

        public int GetPriceCode()
        {
            return priceCode;
        }

        public void SetPriceCode(int code)
        {
            priceCode = code;
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
