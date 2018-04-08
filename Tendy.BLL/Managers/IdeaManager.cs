using Tendy.BLL.Interfaces;
using System;
using System.Collections.Generic;
using Tendy.BLL.ViewModels;
using System.Linq;
using Tendy.Abstract;
using AutoMapper;
using Tendy.DAL.Entities;
using Tendy.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Tendy.Common.ViewModels;

namespace Tendy.BLL.Managers
{
	public class IdeaManager : IIdeaManager
	{
		IUnitOfWork uow;
		public IdeaManager(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public AggregateContent<IdeaViewModel> Search(IdeaSearchFilter filter)
		{
			var query = uow.IdeasRepository
			.GetAll();

			if (filter.IsUserAuthor)
			{
				query = query.Where(idea =>
				(idea.AuthorId == filter.AuthorId));
			}

			return new AggregateContent<IdeaViewModel>
			{
				Source = Mapper.Map<IEnumerable<Idea>, IEnumerable<IdeaViewModel>>(
							query
								.Skip((filter.Page - 1) * filter.PageSize)
								.Take(filter.PageSize)
								.OrderByDescending(item => item.DateOfCreation)
								.ToList()),
				Total = query.Count()
			};
		}

		public IdeaViewModel Get(int ideaId, string userId)
		{
			var idea = uow.IdeasRepository.FindSingle(ideaId);
			if (idea == null)
			{
				throw new CustomException(StatusCodes.Status404NotFound, ExceptionsMessages.CantFindIdea);
			}

			var ideaVm = Mapper.Map<Idea, IdeaViewModel>(idea);

			var request = uow.RequestsRepository
				.FindBy(req => req.IdeaId == ideaId && req.ApplicationUserId == userId)
				.FirstOrDefault();

			if (request != null)
			{
				ideaVm.IsUserJoined = request.IsActive.GetValueOrDefault();
			}
			
			return ideaVm;
		}

		public IdeaViewModel Create(IdeaViewModel ideaVm)
		{
			var idea = Mapper.Map<IdeaViewModel, Idea>(ideaVm);

			if (idea == null)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantCreateIdea, new NullReferenceException());
			}

			idea.DateOfCreation = DateTime.UtcNow;

			try
			{
				var createdIdea = uow.IdeasRepository.Create(idea);
				uow.SaveChanges();
				return Mapper.Map<Idea, IdeaViewModel>(createdIdea);
			}
			catch (Exception ex)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantCreateIdea, ex);
			}
		}

		public IdeaViewModel Update(IdeaViewModel ideaVm)
		{
			var idea = Mapper.Map<IdeaViewModel, Idea>(ideaVm);
			try
			{
				var updatedIdea = uow.IdeasRepository.Update(idea);
				uow.SaveChanges();
				return Mapper.Map<Idea, IdeaViewModel>(updatedIdea);
			}
			catch (Exception ex)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantEditeIdea, ex);
			}
		}

		public bool Delete(int ideaId)
		{
			try
			{
				uow.IdeasRepository.Delete(ideaId);
				uow.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantDeleteIdea, ex);
			}
		}
	}
}