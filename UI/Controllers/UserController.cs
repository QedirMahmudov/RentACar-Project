using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        //    private readonly HttpClient _httpClient;

        //    public UserController(HttpClient httpClient)
        //    {
        //        _httpClient = httpClient;
        //        _httpClient.BaseAddress = new Uri("https://localhost:5001/api/auth/login"); // API URL'i
        //    }

        //    public IActionResult Login()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Login(LoginDTO loginDTO)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(loginDTO);
        //        }

        //        // Login API'sini çağırıyoruz
        //        var jsonContent = JsonConvert.SerializeObject(loginDTO);
        //        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //        var response = await _httpClient.PostAsync("login", content);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            ModelState.AddModelError("", "Invalid username or password");
        //            return View(loginDTO);
        //        }

        //        // API'den başarılı sonuç dönmesi durumunda token'i alıyoruz
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        var token = JsonConvert.DeserializeObject<string>(responseString);

        //        // Token üzerinden kullanıcı bilgilerini ekleyip oturum açıyoruz
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email, loginDTO.Email),
        //            new Claim("AccessToken", token)
        //        };
        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var principal = new ClaimsPrincipal(identity);

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //        return RedirectToAction("Index", "Home");
        //    }

        //    public async Task<IActionResult> LogOut()
        //    {
        //        await HttpContext.SignOutAsync();
        //        return RedirectToAction("Login", "User");
        //    }
        //}

        //private readonly HttpClient _httpClient;
        //private readonly string _apiUrl = "https://localhost:7207"; // API URL'nizi buraya ekleyin

        //public UserController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //// Kullanıcı kaydı
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto registerDto)
        //{
        //    // API'ye POST isteği gönder
        //    var response = await _httpClient.PostAsJsonAsync($"{_apiUrl}/api/values/register", registerDto);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // JSON verisini çözümleyip AccessToken'ı alıyoruz
        //        var result = await response.Content.ReadFromJsonAsync<AccessToken>();

        //        // Token'ı TempData'ya kaydediyoruz (sayfalar arası veri taşımak için)
        //        TempData["Token"] = result.Token;
        //        TempData["Expiration"] = result.Expiration;

        //        // Ana sayfaya yönlendirme
        //        return RedirectToAction("Home", "Index");
        //    }
        //    else
        //    {
        //        // Hata mesajını al
        //        var errorMessage = await response.Content.ReadAsStringAsync();
        //        ModelState.AddModelError("", errorMessage); // Hata mesajını model hata listesine ekle
        //        return View(registerDto);
        //    }
        //}
        //public IActionResult Login()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDTO loginDto)
        //{
        //    var response = await _httpClient.PostAsJsonAsync($"{_apiUrl}/api/values/login", loginDto);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Token'ı al
        //        var result = await response.Content.ReadFromJsonAsync<AccessToken>();
        //        TempData["Token"] = result.Token;
        //        TempData["Expiration"] = result.Expiration;

        //        return RedirectToAction("Listing", "Home");
        //    }
        //    else
        //    {
        //        var errorMessage = await response.Content.ReadAsStringAsync();
        //        ModelState.AddModelError("", errorMessage);
        //        return View(loginDto);
        //    }
        //}

        // Gerekli alanlar
        //private readonly RentACarContext _sql;
        //private readonly IUserService _userService;
        //private readonly IAuthService _authService;
        //public UserController(IUserService userService, RentACarContext sql, IAuthService authService)
        //{
        //    _userService = userService;
        //    _sql = sql;
        //    _authService = authService;
        //}
        //public IActionResult Login()
        //{
        //    return View();
        //}


        //[HttpPost("login")]
        //public ActionResult Login(LoginDTO loginDTO)
        //{
        //    var userToLogin = _authService.Login(loginDTO);
        //    if (!userToLogin.Success)
        //    {
        //        return BadRequest(userToLogin.Message);
        //    }
        //    var result = _authService.CreateAccessToken(userToLogin.Data);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    else
        //        return BadRequest(result.Message);
        //}

        //public IActionResult LogOut()
        //{
        //    HttpContext.SignOutAsync().Wait();
        //    return RedirectToAction("Login", "User");
        //}




        //    [HttpPost]
        //    public IActionResult Login(LoginDTO loginUser)
        //    {
        //        //if (!ModelState.IsValid)
        //        //{
        //        //    return View(loginUser);
        //        //}

        //        // Kullanıcıyı username'e göre bul
        //        var user = _sql.Users.SingleOrDefault(x => x.Email == loginUser.Email && x.Status);


        //        if (user == null)
        //        {
        //            ModelState.AddModelError("", "Invalid email or password");
        //            return View(loginUser);
        //        }

        //        // HashingHelper kullanarak şifreyi doğrula
        //        if (!HashingHelper.VerifiedPasswordHash(loginUser.Password, user.PasswordHash, user.PasswordSalt))
        //        {
        //            ModelState.AddModelError("", "Invalid username or password");
        //            return View(loginUser);
        //        }

        //        // Eğer şifre doğruysa, oturum açma işlemini yap
        //        var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, user.FirstName)
        //};
        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var principal = new ClaimsPrincipal(identity);
        //        var authProperties = new AuthenticationProperties();

        //        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties).Wait();
        //        return RedirectToAction("Index", "Home");
        //    }
        //[HttpPost]
        //public IActionResult Login(LoginDTO loginUser)
        //{

        //    // Kullanıcıyı username'e göre bul
        //    var user = _sql.Users.SingleOrDefault(x => x.Email == loginUser.Email && x.Status);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Invalid username or password");
        //        return View(loginUser);
        //    }

        //    // Şifreyi doğrula
        //    if (!Core.Utilities.Security.Hashing.HashingHelper.VerifiedPasswordHash(loginUser.Password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        ModelState.AddModelError("", "Invalid username or password");
        //        return View(loginUser);
        //    }

        //    // Eğer şifre doğruysa, oturum açma işlemini yap
        //    var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, user.FirstName)
        //};
        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var principal = new ClaimsPrincipal(identity);
        //    var authProperties = new AuthenticationProperties();

        //    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties).Wait();
        //    return RedirectToAction("Index", "Home");
        //}








        //        private readonly RentACarContext _sql;
        //        private readonly IUserService _userService;
        //        public UserController(IUserService userService, RentACarContext sql)
        //        {
        //            _userService = userService;
        //            _sql = sql;

        //        }
        //        public IActionResult Login()
        //        {
        //            return View();
        //        }
        //        [HttpPost]
        //        [ValidationAspect<User>(typeof(UserValidation))]
        //        public IActionResult Login(User u)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return View(u);
        //            }


        //            var getUser = _sql.Users.SingleOrDefault(x => x.FirstName == u.FirstName && x.PasswordHash == u.UserPassword && u.IsActive == true);

        //            if (getUser != null)
        //            {
        //                var claim = new List<Claim>()
        //                {
        //                    new Claim(ClaimTypes.Name, u.FirstName),

        //                };
        //                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
        //                var princ = new ClaimsPrincipal(identity);
        //                var props = new AuthenticationProperties();
        //                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princ, props).Wait();

        //                return RedirectToAction("Index", "Home");

        //            }
        //            if (getUser.UserName != u.UserName || getUser.UserPassword != u.UserPassword)
        //            {
        //                ModelState.AddModelError("", "Invalid username or password");
        //                return View();
        //            }
        //            return View();
        //        }

        //        public IActionResult LogOut()
        //        {
        //            HttpContext.SignOutAsync().Wait();
        //            return RedirectToAction("Login", "User");
        //        }

    }
}