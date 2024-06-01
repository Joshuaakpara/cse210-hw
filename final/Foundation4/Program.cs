using System;
using System.Collections.Generic;
using System.Text;

// Comment class
public class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return new List<Comment>(comments);
    }
}

// Address class
public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

// Product class
public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }
}

// Order class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        foreach (var product in products)
        {
            packingLabel.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// Main Program for both Abstraction and Encapsulation
public class Program
{
    public static void Main()
    {
        // Program 1: Abstraction with YouTube Videos
        // Create videos
        Video video1 = new Video("Video Title 1", "Author 1", 300);
        Video video2 = new Video("Video Title 2", "Author 2", 600);
        Video video3 = new Video("Video Title 3", "Author 3", 900);

        // Add comments to videos
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Thanks for the info."));
        video1.AddComment(new Comment("User3", "Very helpful."));

        video2.AddComment(new Comment("User4", "Amazing content!"));
        video2.AddComment(new Comment("User5", "Well explained."));
        video2.AddComment(new Comment("User6", "Loved it!"));

        video3.AddComment(new Comment("User7", "Good job."));
        video3.AddComment(new Comment("User8", "Nice tutorial."));
        video3.AddComment(new Comment("User9", "Keep it up!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.Length} seconds, Comments: {video.GetNumberOfComments()}");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }

        // Program 2: Encapsulation with Online Ordering
        // Create customers
        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Springfield", "IL", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Elm St", "Toronto", "ON", "Canada"));

        // Create products
        Product product1 = new Product("Widget", "W123", 10.00, 3);
        Product product2 = new Product("Gadget", "G456", 15.00, 2);
        Product product3 = new Product("Doodad", "D789", 7.50, 5);
        Product product4 = new Product("Thingamajig", "T101", 20.00, 1);

        // Create orders and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}
