
using ShopApp.DAL.Models;

namespace ShopApp.DAL.Interface
{
    public interface ICategoryDb
    {
        List<CategoryModel> GetCategories();
        CategoryModel GetCategory(int id);
        void SaveCategory(CategoryAddModel categoryAdd);
        void UpdateCategory(CategoryUpdateModel categoryUpdate);
        void RemoveCategory(int categoryId);
    }
}
