﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Roya.DTO;
using Roya.Errors;
using Roya.helper;
using Roya_BLL.interFaces;
using Roya_BLL.Spesification;
using Roya_DDL.Entities;
using Roya_DDL.Entities.Identity;
using System.Data;
using System.Security.Cryptography;

namespace Roya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {// reposirary
        private readonly IGenercRepositry<Product> repositry;
        private readonly IMapper mapper;
        private readonly RoyaContext context;

        public ProductController(IGenercRepositry<Product> repositry, IMapper mapper, RoyaContext context)
        {
            this.repositry = repositry;
            this.mapper = mapper;
            this.context = context;
        }
        [HttpPost]
        [Authorize(Roles = "Admin,UserBuyer")]


        public async Task<ActionResult<Product>> addProduct([FromForm] ProductDTO product)
        {



            if (!ModelState.IsValid) return BadRequest(new ApiErroeResponse(400, "invalid data"));
            if (product.ImagesFile == null) return BadRequest("At least Add one photo");

            try
            {
                for (int i = 0; i < product.ImagesFile.Length; i++)


                {
                    product.Images.Add(new Image());
                    product.Images[i].Name = DocumentSitting.addFile(product.ImagesFile[i], "images");
                }

                var Addproduct = mapper.Map<ProductDTO , Product>(product);
                Addproduct.Aprove = product.Approve;
                await repositry.Add(Addproduct);
                repositry.SaveChange();
                return Ok(Addproduct);


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Paganation<productViewDTO>>>> GetallProduct([FromQuery] ProductParams productParams)
        {

            // var products = await repositry.GetAllDataAsync();
            var spec = new ProductSpec(productParams);
            var countSpec = new productFilterwithcount(productParams);
            var totalItems = await repositry.GetCountASync(countSpec);

            var products = await repositry.GetAllDataWithSpecAsync(spec);
            var producttrue=products.Where(p => p.Aprove == true).ToList();

            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<productViewDTO>>(producttrue);

            var pagnation = new Paganation<productViewDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data);

            return Ok(pagnation);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<productViewDTO>> GetProduct(int id)
        {
            //  var product = await repositry.GetDataByIdAsync(id);
            var spec = new ProductSpec(id);
            var product = await repositry.GetDataByIdWithSpecAsync(spec);

            var data = mapper.Map<Product, productViewDTO>(product);
         

            return Ok(data);
        }

        // update

        [HttpPut("{Productid}")]
        public async Task<ActionResult> Update(int Productid, [FromForm] ProductDTO product)
        {


            var updateproduct = await repositry.GetDataByIdAsync(Productid);
            if (updateproduct == null)

                return BadRequest();

            if (product.ImagesFile != null)
            {
                var images = context.Images.ToList().Where(img => img.productid == Productid);

                foreach (var img in images)
                {
                    DocumentSitting.deleteFile("images", img.Name);
                }

                context.Images.RemoveRange(context.Images.Where(x => x.productid == Productid));
                repositry.SaveChange();


                for (int i = 0; i < product.ImagesFile.Length; i++)
                {

                    updateproduct.Images.Add(new Image());
                    updateproduct.Images[i].Name = DocumentSitting.addFile(product.ImagesFile[i], "images");
                }
            }

            try
            {

                updateproduct.Name = product.Name;
                updateproduct.Description = product.Description;
                updateproduct.Type = product.Type;
                updateproduct.Price = product.Price;
                updateproduct.address = product.address;
                updateproduct.Aprove = false;
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

        // update Status

        [HttpPut("Status")]
        public async Task<ActionResult> UpdateStatus([FromBody] int Productid)
        {


            var updateproduct = await repositry.GetDataByIdAsync(Productid);
            if (updateproduct == null)

                return BadRequest();

            try
            {

                updateproduct.Aprove = true;

               repositry.Update(updateproduct);
                repositry.SaveChange();

                var prpoveTrue = context.Products.Select(p => p).Where(p => p.Aprove == false);
                return Created("done", prpoveTrue);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }   
        // update Status

        [HttpGet("StatusFalse")]
        public async Task<ActionResult> GetStatusFalse()
        {


       

                var prpoveTrue = context.Products.Select(p => p).Where(p => p.Aprove == false);
          
            
                return Ok(prpoveTrue);

        }  [HttpGet("Statustrue")]
        public async Task<ActionResult> GetStatusTrue()
        {


       

                var prpoveTrue = context.Products.Select(p => p).Where(p => p.Aprove == true);
          
            
                return Ok(prpoveTrue);

        }

        //delete  
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {

            var data = await repositry.GetDataByIdAsync(id);
            if (data == null)
                return NotFound(new ApiErroeResponse(400, "this book not found"));
            var images = context.Images.ToList().Where(img => img.productid == id);
            foreach (var img in images)
            {
                DocumentSitting.deleteFile("images", img.Name);
            }
            repositry.Delete(data);
            repositry.SaveChange();
            return Ok(data);
        }

        [HttpPost("addComment")]
        public ActionResult<Comment> addComent(Comment comment)

        {
            var AddComent = context.Comments.Add(comment);
            context.SaveChanges();
            return Ok("Done");
        }
    }
}
