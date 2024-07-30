namespace LH.ManageProduct.Business.Interfaces
{
    public interface IDapperUnitOfWork
    {
        Task<bool> Commit();
    }
}
