// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace MovieRental
{
    public abstract class Movie
    {
        private string title;
        public Movie(string title)        {  this.title = title; }

        public string getTitle()          {  return title;       }
        public override string ToString() {  return title;       }

        public abstract double getAmount(int daysRental);
    }

    public class NewMovie      : Movie {
        public NewMovie(string title) : base(title) { }

        public override double getAmount(int daysRental)
        {
            return daysRental * 3;
        }
    }
    public class RegularMovie  : Movie {
        public RegularMovie(string title) : base(title) { }

        public override double getAmount(int daysRental)
        {
            double amount = 2;
            if (daysRental > 2)   amount += (daysRental - 2) * 15;

            return amount;
        }
    }
    public class ChildrenMovie : Movie {
        public ChildrenMovie(string title) : base(title) { }

        public override double getAmount(int daysRental)
        {
            double amount = 15;
            if (daysRental > 3)   amount += (daysRental - 3) * 15;

            return amount;
        }
    }
}