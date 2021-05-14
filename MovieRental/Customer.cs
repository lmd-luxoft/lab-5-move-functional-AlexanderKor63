// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental
{
    public class Customer
    {
        private List<Rental> rentals = new List<Rental>();
        private string name;
        public Customer(string name)            {  this.name = name;     }

        public string getName()                 {  return name;          }
        internal void addRental(Rental rental)  {  rentals.Add(rental);  }

        internal string statement()
        {
            StringBuilder report = new StringBuilder();
            report.Append($"учет аренды для {getName()}\n");

            double totalAmount = 0;
            int frequentRenterPoints = 0;

            foreach (Rental item in rentals)
            {
                double thisAmount = item.findAmount();
                
                //добавить очки для активного арендатора
                frequentRenterPoints++;
                item.getMovie().bonusPoints(ref frequentRenterPoints, item.getDaysRented());

                report.Append($"\t{item.getMovie()}\t{thisAmount}\n");
                totalAmount += thisAmount;
            }
            report.Append($"Сумма задолженности составляет {totalAmount}\nВы заработали {frequentRenterPoints} очков за активность");
            return report.ToString();
        }
    }
}