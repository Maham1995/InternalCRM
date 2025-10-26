using InternalCRM.Server.DBContext;
using InternalCRM.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<string> createAccount(OnboardAccount acc)
        {
            var accountId = acc.createAccountId(acc.FirstName, acc.Surname);

            var dbAcc = new Entities.Account
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                FirstName = acc.FirstName,
                Surname = acc.Surname,
                Email = acc.Email,
                CreatedDate = DateTime.UtcNow
            };

            try
            {
                await _context.AddAsync(dbAcc);
                await _context.SaveChangesAsync();

                return dbAcc.Email;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Something went wrong: {ex}");
            }
        }

        //this method is used to fetch account info from DB filtering by email
        public async Task<Account> GetAccountByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email cannot be null");
            }

            var account = await _context.Accounts
                .AsNoTracking()
                .Where(x => x.Email == email)
                .Select(x => new Account
                {
                    AccountId = x.AccountId,
                    FirstName = x.FirstName,
                    Surname = x.Surname,
                    Email = x.Email,
                    CreatedDate = x.CreatedDate
                })
                .FirstOrDefaultAsync();

            if(account == null) 
            {
                throw new InvalidOperationException("Account not found");
            }

            return account;
        }

        public async Task<List<Account>> GetAccountData() 
        {
            var account = await _context.Accounts
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new Account
                {
                    AccountId = x.AccountId,
                    FirstName = x.FirstName,
                    Surname = x.Surname,
                    Email = x.Email,
                    CreatedDate = x.CreatedDate
                })
                .Take(4)
                .ToListAsync();

            return account;
        }
    }
}
