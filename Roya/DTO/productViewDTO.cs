namespace Roya.DTO
{
    public class productViewDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string address { get; set; }
        public  List<string> Images { get; set; }=new List<string>();

      //  public virtual FavoritList FavoritList { get; set; }
      //  public virtual Booking Bookings { get; set; }

        public  List<string> Comments { get; set; } =new List<string>();
       // [ForeignKey("user")]

        //public string UserId { get; set; }
        //public virtual User user { get; set; }
    }
}
