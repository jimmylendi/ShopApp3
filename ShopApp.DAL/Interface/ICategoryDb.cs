
using ShopApp.DAL.Models;

namespace ShopApp.DAL.Interface
{
    public interface ICategoryDb
    {
        List<CategoryModel> GetCategories();
<<<<<<< HEAD
        CategoryModel GetCategoryDb(int id);
=======
        CategoryModel GetCategory(int id);
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
        void SaveCategory(CategoryAddModel categoryAdd);
        void UpdateCategory(CategoryUpdateModel categoryUpdate);
        void RemoveCategory(int categoryId);
    }
}
