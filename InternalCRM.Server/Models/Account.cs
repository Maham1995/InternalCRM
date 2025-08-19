using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace InternalCRM.Server.Models
{
    public class Account
    {
        public Account(string firstName, string surname, string accountId, string email, DateTime createdDate)
        {
            FirstName = firstName;
            Surname = surname;
            AccountId = createAccountId(firstName, surname);
            Email = email;
            CreatedDate = DateTime.UtcNow;
        }

        [Required(ErrorMessage ="First name required")]
        private string FirstName { get; set; }
        [Required(ErrorMessage ="Surname is required")]
        private string Surname { get; set; }
        private string AccountId { get; set; }
        [Required(ErrorMessage ="Email is required")]
        private string Email { get; set; }
        private DateTime CreatedDate { get; set; }

        public void HasRequiredDetails() 
        {
            if (FirstName == string.Empty || FirstName == null)
            {
               
            }
        }

        public string createAccountId(string firstName, string surname)
        {
            var rand = new Random();
            return $"{firstName.Substring(0, 2)}{surname.Substring(0, 2)}{rand.Next(0, 99)}";
        }
    }
}
