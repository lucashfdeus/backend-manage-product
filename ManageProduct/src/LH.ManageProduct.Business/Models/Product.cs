using Dapper.Contrib.Extensions;

namespace LH.ManageProduct.Business.Models
{
    [Table("products")]
    public class Product : Entity
    {
        public string DepartmentCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; } = true;
    }
}
