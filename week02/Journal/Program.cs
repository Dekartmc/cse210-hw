using System;
using System.Collections.Generic;

class Program
{
  static void Main()
  {
    Journal journal = new Journal();
    List<string> prompts = new List<string>
    {
      "Who was the most interesting person I interacted with today?",
      "What was the best part of my day?",
      "How did I see the hand of the Lord in my life today?",
      "What was the strongest emotion I felt today?",
      "If I had one thing I could do over today, what would it be?"
    };

    string choice = "";

    while (choice != "5")
    {
      Console.WriteLine("\nJournal Menu:");
      Console.WriteLine("1. Write a new entry");
      Console.WriteLine("2. Display journal");
      Console.WriteLine("3. Save journal to JSON file");
      Console.WriteLine("4. Load journal from JSON file");
      Console.WriteLine("5. Exit");
      Console.Write("Choose an option: ");
      choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
            string prompt = GetRandomPrompt(prompts);
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            journal.AddEntry(new Entry(prompt, response));
            break;

        case "2":
            journal.DisplayAll();
            break;

        case "3":
            Console.Write("Enter filename to save (e.g., journal.json): ");
            string saveFile = Console.ReadLine();
            journal.SaveToJson(saveFile);
            journal.DisplayAll();
            break;

        case "4":
            Console.Write("Enter filename to load (e.g., journal.json): ");
            string loadFile = Console.ReadLine();
            journal.LoadFromJson(loadFile);
            break;

        case "5":
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
      }
    }
  }

  static string GetRandomPrompt(List<string> prompts)
  {
    Random rand = new Random();
    return prompts[rand.Next(prompts.Count)];
  }
}