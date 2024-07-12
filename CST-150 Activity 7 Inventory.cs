using CST_150_ListTogv.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CST_150_ListTogv.BusinessLayer
{
    internal class Inventory
    {
        public List<InvItem> ReadInventory(List<InvItem> invItems)
        {
            string dirLoc = Application.StartupPath + "Fuzzies,.txt";

            using (var str = File.OpenText(dirLoc))
            {
                foreach (string line in File.ReadLines(dirLoc, Encoding.UTF8))
                {
                    string[] rowData = line.Split(",");

                    invItems.Add(new InvItem(rowData[0].ToString().Trim(),
                        rowData[1].ToString().Trim(), Convert.ToInt32(rowData[2])));
                }
            }
            //Return the list.
            return invItems;
        }

        public List<InvItem> IncQtyValue(List<InvItem> invItems, int selectedRowIndex) 
        {
            int updatedQty = ++invItems[selectedRowIndex].Qty;
            invItems[selectedRowIndex].Qty = updatedQty;
            return invItems;
        }

        /// <summary>
        /// Search the item in the main Inventory List and return the New Search List
        /// </summary>
        /// <param name="invItems"></param>
        /// <param name="searchItem"></param>
        /// <param name="searchCriteria"></param>
        /// <returns></returns>
        public List<InvItem> SearchItem(List<InvItem> invItems, List<InvItem> invSearch, string searchCriteria) 
        {
            invSearch.Clear();

            foreach(InvItem item in invItems)
            {
                if (item.Type.ToLower().Contains(searchCriteria.ToLower()))
                {
                    invSearch.Add(item);
                }
            }
            return invItems;

        }
    }
}
