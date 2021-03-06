﻿namespace videostore
{
    using NUnit.Framework;

    [TestFixture]
    public class VideoStoreTest
    {
        Statement customer;
        Movie newReleaseMovieA;
        Movie newReleaseMovieB;
        Movie childrensMovie;
        Movie regularMovieA;
        Movie regularMovieB;
        Movie regularMovieC;

        [SetUp]
        public void Setup()
        {
            customer = new Statement("SomeCustomerName");
            newReleaseMovieA = new NewReleaseMovie("SomeNewReleaseA");
            newReleaseMovieB = new NewReleaseMovie("SomeNewReleaseB");
            childrensMovie = new ChildrensMovie("SomeChildrensMovie");
            regularMovieA = new RegularMovie("SomeRegularMovieA");
            regularMovieB = new RegularMovie("SomeRegularMovieB");
            regularMovieC = new RegularMovie("SomeRegularMovieC");
        }

        [Test]
        public void TestSingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(newReleaseMovieA, 3));
            customer.GenerateStatement();
            Assert.AreEqual(9, customer.GetTotalAmount());
            Assert.AreEqual(2, customer.GetFrequentRenterPoints());
        }

        [Test]
        public void TestDualNewReleaseStatement()
        {
            customer.AddRental(new Rental(newReleaseMovieA, 3));
            customer.AddRental(new Rental(newReleaseMovieB, 3));
            customer.GenerateStatement();
            Assert.AreEqual(18, customer.GetTotalAmount());
            Assert.AreEqual(4, customer.GetFrequentRenterPoints());
        }

        [Test]
        public void TestSingleChildrensStatement()
        {
            customer.AddRental(new Rental(childrensMovie, 3));
            customer.GenerateStatement();
            Assert.AreEqual(1.5, customer.GetTotalAmount());
            Assert.AreEqual(1, customer.GetFrequentRenterPoints());
        }

        [Test]
        public void TestMultipleRegularStatement()
        {
            customer.AddRental(new Rental(regularMovieA, 1));
            customer.AddRental(new Rental(regularMovieB, 2));
            customer.AddRental(new Rental(regularMovieC, 3));
            customer.GenerateStatement();
            Assert.AreEqual(7.5, customer.GetTotalAmount());
            Assert.AreEqual(3, customer.GetFrequentRenterPoints());
        }

        [Test]
        public void TestFormattingOfStatement()
        {
            customer.AddRental(new Rental(regularMovieA, 1));
            customer.AddRental(new Rental(regularMovieB, 2));
            customer.AddRental(new Rental(regularMovieC, 3));
            customer.GenerateStatement();

            Assert.AreEqual("Rental Record for " + customer.GetCustomerName() + "\n\t" +
                regularMovieA.GetTitle() + "\t2.0\n\t" +
                regularMovieB.GetTitle() + "\t2.0\n\t" +
                regularMovieC.GetTitle() + "\t3.5\n" +
                "You owed 7.5\n" +
                "You earned 3 frequent renter points\n", customer.GenerateStatement());
        }
    }
}
