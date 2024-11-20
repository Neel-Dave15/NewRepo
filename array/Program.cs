
namespace ArrayInitializationExample
{
    class Arrayprogram
    {
        static void Main(string[] args)
        {
            
            int[] myArray = new int[20];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = i * 5;
                Console.WriteLine(myArray[i]);
            }

        }
    }
}
    