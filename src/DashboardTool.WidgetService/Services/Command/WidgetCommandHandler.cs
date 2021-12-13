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
        private ILogger<WidgetCommandHandler> _logger { get; set; }
        
        public WidgetCommandHandler(ILogger<WidgetCommandHandler> logger)
        {
            _logger = logger;
        }

        
        public async Task<Unit> Handle(WidgetCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _logger.LogInformation("Widget Command is success!");
            }, cancellationToken);


            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            using var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled);
            // handle request handler
            //var response = await next();

            // complete database transaction
            transaction.Complete();

            return Unit.Value;
        }

        // private async Task next()
        // {
        //     throw new NotImplementedException();
        // }
    }
}