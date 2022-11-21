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

                     .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                     .ForMember(d => d.address, o => o.MapFrom(s => s.address))
                     .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                     .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                     .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))

                     .ForMember(d => d.Comments, o => o.MapFrom(s => s.Comments.Select(c => new { c.text, c.DateTime })));

            CreateMap<ProductDTO, Product>();
                  
        }
    }
}
