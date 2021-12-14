using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using DashboardTool.WidgetService.Services.Command;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DashboardTool.WidgetService.Services.Query
{
    public class WidgetQueryHandler : IRequestHandler<WidgetQuery, WidgetDto>
    {
        private ILogger<WidgetQueryHandler> Logger { get; set; }

        public WidgetQueryHandler(ILogger<WidgetQueryHandler> logger)
        {
            Logger = logger;
        }


        public async Task<WidgetDto> Handle(WidgetQuery request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { Logger.LogInformation($"Widget {request.Id} Query is success!"); },
                cancellationToken);

            return (request.Id % 2 != 0 ? null : new WidgetDto($"Widget {request.Id} Query is success!"))!;
        }
    }
}