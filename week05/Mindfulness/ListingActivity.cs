public class ListingActivity : Activity
{
  private List<string> _prompts = new List<string>
  {
    "Who are people that you appreciate?",
    "What are your personal strengths?",
    "Who have you helped this week?",
    "When did you feel the Holy Ghost this month?",
    "Who are some of your personal heroes?"
  };

  public ListingActivity() : base("Listing", 
    "This activity helps you list as many positive things as you can.")
  {
  }

  public override void Run()
  {
    DisplayStartingMessage();
    Random rand = new Random();
    Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
    ShowCountDown(3);
    Console.WriteLine("Start listing! Press Enter after each item.");

    List<string> entries = new List<string>();
    DateTime endTime = DateTime.Now.AddSeconds(_duration);
    while (DateTime.Now < endTime)
    {
      if (Console.KeyAvailable)
      {
        string item = Console.ReadLine();
        entries.Add(item);
      }
    }

    Console.WriteLine($"You listed {entries.Count} items.");
    DisplayEndingMessage();
  }
}