using MediatR;

namespace DashboardTool.WidgetService.Services.Command
{
    public class WidgetCommand: IRequest
    {
        public string Name { get; set; }
        
        public WidgetCommand(string name)
        {
            Name = name;
        }

    }
}