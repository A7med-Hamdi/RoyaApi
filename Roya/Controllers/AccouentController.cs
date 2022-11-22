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
        public async Task<ActionResult> AdminRegister([FromForm]RegisterDTO registerDTO)
        {
           if(!emailExist(registerDTO.Email).Result.Value) {

                return BadRequest();            
            }
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
                ImageName = DocumentSitting.addFile(registerDTO.imgNmae, "Images")


            };
            var result = await userManager.CreateAsync(addUserAdmin, registerDTO.Password);
            if (!result.Succeeded) return BadRequest();

            if (!await roleManager.RoleExistsAsync(RoleContentHelper.Admin))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.Admin));
            await userManager.AddToRoleAsync(addUserAdmin, RoleContentHelper.Admin);
            return Ok(registerDTO);

        }
        [HttpPost("UserBuyer")]
        public async Task<ActionResult> userBuyerRegister([FromForm]RegisterDTO registerDTO)
        {

            var addUserBuyer = new User()
            {
                UserName = registerDTO.Name,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumper,
                Addreses = new Addreses()
                {
                    City = registerDTO.City,
                    Country = registerDTO.Country
                },
                ImageName = DocumentSitting.addFile(registerDTO.imgNmae, "Images")



            };
            var result = await userManager.CreateAsync(addUserBuyer, registerDTO.Password);
            if (!result.Succeeded) return BadRequest();

            if (!await roleManager.RoleExistsAsync(RoleContentHelper.UserBuyer))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.UserBuyer));
            await userManager.AddToRoleAsync(addUserBuyer, RoleContentHelper.UserBuyer);
            return Ok(registerDTO);

        }

        

        [HttpPost("Client")]
        public async Task<ActionResult> ClientRegister([FromForm] RegisterDTO registerDTO)
        {

            var addClient = new User()
            {
                UserName = registerDTO.Name,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumper,
                Addreses = new Addreses()
                {
                    City = registerDTO.City,
                    Country = registerDTO.Country
                },
                ImageName = DocumentSitting.addFile(registerDTO.imgNmae, "Images")



            };
            var result = await userManager.CreateAsync(addClient, registerDTO.Password);
            if (!result.Succeeded) return BadRequest();

            if (!await roleManager.RoleExistsAsync(RoleContentHelper.Client))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.Client));
            await userManager.AddToRoleAsync(addClient, RoleContentHelper.Client);
            return Ok(registerDTO);

        }
        [HttpGet("emailExist")]
        public async Task<ActionResult<bool>> emailExist([FromQuery] string email )
        {
            return await userManager.FindByEmailAsync(email)!=null;

        }
    }


}
