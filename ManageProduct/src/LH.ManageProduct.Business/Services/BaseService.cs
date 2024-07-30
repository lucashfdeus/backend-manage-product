using FluentValidation;
using FluentValidation.Results;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Models;
using LH.ManageProduct.Business.Notification;

namespace LH.ManageProduct.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotification _notification;
        private readonly IDapperUnitOfWork _uow;

        protected BaseService(INotification notification, IDapperUnitOfWork uow)
        {
            _notification = notification;
            _uow = uow;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notify(item.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notification.Handle(new AppNotification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

        protected async Task<bool> Commit()
        {
            if (await _uow.Commit()) return true;

            Notify("Não foi possível salvar os dados no banco!");
            return false;
        }
    }
}
