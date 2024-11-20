using System;
using System.Collections.Generic;

class Remove
{
    public static void Main()
    {
        var car = new List<string>() { "Neel", "Gautam", "Shivang", "Amaan" };

        // remove the first occurence of "Tesla" from the list
        car.Add("Tesla");

        // remove the first occurrence of "Suzuki" 
        car.Remove("Amaan");

        // print the updated list after removing   
        for (int i = 0; i < car.Count; i++)
        {
            Console.WriteLine(car[i]);

        }
    }
}
