public class Activity
{
  private string _name;
  private string _description;
  protected int _duration;

  public Activity(string name, string description)
  {
    _name = name;
    _description = description;
  }

  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Starting {_name} Activity");
    Console.WriteLine(_description);
    Console.Write("Enter duration in seconds: ");
    _duration = int.Parse(Console.ReadLine());
    Console.WriteLine("Get ready...");
    ShowSpinner(3);
  }

  public void DisplayEndingMessage()
  {
    Console.WriteLine();
    Console.WriteLine("Well done!");
    ShowSpinner(2);
    Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
    ShowSpinner(2);
  }

  protected void ShowSpinner(int seconds)
  {
    for (int i = 0; i < seconds; i++)
    {
      Console.Write(".");
      Thread.Sleep(1000);
    }
    Console.WriteLine();
  }

  protected void ShowCountDown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write($"{i} ");
      Thread.Sleep(1000);
    }
    Console.WriteLine();
  }

  public virtual void Run()
  {
    DisplayStartingMessage();
    DisplayEndingMessage();
  }
}