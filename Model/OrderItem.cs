using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
