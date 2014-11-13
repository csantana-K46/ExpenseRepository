using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carlos.expense.core.IRepository;
using carlos.expense.core.Model;

namespace carlos.expense.core.FakeRepository
{
   public class FakeCategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>
       {
           new Category{Id = 1,CreationDate = DateTime.Now, Name = "Food"},
           new Category{Id = 2,CreationDate = DateTime.Now, Name = "Dress"},
           new Category{Id = 3,CreationDate = DateTime.Now, Name = "Transport"},
       };

        private bool _submitCategorySave = false;

        public void RegisterCategory(Model.Category category)
        {
            _categories.Add(category);

        }

        public void EditCategory(Model.Category category)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Category> GetCategories()
        {
            //Para los fines
            return _categories;
        }

        public Model.Category GetCategoryById(int id)
        {
            return (from cat in _categories
                    where (cat.Id == id)
                    select cat).FirstOrDefault();
        }

        public void CategorySave()
        {
            _submitCategorySave = true;
        }
    }
}
