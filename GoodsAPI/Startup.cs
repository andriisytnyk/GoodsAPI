//using AutoMapper;
using FluentValidation;
using GoodsAPI.BLL.Interfaces;
using GoodsAPI.BLL.Mapping;
using GoodsAPI.BLL.Services;
using GoodsAPI.BLL.Validators;
using GoodsAPI.DAL.DBInfrastructure;
using GoodsAPI.DAL.Repositories;
using GoodsAPI.Shared.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GoodsContext>(options => options.UseSqlServer(conn));

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<IGoodTypeService, GoodTypeService>();
            services.AddScoped<IImportanceService, ImportanceService>();
            services.AddScoped<IUserService, UserService>();

            services.AddTransient<AbstractValidator<AccountDTO>, AccountValidator>();
            services.AddTransient<AbstractValidator<BillDTO>, BillValidator>();
            services.AddTransient<AbstractValidator<GoodDTO>, GoodValidator>();
            services.AddTransient<AbstractValidator<GoodTypeDTO>, GoodTypeValidator>();
            services.AddTransient<AbstractValidator<ImportanceDTO>, ImportanceValidator>();
            services.AddTransient<AbstractValidator<UserDTO>, UserValidator>();

            services.AddScoped<AccountRepository>();
            services.AddScoped<BillRepository>();
            services.AddScoped<GoodRepository>();
            services.AddScoped<GoodTypeRepository>();
            services.AddScoped<ImportanceRepository>();
            services.AddScoped<UserRepository>();

            //var mapper = Mapping.ConfigureMapping().CreateMapper();
            //services.AddScoped(m => mapper);

            services.AddTransient<IMapper, Mapping>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
