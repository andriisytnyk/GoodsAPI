using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.DAL.Repositories;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace GoodsAPI.BLL.Services
{
    public class BillService : IBillService
    {
        private readonly AccountRepository accountRepository;
        private readonly BillRepository billRepository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<BillDTO> validator;

        public BillService(AccountRepository accountRepository, BillRepository billRepository, IMapper mapper, AbstractValidator<BillDTO> validator)
        {
            this.accountRepository = accountRepository;
            this.billRepository = billRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public List<BillDTO> GetAll()
        {
            var result = new List<BillDTO>();
            foreach (var item in billRepository.GetAll())
            {
                result.Add(mapper.MapBill(item));
            }
            return result;
        }

        public BillDTO GetById(int id)
        {
            return mapper.MapBill(billRepository.GetById(id));
        }

        public int Create(BillDTO bill)
        {
            var validationResult = validator.Validate(bill);
            if (validationResult.IsValid)
                return billRepository.Create(mapper.MapBill(bill));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Update(int id, BillDTO bill)
        {
            var validationResult = validator.Validate(bill);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                billRepository.Update(id, mapper.MapBill(bill));
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
                accountRepository.GetById(account.Id);
                billRepository.UpdateBillByAddingAccount(id, mapper.MapAccount(account));
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
                billRepository.UpdateBillByDeletingAccount(id, sum);
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

        public void Delete(BillDTO bill)
        {
            billRepository.Delete(mapper.MapBill(bill));
        }

        public void DeleteById(int id)
        {
            billRepository.DeleteById(id);
        }
    }
}