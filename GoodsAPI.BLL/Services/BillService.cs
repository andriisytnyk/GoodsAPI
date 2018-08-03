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
    public class BillService : IBillService
    {
        private readonly BillRepository repository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<BillDTO> validator;

        public BillService(BillRepository billRepository, IMapper mapper, AbstractValidator<BillDTO> validator)
        {
            this.repository = billRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public void Create(BillDTO bill)
        {
            var validationResult = validator.Validate(bill);
            if (validationResult.IsValid)
                repository.Create(mapper.Map<Bill>(bill));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(BillDTO bill)
        {
            repository.Delete(mapper.Map<Bill>(bill));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public List<BillDTO> GetAll()
        {
            return mapper.Map<List<BillDTO>>(repository.GetAll());
        }

        public BillDTO GetById(int id)
        {
            return mapper.Map<BillDTO>(repository.GetById(id));
        }

        public void Update(int id, BillDTO bill)
        {
            var validationResult = validator.Validate(bill);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.Map<Bill>(bill));
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

        public void UpdateBillByAddingAccount(int id, AccountDTO account)
        {
            try
            {
                repository.UpdateBillByAddingAccount(id, mapper.Map<Account>(account));
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

        public void UpdateBillByDeletingAccount(int id, decimal sum)
        {
            try
            {
                repository.UpdateBillByDeletingAccount(id, sum);
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