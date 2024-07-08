using Medical_Laboratory_Management.Data;
using Medical_Laboratory_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Medical_Laboratory_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LabDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User, IdentityRole<int>>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<LabDbContext>();

            var app = builder.Build();

            // Seed Admin User
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<LabDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

                context.Database.EnsureCreated();
                //await SeedAdminUserAsync(userManager, roleManager);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            async Task SeedAdminUserAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
            {
                const string adminRole = "Admin";
                const string adminEmail = "admin@example.com";
                const string adminPassword = "AdminPassword123";

                // Ensure the admin role exists
                if (!await roleManager.RoleExistsAsync(adminRole))
                {
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = adminRole });
                }

                // Ensure the admin user exists
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        Name = "Admin",
                        Age = 30,
                        Gender = Gender.MALE,
                        PhoneNumber = "1234567890",
                        Address = "Admin Address",
                        StateId = 1,
                        CityId = 1,
                        BloodGroup = BloodGroup.O_Positive
                    };

                    await userManager.CreateAsync(adminUser, adminPassword);
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
        }
    }
}
