using System;
using System.Collections.Generic;

namespace videostore
{
    class Customer
    {
        private String name;
        private double totalAmount;
        private int frequentRenterPoints;
        private IList<Rental> rentals = new List<Rental>();

        public Customer(String name)
        {
            this.name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String GetName()
        {
            return name;
        }

        public String GenerateStatement()
        {
            totalAmount = 0;
            frequentRenterPoints = 0;
            var statementText = "";
            statementText += StatementHeader();
            foreach (var rental in rentals)
            {
                var rentalAmount = DetermineRentalAmount(rental);
                frequentRenterPoints++;
                if (rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                    && rental.GetDaysRented() > 1)
                    frequentRenterPoints++;

                statementText += FormatRentalLine(rental, rentalAmount);
                totalAmount += rentalAmount;
            }

            statementText += StatementFooter(totalAmount, frequentRenterPoints);
            return statementText;
        }

        static double DetermineRentalAmount(Rental rental)
        {
            double thisAmount = 0;
            // determines the amount for each line
            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.GetDaysRented() > 2)
                        thisAmount += (rental.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.GetDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (rental.GetDaysRented() > 3)
                        thisAmount += (rental.GetDaysRented() - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }

        string StatementHeader()
        {
            return string.Format("Rental Record for {0}\n", name);
        }

        static string FormatFrequentRenterPoints(int frequentRenterPoints)
        {
            return string.Format("You earned {0} frequent renter points\n", frequentRenterPoints);
        }

        string StatementFooter(double totalAmount, int frequentRenterPoints)
        {
            return FormatTotalAmount(totalAmount) + FormatFrequentRenterPoints(frequentRenterPoints);
        }

        static string FormatTotalAmount(double totalAmount)
        {
            return string.Format("You owed {0:F1}\n", totalAmount);
        }

        static string FormatRentalLine(Rental rental, double rentalAmount)
        {
            return string.Format("\t{0}\t{1:F1}\n", rental.GetMovie().GetTitle(), rentalAmount);
        }

        public double GetTotalAmount()
        {
            return totalAmount;
        }

        public int GetFrequentRenterPoints()
        {
            return frequentRenterPoints;
        }
    }
}
