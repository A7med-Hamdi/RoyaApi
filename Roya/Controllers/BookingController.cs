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
    public class BookingController : ControllerBase

    {
        private readonly IGenercRepositry<Booking> repositry;
        private readonly UserManager<User> user;

        public BookingController(IGenercRepositry<Booking> repositry , UserManager<User> user )
        {
            this.repositry = repositry;
            this.user = user;
        }
        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(int productId, string userId)
        {
           
            try
            {
                var AddBooking = new Booking()
                {
                    UserId = userId,
                    ProductId = productId,
                    Stutes = false,

                    
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            return Ok("Booking Done");
        } 
        [HttpGet]
        public async Task<ActionResult<Booking>> GetAllBooking()
        {
            var Bookings = await repositry.GetAllDataAsync();


            return Ok(Bookings) ;
        }   
        [HttpGet("GetBookingByProductId")]
        public async Task<ActionResult<Booking>> GetBookingByProductId(int productId)
        {
            var Bookings = await repositry.GetAllDataAsync();
          var book =  Bookings.Where(b => b.ProductId == productId);


            return Ok(book) ;
        }
    }
}
