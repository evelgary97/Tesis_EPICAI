using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tesis_EPICAI.Models;
using Tesis_EPICAI.ViewModels.Usuarios;

namespace Tesis_EPICAI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {

            if (_userManager.Users.Count() > 0)
            {
                return View();
            }
            var rol = new IdentityRole
            {
                Name = "ADMIN"
            };

            if (!await _roleManager.RoleExistsAsync("ADMIN"))
            {
                await _roleManager.CreateAsync(rol);
            }
            var rol1 = new IdentityRole
            {
                Name = "USUARIO"
            };

            if (!await _roleManager.RoleExistsAsync("USUARIO"))
            {
                await _roleManager.CreateAsync(rol1);
            }

            return View("NewUser");
        }

        public async Task<IActionResult> Index2(Create model)
        {
            var role = await _roleManager.FindByNameAsync("ADMIN");
            var user = new IdentityUser
            {
                UserName = model.Nombre
            };
            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, role.Name);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
