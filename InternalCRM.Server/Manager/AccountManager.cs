using InternalCRM.Server.DBContext;

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
        public async Task<string> createAccount(Models.Account acc)
        {
            acc.AccountId = acc.createAccountId(acc.FirstName, acc.Surname);
            acc.CreatedDate = DateTime.UtcNow;

            var dbAcc = new Entities.Account
            {
                Id = Guid.NewGuid(),
                AccountId = acc.AccountId,
                FirstName = acc.FirstName,
                Surname = acc.Surname,
                Email = acc.Email,
                CreatedDate = acc.CreatedDate
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
    }
}
