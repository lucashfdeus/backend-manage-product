using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Data.Context;

namespace LH.ManageProduct.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManageProductDbContext _context;

        public UnitOfWork(ManageProductDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
