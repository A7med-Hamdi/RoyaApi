using Roya_DDL.Entities;

namespace Roya.DTO
{
    public class CurrentUserDTO
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

        public string Role { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public List<FavoritList> FavoritLists { get; set; } = new List<FavoritList>();

    }
}
