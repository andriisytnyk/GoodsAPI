using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.DAL.Models;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoodsAPI.Controllers
{
    [Route("v1/api/importance")]
    [ApiController]
    public class ImportanceController : ControllerBase
    {
        readonly IImportanceService service;
        readonly IMapper mapper;
        readonly IUserService userService;

        public ImportanceController(IImportanceService importanceService, IMapper mapper, IUserService userService)
        {
            service = importanceService;
            this.mapper = mapper;
            this.userService = userService;
        }

        // GET: v1/api/importance
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

        // GET: v1/api/importance/{id}
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

        // POST: v1/api/importance
        [HttpPost]
        public IActionResult Post([FromBody]ImportanceDTO importance)
        {
            try
            {
                if (importance.Name == null)
                {
                    throw new NotFoundException();
                }
                foreach (var item in service.GetAll())
                {
                    if (item.Name == importance.Name)
                    {
                        return Ok(item.Id);
                    }
                }
                importance.Id = service.Create(importance);
                var userID = Convert.ToInt32(HttpContext.Request.Headers["user"]);
                var user = userService.GetById(userID);
                var ui = new UserImportance()
                {
                    UserID = userID,
                    User = mapper.MapUser(user),
                    ImportanceID = importance.Id,
                    Importance = mapper.MapImportance(importance)
                };
                importance.UserImportances.Add(ui);
                service.Update(importance.Id, importance);               
                return Ok(importance.Id);
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

        // PUT: v1/api/importance/{id}/importance
        [Route("{id:int}/importance")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]ImportanceDTO importance)
        {
            try
            {
                service.Update(id, importance);
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

        // PUT: v1/api/importance/{id}/name
        [Route("{id:int}/name")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]string name)
        {
            try
            {
                service.UpdateImportanceName(id, name);
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

        // DELETE: v1/api/importance/importance
        [Route("importance")]
        [HttpDelete]
        public IActionResult Delete([FromBody]ImportanceDTO importance)
        {
            try
            {
                service.Delete(importance);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/importance/{id}
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