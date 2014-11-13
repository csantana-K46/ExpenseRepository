using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using carlos.expense.core.Model;

namespace MyExpenseManager.Models
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public decimal Amount { get; set; }
        [DisplayName("Register Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }
        public int SelectedValue { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Expense Category")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}