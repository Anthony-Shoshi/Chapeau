using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public Employee Employee { get; set; }
        public Table Table { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PlacedTime { get; set; }
    }
}
