﻿using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.DAL.Repositories;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountRepository repository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<AccountDTO> validator;

        public AccountService(AccountRepository accountRepository, IMapper mapper, AbstractValidator<AccountDTO> validator)
        {
            this.repository = accountRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public List<AccountDTO> GetAll()
        {
            var result = new List<AccountDTO>();
            foreach (var item in repository.GetAll())
            {
                result.Add(mapper.MapAccount(item));
            }
            return result;
        }

        public AccountDTO GetById(int id)
        {
            return mapper.MapAccount(repository.GetById(id));
        }

        public int Create(AccountDTO account)
        {
            var validationResult = validator.Validate(account);
            if (validationResult.IsValid)
                return repository.Create(mapper.MapAccount(account));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Update(int id, AccountDTO account)
        {
            var validationResult = validator.Validate(account);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.MapAccount(account));
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

        public void UpdateAccountByChangingName(int id, string name)
        {
            var validationResult = validator.Validate(new AccountDTO() { Name = name }, "Name");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateAccountByChangingName(id, name);
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

        public void UpdateByChangingSum(int id, decimal sum)
        {
            var validationResult = validator.Validate(new AccountDTO() { Sum = sum }, "Sum");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.UpdateByChangingSum(id, sum);
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

        public void Delete(AccountDTO account)
        {
            repository.Delete(mapper.MapAccount(account));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }
    }
}