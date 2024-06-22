using ShopApp.DAL.Core;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f


namespace ShopApp.DAL.Entities
{
    public class Employee : BaseEntity
    {
<<<<<<< HEAD

        [Key]
=======
>>>>>>> ed3316a4a3d191c1aeac7b02936e144c682a475f
        public int EmpId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public int MgrId { get; set; }
    }
}
