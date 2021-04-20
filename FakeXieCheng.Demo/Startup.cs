using AutoMapper;
using FakeXieCheng.Demo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FakeXieCheng.Demo.MyFakeContext;

namespace FakeXieCheng.Demo
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
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FakeContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    var configKeyBytes = System.Text.Encoding.UTF8.GetBytes(Configuration["SignatureKey:loginKey"]);
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["SignatureKey:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["SignatureKey:Audience"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(configKeyBytes)

                    };
                }
                );
            services.AddControllers(mvcOptions =>
            {
                mvcOptions.ReturnHttpNotAcceptable = true;
            })
                .AddNewtonsoftJson(setupAction => setupAction.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver())
                .AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(
                setupAction => setupAction.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetail = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "阿莱克斯",
                            Title = "数据验证失败",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "详细信息",
                            Instance = context.HttpContext.Request.Path
                        };
                        problemDetail.Extensions.Add("id", context.HttpContext.TraceIdentifier);
                        return new UnprocessableEntityObjectResult(problemDetail)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    }
                );




            // services.AddTransient<ITouristRoutRepository,MockTouristRoutRespository>();
            services.AddTransient<ITouristRoutRepository, TouristRoutRespository>();
            services.AddDbContext<MyFakeContext.FakeContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("linkDb"));
                // optionsBuilder.UseMySql(Configuration.GetConnectionString("mysqlDb"));
            });

            //扫描profile 文件
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();
            //你在哪
            app.UseRouting();
            //你是谁
            app.UseAuthentication();
            //你能干什么
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
