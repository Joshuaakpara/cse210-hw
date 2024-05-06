using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Scripture
{
    private string reference;
    private List<string> words;
    private List<int> hiddenIndices;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').ToList();
        hiddenIndices = new List<int>();
    }

    public void Display()
    {
        Console.WriteLine(reference);
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenIndices.Contains(i))
            {
                Console.Write("_____ ");
            }
            else
            {
                Console.Write(words[i] + " ");
            }
        }
        Console.WriteLine();
    }

    public bool HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count / 2); // Randomly hide up to half of the words

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            if (!hiddenIndices.Contains(index))
            {
                hiddenIndices.Add(index);
            }
        }

        return hiddenIndices.Count < words.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a sample scripture
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        bool allWordsHidden = false;

        while (!allWordsHidden)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press Enter to continue, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            allWordsHidden = !scripture.HideRandomWords();
            Thread.Sleep(1000); // Pause for a moment before hiding more words
        }
    }
}

// Exceeding Requirements:
// - The program provides functionality to hide random words in the scripture, enhancing the user's memorization challenge.
// - The program utilizes threading to pause for a moment before hiding more words, improving user experience.
// - The program encourages users to interactively continue or quit the hiding process, enhancing usability and engagement.
