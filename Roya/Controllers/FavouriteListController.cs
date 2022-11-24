using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roya.Errors;
using Roya_BLL.interFaces;
using Roya_DDL.Entities;
using Roya_DDL.Entities.Identity;

namespace Roya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteListController : ControllerBase

    {
        private readonly IGenercRepositry<FavoritList> repositry;
        private readonly UserManager<User> user;

        public FavouriteListController(IGenercRepositry<FavoritList> repositry, UserManager<User> user)
        {
            this.repositry = repositry;
            this.user = user;
        }
        [HttpPost]
        public async Task<ActionResult<FavoritList>> AddFavourite(int productId, string userId)
        {

            try
            {
                var AddFavourite = new FavoritList()
                {
                    UserId = userId,
                    ProductId= productId,


                };
                await this.repositry.Add(AddFavourite);
                repositry.SaveChange();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("FavouriteList Added");
        }
        [HttpGet]
        public async Task<ActionResult<FavoritList>> GetAllFavourite()
        {
            var Favourite = await repositry.GetAllDataAsync();


            return Ok(Favourite);
        }
        [HttpGet("GetFavouriteByProductId")]
        public async Task<ActionResult<Booking>> GetFavouriteByProductId(int productId)
        {
            var Favouritelist = await repositry.GetAllDataAsync();
            var  Favourite= Favouritelist.Where(b => b.ProductId == productId);


            return Ok(Favourite);
        }
        [HttpGet("GetUserByUserId")]
        public async Task<ActionResult<Booking>> GetUserByUserId(string userId)
        {
            var Favouritelist = await repositry.GetAllDataAsync();
            var Favourite = Favouritelist.Where(b => b.UserId == userId);


            return Ok(Favourite);
        }
        //delete  
        [HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {

            var data = await repositry.GetDataByIdAsync(id);
            if (data == null)
                return NotFound(new ApiErroeResponse(400, "this FavouriteList not found"));

            repositry.Delete(data);
            repositry.SaveChange();
            return Ok(" Delete Done");
        }
    }
}
