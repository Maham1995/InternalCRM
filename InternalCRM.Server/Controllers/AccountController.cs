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

        //this method will be used to onboard new employee accounts
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CreateAccount")]
        public async Task<ActionResult> CreateAccount(OnboardAccount acc)
        {
            var response = await _accountManager.createAccount(acc);
            
            return Ok(new
            {
                data = response
            });
        }

        //FE should fetch account data via email to populate account profile page
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("email")]
        public async Task<Account> GetAccountDatabyEmail(string email) 
        {
            var response = await _accountManager.GetAccountByEmail(email);

            return response;
        }

        //fetch all account data limit to 4
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("fetchAccounts")]
        public async Task<List<Account>> GetAccountData()
        {
            var response = await _accountManager.GetAccountData();

            return response;
        }

        //should have a delete account method
    }
}
