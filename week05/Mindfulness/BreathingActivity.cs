public class BreathingActivity : Activity
{
  public BreathingActivity() : base("Breathing", 
    "This activity will help you relax by guiding your breathing. Clear your mind and focus.")
  {
  }

  public override void Run()
  {
    DisplayStartingMessage();
    int interval = 6; // 3 in, 3 out
    int rounds = _duration / interval;

    for (int i = 0; i < rounds; i++)
    {
      Console.WriteLine("Breathe in...");
      ShowCountDown(3);
      Console.WriteLine("Breathe out...");
      ShowCountDown(3);
    }

    DisplayEndingMessage();
  }
}