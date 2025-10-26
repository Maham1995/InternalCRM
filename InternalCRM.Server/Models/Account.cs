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

        /*public Account(string firstName, string surname, string email)
        {
            FirstName = firstName;
            Surname = surname;
            Email = email;
        }*/
    }
}
