using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carlos.expense.core.Model
{
   public class Expense
    {
        public int Id { get; set; }// The unique key
        public decimal Amount { get; set; }
        public DateTime RegisterDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }     
    }
}
