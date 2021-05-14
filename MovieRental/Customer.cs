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

        internal string report()
        {
            StringBuilder report = new StringBuilder();

            reportHead(report, getName());
            var stats = reportBody(report);
            reportTail(report, stats.Item1, stats.Item2);

            return report.ToString();
        }

        private void reportHead(StringBuilder report, string name)
        {
            report.Append($"учет аренды для {name}\n");
        }
        private Tuple<double,int> reportBody(StringBuilder report)
        {
            double totalAmount = 0;
            int points = 0;

            foreach (Rental item in rentals)
            {
                double thisAmount = item.findAmount();

                //добавить очки для активного арендатора
                points++;
                item.getMovie().bonusPoints(ref points, item.getDaysRented());

                reportItem(report, item.getMovie(), thisAmount);
                totalAmount += thisAmount;
            }
            return new Tuple<double, int>(totalAmount, points);
        }
        private void reportItem(StringBuilder report, Movie movie, double amount)
        {
            report.Append($"\t{movie}\t{amount}\n");
        }
        private void reportTail(StringBuilder report, double amount, int points)
        {
            report.Append($"Сумма задолженности составляет {amount}\nВы заработали {points} очков за активность");
        }
    }
}