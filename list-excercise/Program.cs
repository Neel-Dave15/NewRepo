using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        // create a list
        List<string> country = new List<string>() { "Russia", "India", "UK", "Brazil" };

        //add "USA" to the country list
        country.Add("USA");

        // add "Japan" to the country list 
        country.Add("Japan");

        // iterate through the country list  
        for (int i = 0; i < country.Count; i++)
            Console.WriteLine(country[i]);

    }
}


