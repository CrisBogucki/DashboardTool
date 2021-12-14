using MediatR;

namespace DashboardTool.WidgetService.Services.Query
{
    public class WidgetDto
    {
        public string Nazwa { get; set; }

        public WidgetDto(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
}