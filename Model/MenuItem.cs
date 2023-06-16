using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MenuItem
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAlcoholic { get; set; }
        public MenuCategory Category { get; set; }
        public string MenuType { get; set; }
        public int Stock { get; set; }
    }
}
