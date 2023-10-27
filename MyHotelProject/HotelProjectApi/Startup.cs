using MHBusinessLayer.Abstract;
using MHBusinessLayer.Concrete;
using MHDataAccessLayer.Abstract;
using MHDataAccessLayer.Concrete;
using MHDataAccessLayer.EntityFramework;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProjectApi
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
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>
                (TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();
           // services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders(); // ýdentity için

            services.AddHttpClient();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum zaman aþýmýný ayarlayabilirsiniz
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();


            //services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            //services.AddScoped<ISubscribeService, SubscribeManager>();

            //services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            //services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddSession();

            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            //services.AddScoped<IContactDal, EfContactDal>();
            //services.AddScoped<IContactService, ContactManager>();

            //services.AddScoped<IGuestDal, EfGuestDal>();
            //services.AddScoped<IGuestService, GuestManager>();

            //services.AddScoped<ISendMessageDal, EfSendMessageDal>();
            //services.AddScoped<ISendMessageService, SendMessageManager>();

            //services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();
            //services.AddScoped<IMessageCategoryService, MessageCategoryManager>();

            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddSingleton<IFileProvider>(
      new PhysicalFileProvider(Directory.GetCurrentDirectory()));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("http://localhost:35837") // Ýzin vermek istediðiniz kaynaðý burada belirtin
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddHttpClient();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelProjectApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelProjectApi v1"));
            }

            app.UseRouting();

            app.UseHttpsRedirection();


            app.UseCors(x => x
             .AllowAnyOrigin()     // api req kodlarý güvenlik için (vs code)
             .AllowAnyMethod()
             .AllowAnyHeader());

            


            app.UseAuthentication();


            app.UseAuthorization();



            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

      
    }
}
