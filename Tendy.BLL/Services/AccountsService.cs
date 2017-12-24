using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;
using Tendy.Common.Exceptions;
using Tendy.DAL.Entities;

namespace Tendy.BLL.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<RegistrationViewModel> Create(RegistrationViewModel regModel)
        {
            var userIdentity = _mapper.Map<ApplicationUser>(regModel);

            var result = await _userManager.CreateAsync(userIdentity, regModel.Password);

            if (!result.Succeeded)
            {
                throw new CustomException(StatusCodes.Status501NotImplemented, BLLExceptionsMessages.CantRegisterAccount);
            }

            return regModel;
        }
    }
}
