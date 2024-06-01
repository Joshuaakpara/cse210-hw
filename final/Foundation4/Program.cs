using System;
using System.Collections.Generic;

// Comment class
public class Comment
{
    public string CommenterName { get; private set; }
    public string CommentText { get; private set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

// Video class
public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; } // in seconds
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
    }
}

// Main Program
public class Program
{
    public static void Main()
    {
        // Create videos
        Video video1 = new Video("Understanding Abstraction", "John Doe", 300);
        Video video2 = new Video("Mastering Encapsulation", "Jane Smith", 450);
        Video video3 = new Video("Inheritance Basics", "Alice Johnson", 360);
        Video video4 = new Video("Polymorphism Explained", "Bob Brown", 420);

        // Add comments to videos
        video1.AddComment(new Comment("User1", "Great explanation!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
        video1.AddComment(new Comment("User3", "I learned a lot."));

        video2.AddComment(new Comment("User4", "Clear and concise."));
        video2.AddComment(new Comment("User5", "Excellent video!"));

        video3.AddComment(new Comment("User6", "I finally understand inheritance!"));
        video3.AddComment(new Comment("User7", "This was so useful."));
        video3.AddComment(new Comment("User8", "Thanks for the tutorial."));

        video4.AddComment(new Comment("User9", "Polymorphism rocks!"));
        video4.AddComment(new Comment("User10", "Well explained."));
        video4.AddComment(new Comment("User11", "Great content as always."));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}
