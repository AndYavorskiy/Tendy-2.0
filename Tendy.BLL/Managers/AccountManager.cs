﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tendy.Abstract;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;
using Tendy.Common.Exceptions;
using Tendy.DAL.Entities;

namespace Tendy.BLL.Managers
{
	public class AccountManager : IAccountManager
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public AccountManager(UserManager<ApplicationUser> userManager, IUnitOfWork uow, IMapper mapper)
		{
			_userManager = userManager;
			_uow = uow;
			_mapper = mapper;
		}

		public async Task<RegistrationViewModel> CreateAccount(RegistrationViewModel regModel)
		{
			var userIdentity = _mapper.Map<ApplicationUser>(regModel);

			var result = await _userManager.CreateAsync(userIdentity, regModel.Password);

			if (!result.Succeeded)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantRegisterAccount);
			}

			return regModel;
		}

		public AccountSettingsViewModel UpdateSettings(AccountSettingsViewModel accConfig)
		{
			var configuration = _uow.AccountCofigurationRepository.FindSingle(accConfig.Id);

			if (configuration == null)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantUpdateAccountConfiguration);
			}

			configuration.IsAdminMode = accConfig.IsAdminMode;
			var result = _uow.AccountCofigurationRepository.Update(configuration);

			return _mapper.Map<AccountSettingsViewModel>(result);
		}
	}
}
