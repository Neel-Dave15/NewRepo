internal class Program
{
    private static void Main(string[] args)
    {
        bool exitMain = false;
        string petName = "";
        string petType = "";

        while (!exitMain)
        {
            Console.WriteLine("Welcome to Virtual Pet Simulator");
            Console.WriteLine("Please choose a type of pet : ");
            Console.WriteLine("1. Cat:");
            Console.WriteLine("2. Dog:");
            Console.WriteLine("3. Rabbit:");
            Console.Write("User Input: ");
            petType = Console.ReadLine();

            switch (petType)
            {
                case "1":
                    petType = "Cat";
                    break;
                case "2":
                    petType = "Dog";
                    break;
                case "3":
                    petType = "Rabbit";
                    break;
                default:
                    Console.WriteLine("Invalid Option choose again!");
                    Console.WriteLine();
                    continue; // Restart the loop for another attempt
            }

            Console.WriteLine("You have chosen a " + petType + " " + "What would you like to name your pet?");
            Console.Write("Name: ");
            petName = Console.ReadLine();
            Console.WriteLine("Welcome " + petName + "! Let's take good care of him");
            exitMain = true;
        }

        int hunger = 5;
        int happiness = 5;
        int health = 5;

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Feed Pet");
            Console.WriteLine("2. Play with pet");
            Console.WriteLine("3. Let Pet Rest");
            Console.WriteLine("4. Check Pet Status");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    hunger = 3;
                    happiness = 6;
                    health = 7;
                    break;
                case "2":
                    happiness = 9;
                    hunger = 8;
                    break;
                case "3":
                    health = 8;
                    hunger = 5;
                    happiness = 4;
                    break;
                case "4":
                    Console.WriteLine();
                    Console.WriteLine(petName + "'s Current Status: \n");
                    Console.WriteLine("Happiness:" + happiness);
                    Console.WriteLine("Hunger:" + hunger);
                    Console.WriteLine("Health:" + health);
                    continue; 
                case "5":
                    Console.WriteLine("Thank you for using the pet simulator!");
                    exit = true;
                    continue; // Exit the loop
                default:
                    Console.WriteLine("Invalid Choice Try Again");
                    Console.WriteLine();
                    continue; 
            }

            // Display the status after performing an action
            Console.WriteLine( petName + "'s Status");
            Console.Write("\n");
            Console.WriteLine("Happiness:" + happiness );
            Console.WriteLine("Hunger:" + hunger );
            Console.WriteLine("Health:" + health);
            Console.WriteLine();
        }
    }
}