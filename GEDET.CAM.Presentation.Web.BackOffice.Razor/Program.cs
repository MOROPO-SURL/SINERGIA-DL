using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using MOROPO.GEDET.CAM.Core.Common.Ports.Service;
using MOROPO.GEDET.CAM.Core.Extensions;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;
using MOROPO.GEDET.CAM.Domain.Aggretates.PermissionAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Common.Ports.Service;
using MOROPO.GEDET.CAM.Infrastructure.Configurations;
using MOROPO.GEDET.CAM.Infrastructure.Extensions;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Configurations;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Extensions;
using MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Ports.Adapters.Manager;
using System.Runtime.CompilerServices;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor;

public class Program
{
    [ModuleInitializer]
    public static void Initialize()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
    }

    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection("Authentication"));
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        builder.Services.UseCoreLayer();
        builder.Services.UseInfrastructureLayer(builder.Configuration);

        builder.Services.AddMapster();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
        })
            .AddCookie(config =>
            {
                config.AccessDeniedPath = new PathString("/error/403");
                config.LoginPath = new PathString("/session/login");
                config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                config.SlidingExpiration = true;
            });

        builder.Services.AddSingleton<Ports.Manager.IRoleRuntimeManagerPort, InMemoryRoleRuntimeManagerPortAdapter>();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddResponseCaching();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddCors();

        builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "dpkeys")));

        builder.Services.AddControllersWithViews();

        builder.Services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();

        WebApplication app = builder.Build();

        app.Services.ApplyCoreMappings();
        app.Services.ApplyPresentationMappings();

        using (var serviceScope = app.Services.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<Infrastructure.Persistence.EF.DefaultDbContext>();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (app.Environment.IsStaging())
            {
                dbContext!.Database.Migrate();

                var hasSeedingChanges = dbContext.LoadCoreSeeding();

                var backOfficeMmanagementPermissionId = new PermissionId(Constants.PermissionConstants.BACKOFFICE_MANAGEMENT_PERMISSION);

                if (!dbContext.Permissions.Any(entity => entity.Id == backOfficeMmanagementPermissionId))
                {
                    dbContext.Permissions.Add(Constants.PermissionConstants.BACKOFFICE_MANAGEMENT_PERMISSION.ToPermissionEntity());

                    if (!hasSeedingChanges) hasSeedingChanges = true;
                }

                if (!dbContext.Users.Any())
                {
                    var defaultUserConfiguration = new DefaultUserConfiguration();

                    app.Configuration.Bind("DefaultUser", defaultUserConfiguration);

                    var defaultUser = new User(
                        new UserId(defaultUserConfiguration.UserName),
                        true,
                        app.Services.GetService<IStringHashingServicePort>()!.GetHashed(defaultUserConfiguration.Password),
                        defaultUserConfiguration.FirstName,
                        defaultUserConfiguration.LastName,
                        true,
                        true);

                    defaultUser.Signature = serviceScope.ServiceProvider.GetService<IDataIntegrityServicePort>()!.GetEntitySignatureAsync(defaultUser).GetAwaiter().GetResult();

                    dbContext.Users.Add(defaultUser);

                    if (!hasSeedingChanges) hasSeedingChanges = true;
                }

                if (hasSeedingChanges) dbContext.SaveChanges();
            }
            else
            {
                app.UseExceptionHandler("/error/exception");
                app.UseHsts();
            }

            Role[] atStartUpRoles = [.. dbContext!.Roles.Include(e => e.PermissionBridges).ThenInclude(b => b.Linked)];

            Ports.Manager.IRoleRuntimeManagerPort roleMemoryManager = app.Services.GetService<Ports.Manager.IRoleRuntimeManagerPort>()!;
            
            IMapper mapper = app.Services.GetService<IMapper>()!;

            foreach (Role item in atStartUpRoles)
            {
                roleMemoryManager!.RememberRole(mapper!.Map<RoleDetailDto>(item));
            }
        }

        app.UseStatusCodePagesWithReExecute("/error/{0}");

        app
            .UseHttpsRedirection()
            .UseStaticFiles()
            .UseCors()
            .UseRouting();
            
        app
            .UseAuthentication()
            .UseAuthorization()
            .UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{area:exists}/{controller=start}/{action=index}/{id?}");
        app.MapControllerRoute(
            name: "area_default",
            pattern: "{controller=start}/{action=index}/{key?}");

        app.Run();
    }
}
