/*
Showing Creativity and Exceeding Requirements:
- The program includes a validation and a message when all text is hidden
- A ScriptureLibrary class was created that contains a list of 5 scriptures
- When the program is initialized, a random scripture is displayed
*/
using System;

class Program
{
	static void Main(string[] args)
	{
		ScriptureLibrary library = new ScriptureLibrary();
		Scripture scripture = library.GetRandomScripture();

		while (true)
		{
			scripture.Display();
			Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
			string input = Console.ReadLine().ToLower();

			if (input == "quit") break;

			if (scripture.AllWordsHidden())
			{
				Console.WriteLine("All words are hidden. Press any key to exit.");
				Console.ReadKey();
				break;
			}

			scripture.HideRandomWords();
		}
	}
}
