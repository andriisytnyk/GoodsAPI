using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.Shared.DTO;
using GoodsAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GoodsAPI.Controllers
{
    [Route("v1/api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountService service;
        readonly IBillService billService;

        public AccountController(IAccountService accountService, IBillService billService)
        {
            service = accountService;
            this.billService = billService;
        }

        // GET: v1/api/account
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

        // GET: v1/api/account/{id}
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

        // POST: v1/api/account
        [HttpPost]
        public IActionResult Post([FromBody]AccountDTO account)
        {
            try
            {
                service.Create(account);
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

        // PUT: v1/api/account/{id}/account
        [Route("{id:int}/account")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]AccountDTO account)
        {
            try
            {
                service.Update(id, account);
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

        // PUT: v1/api/account/{id}/name
        [Route("{id:int}/name")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]string name)
        {
            try
            {
                service.UpdateAccountByChangingName(id, name);
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

        // PUT: v1/api/account/{id}/sum
        [Route("{id:int}/sum")]
        [HttpPut]
        public IActionResult Put([FromRoute]int id, [FromBody]decimal sum)
        {
            try
            {
                service.UpdateByChangingSum(id, sum);
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

        // DELETE: v1/api/account/account
        [Route("account")]
        [HttpDelete]
        public IActionResult Delete([FromBody]AccountDTO account)
        {
            try
            {
                var bill = billService.GetAll().SingleOrDefault(b => b.Accounts.Select(a => a.Id).Contains(account.Id));
                billService.UpdateBillByDeletingAccount(bill.Id, account.Sum);
                service.Delete(account);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: v1/api/account/{id}
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                var bill = billService.GetAll().SingleOrDefault(b => b.Accounts.Select(a => a.Id).Contains(id));
                billService.UpdateBillByDeletingAccount(bill.Id, bill.Accounts.SingleOrDefault(a => a.Id == id).Sum);
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