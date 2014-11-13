using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carlos.expense.core.Model;

namespace carlos.expense.core.IRepository
{
   public interface ICategoryRepository
    {
        void RegisterCategory(Category category);
        void EditCategory(Category category);
        IList<Category> GetCategories();
        Category GetCategoryById(int id);
        void CategorySave();
    }
}
