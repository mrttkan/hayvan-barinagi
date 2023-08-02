using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HayvanBarinagi.Models;
using System.Threading.Tasks;

namespace HayvanBarinagi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        public AccountController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Kullanici model, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = new Kullanici
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    DogumTarihi = model.DogumTarihi,
                    TelefonNumarasi = model.TelefonNumarasi,
                    Adres = model.Adres
                };
                var result = await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Kullanıcı");
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    TempData["SuccessMessage"] = "Başarıyla kayıt oldunuz!";
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Register");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var result = await _signInManager.PasswordSignInAsync(Email, Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                HttpContext.Session.SetString("Email", Email);
                return RedirectToAction("Index", "Home");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesap kilitlendi. Lütfen daha sonra tekrar deneyin.");
            }
            else
            {
                ModelState.AddModelError("", "E-posta veya parola yanlış.");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["SuccessMessage"] = "Başarıyla çıkış yaptınız!";
            return RedirectToAction("Index", "Home");
        }
    }
}


