internal class bignumber
{
    private static void Main(string[] args)
    {
        int a = 2;
        int b = 3;
        int c = 4;

        int biggestnumber;

        if (a <= b)
        {
            if (a <= c)
                biggestnumber = c;
            else
                biggestnumber = b;
        }
        else
        {
            if (b <= c)
                biggestnumber = b;
            else
                biggestnumber = c;
        }

        Console.WriteLine("the biggest number is:");


    }
}