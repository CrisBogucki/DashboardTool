using Microsoft.AspNetCore.Mvc;

namespace DashboardTool.WidgetService.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class WidgetEndpoints: ControllerBase
    {
        [HttpGet(Name = "Fubby")] 
        public string Get() => "OK";
    }
}