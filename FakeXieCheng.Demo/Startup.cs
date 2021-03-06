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
using FakeXieCheng.Demo.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Formatters;

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
            services.AddIdentity<MyApplicationIdentity, IdentityRole>().AddEntityFrameworkStores<FakeContext>();

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
                            Type = "????????",
                            Title = "????????????",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Detail = "????????",
                            Instance = context.HttpContext.Request.Path
                        };
                        problemDetail.Extensions.Add("id", context.HttpContext.TraceIdentifier);
                        return new UnprocessableEntityObjectResult(problemDetail)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    }
                );

            var linkSqlServer = "linkDb";
            string computerName = Environment.GetEnvironmentVariable("computername");
            if (computerName == "DESKTOP-DU03A7R")
            {
                linkSqlServer = "linkDbDell";
            }

            // services.AddTransient<ITouristRoutRepository,MockTouristRoutRespository>();
            services.AddTransient<ITouristRoutRepository, TouristRoutRespository>();
            services.AddDbContext<MyFakeContext.FakeContext>(optionsBuilder =>
            {
                // ????????????,b=>b.UseRowNumberForPaging()
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString(linkSqlServer));
                // optionsBuilder.UseMySql(Configuration.GetConnectionString("mysqlDb"));
            });

            //????profile ????
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //????urlHelp ???? ????api??url????
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //????????????????model????
            services.AddTransient<IPropertyMappingServer, PropertyMappingServer>();

            //????????????????????
            services.Configure<MvcOptions>(options =>
            {
                var outPutFormatter = options.OutputFormatters.OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();
                if (outPutFormatter != null)
                {
                    outPutFormatter.SupportedMediaTypes.Add(Configuration["CostomApplicationType:hateoas"].Trim().ToLowerInvariant());
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //??????
            app.UseRouting();
            //??????
            app.UseAuthentication();
            //??????????
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
