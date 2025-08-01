using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("How to Bake Bread", "Alice", 600);
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Samantha", "I love baking."));
        video1.AddComment(new Comment("Mike", "Thanks for sharing!"));

        var video2 = new Video("Learn C# in 10 Minutes", "Bob", 720);
        video2.AddComment(new Comment("Nina", "Very helpful."));
        video2.AddComment(new Comment("Alex", "Clear explanations."));
        video2.AddComment(new Comment("Rachel", "Can't wait to try this."));

        var video3 = new Video("Top 5 Travel Destinations", "Charlie", 540);
        video3.AddComment(new Comment("Laura", "I want to go there!"));
        video3.AddComment(new Comment("Dan", "Great list."));
        video3.AddComment(new Comment("Megan", "Nice video!"));
        video3.AddComment(new Comment("Kevin", "Very informative."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}