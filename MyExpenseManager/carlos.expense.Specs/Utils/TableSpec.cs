using System;
using carlos.expense.core.Model;

namespace carlos.expense.specs.Utils
{
    public class TableSpec
    {
        public decimal Amount { get; set; }
        public DateTime RegisterDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
       
    }
}
