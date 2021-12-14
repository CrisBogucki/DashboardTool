using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DashboardTool.WidgetService.Services.Command
{
    public class WidgetCommandHandler : IRequestHandler<WidgetCommand>
    {
        private ILogger<WidgetCommandHandler> Logger { get; set; }
        
        public WidgetCommandHandler(ILogger<WidgetCommandHandler> logger)
        {
            Logger = logger;
        }

        
        public async Task<Unit> Handle(WidgetCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Logger.LogInformation("Widget Command is success!");
            }, cancellationToken);
            
            return Unit.Value;
        }
        
    }
}