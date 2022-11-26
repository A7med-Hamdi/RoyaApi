
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Roya.DTO;
using Roya.Errors;
using Roya.Extaintions;
using Roya.helper;
using Roya_BLL.interFaces;
using Roya_DDL.Entities.Identity;
using System.Security.Claims;

namespace Roya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccouentController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenService token;

        public AccouentController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, ITokenService token)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.token = token;
        }
        [HttpPost("admin")]
        public async Task<ActionResult> AdminRegister([FromForm] RegisterDTO registerDTO)
        {
            if (emailExist(registerDTO.Email).Result.Value)
            {

                return BadRequest(new ApiErroeResponse(400, "this Email is Already in use ! "));
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
            if (!result.Succeeded) return BadRequest(new ApiErroeResponse(400));


            if (!await roleManager.RoleExistsAsync(RoleContentHelper.Admin))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.Admin));
            await userManager.AddToRoleAsync(addUserAdmin, RoleContentHelper.Admin);
            return Ok(registerDTO);

        }
        [HttpPost("UserBuyer")]
        public async Task<ActionResult> userBuyerRegister([FromForm] RegisterDTO registerDTO)
        {
            if (emailExist(registerDTO.Email).Result.Value)
            {

                return BadRequest(new ApiErroeResponse(400, "this Email is Already in use ! "));
            }

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
            if (!result.Succeeded) return BadRequest(new ApiErroeResponse(400));

            if (!await roleManager.RoleExistsAsync(RoleContentHelper.UserBuyer))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.UserBuyer));
            await userManager.AddToRoleAsync(addUserBuyer, RoleContentHelper.UserBuyer);
            return Ok(registerDTO);

        }



        [HttpPost("Client")]
        public async Task<ActionResult> ClientRegister([FromForm] RegisterDTO registerDTO)
        {
            if (emailExist(registerDTO.Email).Result.Value)
            {

                return BadRequest(new ApiErroeResponse(400, "this Email is Already in use ! "));
            }
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
            if (!result.Succeeded) return BadRequest(new ApiErroeResponse(400));

            if (!await roleManager.RoleExistsAsync(RoleContentHelper.Client))
                await roleManager.CreateAsync(new IdentityRole(RoleContentHelper.Client));
            await userManager.AddToRoleAsync(addClient, RoleContentHelper.Client);
            return Ok(registerDTO);

        }
        [HttpGet("emailExist")]
        public async Task<ActionResult<bool>> emailExist([FromQuery] string email)
        {
            return await userManager.FindByEmailAsync(email) != null;

        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDTO>> LoginUser(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return Unauthorized(new ApiErroeResponse(400, "Email Not here"));
            var password = await userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (password)
            {
                var result = await signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
                if (!result.Succeeded) return BadRequest(new ApiErroeResponse(400, "signIn Filed"));
            }
            else { return BadRequest(new ApiErroeResponse(400, " invalid Password")); };
            var userRole = await userManager.GetRolesAsync(user);
            var authUser = new UserDTO()
            {
                UserName = user.UserName,
                Roles = userRole[0],
                Token = await token.CreateToken(user, userManager),
                UserId=user.Id
                
                
                

            };


            return Ok(authUser);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CurrentUserDTO>> CurrentUser()
        {


            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailWithAddressAsync(User);
            var role = await userManager.GetRolesAsync(user);
            if (role[0] == "Admin")
            {
                return Ok
              (new CurrentUserDTO()
              {
                  Email = email,
                  Role = role[0],
                  Name = user.UserName,
                  Phone = user.PhoneNumber,
                  City = user.Addreses.City,
                  Country = user.Addreses.Country,
                  Image = user.ImageName

              }
              );
            }
            if (role[0] == "Client")
            {
                return Ok
              (new CurrentUserDTO()
              {
                  Email = email,
                  Role = role[0],
                  Name = user.UserName,
                  Phone = user.PhoneNumber,
                  City = user.Addreses.City,
                  Bookings = user.Bookings,
                  Country = user.Addreses.Country,
                  FavoritLists = user.FavoritLists,
                  Image = user.ImageName


              }
              );
            }

            if (role[0] == "UserBuyer")
            {
                return Ok
              (new CurrentUserDTO()
              {
                  Email = email,
                  Role = role[0],
                  Name = user.UserName,
                  Phone = user.PhoneNumber,
                  City = user.Addreses.City,
                  Bookings = user.Bookings,
                  Products = user.Products,
                  Country = user.Addreses.Country,
                  FavoritLists = user.FavoritLists,
                  Image = user.ImageName


              }
              );
            }
                return Ok("you have to login");

        }


    }
}
