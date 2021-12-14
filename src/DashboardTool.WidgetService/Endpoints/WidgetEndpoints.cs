using System.Threading.Tasks;
using DashboardTool.WidgetService.Services.Command;
using DashboardTool.WidgetService.Services.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DashboardTool.WidgetService.Endpoints
{
    [ApiController]
    [Route("widget")]
    public class WidgetEndpoints : ControllerBase
    {
        private readonly IMediator _mediator;

        public WidgetEndpoints(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddWidget()
        {
            await _mediator.Send(new WidgetCommand("New widget"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWidget(int id)
        {
            WidgetDto result = await _mediator.Send(new WidgetQuery(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }
    }
}