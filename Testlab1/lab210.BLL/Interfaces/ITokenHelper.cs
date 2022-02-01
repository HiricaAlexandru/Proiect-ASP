using lab210.DAL.Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(Utilizatori _User);
         string CreateRefreshToken();

         ClaimsPrincipal GetPrincipalFromExpiredToken(string _Token);
    }
}
