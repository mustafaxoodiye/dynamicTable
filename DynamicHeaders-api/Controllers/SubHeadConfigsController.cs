using DynamicHeaders_api.Data;
using DynamicHeaders_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamicHeaders_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubHeadConfigsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SubHeadConfigsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var res = await _context.subHeadConfigs.ToListAsync();

        return Ok(res);
    }

     [HttpGet("{id}")]
    public async Task<IActionResult> GetBySubheadId(string id)
    {
        var res = await _context.subHeadConfigs.FirstOrDefaultAsync(e=> e.SubHeadId == id);

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Post(PostConfigRequest request)
    {
        var config = new SubHeadConfig
        {
            SubHeadId = request.SubHeadId,
            MetaData = request.MetaData,
        };

        _context.subHeadConfigs.Add(config);

        await _context.SaveChangesAsync();

        return Created("", new { });
    }
}

public class PostConfigRequest
{
    public string SubHeadId { get; set; }
    public List<SubHeadMetaData> MetaData { get; set; } = [];
}