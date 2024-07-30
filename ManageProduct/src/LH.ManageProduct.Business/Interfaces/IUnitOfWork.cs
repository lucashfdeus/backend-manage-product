namespace LH.ManageProduct.Business.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
