using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GoodsAPI.Controllers
{
    [Route("v1/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService service;

        public UserController(IUserService userService)
        {
            service = userService;
        }

        // GET: v1/api/user
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.GetAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: v1/api/user/{id}
        [Route("{id:int}")]
        [HttpGet]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                return Ok(service.GetById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: v1/api/user
        [HttpPost]
        public IActionResult Post([FromBody]UserDTO user)
        {
            try
            {
                return Ok(service.Create(user));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: v1/api/user/{id}/user
        [Route("{id:int}/user")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]UserDTO user)
        {
            try
            {
                service.Update(id, user);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/list_of_all_goods
        [Route("{id:int}/list_of_all_goods")]
        [HttpPatch]
        public IActionResult PatchListOfAllGoods([FromRoute]int id, [FromBody]List<GoodDTO> allGoods)
        {
            try
            {
                service.UpdateAllGoods(id, allGoods);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/good_for_list_of_all_goods
        [Route("{id:int}/good_for_list_of_all_goods")]
        [HttpPatch]
        public IActionResult PatchListOfAllGoodsByAddingGood([FromRoute]int id, [FromBody]GoodDTO good)
        {
            try
            {
                service.UpdateAllGoodsByAddingGood(id, good);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/goods_for_list_of_all_goods
        [Route("{id:int}/goods_for_list_of_all_goods")]
        [HttpPatch]
        public IActionResult PatchListOfAllGoodsByAddingGoods([FromRoute]int id, [FromBody]List<GoodDTO> goods)
        {
            try
            {
                service.UpdateAllGoodsByAddingGoods(id, goods);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/billid
        [Route("{id:int}/billid")]
        [HttpPatch]
        public IActionResult PatchBill([FromRoute]int id, [FromBody]BillDTO bill)
        {
            try
            {
                service.UpdateBill(id, bill);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/login
        [Route("{id:int}/login")]
        [HttpPatch]
        public IActionResult PatchLogin([FromRoute]int id, [FromBody]string login)
        {
            try
            {
                service.UpdateLogin(id, login);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/password
        [Route("{id:int}/password")]
        [HttpPatch]
        public IActionResult PatchPassword([FromRoute]int id, [FromBody]string password)
        {
            try
            {
                service.UpdatePassword(id, password);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/user_good_types
        [Route("{id:int}/user_good_types")]
        [HttpPatch]
        public IActionResult PatchListOfUserGoodTypes([FromRoute]int id, [FromBody]List<GoodTypeDTO> goodTypes)
        {
            try
            {
                service.UpdateUserGoodTypes(id, goodTypes);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/good_type_for_list_of_user_good_types
        [Route("{id:int}/good_type_for_list_of_user_good_types")]
        [HttpPatch]
        public IActionResult PatchListOfUserGoodTypesByAddingType([FromRoute]int id, [FromBody]GoodTypeDTO goodType)
        {
            try
            {
                service.UpdateUserGoodTypesByAddingType(id, goodType);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PATCH: v1/api/user/{id}/good_types_for_list_of_user_good_types
        [Route("{id:int}/good_types_for_list_of_user_good_types")]
        [HttpPatch]
        public IActionResult PatchListOfUserGoodTypesByAddingTypes([FromRoute]int id, [FromBody]List<GoodTypeDTO> goodTypes)
        {
            try
            {
                service.UpdateUserGoodTypesByAddingTypes(id, goodTypes);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: v1/api/user/user
        [Route("user")]
        [HttpDelete]
        public IActionResult Delete([FromBody]UserDTO user)
        {
            try
            {
                service.Delete(user);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/user/{id}
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                service.DeleteById(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}