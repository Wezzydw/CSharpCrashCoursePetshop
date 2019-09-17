﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA_Petshop.Core.ApplicationServices;
using CA_Petshop.Core.ApplicationServices.Services;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Infrastructure.Data.Repositories;
using CA_Petshop.Infrastructure.Data.SQL;
using CA_Petshop.Infrastructure.Data.SQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UI.RestAPI
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
            services.AddScoped<IPetRepository, PetSQLRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerSQLRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddDbContext<PetshopContext>(opt => opt.UseSqlite("Data Source=Petshop.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PetshopContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DBfiller.Seed(context);
                }

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
