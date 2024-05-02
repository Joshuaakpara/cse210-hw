using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompting the user for their first name
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        // Prompting the user for their last name
        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        // Displaying the name in the specified format
        Console.WriteLine("Your name is {0}, {1}, {0}", lastName, firstName);
    }
}
