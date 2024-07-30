using LH.ManageProduct.Business.Models;
using System.Linq.Expressions;

namespace LH.ManageProduct.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);

        Task<int> SaveChanges();
    }
}