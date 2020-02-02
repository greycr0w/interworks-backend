using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Interworks.API.Entities;
using Interworks.API.Entities.Part1;
using Interworks.API.Entities.Part2;
using Interworks.API.Helpers;
using Interworks.API.Interfaces;
using Interworks.API.Repositories;
using Interworks.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Interworks.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = this.Configuration.GetSection("AppSettings").Get<AppSettings>();

            
            string  smtp_host = appSettings.smtp.server;
            
            if (smtp_host == null || !Int32.TryParse(appSettings.smtp.port, out int _smtp_port)) {
                throw new Exception("SMTP server details are invalid");
            }
            var smtp_credientals = new NetworkCredential(appSettings.smtp.user,appSettings.smtp.pass);

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(appSettings.secret);
            
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // configure DI for application services
            services.Configure<AppSettings>(this.Configuration.GetSection("AppSettings"));
            services.AddMvc();
         
                

            services
                .AddCors()
                .AddScoped(a => new SmtpClient(smtp_host, _smtp_port) {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = smtp_credientals,
                    EnableSsl = true
                })
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseNpgsql(appSettings.database,
                        psql => psql.SetPostgresVersion(11, 5)
                    ))
                .AddControllers()
                .AddNewtonsoftJson();
            
            //services
            services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IDiscountService, DiscountService>()
                .AddScoped<IAuthenticationService, AuthenticationService>();
            
            
            //repositories
            services
                .AddScoped<UserRepository>()
                .AddScoped<IRepositoryAsync<Category>, BaseRepository<Category>>()
                .AddScoped<IRepositoryAsync<Country>,BaseRepository<Country>>()
                .AddScoped<IRepositoryAsync<Discount>,BaseRepository<Discount>>()
                .AddScoped<IRepositoryAsync<Order>,BaseRepository<Order>>()
                .AddScoped<ProductRepository>()
                .AddScoped<IRepositoryAsync<Data>,BaseRepository<Data>>()
                .AddScoped<IRepositoryAsync<Field>,BaseRepository<Field>>()
                .AddScoped<IRepositoryAsync<FieldOption>,BaseRepository<FieldOption>>()
                .AddScoped<IRepositoryAsync<Page>,BaseRepository<Page>>()
                .AddScoped<IDiscountRepository, DiscountRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
