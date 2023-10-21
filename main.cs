using System;

class Program
{
    static void Main()
    {
        decimal[] temperatures = new decimal[5];
        decimal totalTemperature = 0;
        decimal? previousTemperature = null;
        int warmerCount = 0;
        int coolerCount = 0;

        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                Console.WriteLine($"Enter temperature for day {i + 1}:");
                decimal temperature = decimal.Parse(Console.ReadLine());

                if (temperature < -30 || temperature > 130 || temperature == -25)
                {
                    Console.WriteLine($"Temperature {temperature} is invalid. Please enter a valid temperature between -30 and 130.");
                    continue;
                }
                else
                {
                    temperatures[i] = temperature;
                    totalTemperature += temperature;

                    if (previousTemperature.HasValue)
                    {
                        if (temperature > previousTemperature.Value)
                        {
                            warmerCount++;
                        }
                        else if (temperature < previousTemperature.Value)
                        {
                            coolerCount++;
                        }
                    }

                    previousTemperature = temperature;
                    break;
                }
            }
        }

        if (warmerCount == 4) // 4 comparisons for 5 temperatures
        {
            Console.WriteLine("Getting Warmer");
        }
        else if (coolerCount == 4)
        {
            Console.WriteLine("Getting Cooler");
        }
        else
        {
            Console.WriteLine("It's a mixed bag");
        }

        Console.WriteLine($"5-day Temperature [{string.Join(", ", temperatures)}]");
        Console.WriteLine($"Average Temperature is {totalTemperature / 5} degrees");
    }
}
