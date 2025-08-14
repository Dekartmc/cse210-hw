using System;

class Program
{
    static GoalManager goalManager = new GoalManager();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");

        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine($"Current Score: {goalManager.Score}");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    goalManager.DisplayGoals();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using Eternal Quest. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\n--- Create New Goal ---");
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string goalTypeChoice = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();
        Console.Write("Enter the point value for this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (goalTypeChoice)
        {
            case "1":
                goalManager.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                goalManager.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter the target count for this checklist goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus point value for completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type. No goal was created.");
                break;
        }
    }

    static void RecordEvent()
    {
        goalManager.DisplayGoals();
        Console.Write("Enter the number of the goal you accomplished: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goalManager.Goals.Count)
        {
            goalManager.RecordEvent(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please try again.");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter the filename to save to (e.g., goals.json): ");
        string filename = Console.ReadLine();
        goalManager.SaveGoals(filename);
    }

    static void LoadGoals()
    {
        Console.Write("Enter the filename to load from (e.g., goals.json): ");
        string filename = Console.ReadLine();
        goalManager.LoadGoals(filename);
    }
}