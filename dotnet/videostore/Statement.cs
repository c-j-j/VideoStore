using System;
using System.Collections.Generic;

namespace videostore
{
    class Statement
    {
        private String customerName;
        private double totalAmount;
        private int frequentRenterPoints;
        private IList<Rental> rentals = new List<Rental>();

        public Statement(String customerName)
        {
            this.customerName = customerName;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String GetCustomerName()
        {
            return customerName;
        }

        public String GenerateStatement()
        {
            ResetTotals();
            var statementText = "";
            statementText += StatementHeader();
            statementText += StatementBody();
            return statementText;
        }

        string StatementHeader()
        {
            return string.Format("Rental Record for {0}\n", customerName);
        }

        string StatementBody()
        {
            var bodyText = "";
            foreach (var rental in rentals)
            {
                var rentalAmount = rental.DetermineRentalAmount();
                frequentRenterPoints += rental.DetermineFrequentRenterPoints();
                bodyText += FormatRentalLine(rental, rentalAmount);
                totalAmount += rentalAmount;
            }

            bodyText += StatementFooter(totalAmount, frequentRenterPoints);
            return bodyText;
        }

        void ResetTotals()
        {
            totalAmount = 0;
            frequentRenterPoints = 0;
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
