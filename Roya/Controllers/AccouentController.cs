using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Roya.DTO;
using Roya.helper;
using Roya_DDL.Entities.Identity;

namespace Roya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccouentController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccouentController(UserManager<User> userManager , SignInManager<User> signInManager ,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpPost("admin")]
        public async Task<ActionResult> AdminRegister(RegisterDTO registerDTO)
        {

            var addUserAdmin = new User()
            {
                UserName = registerDTO.Name,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumper,
                Addreses = new Addreses()
                {
                    City = registerDTO.City,
                    Country = registerDTO.Country
                },
                ImageName = "dsdasdas"
                
                
            };
            var result = await userManager.CreateAsync(addUserAdmin, registerDTO.Password);
            if (!result.Succeeded) return BadRequest();

            if (!await roleManager.RoleExistsAsync(RoleContentHelper.Admin))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.Admin));
            await userManager.AddToRoleAsync(addUserAdmin, RoleContentHelper.Admin);
            return Ok(registerDTO);

        }
    }


}
