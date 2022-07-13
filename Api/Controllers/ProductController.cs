using Api.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var pro = await _unitOfWork.ProductService.GetAsync(id);
        return Ok(pro);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pros = await _unitOfWork.ProductService.GetAllProductAsync();
        return Ok(pros);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ProductCreateDto productCreateDto)
    {
        string pictureUrl = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(productCreateDto.Picture.FileName);

        using (FileStream stream = new FileStream(Path.Combine("wwwroot", "images", pictureUrl), FileMode.CreateNew))
        {
            await productCreateDto.Picture.CopyToAsync(stream);
        }

        Product product = new Product()
        {
            Name = productCreateDto.Name,
            Price = productCreateDto.Price,
            Brand = productCreateDto.Brand,
            Description = productCreateDto.Description,
            Type = productCreateDto.Type,
            PictureUrl = pictureUrl
        };

        await _unitOfWork.ProductService.CreateAsync(product);
        await _unitOfWork.SaveChangesAsync();
        return Ok();
    }

}
