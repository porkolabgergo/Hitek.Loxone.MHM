using Hitek.Loxone.MHM.Shared.Enums;
using Hitek.Loxone.MHM.Shared.Models;
using Hitek.Loxone.MHM.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hitek.Loxone.MHM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoxoneController : ControllerBase
    {
        LogRecordRepository LogRecordRepository { get; } = new LogRecordRepository();
        EmployeeRepository EmployeeRepository { get; } = new EmployeeRepository();
        // GET: api/<LoxoneController>
        [HttpGet]
        public void Get()
        {
            var client = new RestClient("http://192.168.0.24/jdev/sps/io/1a2b4010-0188-6039-ffffed57184a04d2");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic YWRtaW46NkMzZjQwNDg=");
            IRestResponse response = client.Execute(request);
            var resp = JsonConvert.DeserializeObject<LoxoneResponse>(response.Content);
            var emp = EmployeeRepository.GetEmployee(resp.LL.value);
            LogRecordRepository.AddLogRecord(new LogRecord
            {
                Id = Guid.NewGuid(),
                LogType = emp.IsCheckedIn ? LogType.Out : LogType.In,
                Date = DateTime.Now,
                EmployeeID = resp.LL.value
            });
        }
    }
}
