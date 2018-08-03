using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoodsAPI.Controllers
{
    [Route("v1/api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        readonly IBillService service;

        public BillController(IBillService billService)
        {
            service = billService;
        }

        // GET: v1/api/bill
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

        // GET: v1/api/bill/{id}
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

        // POST: v1/api/bill
        [HttpPost]
        public IActionResult Post([FromBody]BillDTO bill)
        {
            try
            {
                service.Create(bill);
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

        // PUT: v1/api/bill/{id}/bill
        [Route("{id:int}/bill")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]BillDTO bill)
        {
            try
            {
                service.Update(id, bill);
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

        // PUT: v1/api/bill/{id}/account
        [Route("{id:int}/account")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]AccountDTO account)
        {
            try
            {
                service.UpdateBillByAddingAccount(id, account);
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

        // PUT: v1/api/bill/{id}/sum
        [Route("{id:int}/sum")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]decimal sum)
        {
            try
            {
                service.UpdateBillByDeletingAccount(id, sum);
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

        // DELETE: v1/api/bill/bill
        [Route("bill")]
        [HttpDelete]
        public IActionResult Delete([FromBody]BillDTO bill)
        {
            try
            {
                service.Delete(bill);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/bill/{id}
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