using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_150_Milestone_6
{
    internal class Inventory
    {
        public List<InventoryItem> InventoryItems { get; private set; }

        public Inventory(string filePath)
        {
            InventoryItems = ReadInventoryFromFile(filePath);
        }

        private List<InventoryItem> ReadInventoryFromFile(string filePath)
        {
            var items = new List<InventoryItem>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    try
                    {
                        string name = parts[0].Trim();
                        int quantity = int.Parse(parts[1].Trim());
                        decimal price = decimal.Parse(parts[2].Trim());
                        items.Add(new InventoryItem(name, quantity, price));
                    }
                    catch (FormatException ex)
                    {
                        // Log the error and continue processing the next line
                        Console.WriteLine($"Error parsing line: '{line}'. Exception: {ex.Message}");
                    }
                }
                else
                {
                    // Log the error and continue processing the next line
                    Console.WriteLine($"Incorrect format for line: '{line}'");
                }
            }

            return items;
        }

        public void WriteInventoryToFile(string filePath)
        {
            var lines = InventoryItems.Select(item => $"{item.Name},{item.Quantity},{item.Price}");
            File.WriteAllLines(filePath, lines);
        }

        public void AddItem(InventoryItem item)
        {
            InventoryItems.Add(item);
        }

        public void RemoveItem(InventoryItem item)
        {
            InventoryItems.Remove(item);
        }

        public void IncrementQuantity(InventoryItem item)
        {
            item.Quantity++;
        }

        public void DecrementQuantity(InventoryItem item)
        {
            if (item.Quantity > 0)
            {
                item.Quantity--;
            }
        }
    }
}
