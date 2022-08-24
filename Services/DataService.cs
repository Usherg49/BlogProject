using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await SeedRolesAsync();

            await SeedUserssAsync();
        }

        private async Task SeedRolesAsync()
        {
            if(_dbContext.Roles.Any())
            {
                return;
            }

            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUserssAsync()
        {
            if(_dbContext.Users.Any())
            {
                return;
            }

            var adminUser = new BlogUser()
            {
                Email = "ushergluck@gmail.com",
                UserName = "ushergluck@gmail.com",
                FirstName = "Usher",
                LastName = "Gluck",
                PhoneNumber = "347-452-4895",
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(adminUser, "1234");

            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            var modUser = new BlogUser()
            {
                Email = "bobovprincipal@gmail.com",
                UserName = "bobovprincipal@gmail.com",
                FirstName = "Principal",
                LastName = "Bobov",
                PhoneNumber = "718-253-1213",
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(modUser, "1234");

            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }
    }
}
