using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST_150_ListTogv.Models
{
    /// <summary>
    /// Model Class that will structure all my inventory items. 
    /// </summary>
    internal class InvItem
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int Qty { get; set; }

        /// <summary>
        /// Model CLass Pararmterized Constructor.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="qty"></param>
        public InvItem(string type, string color, int qty)
        {
            Type = type;
            Color = color;
            Qty = qty;
        }
    }
}
