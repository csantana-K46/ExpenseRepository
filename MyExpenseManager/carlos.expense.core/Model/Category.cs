using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carlos.expense.core.Model
{
   public class Category
    {
        public int Id { get; set; }// The unique key
        public String Name { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
