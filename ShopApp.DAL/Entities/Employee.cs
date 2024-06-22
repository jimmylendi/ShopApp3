using ShopApp.DAL.Core;


namespace ShopApp.DAL.Entities
{
    public class Employee : BaseEntity
    {
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
