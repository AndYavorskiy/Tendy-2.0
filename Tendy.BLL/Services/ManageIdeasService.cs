using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tendy.Abstract;
using Tendy.BLL.Interfaces;
using Tendy.DAL.Entities;

namespace Tendy.BLL.Services
{
	public class ManageIdeasService : IManageIdeasService
	{
		IUnitOfWork uow;
		public ManageIdeasService(IUnitOfWork uow)
		{
			this.uow = uow;
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
	}
}
