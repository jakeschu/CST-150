using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_150_Milestone_5.BusinessLogic
{
    internal class Inventory
    {
        public string[] InventoryLines { get; private set; }

        public Inventory(string filePath)
        {
            InventoryLines = ReadInventoryFromFile(filePath);
        }

        private string[] ReadInventoryFromFile(string filePath)
        {
            // Read the contents of the file
            return File.ReadAllLines(filePath);
        }
    }
}
