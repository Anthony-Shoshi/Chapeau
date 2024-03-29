﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Tip { get; set; }
        public decimal Amount { get; set; }
        public decimal CashAmount { get; set; }
        public string Comment { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}
