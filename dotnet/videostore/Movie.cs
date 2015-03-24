namespace videostore
{
    public abstract class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        private readonly string title;
        protected int _priceCode;

        protected Movie(string title, int priceCode)
        {
            this.title = title;
            this._priceCode = priceCode;
        }

        public abstract double DetermineAmount(int daysRented);
        public abstract int DetermineFrequentRenterPoints(int daysRented);

        public int GetPriceCode()
        {
            return _priceCode;
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
