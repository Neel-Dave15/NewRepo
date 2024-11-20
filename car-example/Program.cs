namespace carClassExample
{

    // Class Declaration
    public class car
    {

        // Instance Variables
        String name;
        String brand;
        int model;
        String color;

        // Constructor Declaration of Class
        public car(String name, String brand,
                      int model, String color)
        {
            this.name = name;
            this.brand = brand;
            this.model = model;
            this.color = color;
        }

        // Property 1
        public String GetName()
        {
            return name;
        }

        // Property 2
        public String GetBrand()
        {
            return brand;
        }

        // Property 3
        public int GetModel()
        {
            return model;
        }

        // Property 4
        public String GetColor()
        {
            return color;
        }

        // Method 1
        public String ToString()
        {
            return ("Hi my name is " + this.GetName()
                    + ".\nMy brand, model and color are " + this.GetBrand()
                    + ", " + this.GetModel() + ", " + this.GetColor());
        }

        // Main Method
        public static void Main(String[] args)
        {

            // Creating object
            car Civic = new car("civic", "Honda", 2, "white");
            Console.WriteLine(Civic.ToString());

            // Creating another object
            car BMW = new car("BMW", "M5", 5, "black");
            Console.WriteLine(BMW.ToString());
        }
    }


}
