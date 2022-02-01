using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Entitati
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual Utilizatori User { get; set; }
        public virtual Roluri Role { get; set; }
    }
}
