using System;
using System.Collections.Generic;
using System.Text;

namespace CitySpeaks.Domain.Models
{
    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
