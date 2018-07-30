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
    public class UserService : IUserService
    {
        private readonly UserRepository repository;
        private readonly IMapper mapper;
        private readonly AbstractValidator<UserDTO> userValidator;
        private readonly AbstractValidator<GoodDTO> goodValidator;
        private readonly AbstractValidator<BillDTO> billValidator;
        private readonly AbstractValidator<GoodTypeDTO> goodTypeValidator;

        public UserService(UserRepository userRepository, IMapper mapper, AbstractValidator<UserDTO> userValidator)
        {
            this.repository = userRepository;
            this.mapper = mapper;
            this.userValidator = userValidator;
        }

        public void Create(UserDTO user)
        {
            var validationResult = userValidator.Validate(user);
            if (validationResult.IsValid)
                repository.Create(mapper.Map<User>(user));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(UserDTO user)
        {
            repository.Delete(mapper.Map<User>(user));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public List<UserDTO> GetAll()
        {
            return mapper.Map<List<UserDTO>>(repository.GetAll());
        }

        public UserDTO GetById(int id)
        {
            return mapper.Map<UserDTO>(repository.GetById(id));
        }

        public void Update(int id, UserDTO user)
        {
            var validationResult = userValidator.Validate(user);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.Map<User>(user));
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

        public void UpdateAllGoods(int id, List<GoodDTO> allGoods)
        {
            foreach (var item in allGoods)
            {
                var validationResult = goodValidator.Validate(item);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }
  
            try
            {
                repository.UpdateAllGoods(id, mapper.Map<List<Good>>(allGoods));
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

        public void UpdateAllGoodsByAddingGood(int id, GoodDTO good)
        {
            var validationResult = goodValidator.Validate(good);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                repository.UpdateAllGoodsByAddingGood(id, mapper.Map<Good>(good));
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

        public void UpdateAllGoodsByAddingGoods(int id, List<GoodDTO> goods)
        {
            foreach (var item in goods)
            {
                var validationResult = goodValidator.Validate(item);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            try
            {
                repository.UpdateAllGoodsByAddingGoods(id, mapper.Map<List<Good>>(goods));
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

        public void UpdateBill(int id, BillDTO userBill)
        {
            var validationResult = billValidator.Validate(userBill);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                repository.UpdateBill(id, mapper.Map<Bill>(userBill));
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

        public void UpdateLogin(int id, string login)
        {
            var validationResult = userValidator.Validate(new UserDTO { Login = login }, "Login");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                repository.UpdateLogin(id, login);
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

        public void UpdatePassword(int id, string password)
        {
            var validationResult = userValidator.Validate(new UserDTO { Password = password }, "Password");
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                repository.UpdatePassword(id, password);
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

        public void UpdateUniqueGoods(int id, List<GoodDTO> uniqueGoods)
        {
            foreach (var item in uniqueGoods)
            {
                var validationResult = goodValidator.Validate(item);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            try
            {
                repository.UpdateUniqueGoods(id, mapper.Map<List<Good>>(uniqueGoods));
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

        public void UpdateUniqueGoodsByAddingGood(int id, GoodDTO good)
        {
            var validationResult = goodValidator.Validate(good);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                repository.UpdateUniqueGoodsByAddingGood(id, mapper.Map<Good>(good));
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

        public void UpdateUniqueGoodsByAddingGoods(int id, List<GoodDTO> goods)
        {
            foreach (var item in goods)
            {
                var validationResult = goodValidator.Validate(item);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            try
            {
                repository.UpdateUniqueGoodsByAddingGoods(id, mapper.Map<List<Good>>(goods));
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

        public void UpdateUserGoodTypes(int id, List<GoodTypeDTO> userGoodTypes)
        {
            foreach (var item in userGoodTypes)
            {
                var validationResult = goodTypeValidator.Validate(item);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            try
            {
                repository.UpdateUserGoodTypes(id, mapper.Map<List<GoodType>>(userGoodTypes));
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

        public void UpdateUserGoodTypesByAddingType(int id, GoodTypeDTO goodType)
        {
            var validationResult = goodTypeValidator.Validate(goodType);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            try
            {
                repository.UpdateUserGoodTypesByAddingType(id, mapper.Map<GoodType>(goodType));
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

        public void UpdateUserGoodTypesByAddingTypes(int id, List<GoodTypeDTO> goodTypes)
        {
            foreach (var item in goodTypes)
            {
                var validationResult = goodTypeValidator.Validate(item);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }

            try
            {
                repository.UpdateUserGoodTypesByAddingTypes(id, mapper.Map<List<GoodType>>(goodTypes));
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
