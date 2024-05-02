using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        // Variable to store the letter grade
        char letter;

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Determine if the user passed the course
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard for next time.");
        }

        // Display the letter grade
        Console.WriteLine("Your letter grade is: " + letter);

        // Stretch Challenge: Determine the sign for grades with +/- signs
        int lastDigit = (int)gradePercentage % 10;
        char sign = ' ';

        if (letter == 'A' && lastDigit >= 7)
        {
            letter = 'A';
            sign = '+';
        }
        else if (letter == 'B' && lastDigit >= 7)
        {
            letter = 'B';
            sign = '+';
        }
        else if (letter != 'F' && lastDigit < 3)
        {
            sign = '-';
        }

        // Display the letter grade with the sign
        if (sign != ' ')
        {
            Console.WriteLine("Your letter grade with sign is: " + letter + sign);
        }
    }
}

