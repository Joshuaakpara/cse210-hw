using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public abstract void RecordEvent(User user);
    public abstract string GetDetailsString();
    public abstract bool IsComplete();
}

public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void RecordEvent(User user)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            user.AddPoints(Points);
        }
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {Points} points - Completed: {_isComplete}";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void RecordEvent(User user)
    {
        user.AddPoints(Points);
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {Points} points (Eternal Goal)";
    }

    public override bool IsComplete()
    {
        return false;
    }
}

public class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, int points, int requiredCount, int bonusPoints)
    {
        Name = name;
        Points = points;
        RequiredCount = requiredCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent(User user)
    {
        CurrentCount++;
        user.AddPoints(Points);
        if (IsComplete())
        {
            user.AddPoints(BonusPoints);
        }
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {Points} points each - Completed {CurrentCount}/{RequiredCount} times - Bonus: {BonusPoints} points";
    }

    public override bool IsComplete()
    {
        return CurrentCount >= RequiredCount;
    }
}

public class User
{
    public int Score { get; set; }
    public int Level { get; set; }

    public User()
    {
        Score = 0;
        Level = 1;
    }

    public void AddPoints(int points)
    {
        Score += points;
        while (Score >= Level * 1000)
        {
            Score -= Level * 1000;
            Level++;
            Console.WriteLine($"Congratulations! You've reached level {Level}!");
        }
    }
}

public class Program
{
    private static User user = new User();
    private static List<Goal> goals = new List<Goal>();

    public static void Main(string[] args)
    {
        LoadData();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Show Score and Level");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    Console.WriteLine($"Current Score: {user.Score}, Current Level: {user.Level}");
                    break;
                case "5":
                    SaveData();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the points value: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter the required count: ");
                int requiredCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, requiredCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Select a goal to record an event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.RecordEvent(user);
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private static void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string status = goal.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {goal.GetDetailsString()}");
        }
    }

    private static void SaveData()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine($"{user.Score}|{user.Level}");
            foreach (Goal goal in goals)
            {
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{checklistGoal.CurrentCount}|{checklistGoal.RequiredCount}|{checklistGoal.BonusPoints}");
                }
                else
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}");
                }
            }
        }
    }

    private static void LoadData()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string[] userParts = reader.ReadLine().Split('|');
                user.Score = int.Parse(userParts[0]);
                user.Level = int.Parse(userParts[1]);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    int points = int.Parse(parts[2]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            goals.Add(new SimpleGoal(name, points));
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(name, points));
                            break;
                        case "ChecklistGoal":
                            int currentCount = int.Parse(parts[3]);
                            int requiredCount = int.Parse(parts[4]);
                            int bonusPoints = int.Parse(parts[5]);
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, points, requiredCount, bonusPoints) { CurrentCount = currentCount };
                            goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }
    }
}
/*
Exceeding Requirements:

1. Leveling System:
   - Implemented a leveling system for the user, where the user gains levels after accumulating a certain number of points (1000 points per level).
   - Added a congratulatory message to notify the user when they reach a new level, enhancing user engagement and motivation.

2. Save and Load Functionality:
   - Implemented the ability to save and load user data and goals to/from a file ("goals.txt").
   - This feature allows users to persist their progress across sessions, providing a seamless experience and enhancing usability.

These additional features go beyond the core requirements and enhance the program's functionality, user experience, and engagement.
*/
