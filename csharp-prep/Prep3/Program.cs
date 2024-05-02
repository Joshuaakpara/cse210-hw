using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;

            Console.WriteLine("Welcome to Guess My Number Game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"Congratulations! You guessed the magic number in {guessCount} guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();

            if (playAgainResponse != "yes")
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thank you for playing Guess My Number Game!");
    }
}

