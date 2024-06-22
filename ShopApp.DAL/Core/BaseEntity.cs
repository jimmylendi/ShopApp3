

namespace ShopApp.DAL.Core
{
    public abstract class BaseEntity
    {
<<<<<<< HEAD
        public DateTime Creation_Date { get; set; }
        public int Creation_User { get; set; }
        public DateTime? Modify_Date { get; set; }
        public int? Modify_User { get; set; }
        public int? Delete_User { get; set; }
        public DateTime? Delete_Date { get; set; }
=======
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyUser { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
        public bool Deleted { get; set; }
    }
}
