using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Airline
{
    class SoftUni_Airline
    {
        static void Main(string[] args)
        {
            int flightsCount = int.Parse(Console.ReadLine());
            decimal TotalProfit = 0.0M;
            for (int i = 0; i < flightsCount; i++)
            {
                Flight flight = Flight.Parse();
                TotalProfit += flight.Profit;

                if (flight.Profit >= 0)
                {
                    Console.WriteLine($"You are ahead with {flight.Profit:f3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {flight.Profit:f3}$.");
                }
            }
            Console.WriteLine($"Overall profit -> {TotalProfit:f3}$.");
            Console.WriteLine($"Average profit -> {TotalProfit / flightsCount:f3}$.");
        }
    }
    class Flight
    {
        public long AdultPassengers;
        public long YoungPassengers;
        public decimal AdultPrice;
        public decimal YoungPrice;
        public decimal Consumption;
        public decimal FuelPrice;
        public int Duration;

        public decimal Expenses;
        public decimal Income;
        public decimal Profit;

        public Flight()
        {

        }
        public static Flight Parse()
        {
            long adultPassengers = long.Parse(Console.ReadLine());
            decimal adultPrice = decimal.Parse(Console.ReadLine());
            long youngPassengers = long.Parse(Console.ReadLine());
            decimal youngPrice = decimal.Parse(Console.ReadLine());
            decimal fuelPrice = decimal.Parse(Console.ReadLine());
            decimal consumption = decimal.Parse(Console.ReadLine());
            int duration = int.Parse(Console.ReadLine());

            Flight flight = new Flight
            {
                AdultPassengers = adultPassengers,
                AdultPrice = adultPrice,
                YoungPassengers = youngPassengers,
                YoungPrice = youngPrice,
                FuelPrice = fuelPrice,
                Consumption = consumption,
                Duration = duration,
                Income = adultPrice * adultPassengers + youngPrice * youngPassengers,
                Expenses = duration * consumption * fuelPrice,
            };
            flight.Profit = flight.Income - flight.Expenses;

            return flight;
        }
    }
}
