using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BasketController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public BasketController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
