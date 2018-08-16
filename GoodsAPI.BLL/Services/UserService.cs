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
        private readonly IBillService billService;
        private readonly IMapper mapper;
        private readonly AbstractValidator<UserDTO> userValidator;
        private readonly AbstractValidator<GoodDTO> goodValidator;
        private readonly AbstractValidator<BillDTO> billValidator;
        private readonly AbstractValidator<GoodTypeDTO> goodTypeValidator;

        public UserService(UserRepository userRepository, IBillService billService, IMapper mapper, AbstractValidator<UserDTO> userValidator,
            AbstractValidator<GoodDTO> goodValidator, AbstractValidator<BillDTO> billValidator, AbstractValidator<GoodTypeDTO> goodTypeValidator)
        {
            this.repository = userRepository;
            this.billService = billService;
            this.mapper = mapper;
            this.userValidator = userValidator;
            this.goodValidator = goodValidator;
            this.billValidator = billValidator;
            this.goodTypeValidator = goodTypeValidator;
        }

        public List<UserDTO> GetAll()
        {
            var result = new List<UserDTO>();
            foreach (var item in repository.GetAll())
            {
                result.Add(mapper.MapUser(item));
            }
            return result;
        }

        public UserDTO GetById(int id)
        {
            return mapper.MapUser(repository.GetById(id));
        }

        public int Create(UserDTO user)
        {
            var validationResult = userValidator.Validate(user);
            if (validationResult.IsValid)
                return repository.Create(mapper.MapUser(user));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Update(int id, UserDTO user)
        {
            var validationResult = userValidator.Validate(user);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                repository.Update(id, mapper.MapUser(user));
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
                var newAllGoods = new List<Good>();
                foreach (var item in allGoods)
                {
                    newAllGoods.Add(mapper.MapGood(item));
                }
                repository.UpdateAllGoods(id, newAllGoods);
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
                repository.UpdateAllGoodsByAddingGood(id, mapper.MapGood(good));
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
                var newGoods = new List<Good>();
                foreach (var item in goods)
                {
                    newGoods.Add(mapper.MapGood(item));
                }
                repository.UpdateAllGoodsByAddingGoods(id, newGoods);
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
                repository.UpdateBill(id, mapper.MapBill(userBill));
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
                var newGoodTypes = new List<GoodType>();
                foreach (var item in userGoodTypes)
                {
                    newGoodTypes.Add(mapper.MapGoodType(item));
                }
                repository.UpdateUserGoodTypes(id, newGoodTypes);
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
                repository.UpdateUserGoodTypesByAddingType(id, mapper.MapGoodType(goodType));
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
                var newGoodTypes = new List<GoodType>();
                foreach (var item in goodTypes)
                {
                    newGoodTypes.Add(mapper.MapGoodType(item));
                }
                repository.UpdateUserGoodTypesByAddingTypes(id, newGoodTypes);
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

        public void Delete(UserDTO user)
        {
            repository.Delete(mapper.MapUser(user));
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }
    }
}
