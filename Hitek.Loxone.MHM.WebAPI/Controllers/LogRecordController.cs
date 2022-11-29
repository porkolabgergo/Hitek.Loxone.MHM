using Hitek.Loxone.MHM.Shared.Models;
using Hitek.Loxone.MHM.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Hitek.Loxone.MHM.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LogRecordController : Controller
{
    private readonly ILogger<LogRecordController> _logger;
    private LogRecordRepository db = new();

    public LogRecordController(ILogger<LogRecordController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public object Get()
    {
        var data = db.GetAllLogRecords().AsQueryable();
        var count = data.Count();
        var queryString = Request.Query;
        if (!queryString.Keys.Contains("$inlinecount")) return data;
        StringValues Skip;
        StringValues Take;
        var skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
        var top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
        return new {Items = data.Skip(skip).Take(top), Count = count};
    }

    [HttpPost]
    public void Post([FromBody] LogRecord l)
    {
        db.AddLogRecord(l);
    }

    [HttpPut]
    public object Put([FromBody] LogRecord l)
    {
        db.UpdateLogRecord(l);
        return l;
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        db.DeleteLogRecord(id);
    }
}
