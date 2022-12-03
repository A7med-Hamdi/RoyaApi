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
        private readonly RoyaContext context;

        public BookingController(IGenercRepositry<Booking> repositry , UserManager<User> user, RoyaContext context)
        {
            this.repositry = repositry;
            this.user = user;
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking([FromForm]Booking booking)

        {


            try
            {
                if (productExist(booking.ProductId, booking.UserId))
                {


                    return BadRequest(new ApiErroeResponse(400, "Alredy add to favourite list "));
                }
                else
                {
                    var AddBooking = new Booking()
                    {
                        UserId = booking.UserId,
                        ProductId = booking.ProductId,
                        Stutes = false,
                        UserEmail = booking.UserEmail,
                        ProductName = booking.ProductName,
                        UserName = booking.UserName,
                        Image = booking.Image,

                    };
                    await this.repositry.Add(AddBooking);
                    repositry.SaveChange();
                }
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
        [HttpGet("productExist")]
        public bool productExist(int id, string userId)
        {


            var x = context.Bookings.Where(p => p.ProductId == id).ToList();
            if (x.Count == 0) return false;
            var exist = x.Where(u => u.UserId == userId).ToList();
            if (exist.Count == 0) return false;
            return true;
        }
    }
}
