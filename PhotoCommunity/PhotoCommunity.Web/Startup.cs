using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.PlatformAbstractions;
using PhotoCommunity.Repository.ArticleDomain.Repository;
using PhotoCommunity.Repository.myDbContent;
using PhotoCommunity.Repository.UserDomain.Repository;
using PhotoCommunity.Service;
using PhotoCommunity.Service.Impl;
using Swashbuckle.AspNetCore.Swagger;
using UEditor.Core;

namespace PhotoCommunity.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //swagger
#if DEBUG
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "PhotoCommunity"
                });

                //Determine base path for the application.  
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //Set the comments path for the swagger json and ui.  
                var xmlPath = Path.Combine(basePath, "PhotoCommunity.Web.xml");
                options.IncludeXmlComments(xmlPath);
            });
#endif
            //DbContext注入
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyDbContext>(options => options.UseMySql(connection));

            //Session注入
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".PhotoCommunity.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            //注入服务
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IClassService,ClassService>();
            services.AddScoped<IPhotoService,PhotoService>();
            services.AddScoped<ICommentService,CommentService>();

            //注入Repository
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IClassRepository,ClassRepository>();
            services.AddScoped<IPhotoRepository,PhotoRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<IReplyCommentRepository,ReplyCommentRepository>();

            //注入editor
            services.AddUEditorService();

            // init automapper
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DefaultProfile>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("/index.html");
            app.UseDefaultFiles(defaultFilesOptions);

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            //ueditor
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "upload")),
                RequestPath = "/upload",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
                }
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
           app.UseMvc();

            //swagger
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoCommunity.Web");
            });

            app.UseStaticFiles();
#endif
        }
    }
}
