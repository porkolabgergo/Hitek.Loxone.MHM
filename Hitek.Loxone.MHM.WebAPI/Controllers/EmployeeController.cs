using Hitek.Loxone.MHM.Shared.Models;
using Hitek.Loxone.MHM.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Hitek.Loxone.MHM.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;
    private EmployeeRepository db = new();
    
    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public object Get()
    {
        var data = db.GetAllEmployees().AsQueryable();
        var count = data.Count();
        var queryString = Request.Query;
        if (!queryString.Keys.Contains("$inlinecount")) return data;
        StringValues Skip;
        StringValues Take;
        var skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
        var top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
        return new { Items = data.Skip(skip).Take(top), Count = count };
    }

    [HttpPost]
    public void Post([FromBody]Employee e)
    {
        db.AddEmployee(e);
    }

    [HttpPut]
    public object Put([FromBody] Employee e)
    {
        db.UpdateEmployee(e);
        return e;
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        db.DeleteEmployee(id);
    }
}