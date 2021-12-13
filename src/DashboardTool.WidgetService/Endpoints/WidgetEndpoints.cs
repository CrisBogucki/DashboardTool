using System.Threading.Tasks;
using DashboardTool.WidgetService.Services.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DashboardTool.WidgetService.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class WidgetEndpoints: ControllerBase
    {
        private readonly IMediator _mediator;

        public WidgetEndpoints(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "Add")] 
        public Task AddWidget() => _mediator.Send(new WidgetCommand("New widget"));
    }
}