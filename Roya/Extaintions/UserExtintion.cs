using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roya_DDL.Entities.Identity;
using System.Security.Claims;

namespace Roya.Extaintions
{
    public static class UserExtintion
    {
        public static async Task<User> FindByEmailWithAddressAsync(this UserManager<User> userManager, ClaimsPrincipal claims)
        {
            var email = claims.FindFirstValue(ClaimTypes.Email);
            return await userManager.Users.Include(u => u.Addreses).Include(u => u.Products).ThenInclude(p => p.Images).Include(u => u.Bookings).Include(u => u.FavoritLists).ThenInclude(f => f.productfavourite).ThenInclude(i => i.Images).SingleOrDefaultAsync(u => u.Email == email);

        }
    }
}
