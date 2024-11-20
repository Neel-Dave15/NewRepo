using System;

class Program
{
    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static void Main()
    {
        Console.Write("Enter temperature in Fahrenheit:");
        double fahrenheit = Convert.ToDouble(Console.ReadLine());

        double celsiusResult = FahrenheitToCelsius(fahrenheit);
        Console.WriteLine("Temperature in Celsius:" + celsiusResult);
    }
}
