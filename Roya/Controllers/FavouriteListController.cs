using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roya.DTO;
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
        private readonly RoyaContext context;

        public FavouriteListController(IGenercRepositry<FavoritList> repositry, UserManager<User> user, RoyaContext context)
        {
            this.repositry = repositry;
            this.user = user;
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<FavoritList>> AddFavourite([FromBody] FavoriteDTO favoriteDTO)
        {

            try
            {

                if (productExist( favoriteDTO.ProductId ,favoriteDTO.UserId))
                {
                    

                    return BadRequest(new ApiErroeResponse(400, "Alredy add to favourite list "));
                }
                else
                {
                    var AddFavourite = new FavoritList()
                    {
                        UserId = favoriteDTO.UserId,
                        ProductId = favoriteDTO.ProductId,


                    };
                    await this.repositry.Add(AddFavourite);
                    repositry.SaveChange();

                }

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetFavouriteByProductId(int id)
        {
            var Favouritelist = await repositry.GetDataByIdAsync(id);


            return Ok(Favouritelist);
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
            return Ok(data);
        }

        [HttpGet("productExist")]
        public  bool productExist( int id,string userId)
        {
           

            var x =  context.FavoritLists.Where(p => p.ProductId == id).ToList() ;
            if (x.Count==0) return false;
            var exist = x.Where(u =>u.UserId==userId).ToList() ;
            if (exist.Count == 0) return  false;
            return true;
        }
      
    }
}
