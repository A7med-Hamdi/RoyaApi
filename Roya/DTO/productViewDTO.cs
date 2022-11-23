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

 
        public  List<string> Comments { get; set; } =new List<string>();

    }
}
