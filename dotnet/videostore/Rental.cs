namespace videostore
{
    class Rental
    {
        private readonly Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return daysRented;
        }

        public double DetermineRentalAmount()
        {
            double thisAmount = 0;
            switch (movie.GetPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (daysRented > 2)
                        thisAmount += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (daysRented > 3)
                        thisAmount += (daysRented - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }

        public int DetermineFrequentRenterPoints()
        {
            return QualifiesForFrequentRenterBonus() ? 2 : 1;
        }

        bool QualifiesForFrequentRenterBonus()
        {
            return IsMovieNewRelease() && daysRented > 1;
        }

        bool IsMovieNewRelease()
        {
            var variable = movie.GetPriceCode() == Movie.NEW_RELEASE;
            return variable;
        }

        public Movie GetMovie()
        {
            return movie;
        }

    }
}
