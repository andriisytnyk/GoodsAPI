using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.DAL.Repositories;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Services
{
    public class GoodService : IGoodService
    {
        private readonly GoodRepository repository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<GoodDTO> validator;

        public GoodService(GoodRepository goodRepository, IMapper mapper, AbstractValidator<GoodDTO> validator)
        {
            this.repository = goodRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public List<GoodDTO> GetAll()
        {
            var result = new List<GoodDTO>();
            foreach (var item in repository.GetAll())
            {
                result.Add(mapper.MapGood(item));
            }
            return result;
        }

        public GoodDTO GetById(int id)
        {
            return mapper.MapGood(repository.GetById(id));
        }

        public int Create(GoodDTO good)
        {
            var validationResult = validator.Validate(good);
            if (validationResult.IsValid)
                return repository.Create(mapper.MapGood(good));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Update(int id, GoodDTO good)
        {
            var validationResult = validator.Validate(good);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.MapGood(good));
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

        public void UpdateGoodByChangingBoughtDate(int id, DateTime boughtDate)
        {
            var validationResult = validator.Validate(new GoodDTO { BoughtDate = boughtDate }, "BoughtDate");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodByChangingBoughtDate(id, boughtDate);
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

        public void UpdateGoodByChangingCount(int id, float count)
        {
            var validationResult = validator.Validate(new GoodDTO { Count = count }, "Count");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodByChangingCount(id, count);
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

        public void UpdateGoodByChangingImportance(int id, ImportanceDTO goodImportance)
        {
            var validationResult = validator.Validate(new GoodDTO { GoodImportance = goodImportance }, "GoodImportance");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodByChangingImportance(id, mapper.MapImportance(goodImportance));
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

        public void UpdateGoodByChangingName(int id, string name)
        {
            var validationResult = validator.Validate(new GoodDTO { Name = name }, "Name");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodByChangingName(id, name);
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

        public void UpdateGoodByChangingPrice(int id, decimal price)
        {
            var validationResult = validator.Validate(new GoodDTO { Price = price }, "Price");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodByChangingPrice(id, price);
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

        public void UpdateGoodByChangingType(int id, GoodTypeDTO goodType)
        {
            var validationResult = validator.Validate(new GoodDTO { GoodType = goodType }, "GoodType");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateGoodByChangingType(id, mapper.MapGoodType(goodType));
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

        public void Delete(GoodDTO good)
        {
            repository.Delete(mapper.MapGood(good));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }
    }
}