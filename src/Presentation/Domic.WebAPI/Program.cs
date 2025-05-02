using Domic.Core.Infrastructure.Extensions;
using Domic.Core.WebAPI.Extensions;
using Domic.Infrastructure.Extensions.C;
using Domic.Persistence.Contexts.C;
using Domic.WebAPI.EntryPoints.GRPCs;
using Domic.WebAPI.Frameworks.Extensions;

/*-------------------------------------------------------------------*/

WebApplicationBuilder builder = WebApplication.CreateBuilder();

#region Configs

builder.WebHost.ConfigureAppConfiguration((context, builder) => builder.AddJsonFiles(context.HostingEnvironment));

#endregion

/*-------------------------------------------------------------------*/

#region Service Container

builder.RegisterHelpers();
builder.RegisterELK();
builder.RegisterGrpcServer();
builder.RegisterEntityFrameworkCoreCommand<SQLContext, string>();
builder.RegisterCommandQueryUseCases();
builder.RegisterCommandRepositories();
builder.RegisterMessageBroker();
builder.RegisterEventStreamBroker();
builder.RegisterDistributedCaching();
builder.RegisterEventsPublisher();
builder.RegisterEventsSubscriber();
builder.RegisterServices();
builder.RegisterAssemblyTypesInMemory();

builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

#endregion

/*-------------------------------------------------------------------*/

WebApplication application = builder.Build();

/*-------------------------------------------------------------------*/

//primary processing

application.Services.AutoMigration<SQLContext>(context => context.Seed());

/*-------------------------------------------------------------------*/

#region Middleware

if (application.Environment.IsProduction())
{
    application.UseHsts();
    application.UseHttpsRedirection();
}

application.UseRouting();

application.UseEndpoints(endpoints => {

    endpoints.HealthCheck(application.Services);
    
    #region GRPC's Services

    endpoints.MapGrpcService<TicketRPC>();

    #endregion

});

#endregion

/*-------------------------------------------------------------------*/

//HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

application.Run();

/*-------------------------------------------------------------------*/

//For Integration Test

public partial class Program;