using Application.Commands;
using Application.Queries;
using Application.Services;


namespace ArchitectureTestApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var companyDto = await _companyService.FindById(new GetCompanyQuery(id));
        return Ok(companyDto);
    }
    
   
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CreateCompanyCommand request)
    {
        var companyId = await _companyService.CreateCompany(request);
        return Ok(new { CompanyId = companyId });
    }
}
