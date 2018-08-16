using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoodsAPI.Controllers
{
    [Route("v1/api/good")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        readonly IGoodService service;

        public GoodController(IGoodService goodService)
        {
            service = goodService;
        }

        // GET: v1/api/good
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

        // GET: v1/api/good/{id}
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

        // POST: v1/api/good
        [HttpPost]
        public IActionResult Post([FromBody]GoodDTO good)
        {
            try
            {
                return Ok(service.Create(good));
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

        // PUT: v1/api/good/{id}/good
        [Route("{id:int}/good")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]GoodDTO good)
        {
            try
            {
                service.Update(id, good);
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

        // PUT: v1/api/good/{id}/date
        [Route("{id:int}/date")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]DateTime boughtDate)
        {
            try
            {
                service.UpdateGoodByChangingBoughtDate(id, boughtDate);
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

        // PUT: v1/api/good/{id}/count
        [Route("{id:int}/count")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]float count)
        {
            try
            {
                service.UpdateGoodByChangingCount(id, count);
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

        // PUT: v1/api/good/{id}/importance
        [Route("{id:int}/importance")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]ImportanceDTO goodImportance)
        {
            try
            {
                service.UpdateGoodByChangingImportance(id, goodImportance);
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

        // PUT: v1/api/good/{id}/name
        [Route("{id:int}/name")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]string name)
        {
            try
            {
                service.UpdateGoodByChangingName(id, name);
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

        // PUT: v1/api/good/{id}/price
        [Route("{id:int}/price")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]decimal price)
        {
            try
            {
                service.UpdateGoodByChangingPrice(id, price);
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

        // PUT: v1/api/good/{id}/type
        [Route("{id:int}/type")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]GoodTypeDTO goodType)
        {
            try
            {
                service.UpdateGoodByChangingType(id, goodType);
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

        // DELETE: v1/api/good/good
        [Route("good")]
        [HttpDelete]
        public IActionResult Delete([FromBody]GoodDTO good)
        {
            try
            {
                service.Delete(good);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/good/{id}
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