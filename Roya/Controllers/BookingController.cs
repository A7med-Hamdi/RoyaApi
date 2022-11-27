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
        public async Task<ActionResult<Booking>> AddBooking(Booking booking)

        {
           
            try
            {
                var AddBooking = new Booking()
                {
                    UserId = booking.UserId,
                    ProductId = booking.ProductId,
                    Stutes = false,
                    UserEmail = booking.UserEmail,
                    ProductName = booking.ProductName,
                    UserName   = booking.UserName,

                    
                };
                await this.repositry.Add( AddBooking );
                 repositry.SaveChange();
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
        [HttpGet("GetBookingByUserId")]
        public async Task<ActionResult<Booking>> GetBookingByUserId(string userId)
        {
            var Bookings = await repositry.GetAllDataAsync();
            var book = Bookings.Where(b => b.UserId == userId);


            return Ok(book);
        }
        //delete  
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
         
            var data = await repositry.GetDataByIdAsync(id);
            if (data == null)
                return NotFound(new ApiErroeResponse(400,"this book not found") );
          
            repositry.Delete(data);
            repositry.SaveChange();
            return Ok(" Delete Done");
        }
    }
}
