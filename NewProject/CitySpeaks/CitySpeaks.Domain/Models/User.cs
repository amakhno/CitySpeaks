using System.ComponentModel.DataAnnotations;

namespace CitySpeaks.Domain.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
