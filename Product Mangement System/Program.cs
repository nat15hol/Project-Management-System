// Product Management System
// Author: Henrik Oldehed
// Date: 2026-05-08

using System.Text.RegularExpressions;

Console.WriteLine("================================");
Console.WriteLine("   PRODUCT MANAGEMENT SYSTEM");
Console.WriteLine("================================");
Console.WriteLine();

List<string> myProducts = new List<string>();

Console.WriteLine("Add a product name and close with 'exit'");

int index = 0; // Initialize index to keep track of the current position in the array

bool running = true;
void ShowMenu()
{
    Console.WriteLine("\nMENU");
    Console.WriteLine("1. Add product");
    Console.WriteLine("2. View products");
    Console.WriteLine("3. Search products");
    Console.WriteLine("4. Delete product");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Save to file");
    Console.WriteLine("7. Exit");
}

while (running)
{
    Console.WriteLine("\nMENU");
    Console.WriteLine("1. Add product");
    Console.WriteLine("2. View products");
    Console.WriteLine("3. Search products");
    Console.WriteLine("4. Delete product");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Save to file");
    Console.WriteLine("7. Exit");

    Console.Write("Choose: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter product: ");
            string data = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(data))
            {
                Console.WriteLine("Invalid input");
                break;
            }

            if (!data.Contains("-"))
            {
                Console.WriteLine("Product must contain a dash (-)");
                break;
            }

            string[] parts = data.Split('-');
            string part1 = parts[0];
            string part2 = parts[1];

            if (!Regex.IsMatch(part1, @"^[A-Z]+$"))
            {
                Console.WriteLine("Left side must contain letters only");
                break;
            }

            if (!int.TryParse(part2, out int number))
            {
                Console.WriteLine("Right side must be a number");
                break;
            }

            if (number < 200 || number > 500)
            {
                Console.WriteLine("Invalid range");
                break;
            }

            if (myProducts.Contains(data))
            {
                Console.WriteLine("Duplicate product");
                break;
            }

            myProducts.Add(data);
            Console.WriteLine("Product added!");
            break;

        case "2":
            if (myProducts.Count == 0)
            {
                Console.WriteLine("No products added yet.");
                break;
            }

            var sorted = new List<string>(myProducts);
            sorted.Sort();

            Console.WriteLine("Products:");
            foreach (var product in sorted)
            {
                Console.WriteLine(product);
            }
            break;
        case "3":
            Console.Write("Search term: ");
            string search = Console.ReadLine();

            var matches = myProducts
                .Where(p => p.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matches.Count == 0)
            {
                Console.WriteLine("No matches found.");
            }
            else
            {
                Console.WriteLine("Found products:");
                foreach (var m in matches)
                {
                    Console.WriteLine(m);
                }
            }
            break;
        case "4":
            Console.Write("Enter product to delete: ");
            string toDelete = Console.ReadLine();

            var item = myProducts
                .FirstOrDefault(p => p.Equals(toDelete, StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                myProducts.Remove(item);
                Console.WriteLine("Product removed!");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            break;
        case "5":
            Console.WriteLine($"Number of products: {myProducts.Count}");

            var numbers = myProducts
                .Select(p => int.Parse(p.Split('-')[1]))
                .ToList();

            if (numbers.Count == 0)
            {
                Console.WriteLine("No products available.");
                break;
            }

            int highest = numbers.Max();
            int lowest = numbers.Min();
            double average = numbers.Average();

            Console.WriteLine($"Total products: {numbers.Count}");
            Console.WriteLine($"Lowest product number: {lowest}");
            Console.WriteLine($"Highest product number: {highest}");
            Console.WriteLine($"Average product number: {average:F2}");
            break;
        case "6":

            string folder = "data";
            Directory.CreateDirectory(folder);

            string fileName = $"products_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
            string path = Path.Combine(folder, fileName);

            File.WriteAllLines(path, myProducts);

            Console.WriteLine($"Products saved to: {path}");

            running = false;
            break;

        case "7":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

// Array.Resize(ref myProducts, index); // Resize the array to the number of entered elements
// Console.WriteLine("Unsorted Products");
// foreach (string product in myProducts)
//{
//Console.WriteLine(product);
//}

// create a copy of the original array and sort it
var myProductsCopy = new List<string>(myProducts);
myProductsCopy.Sort();
// File.WriteAllLines("products.txt", myProducts);
//Console.WriteLine("Sorted Products");
//foreach (var product in myProductsCopy)
//{
//Console.WriteLine(product);
//}
//string folder = "data";
//Directory.CreateDirectory(folder);

//string fileName = $"products_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
//string path = Path.Combine(folder, fileName);
// Console.ReadLine(); // Wait for user input before closing the console