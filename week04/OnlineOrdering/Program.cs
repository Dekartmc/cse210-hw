using System;

class Program
{
    static void Main(string[] args)
    {
        // First order
        var address1 = new Address("123 Main St", "New York", "NY", "USA");
        var customer1 = new Customer("Alice Smith", address1);
        var order1 = new Order(customer1);

        order1.AddProduct(new Product("Book", "B001", 12.99m, 2));
        order1.AddProduct(new Product("Pen", "P101", 1.50m, 5));

        // Second order
        var address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        var customer2 = new Customer("Bob Lee", address2);
        var order2 = new Order(customer2);

        order2.AddProduct(new Product("Notebook", "N303", 5.75m, 3));
        order2.AddProduct(new Product("Backpack", "BP202", 29.99m, 1));

        // Display results
        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"TOTAL PRICE: ${order.GetTotalCost():0.00}");
    }
}