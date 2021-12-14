using MediatR;

namespace DashboardTool.WidgetService.Services.Query
{
    public class WidgetQuery: IRequest<WidgetDto>
    {
        public int Id { get; set; }
        
        public WidgetQuery(int id)
        {
            Id = id;
        }

        

    }
}