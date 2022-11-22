using Roya_DDL.Entities;
using Roya_DDL.Entities.Identity;

namespace Roya.DTO
{
    public class ProductDTO
    {
        /// <summary>
        /// /////////////////////
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string  address { get; set; }
        public string  UserId { get; set; }
        public IFormFile[]? ImagesFile { get; set; }
        public List<Image>? Images { get; set; } = new List<Image>();


        
    }
}
