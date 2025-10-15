using System.ComponentModel.DataAnnotations;

namespace InternalCRM.Server.Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string? AccountId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public Account() { }

        public Account(string firstName, string surname, string email)
        {
            FirstName = firstName;
            Surname = surname;
            Email = email;
        }

        public string createAccountId(string firstName, string surname)
        {
            var rand = new Random();
            return $"{firstName.Substring(0, 2)}{surname.Substring(0, 2)}{rand.Next(0, 99)}";
        }
    }
}
