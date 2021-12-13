using System.Reflection;
using Autofac;
using MediatR;

namespace DashboardTool.WidgetService.IoC
{
    public class WidgetServiceIoCModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            var mediateOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>)
            };

            foreach (var mediateOpenType in mediateOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .AsClosedTypesOf(mediateOpenType)
                    .AsImplementedInterfaces();
            }

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }
    }
}