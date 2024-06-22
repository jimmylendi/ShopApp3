<<<<<<< HEAD
﻿using ShopApp.DAL.Context;
using ShopApp.DAL.Entities;
using ShopApp.DAL.Exceptions;
using ShopApp.DAL.Interface;
=======
﻿

using ShopApp.DAL.Context;
using ShopApp.DAL.Entities;
using ShopApp.DAL.Exceptions;
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
using ShopApp.DAL.Models;

namespace ShopApp.DAL.Daos
{
<<<<<<< HEAD
    public class CategoryDb : ICategoryDb
=======
    public class CategoryDb : ICategory
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
    {
        private readonly ShopContext context;

        public CategoryDb(ShopContext context)
        {
            this.context = context;
        }

<<<<<<< HEAD
        // Get all categories
        List<CategoryModel> ICategoryDb.GetCategories()
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
                        CreationDate = category.Creation_Date,
                        CreationUser = category.Creation_User,
                        ModifyDate = category.Modify_Date,
                        ModifyUser = category.Modify_User,
                        DeleteUser = category.Delete_User,
                        DeleteDate = category.Delete_Date,
                        Deleted = category.Deleted
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new OperacionBaseDatosException("Error al recuperar las categorías.", ex);
            }
        }

       
        CategoryModel ICategoryDb.GetCategoryDb(int id)
        {
            try
            {
                var category = context.Categories.Find(id);
                if (category == null || category.Deleted)
                    throw new EntidadNoEncontradaException($"Categoría con ID {id} no encontrada o ya eliminada.");
=======
        public CategoryModel? GetCategory(int CategoryId)
        {
            try
            {
                var category = context.Categories.Find(CategoryId);
                if (category == null || category.Deleted)
                    throw new EntidadNoEncontradaException($"Categoría con ID {CategoryId} no encontrada o ya eliminada.");
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f

                return new CategoryModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
<<<<<<< HEAD
                    CreationDate = category.Creation_Date,
                    CreationUser = category.Creation_User,
                    ModifyDate = category.Modify_Date,
                    ModifyUser = category.Modify_User,
                    DeleteUser = category.Delete_User,
                    DeleteDate = category.Delete_Date,
=======
                    CreationDate = category.CreationDate,
                    CreationUser = category.CreationUser,
                    ModifyDate = category.ModifyDate,
                    ModifyUser = category.ModifyUser,
                    DeleteUser = category.DeleteUser,
                    DeleteDate = category.DeleteDate,
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
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

<<<<<<< HEAD
    
        void ICategoryDb.RemoveCategory(int categoryId)
        {
            try
            {
                var category = context.Categories.Find(categoryId);
                if (category == null)
                    throw new EntidadNoEncontradaException($"Categoría con ID {categoryId} no encontrada.");
                if (category.Deleted)
                    throw new EntidadYaEliminadaException($"Categoría con ID {categoryId} ya está eliminada.");

                category.Deleted = true;
                category.Delete_Date = DateTime.Now;
                category.Delete_User = GetCurrentUserId();
=======
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
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
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

<<<<<<< HEAD
    
        void ICategoryDb.SaveCategory(CategoryAddModel categoryAdd)
=======
        public void SaveCategory(CategoryAddModel CategoryAdd)
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
        {
            try
            {
                var category = new Category
                {
<<<<<<< HEAD
                    CategoryName = categoryAdd.CategoryName,
                    Description = categoryAdd.Description,
                    Creation_Date = DateTime.Now,
                    Creation_User = GetCurrentUserId(),
=======
                    CategoryName = CategoryAdd.CategoryName,
                    Description = CategoryAdd.Description,
                    CreationDate = DateTime.Now,
                    CreationUser = GetCurrentUserId(),
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
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

<<<<<<< HEAD
   
        void ICategoryDb.UpdateCategory(CategoryUpdateModel categoryUpdate)
        {
            try
            {
                var category = context.Categories.Find(categoryUpdate.CategoryId);
                if (category == null)
                    throw new EntidadNoEncontradaException($"Categoría con ID {categoryUpdate.CategoryId} no encontrada.");
                if (category.Deleted)
                    throw new EntidadYaEliminadaException($"Categoría con ID {categoryUpdate.CategoryId} ya está eliminada.");

                category.CategoryName = categoryUpdate.CategoryName;
                category.Description = categoryUpdate.Description;
                category.Modify_Date = DateTime.Now;
                category.Modify_User = GetCurrentUserId();
=======
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
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
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

<<<<<<< HEAD

        private int GetCurrentUserId()
        {
            return 1;
        }
    }
}
=======
        private int GetCurrentUserId()
        {
            
            return 1; 
        }
    }
}
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
