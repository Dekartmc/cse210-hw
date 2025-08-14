using System;

class Program
{
    static void Main()
    {
        int choice = -1;
        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    new BreathingActivity().Run();
                    break;
                case 2:
                    new ReflectionActivity().Run();
                    break;
                case 3:
                    new ListingActivity().Run();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (choice != 4)
            {
                Console.WriteLine("Press Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}