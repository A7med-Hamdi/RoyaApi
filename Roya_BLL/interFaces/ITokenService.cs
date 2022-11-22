using Microsoft.AspNetCore.Identity;
using Roya_DDL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_BLL.InterFaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user,UserManager<User> userManager);
    }
}
