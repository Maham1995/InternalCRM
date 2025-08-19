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
        [HttpPost(Name = "CreateAccount")]
        public ActionResult CreateAccount(Account acc)
        {
            var result = _accountManager.createAccount(acc);
            return Ok(result);
        }
    }
}
