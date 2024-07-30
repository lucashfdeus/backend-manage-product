using AutoMapper;
using LH.ManageProduct.Api.Controllers;
using LH.ManageProduct.Api.ViewModels;
using LH.ManageProduct.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LH.ManageProduct.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/departments")]
    public class DepartmentController : MainController
    {
        private readonly IDepartamentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(INotification notification, IMapper mapper, IDepartamentService departmentService, IUser user) : base(notification, user)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<DepartmentViewModel>>(await _departmentService.GetAllDepartment());
        }
    }
}
