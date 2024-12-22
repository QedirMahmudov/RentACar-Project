//using Business.Abstract;
//using Entities.DTOs;
//using Microsoft.AspNetCore.Mvc;

//namespace UI.Controllers
//{
//    public class AuthController : Controller
//    {
//        private readonly IAuthService _authService;

//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpGet("register")]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost("register")]
//        public IActionResult Register(RegisterDto userForRegisterDto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(userForRegisterDto);
//            }

//            var userExists = _authService.UserExists(userForRegisterDto.Email);
//            if (!userExists.Success)
//            {
//                ModelState.AddModelError("", userExists.Message);
//                return View(userForRegisterDto);
//            }

//            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
//            if (!registerResult.Success)
//            {
//                ModelState.AddModelError("", registerResult.Message);
//                return View(userForRegisterDto);
//            }

//            var result = _authService.CreateAccessToken(registerResult.Data);
//            if (result.Success)
//            {
//                return RedirectToAction("Index", "Home");
//            }

//            ModelState.AddModelError("", result.Message);
//            return View(userForRegisterDto);
//        }

//        [HttpGet("Login")]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost("Login")]
//        public IActionResult Login(LoginDTO loginDTO)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(loginDTO);
//            }

//            var userToLogin = _authService.Login(loginDTO);
//            if (!userToLogin.Success)
//            {
//                ModelState.AddModelError("", userToLogin.Message);
//                return View(loginDTO);
//            }

//            var result = _authService.CreateAccessToken(userToLogin.Data);
//            if (result.Success)
//            {
//                HttpContext.Response.Cookies.Append("AuthToken", result.Data.Token);
//                return RedirectToAction("Index", "Home");
//            }

//            ModelState.AddModelError("", result.Message);
//            return View(loginDTO);
//        }
//    }
//}
