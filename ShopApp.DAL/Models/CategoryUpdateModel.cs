

using ShopApp.DAL.Core;

namespace ShopApp.DAL.Models
{
    public class CategoryUpdateModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
