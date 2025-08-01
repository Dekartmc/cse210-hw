using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Michael Flores", "Programming with Classes");
        Console.WriteLine(a1.GetSummary());

        Assignment a2 = new Assignment("Leslie Bazo", "Multiplication");
        Console.WriteLine(a2.GetSummary());
        
        MathAssignment a3 = new MathAssignment("Jaime Santiago", "Fractions", "7.3", "8-19");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetHomeworkList());

        WritingAssignment a4 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a4.GetSummary());
        Console.WriteLine(a4.GetWritingInformation());
    }
}