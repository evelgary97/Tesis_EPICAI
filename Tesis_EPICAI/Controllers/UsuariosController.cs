using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tesis_EPICAI.ViewModels.Usuarios;

namespace Tesis_EPICAI.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class UsuariosController : Controller
    {
        private readonly AppContext _appContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsuariosController(AppContext appContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appContext = appContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = from user in _appContext.Users
                       from userRol in _appContext.UserRoles
                       from rol in _appContext.Roles
                       where user.Id == userRol.UserId && userRol.RoleId == rol.Id
                       select new UserWithRole
                       {
                           User = user.UserName,
                           Role = rol.Name,
                           Id = user.Id
                       };
            var sal = list.ToList<UserWithRole>();
            return View(sal);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Create model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Nombre,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "USUARIO");
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Nombre);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        [Route("Usuarios/CheckName")]
        public async Task<IActionResult> CheckName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"El usuario {name} no esta disponible.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _appContext.Users.FirstAsync(x => x.Id == Id);

            if (user != null)
            {
                var model = new Create
                {
                    Nombre = user.UserName
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Create model, string Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                var user = await _appContext.Users.FirstAsync(x => x.Id == Id);
                user.UserName = model.Nombre;
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, model.Password);
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var user = await _appContext.Users.FirstAsync(x => x.Id == Id);
            if (user != null)
            {
                var rol = from u in _appContext.Users
                          from userRol in _appContext.UserRoles
                          from r in _appContext.Roles
                          where u.Id == userRol.UserId && userRol.RoleId == r.Id
                          select r.Name;
                var rollist = rol.ToList();
                var model = new Delete
                {
                    Nombre = user.UserName,
                    Rol = rollist.ElementAt(0),
                    Id = user.Id
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Deleted(string Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            var user = await _appContext.Users.FirstAsync(x => x.Id == Id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
