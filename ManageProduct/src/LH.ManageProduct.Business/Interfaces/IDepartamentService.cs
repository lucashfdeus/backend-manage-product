using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IDepartamentService : IDisposable
    {
        Task<IEnumerable<Department>> GetAllDepartment();
    }
}
