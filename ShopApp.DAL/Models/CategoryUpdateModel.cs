

using ShopApp.DAL.Core;

namespace ShopApp.DAL.Models
{
    public class CategoryUpdateModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
<<<<<<< HEAD

        public DateTime? Modify_Date { get; set; }
        public int? Modify_User { get; set; } = 0;
=======
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
    }
}
