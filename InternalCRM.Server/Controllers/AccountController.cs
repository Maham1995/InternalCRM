using InternalCRM.Server.Manager;
using InternalCRM.Server.Models;
using Microsoft.AspNetCore.Mvc;
namespace InternalCRM.Server.Controllers
{
    [ApiController]
    [Route("maham/account")]
    public class AccountController: ControllerBase
    {
        private readonly AccountManager _accountManager;

        public AccountController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        //this method will be used to onboard new accounts
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = "CreateAccount")]
        public async Task<ActionResult> CreateAccount(Account acc)
        {
            var result = await _accountManager.createAccount(acc);
            
            return Ok(result);
        }
    }
}
