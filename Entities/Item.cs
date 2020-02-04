using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class Item
    {
        public int OrderedQuantity { get; set; }
        public Book Book { get; set; }
    }
}
