using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roya.DTO;
using Roya_BLL.interFaces;
using Roya_DDL.Entities;
using Roya_DDL.Entities.Identity;

namespace Roya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {// reposirary
        private readonly IGenercRepositry<Product> repositry;
        private readonly IMapper mapper;

        public ProductController(IGenercRepositry<Product> repositry ,IMapper mapper)
        {
            this.repositry = repositry;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> addProduct(ProductDTO product)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var Addproduct = mapper.Map<Product>(product);
                await repositry.Add(Addproduct);
                repositry.SaveChange();
                return Created("done", product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<productViewDTO>>> GetallProduct()
        {
            
            var products = await repositry.GetAllDataAsync();

            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<productViewDTO>>(products);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<productViewDTO>> GetProduct(int id)
        {
            var product = await repositry.GetDataByIdAsync(id);
            var data = mapper.Map <Product,  productViewDTO>(product);

            return Ok(data);
        }

        // update

        [HttpPut]
        public async Task<ActionResult> Update(ProductDTO product)
        {


            if (product.Id == null)
                return BadRequest();
            try
            {
                var updateproduct = await repositry.GetDataByIdAsync(product.Id);

                updateproduct.Name = product.Name;
                updateproduct.Description = product.Description;
                updateproduct.Type = product.Type;
                updateproduct.Price = product.Price;
                updateproduct.address = product.address;
                updateproduct.UserId = updateproduct.UserId;



                repositry.Update(updateproduct);
                repositry.SaveChange();
                return Created("done", product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //delete  
        [HttpDelete]

        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
                return NotFound();
            var data = await repositry.GetDataByIdAsync(id);
            if (data == null)
                return NotFound();
            repositry.Delete(data);
            repositry.SaveChange();
            return Ok(" Delete Done");
        }


    }
}
