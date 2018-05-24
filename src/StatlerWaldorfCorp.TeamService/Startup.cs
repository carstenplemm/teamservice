using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService
{
    class Startup
    {
	public Startup(IHostingEnvironment env)
        {
	   	
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logerFactory)
        {
	   app.Run(async (context) =>
           {
	      await context.Response.WriteAsync("Kuckuck!");
           });
        }

	public void ConfigureServices(IServiceCollection services)
	{
	   services.AddMvc();
	   services.AddScoped<ITeamRepository, MemoryTeamRepository>();
	}
    }
}
