using System;
using System.Threading.Tasks;

namespace LemonadeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = 1000.0; // starting money
            int cupsSold = 0;
            Random random = new Random();

            while (true)
            {
                // Generate random temperature and humidity
                int temperature = random.Next(60, 111); // 60°F to 110°F
                int humidity = random.Next(20, 81); // Humidity from 20% to 80%
                Console.WriteLine($"Current temperature: {temperature}°F, Humidity: {humidity}%");

                // Simulate selling lemonade
                Console.WriteLine("How many packs of cups (100 cups each) do you want to sell?");
                int packs = Convert.ToInt32(Console.ReadLine());
                cupsSold += packs * 100;

                // Calculate cost based on temperature and humidity
                double costPerCup = CalculateCost(temperature, humidity);
                double totalCost = costPerCup * cupsSold;

                // Update money
                money += (totalCost - CalculateMaterialCost(packs));
                Console.WriteLine($"Total money: {money:F2}");
            }
        }

        static double CalculateCost(int temperature, int humidity)
        {
            // Pricing strategy based on temperature and humidity
            double basePrice = 1.5; // base price per cup
            double priceAdjustment = (temperature - 60) * 0.05 + (humidity - 20) * 0.02;
            return basePrice + priceAdjustment;
        }

        static double CalculateMaterialCost(int packs)
        {
            // Calculate material cost for the number of packs sold
            return packs * 50; // Assuming $50 cost per pack of 100 cups
        }
    }
}