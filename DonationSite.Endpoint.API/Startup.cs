using DonationSite.Core.Contracts;
using DonationSite.Core.Contracts.Donate;
using DonationSite.Core.Contracts.Report;
using DonationSite.Core.Contracts.Site;
using DonationSite.Core.Services;
using DonationSite.DataAccess.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DonationSite.Endpoint.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Dependencies

            services.AddDbContext<DonationSiteDataContext>(option =>
            option.UseSqlServer($"Data Source=.;Initial Catalog=DonationSite;Integrated Security=True"));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISiteService, SiteService>();
            services.AddTransient<IDonateService, DonateService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            #endregion

            services.AddCors(o =>
            {
                o.AddPolicy("CorsAllowAll", builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DonationSite.Endpoint.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DonationSiteDataContext dataContext )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DonationSite.Endpoint.API v1"));
            }
            app.UseHttpsRedirection();
            app.UseCors("CorsAllowAll");
            app.UseRouting();            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            dataContext.Database.EnsureCreated();

        }
    }
}
