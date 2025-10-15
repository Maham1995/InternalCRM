using System.ComponentModel.DataAnnotations;

namespace InternalCRM.Server.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string AccountId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
