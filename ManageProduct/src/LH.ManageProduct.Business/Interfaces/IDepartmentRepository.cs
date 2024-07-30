using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IDepartmentRepository : IRepositoryDapper<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> CreateDepartment(Department department);

    }
}
