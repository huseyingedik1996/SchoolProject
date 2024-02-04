using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.DataAccess.Context;
using School.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace School.Business.ProgramCsExtensions
{
    public static class ProgramCsExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(opt =>
            {
                opt.UseNpgsql("Host=localhost;Port=5432;Database=SchoolContextDb;Username=admin;Password=shaze");
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    
                };
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }

        
    }
}
