using AutoMapper;
using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.DAL.Models;
using GoodsAPI.DAL.Repositories;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Services
{
    public class ImportanceService : IImportanceService
    {
        private readonly ImportanceRepository repository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<ImportanceDTO> validator;

        public ImportanceService(ImportanceRepository importanceRepository, IMapper mapper, AbstractValidator<ImportanceDTO> validator)
        {
            this.repository = importanceRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public void Create(ImportanceDTO importance)
        {
            var validationResult = validator.Validate(importance);
            if (validationResult.IsValid)
                repository.Create(mapper.Map<Importance>(importance));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(ImportanceDTO importance)
        {
            repository.Delete(mapper.Map<Importance>(importance));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public List<ImportanceDTO> GetAll()
        {
            return mapper.Map<List<ImportanceDTO>>(repository.GetAll());
        }

        public ImportanceDTO GetById(int id)
        {
            return mapper.Map<ImportanceDTO>(repository.GetById(id));
        }

        public void Update(int id, ImportanceDTO importance)
        {
            var validationResult = validator.Validate(importance);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.Map<Importance>(importance));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateImportanceName(int id, string name)
        {
            var validationResult = validator.Validate(new ImportanceDTO { Name = name }, "Name");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateImportanceName(id, name);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}