using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoodsAPI.Controllers
{
    [Route("v1/api/goodtype")]
    [ApiController]
    public class GoodTypeController : ControllerBase
    {
        readonly IGoodTypeService service;

        public GoodTypeController(IGoodTypeService goodTypeService)
        {
            service = goodTypeService;
        }

        // GET: v1/api/goodtype
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

        // GET: v1/api/goodtype/{id}
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

        // POST: v1/api/goodtype
        [HttpPost]
        public IActionResult Post([FromBody]GoodTypeDTO goodType)
        {
            try
            {
                service.Create(goodType);
                return Ok();
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

        // PUT: v1/api/goodtype/{id}/goodtype
        [Route("{id:int}/goodtype")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]GoodTypeDTO goodType)
        {
            try
            {
                service.Update(id, goodType);
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

        // PUT: v1/api/goodtype/{id}/name
        [Route("{id:int}/name")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]string name)
        {
            try
            {
                service.UpdateGoodTypeName(id, name);
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

        // DELETE: v1/api/goodtype/goodtype
        [Route("goodtype")]
        [HttpDelete]
        public IActionResult Delete([FromBody]GoodTypeDTO goodType)
        {
            try
            {
                service.Delete(goodType);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/goodtype/{id}
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