using InternalCRM.Server.DBContext;
using InternalCRM.Server.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace InternalCRM.Server.Manager
{
    public class AccountManager
    {
        private readonly AppDbContext _context;

        public AccountManager(AppDbContext context) 
        {
            _context = context;
        }

        //this method will be used to onboard new accounts
        public IActionResult createAccount(Account acc)
        {

            if (acc == null)
            {
                throw new ArgumentNullException();
            }


            //should i move this to a seperate folder called handler
            _context.Add(acc);
            _context.SaveChanges();

            return null;
        }
        
    }
}
