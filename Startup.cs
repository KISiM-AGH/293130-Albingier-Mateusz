using AutoMapper;
using FullStack_Project_IE_2.Core.Repositories;
using FullStack_Project_IE_2.Core.Security.Hashing;
using FullStack_Project_IE_2.Core.Security.Tokens;
using FullStack_Project_IE_2.Core.Services;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Persistence.Contexts;
using FullStack_Project_IE_2.Persistence.Repositories;
using FullStack_Project_IE_2.Security.Hashing;
using FullStack_Project_IE_2.Security.Tokens;
using FullStack_Project_IE_2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;

namespace FullStack_Project_IE_2
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("test"));
            services.AddScoped<IDancerRepository, DancerRepository>();
            services.AddScoped<IDancerService, DancerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICoupleRepository, CoupleRepository>();
            services.AddScoped<ICoupleService, CoupleService>();
            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<ICompetitionService, CompetitionService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, Security.Tokens.TokenHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            var signingConfiguration = new SigningConfigurations();
            services.AddSingleton(signingConfiguration);

            Console.WriteLine("*************************************************");
            Console.WriteLine(tokenOptions.Equals(null));
            Console.WriteLine("*************************************************");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions=>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfiguration.Key,
                        ClockSkew = TimeSpan.Zero
                    };
                }
            );

            services.AddSwaggerGen(c=>c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{ Title = "Dancers database", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dancers database");
                });
            
        }
    }
}
