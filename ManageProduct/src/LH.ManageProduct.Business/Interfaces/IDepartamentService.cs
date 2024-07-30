using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IDepartamentService : IDisposable
    {
        Task CreateDepartmentsAsync(IEnumerable<Department> departments);

        Task<IEnumerable<Department>> GetAllDepartment();
    }
}
