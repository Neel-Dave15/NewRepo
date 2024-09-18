internal class Company
{
    private static void Main(string[] args)
    {
        Console.Write(" Please enter the company name: ");
        string companyName= Console.ReadLine();

        Console.Write(" Please enter the address: ");
        string address = Console.ReadLine();

        Console.Write(" Please enter the phone number: ");
        int  phonenumber = int.Parse( Console.ReadLine());

        Console.Write(" Please enter the fax number: ");
        int faxnumber = int.Parse(Console.ReadLine());

        Console.Write(" Please enter the website: ");
        string website = Console.ReadLine();

        Console.WriteLine("Company's-info: {0} {1} {2} {3} {4}!", companyName, address, phonenumber, faxnumber, website);

        // manager information

        Console.Write(" Please enter the  manager name: ");
        string managerName = Console.ReadLine();

        Console.Write(" Please enter the surname: ");
        string surname = Console.ReadLine();

        Console.Write(" Please enter the manager's mobile number: ");
        int mobilenumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Manager's info: {0} {1} {2}.", managerName, surname, mobilenumber);
    }
}