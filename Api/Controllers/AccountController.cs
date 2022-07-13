using Api.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AccountController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public AccountController(IUnitOfWork unitOfWork, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }


    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        string token = await _unitOfWork.UserService.CheckPasswordAsync(loginDto.Email, loginDto.Password);
        if (!string.IsNullOrEmpty(token))
        {
            return Ok(new { token });
        }
        else
        {
            return Unauthorized();
        }
    }


    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        User u = new User()
        {
            Email = registerDto.Email,
            UserName = registerDto.Username
        };
        IdentityResult identityResult = await _unitOfWork.UserService.CreateAsync(u, registerDto.Password);
        if (identityResult.Succeeded)
        {
            return Ok();
        }
        var errs = JsonConvert.SerializeObject(identityResult.Errors);
        return BadRequest(errs);
    }



}