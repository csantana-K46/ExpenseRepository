using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyExpenseManager.Models
{
    public class ExpenseHistoryViewModel
    {
        [DisplayName("From Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }
    }
}