using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ComputersStore.Data;
using ComputersStore.Data.Entities;
using AutoMapper;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.BusinessServices.Implementation;
using ComputersStore.Services.Interfaces;
using ComputersStore.Services.Implementation;
using ComputersStore.Models.Mappings;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.EmailService.Configuration;
using ComputersStore.EmailService.Service.Interface;
using ComputersStore.EmailService.Service.Implementation;
using ComputersStore.EmailService.Sender.Interface;
using ComputersStore.EmailService.Factory.Interface;
using ComputersStore.EmailService.Sender.Implementation;
using ComputersStore.EmailService.Factory.Implementation;
using ComputersStore.EmailTemplates.Renderer.Interface;
using ComputersStore.EmailTemplates.Renderer.Implementation;

namespace ComputersStore
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
            var emailConfig = Configuration
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("ComputersStore.Database")));
            
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<SignInManager<ApplicationUser>>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductsMappingProfile());
                mc.AddProfile(new NewsletterMappingProfile());
                mc.AddProfile(new OrdersMappingProfile());
                mc.AddProfile(new ApplicationUserMappings());
                mc.AddProfile(new OrderStatusMappingProfile());
                mc.AddProfile(new PaymentTypeMappingProfile());
                mc.AddProfile(new AccountMappings());
                mc.AddProfile(new ShoppingCartMappingProfile());
                mc.AddProfile(new ProductCategoryMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<IShoppingCartBusinessService, ShoppingCartBusinessService>();
            services.AddTransient<IProductBusinessService, ProductBusinessService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<INewsletterBusinessService, NewsletterBusinessService>();
            services.AddTransient<INewsletterService, NewsletterService>();
            services.AddTransient<IOrderBusinessService, OrderBusinessService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderStatusBusinessService, OrderStatusBusinessService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<IPaymentTypeBusinessService, PaymentTypeBusinessService>();
            services.AddTransient<IPaymentTypeService, PaymentTypeService>();
            services.AddTransient<IProductCategoryBusinessService, ProductCategoryBusinessService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IAccountBusinessService, AccountBusinessService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IApplicationUserBusinessService, ApplicationUserBusinessService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IEmailMessagesService, EmailMessagesService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmailMessageFactory, EmailMessageFactory>();
            services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberGroupSeparator = ".";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
