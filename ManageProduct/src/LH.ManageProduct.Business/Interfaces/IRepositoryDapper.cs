using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IRepositoryDapper<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll(string sql, object parameters = null);
        Task<TEntity> GetById(string sql, object parameters);
        Task<int> Create(string sql, object parameters);
        Task<int> Update(string sql, object parameters);
        Task<int> Delete(string sql, object parameters);
    }
}
