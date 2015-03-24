using System;
using System.Collections;
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
            String result = "Rental Record for " + GetName() + "\n";
            foreach (var rental in rentals)
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

                frequentRenterPoints++;

                if (rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                        && rental.GetDaysRented() > 1)
                    frequentRenterPoints++;

                result += "\t" + rental.GetMovie().GetTitle() + "\t" + string.Format("{0:F1}", thisAmount) + "\n";
                totalAmount += thisAmount;

            }

            result += "You owed " + string.Format("{0:F1}", totalAmount) + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points\n";


            return result;
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
