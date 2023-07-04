using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BillSplit
    {
        public int BillSplitId { get; set; }
        public Payment Payment { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal AmountPerPerson { get; set; }
    }
}
