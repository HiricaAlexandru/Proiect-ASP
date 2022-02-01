using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class Utilizatori : IdentityUser<int>
    {
        public string RefreshToken { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
