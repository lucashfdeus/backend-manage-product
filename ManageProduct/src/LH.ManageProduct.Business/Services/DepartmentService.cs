using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Services
{
    public class DepartmentService : BaseService, IDepartamentService
    {
        private readonly IDepartmentRepository _departamentRepository;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

        public DepartmentService(INotification notification, IDepartmentRepository departamentRepository, IDapperUnitOfWork dapperUnitOfWork) : base(notification, dapperUnitOfWork)
        {
            _departamentRepository = departamentRepository;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await _departamentRepository.GetAllDepartment();
        }
        public async Task CreateDepartmentsAsync(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                await _departamentRepository.CreateDepartment(department);
            }
        }

        public void Dispose()
        {
            _departamentRepository.Dispose();
        }
    }
}
