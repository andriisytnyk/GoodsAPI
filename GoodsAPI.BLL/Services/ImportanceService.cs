using FluentValidation;
using GoodsAPI.BLL.Interfaces;
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

        public List<ImportanceDTO> GetAll()
        {
            var result = new List<ImportanceDTO>();
            foreach (var item in repository.GetAll())
            {
                result.Add(mapper.MapImportance(item));
            }
            return result;
        }

        public ImportanceDTO GetById(int id)
        {
            return mapper.MapImportance(repository.GetById(id));
        }

        public int Create(ImportanceDTO importance)
        {
            var validationResult = validator.Validate(importance);
            if (validationResult.IsValid)
                return repository.Create(mapper.MapImportance(importance));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Update(int id, ImportanceDTO importance)
        {
            var validationResult = validator.Validate(importance);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.MapImportance(importance));
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

        public void Delete(ImportanceDTO importance)
        {
            repository.Delete(mapper.MapImportance(importance));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }
    }
}