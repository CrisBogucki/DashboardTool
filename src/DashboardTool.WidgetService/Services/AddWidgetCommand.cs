using MediatR;

namespace DashboardTool.WidgetService.Services
{
    public class WidgetCommand: IRequest
    {
        public string Name { get; set; }
    }
}