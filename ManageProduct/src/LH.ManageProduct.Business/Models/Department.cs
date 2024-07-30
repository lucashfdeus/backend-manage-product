using Dapper.Contrib.Extensions;

namespace LH.ManageProduct.Business.Models
{
    [Table("departament")]
    public class Department : Entity
    {
        public  string Code { get; set; }
        public string Description { get; set; }
    }
}
