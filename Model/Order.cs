using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TableId { get; set; }
        public string Status { get; set; }
        public TimeSpan PlacedTime { get; set; }
    }

    public class OrderRestaurantView : Order
    {
        public int? Quantity { get; set; }
        public string? Note { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? MenuItemName { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAlcholic { get; set; }
        public string? MenuType { get; set; }
        public string? CategoryName { get; set; }
        public string? EmployeeName { get; set; }
        public int? TableNumber { get; set; }
        public string? TableStatus { get; set; }

    }
}
