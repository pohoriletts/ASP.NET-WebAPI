using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMono.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService services)
        {
            _transactionService = services;
        }

        [AllowAnonymous]
        [HttpGet("/All")]      
        public IActionResult GetAll() => Ok(_transactionService.GetAll());

        [AllowAnonymous]
        [HttpGet("/Get/{id}")] 
        public IActionResult Get([FromRoute] int id) => Ok(_transactionService.Get(id));
     
        [HttpPost("/Create")]  
        public IActionResult Create([FromBody] TransactionDTO transaction)
        {
            if (!ModelState.IsValid) return BadRequest();
            _transactionService.Create(transaction);
            return Ok();
        }

        [HttpPut("/Edit")]     
        public IActionResult Edit([FromBody] TransactionDTO transaction)
        {
            if (!ModelState.IsValid) return BadRequest();

            _transactionService.Edit(transaction);

            return Ok();
        }

        [HttpDelete("/Delete/{id}")] 
        public IActionResult Delete([FromRoute] int id)
        {
            _transactionService.Delete(id);
            return Ok();
        }
    }
}
