﻿using AutoMapper;
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
	public class AttachmentsManager : IAttachmentsManager
	{
		IUnitOfWork _uow;
		public AttachmentsManager(IUnitOfWork uow)
		{
			_uow = uow;
		}

		public IEnumerable<LinkViewModel> GetLinks(int ideaId)
		{
			var links = _uow.LinksRepository.FindBy(link => link.IdeaId == ideaId);

			return Mapper.Map<IEnumerable<Link>, IEnumerable<LinkViewModel>>(links);
		}		

		public bool UpdateLinks(int ideaId, IEnumerable<LinkViewModel> links)
		{
			var linkToUpdate = Mapper.Map<IEnumerable<LinkViewModel>, IEnumerable<Link>>(links);
			var oldLinks = _uow.LinksRepository.FindBy(link => link.IdeaId == ideaId).ToList();

			var toCreate = linkToUpdate.Where(x => !oldLinks.Any(link => link.Id == x.Id));
			var toDetete = oldLinks.Where(x => !linkToUpdate.Any(link => link.Id == x.Id));
			var toUpdate = oldLinks.Where(x => linkToUpdate.Any(link => link.Id == x.Id));

			try
			{
				foreach (var item in toCreate)
				{
					item.Id = 0;
					_uow.LinksRepository.Create(item);
				}

				foreach (var item in toUpdate)
				{
					_uow.LinksRepository.Update(item);
				}

				foreach (var item in toDetete)
				{
					_uow.LinksRepository.Delete(item);
				}

				_uow.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantUpdateLinks, ex);
			}
		}

		public IEnumerable<FileViewModel> GetFiles(int ideaId)
		{
			var files = _uow.FilesRepository.FindBy(link => link.IdeaId == ideaId);

			return Mapper.Map<IEnumerable<File>, IEnumerable<FileViewModel>>(files);
		}

		public bool UpdateFile(int ideaId, IEnumerable<FileViewModel> links)
		{
			var linkToUpdate = Mapper.Map<IEnumerable<FileViewModel>, IEnumerable<File>>(links);
			var oldLinks = _uow.FilesRepository.FindBy(link => link.IdeaId == ideaId).ToList();

			var toCreate = linkToUpdate.Where(x => !oldLinks.Any(link => link.Id == x.Id));
			var toDetete = oldLinks.Where(x => !linkToUpdate.Any(link => link.Id == x.Id));
			var toUpdate = oldLinks.Where(x => linkToUpdate.Any(link => link.Id == x.Id));

			try
			{
				foreach (var item in toCreate)
				{
					item.Id = 0;
					_uow.FilesRepository.Create(item);
				}

				foreach (var item in toUpdate)
				{
					_uow.FilesRepository.Update(item);
				}

				foreach (var item in toDetete)
				{
					_uow.FilesRepository.Delete(item);
				}

				_uow.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new CustomException(StatusCodes.Status501NotImplemented, ExceptionsMessages.CantUpdateFiles, ex);
			}
		}
	}
}
