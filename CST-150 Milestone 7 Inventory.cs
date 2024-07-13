using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_150_Milestone_5.BusinessLogic
{
    internal class Inventory
    {
        public List<InvItem> ReadInventory(List<InvItem> invItems)
        {
            string dirLoc = Path.Combine(Application.StartupPath, "Fuzzies,.txt");

            try
            {
                using (var str = File.OpenText(dirLoc))
                {
                    foreach (string line in File.ReadLines(dirLoc, Encoding.UTF8))
                    {
                        string[] rowData = line.Split(',');

                        if (rowData.Length >= 3 &&
                            double.TryParse(rowData[1].Trim(), out double price) &&
                            int.TryParse(rowData[2].Trim(), out int quantity))
                        {
                            invItems.Add(new InvItem(rowData[0].Trim(), price, quantity));
                        }
                        else
                        {
                            // Handle invalid data format
                            Console.WriteLine($"Invalid data format in line: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle file read errors
                Console.WriteLine($"Error reading the inventory file: {ex.Message}");
            }

            // Return the list.
            return invItems;
        }

        public List<InvItem> SearchItem(List<InvItem> invItems, List<InvItem> invSearch, string searchCriteria)
        {
            invSearch.Clear();

            foreach (InvItem item in invItems)
            {
                if (item.Name.ToLower().Contains(searchCriteria.ToLower()))
                {
                    invSearch.Add(item);
                }
            }
            return invItems;

        }
        public List<InvItem> IncQtyValue(List<InvItem> invItems, int selectedRowIndex)
        {
            int updatedQty = ++invItems[selectedRowIndex].Qty;
            invItems[selectedRowIndex].Qty = updatedQty;
            return invItems;
        }
    }

}
