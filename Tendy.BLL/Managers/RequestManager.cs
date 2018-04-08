using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Tendy.Abstract;
using Tendy.BLL.Interfaces;
using Tendy.BLL.ViewModels;
using Tendy.Common.Exceptions;
using Tendy.DAL.Entities;

namespace Tendy.BLL.Managers
{
	public class RequestManager : IRequestManager
	{
		IUnitOfWork uow;
		public RequestManager(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public IEnumerable<RequestViewModel> GetRequests(int? ideaId)
		{
			var requests = uow.RequestsRepository
				.FindBy(req => req.IdeaId == ideaId)
				.Where(req => req.IsActive.GetValueOrDefault())
				.ToList();

			var usersIds = requests
				.Select(req => req.ApplicationUserId)
				.ToList();

			var users = uow.ApplicationUsersRepository
				.FindBy(user => usersIds.Contains(user.Id))
				.Select(user => new { user.Id, user.UserName })
				.ToList();

			var result = Mapper.Map<IEnumerable<Request>, IEnumerable<RequestViewModel>>(requests);

			return result.Join(
				users,
				res => res.ApplicationUserId,
				user => user.Id,
				(res, user) =>
				{
					res.UserName = user.UserName;

					return res;
				});
		}

		public bool UpdateJoinRequest(int ideaId, string userId)
		{
			var requestToUpdate = uow.RequestsRepository
				.FindBy(req => req.IdeaId == ideaId && req.ApplicationUserId == userId)
				.FirstOrDefault();

			if (requestToUpdate == null)
			{
				Request request = new Request()
				{
					ApplicationUserId = userId,
					IdeaId = ideaId,
					IsActive = true,
					DateOfJoining = DateTime.UtcNow
				};

				uow.RequestsRepository
					.Create(request);
			}
			else
			{
				requestToUpdate.IsActive = !requestToUpdate.IsActive;

				uow.RequestsRepository
					.Update(requestToUpdate);
			}

			uow.SaveChanges();

			return true;
		}

		public bool ConfirmRequest(int ideaId, int requestId, string userId, string managerId)
		{
			var allowEdit = uow.IdeasRepository
				.FindBy(idea => idea.Id == idea.Id && idea.AuthorId == managerId)
				.SingleOrDefault();

			if (allowEdit == null)
			{
				throw new CustomException(StatusCodes.Status403Forbidden, ExceptionsMessages.CannotAcceptDeclaimRequest);
			}

			var requestToUpdate = uow.RequestsRepository
				.FindBy(req => req.IdeaId == ideaId && req.ApplicationUserId == userId)
				.FirstOrDefault();

			if (requestToUpdate == null)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CannotAcceptDeclaimRequest);
			}

			requestToUpdate.IsAccepted = !requestToUpdate.IsAccepted;

			uow.SaveChanges();

			return true;
		}
	}
}
