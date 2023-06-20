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
        public List<OrderItem> OrderItems { get; set; }
        public TimeSpan WaitingTime
        {
            get
            {
                TimeSpan waitingTime = PlacedTime - DateTime.Now;
                return waitingTime.Duration();
            }
        }
        public string FormattedWaitingTime
        {
            get
            {
                TimeSpan waitingTime = WaitingTime;
                return $"{(int)waitingTime.TotalMinutes} min {(int)waitingTime.Seconds} sec";
            }
        }
    }
}
