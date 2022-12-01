using Roya_DDL.Entities;

namespace Roya.DTO
{
    public class productViewDTO
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string address { get; set; }
        public  List<string> Images { get; set; }=new List<string>();

        public bool Aprove { get; set; } = false;
        public List<CommentDto> Comments { get; set; } =new List<CommentDto>();

    }
}
