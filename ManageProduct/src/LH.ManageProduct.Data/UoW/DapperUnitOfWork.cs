using LH.ManageProduct.Business.Interfaces;
using System.Data;

namespace LH.ManageProduct.Data.UoW
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public DapperUnitOfWork(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _transaction = _connection.BeginTransaction();
        }

        public async Task<bool> Commit()
        {
            try
            {
                await Task.Run(() => _transaction.Commit());
                return true;
            }
            catch
            {
                Rollback();
                return false;
            }
        }

        private void Rollback()
        {
            _transaction?.Rollback();
        }

        public void Dispose()
        {
            Rollback();
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
