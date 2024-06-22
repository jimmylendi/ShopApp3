

using ShopApp.DAL.Context;
using ShopApp.DAL.Entities;
using ShopApp.DAL.Exceptions;
using ShopApp.DAL.Models;

namespace ShopApp.DAL.Daos
{
    public class CategoryDb : ICategory
    {
        private readonly ShopContext context;

        public CategoryDb(ShopContext context)
        {
            this.context = context;
        }

        public CategoryModel? GetCategory(int CategoryId)
        {
            try
            {
                var category = context.Categories.Find(CategoryId);
                if (category == null || category.Deleted)
                    throw new EntidadNoEncontradaException($"Categoría con ID {CategoryId} no encontrada o ya eliminada.");

                return new CategoryModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    CreationDate = category.CreationDate,
                    CreationUser = category.CreationUser,
                    ModifyDate = category.ModifyDate,
                    ModifyUser = category.ModifyUser,
                    DeleteUser = category.DeleteUser,
                    DeleteDate = category.DeleteDate,
                    Deleted = category.Deleted
                };
            }
            catch (EntidadNoEncontradaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDatosException("Error al recuperar la categoría.", ex);
            }
        }

        public List<CategoryModel> GetCategory()
        {
            try
            {
                return context.Categories
                    .Where(c => !c.Deleted)
                    .Select(category => new CategoryModel
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                        CreationDate = category.CreationDate,
                        CreationUser = category.CreationUser,
                        ModifyDate = category.ModifyDate,
                        ModifyUser = category.ModifyUser,
                        DeleteUser = category.DeleteUser,
                        DeleteDate = category.DeleteDate,
                        Deleted = category.Deleted
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDatosException("Error al recuperar las categorías.", ex);
            }
        }

        public void RemoveCategory(CategoryRemoveModel CategoryRemove)
        {
            try
            {
                var category = context.Categories.Find(CategoryRemove.CategoryId);
                if (category == null)
                    throw new EntidadNoEncontradaException($"Categoría con ID {CategoryRemove.CategoryId} no encontrada.");
                if (category.Deleted)
                    throw new EntidadYaEliminadaException($"Categoría con ID {CategoryRemove.CategoryId} ya está eliminada.");

                category.Deleted = true;
                category.DeleteDate = DateTime.Now;
                category.DeleteUser = GetCurrentUserId();
                context.SaveChanges();
            }
            catch (EntidadNoEncontradaException)
            {
                throw;
            }
            catch (EntidadYaEliminadaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDatosException("Error al eliminar la categoría.", ex);
            }
        }

        public void SaveCategory(CategoryAddModel CategoryAdd)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = CategoryAdd.CategoryName,
                    Description = CategoryAdd.Description,
                    CreationDate = DateTime.Now,
                    CreationUser = GetCurrentUserId(),
                    Deleted = false
                };

                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDatosException("Error al guardar la categoría.", ex);
            }
        }

        public void UpdateCategory(CategoryUpdateModel CategoryUpdate)
        {
            try
            {
                var category = context.Categories.Find(CategoryUpdate.CategoryId);
                if (category == null)
                    throw new EntidadNoEncontradaException($"Categoría con ID {CategoryUpdate.CategoryId} no encontrada.");
                if (category.Deleted)
                    throw new EntidadYaEliminadaException($"Categoría con ID {CategoryUpdate.CategoryId} ya está eliminada.");

                category.CategoryName = CategoryUpdate.CategoryName;
                category.Description = CategoryUpdate.Description;
                category.ModifyDate = DateTime.Now;
                category.ModifyUser = GetCurrentUserId();
                context.SaveChanges();
            }
            catch (EntidadNoEncontradaException)
            {
                throw;
            }
            catch (EntidadYaEliminadaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDatosException("Error al actualizar la categoría.", ex);
            }
        }

        private int GetCurrentUserId()
        {
            
            return 1; 
        }
    }
}
