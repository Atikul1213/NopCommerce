using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.NopStationTeams.Factories;
using Nop.Plugin.Misc.NopStationTeams.Services;

namespace Nop.Plugin.Misc.NopStationTeams.Infrastructure;
public class NopStartup : INopStartup
{
    public int Order => 3000;

    public void Configure(IApplicationBuilder application)
    {
       
    }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeModelFactory, EmployeeModelFactory>();
    }
}
