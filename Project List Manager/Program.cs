// Product Management System
// Author: Henrik Oldehed
// Date: 2026-05-08

// 1. Create a string list 
// 2. Initialize the list with some string values
// 3. User can enter elements from the console until user enter "exit"
// 4. Print the values of the list to the console
// 5. Exit the program

using System.Text.RegularExpressions;

// Basic Product Input

Console.WriteLine("================================");
Console.WriteLine("   PRODUCT MANAGEMENT SYSTEM");
Console.WriteLine("================================");
Console.WriteLine();

List<string> myProducts = new List<string>();

Console.WriteLine("Add a product name and close with 'exit'");

int index = 0; // Initialize index to keep track of the current position in the array

while (true)
{
    Console.Write("Add a product name: ");
    string data = Console.ReadLine();

    // Sorting & Improved Exit Handling

    if (data.ToLower().Trim() == "exit")
    {
        break;
    }

    // Product Validation

    if (!data.Contains("-"))
    {
        Console.WriteLine("Product must contain a dash (-)");
        continue;
    }

    string[] parts = data.Split('-');
    string part1 = parts[0];
    string part2 = parts[1];

    bool leftIsNumber = int.TryParse(part1, out _);
    bool rightIsNumber = int.TryParse(part2, out int number);

    if (!Regex.IsMatch(part1, @"^[A-Z]+$") && !rightIsNumber)
    {
        Console.WriteLine("Right side must be a number and left side must contain letters only");
        continue;
    }

    if (!Regex.IsMatch(part1, @"^[A-Z]+$"))
    {
        Console.WriteLine("Left side must contain letters only");
        continue;
    }

    if (!rightIsNumber)
    {
        Console.WriteLine("Right side must be a number - no letters allowed");
        continue;
    }

    if (!Regex.IsMatch(data, @"^[A-Z]{1}"))
    {
        Console.WriteLine("Invalid letters");
        continue;
    }

    if (number < 200 || number > 500)
    {
        Console.WriteLine("Invalid range");
        continue;
    }
    if (myProducts.Contains(data))
    {
        Console.WriteLine("Duplicate product");
        continue;
    }
    myProducts.Add(data);

    index++;
}

// Array.Resize(ref myProducts, index); // Resize the array to the number of entered elements
// Console.WriteLine("Unsorted Products");
// foreach (string product in myProducts)
// {
// Console.WriteLine(product);
// }

// create a copy of the original array and sort it
var myProductsCopy = new List<string>(myProducts);
myProductsCopy.Sort();

Console.WriteLine("Sorted valid products");
foreach (var product in myProductsCopy)
{
    Console.WriteLine(product);
}

Console.ReadLine(); // Wait for user input before closing the console