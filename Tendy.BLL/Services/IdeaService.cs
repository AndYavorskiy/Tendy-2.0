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

namespace Tendy.BLL.Services
{
    public class IdeaService : IIdeasService
    {
        IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public IdeaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<IdeaViewModel> GetAll()
        {
            var allIdeas = _uow.IdeasRepository.GetAll().ToList();
            return Mapper.Map<IEnumerable<Idea>, IEnumerable<IdeaViewModel>>(allIdeas);
        }

        public IdeaViewModel GetById(int id)
        {
            var idea = _uow.IdeasRepository.FindSingle(id);
            if (idea == null)
            {
                throw new CustomException(StatusCodes.Status404NotFound, BLLExceptionsMessages.CantFindIdea);
            }
            return Mapper.Map<Idea, IdeaViewModel>(idea);
        }

        public IdeaViewModel Create(IdeaViewModel ideaVm)
        {
            var idea = Mapper.Map<IdeaViewModel, Idea>(ideaVm);

            if (idea == null)
            {
                throw new CustomException(StatusCodes.Status501NotImplemented, BLLExceptionsMessages.CantCreateIdea, new NullReferenceException());
            }

            idea.DateOfCreation = DateTime.UtcNow;

            try
            {
                var createdIdea = _uow.IdeasRepository.Create(idea);
                _uow.SaveChanges();
                return Mapper.Map<Idea, IdeaViewModel>(createdIdea);
            }
            catch (Exception ex)
            {
                throw new CustomException(StatusCodes.Status501NotImplemented, BLLExceptionsMessages.CantCreateIdea, ex);
            }
        }

        public IdeaViewModel Update(IdeaViewModel ideaVm)
        {
            var idea = Mapper.Map<IdeaViewModel, Idea>(ideaVm);
            try
            {
                var updatedIdea = _uow.IdeasRepository.Update(idea);
                _uow.SaveChanges();
                return Mapper.Map<Idea, IdeaViewModel>(updatedIdea);
            }
            catch (Exception ex)
            {
                throw new CustomException(StatusCodes.Status501NotImplemented, BLLExceptionsMessages.CantEditeIdea, ex);
            }
        }

        public bool Delete(int ideaId)
        {
            try
            {
                _uow.IdeasRepository.Delete(ideaId);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new CustomException(StatusCodes.Status501NotImplemented, BLLExceptionsMessages.CantDeleteIdea, ex);
            }
        }
    }
}