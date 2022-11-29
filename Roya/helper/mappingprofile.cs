using AutoMapper;
using Roya_DDL.Entities;
using Roya.DTO;

namespace Roya.helper
{
    public class mappingprofile : Profile
    {
        public mappingprofile()
        {
            CreateMap<Product, productViewDTO>()

                  
                     .ForMember(d => d.Images, o => o.MapFrom(s => s.Images.Select(m=>m.Name)))

                     .ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments.Select(c => new { c.text, c.DateTime,c.UserName , c.UserImage })));

            CreateMap<ProductDTO, Product>().ReverseMap();
                  
        }
    }
}
