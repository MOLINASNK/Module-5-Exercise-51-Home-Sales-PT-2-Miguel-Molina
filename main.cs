using System;

class Program {
  public static void Main (string[] args) {
    string[] salespersons = { "Danielle", "Edward", "Francis" };
    char[] initials = { 'D', 'E', 'F' };
    double[] sales = { 0, 0, 0 };
    double saleAmount;
    char initial;

    while (true) {
        Console.Write("Enter the salesperson initial (D, E, F) or Z to quit: ");
        initial = Char.ToUpper(Console.ReadLine()[0]);

        if (initial == 'Z') {
            break;
        }

        int index = Array.IndexOf(initials, initial);
        if (index == -1) {
            Console.WriteLine("Invalid initial. Please enter D, E, or F.");
            continue;
        }

        Console.Write("Enter the sale amount: ");
        while (!Double.TryParse(Console.ReadLine(), out saleAmount) || saleAmount < 0) {
            Console.WriteLine("Invalid sale amount. Please enter a positive number.");
            Console.Write("Enter Sale Amount: ");
        }

        sales[index] += saleAmount;
    }

    double grandTotal = 0;
    for (int i = 0; i < sales.Length; i++) {
        grandTotal += sales[i];
    }

    Console.WriteLine("\nSales Totals:");
    for (int i = 0; i < salespersons.Length; i++) {
        Console.WriteLine($"{salespersons[i]}: ${sales[i]:F2}");
    }
    Console.WriteLine($"Grand Total: ${grandTotal:F2}");

    int highestIndex = 0;
    for (int i = 1; i < sales.Length; i++) {
        if (sales[i] > sales[highestIndex]) {
            highestIndex = i;
        }
    }

    Console.WriteLine($"Highest Salesperson: {salespersons[highestIndex]} with ${sales[highestIndex]:F2}");
  }
}