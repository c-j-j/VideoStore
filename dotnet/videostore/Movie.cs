namespace videostore
{
    public abstract class Movie
    {
        private readonly string title;

        protected Movie(string title)
        {
            this.title = title;
        }

        public abstract double DetermineAmount(int daysRented);
        public abstract int DetermineFrequentRenterPoints(int daysRented);

        public string GetTitle()
        {
            return title;
        }
    }
}
