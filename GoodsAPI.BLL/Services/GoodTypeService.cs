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
    public class GoodTypeService : IGoodTypeService
    {
        private readonly GoodTypeRepository repository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<GoodTypeDTO> validator;

        public GoodTypeService(GoodTypeRepository goodTypeRepository, IMapper mapper, AbstractValidator<GoodTypeDTO> validator)
        {
            this.repository = goodTypeRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public void Create(GoodTypeDTO goodType)
        {
            var validationResult = validator.Validate(goodType);
            if (validationResult.IsValid)
                repository.Create(mapper.Map<GoodType>(goodType));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(GoodTypeDTO goodType)
        {
            repository.Delete(mapper.Map<GoodType>(goodType));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public List<GoodTypeDTO> GetAll()
        {
            return mapper.Map<List<GoodTypeDTO>>(repository.GetAll());
        }

        public GoodTypeDTO GetById(int id)
        {
            return mapper.Map<GoodTypeDTO>(repository.GetById(id));
        }

        public void Update(int id, GoodTypeDTO goodType)
        {
            var validationResult = validator.Validate(goodType);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.Map<GoodType>(goodType));
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

        public void UpdateGoodTypeName(int id, string name)
        {
            var validationResult = validator.Validate(new GoodTypeDTO { Name = name }, "Name");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodTypeName(id, name);
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