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

        public double DetermineRentalAmount()
        {
            return movie.DetermineAmount(daysRented);
        }

        public int DetermineFrequentRenterPoints()
        {
            return movie.DetermineFrequentRenterPoints(daysRented);
        }

        public string GetMovieTitle()
        {
            return movie.GetTitle();
        }
    }
}
