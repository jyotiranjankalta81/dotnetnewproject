// // // // // // using System;
// // // // // // using System.Collections.Generic;
// // // // // // using System.Linq;
// // // // // // using System.Threading.Tasks;
// // // // // // using api.Dtos.Account;
// // // // // // using api.Interfaces;
// // // // // // using api.Models;
// // // // // // using Microsoft.AspNetCore.Identity;
// // // // // // using Microsoft.AspNetCore.Mvc;
// // // // // // using Microsoft.EntityFrameworkCore;

// // // // // // namespace api.Controllers
// // // // // // {
// // // // // //     [Route("api/account")]
// // // // // //     [ApiController]
// // // // // //     public class AccountController : ControllerBase
// // // // // //     {
// // // // // //         private readonly UserManager<AppUser> _userManager;
// // // // // //         private readonly ITokenService _tokenService;
// // // // // //         private readonly SignInManager<AppUser> _signinManager;
// // // // // //         public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
// // // // // //         {
// // // // // //             _userManager = userManager;
// // // // // //             _tokenService = tokenService;
// // // // // //             _signinManager = signInManager;
// // // // // //         }

// // // // // //         [HttpPost("login")]
// // // // // //         public async Task<IActionResult> Login(LoginDto loginDto)
// // // // // //         {
// // // // // //             if (!ModelState.IsValid)
// // // // // //                 return BadRequest(ModelState);

// // // // // //             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

// // // // // //             if (user == null) return Unauthorized("Invalid username!");

// // // // // //             var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

// // // // // //             if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

// // // // // //             return Ok(
// // // // // //                 new NewUserDto
// // // // // //                 {
// // // // // //                     UserName = user.UserName,
// // // // // //                     Email = user.Email,
// // // // // //                     Token = _tokenService.CreateToken(user)
// // // // // //                 }
// // // // // //             );
// // // // // //         }

// // // // // //         [HttpPost("register")]
// // // // // //         public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
// // // // // //         {
// // // // // //             try
// // // // // //             {
// // // // // //                 if (!ModelState.IsValid)
// // // // // //                     return BadRequest(ModelState);

// // // // // //                 var appUser = new AppUser
// // // // // //                 {
// // // // // //                     UserName = registerDto.Username,
// // // // // //                     Email = registerDto.Email
// // // // // //                 };

// // // // // //                 var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

// // // // // //                 if (createdUser.Succeeded)
// // // // // //                 {
// // // // // //                     var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
// // // // // //                     if (roleResult.Succeeded)
// // // // // //                     {
// // // // // //                         return Ok(
// // // // // //                             new NewUserDto
// // // // // //                             {
// // // // // //                                 UserName = appUser.UserName,
// // // // // //                                 Email = appUser.Email,
// // // // // //                                 Token = _tokenService.CreateToken(appUser)
// // // // // //                             }
// // // // // //                         );
// // // // // //                     }
// // // // // //                     else
// // // // // //                     {
// // // // // //                         return StatusCode(500, roleResult.Errors);
// // // // // //                     }
// // // // // //                 }
// // // // // //                 else
// // // // // //                 {
// // // // // //                     return StatusCode(500, createdUser.Errors);
// // // // // //                 }
// // // // // //             }
// // // // // //             catch (Exception e)
// // // // // //             {
// // // // // //                 return StatusCode(500, e);
// // // // // //             }
// // // // // //         }
// // // // // //     }
// // // // // // }




// // // // // using System;
// // // // // using System.Threading.Tasks;
// // // // // using api.Dtos.Account;
// // // // // using api.Interfaces;
// // // // // using api.Models;
// // // // // using Microsoft.AspNetCore.Identity;
// // // // // using Microsoft.AspNetCore.Mvc;
// // // // // using Microsoft.EntityFrameworkCore;

// // // // // namespace api.Controllers
// // // // // {
// // // // //     [Route("api/account")]
// // // // //     [ApiController]
// // // // //     public class AccountController : ControllerBase
// // // // //     {
// // // // //         private readonly UserManager<AppUser> _userManager;
// // // // //         private readonly ITokenService _tokenService;
// // // // //         private readonly SignInManager<AppUser> _signInManager;

// // // // //         public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
// // // // //         {
// // // // //             _userManager = userManager;
// // // // //             _tokenService = tokenService;
// // // // //             _signInManager = signInManager;
// // // // //         }

// // // // //         [HttpPost("login")]
// // // // //         public async Task<IActionResult> Login(LoginDto loginDto)
// // // // //         {
// // // // //             if (!ModelState.IsValid)
// // // // //                 return BadRequest(ModelState);

// // // // //             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

// // // // //             if (user == null)
// // // // //                 return Unauthorized("Invalid username!");

// // // // //             var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

// // // // //             if (!result.Succeeded)
// // // // //                 return Unauthorized("Username not found and/or password incorrect");

// // // // //             return Ok(new NewUserDto
// // // // //             {
// // // // //                 UserName = user.UserName,
// // // // //                 Email = user.Email,
// // // // //                 Token = _tokenService.CreateToken(user)
// // // // //             });
// // // // //         }

// // // // //         [HttpPost("register")]
// // // // //         public async Task<IActionResult> Register(RegisterDto registerDto)
// // // // //         {
// // // // //             if (!ModelState.IsValid)
// // // // //                 return BadRequest(ModelState);

// // // // //             var appUser = new AppUser
// // // // //             {
// // // // //                 UserName = registerDto.Username,
// // // // //                 Email = registerDto.Email
// // // // //             };

// // // // //             var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

// // // // //             if (createdUser.Succeeded)
// // // // //             {
// // // // //                 var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

// // // // //                 if (roleResult.Succeeded)
// // // // //                 {
// // // // //                     return Ok(new NewUserDto
// // // // //                     {
// // // // //                         UserName = appUser.UserName,
// // // // //                         Email = appUser.Email,
// // // // //                         Token = _tokenService.CreateToken(appUser)
// // // // //                     });
// // // // //                 }
// // // // //                 else
// // // // //                 {
// // // // //                     return StatusCode(500, "Failed to assign role to user");
// // // // //                 }
// // // // //             }
// // // // //             else
// // // // //             {
// // // // //                 return StatusCode(500, "Failed to create user");
// // // // //             }
// // // // //         }
// // // // //     }
// // // // // }


// // // // using System;
// // // // using System.Threading.Tasks;
// // // // using api.Dtos.Account;
// // // // using api.Interfaces;
// // // // using api.Models;
// // // // using Microsoft.AspNetCore.Identity;
// // // // using Microsoft.AspNetCore.Mvc;
// // // // using Microsoft.EntityFrameworkCore;

// // // // namespace api.Controllers
// // // // {
// // // //     [Route("api/account")]
// // // //     [ApiController]
// // // //     public class AccountController : ControllerBase
// // // //     {
// // // //         private readonly UserManager<AppUser> _userManager;
// // // //         private readonly ITokenService _tokenService;
// // // //         private readonly SignInManager<AppUser> _signInManager;

// // // //         public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
// // // //         {
// // // //             _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
// // // //             _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
// // // //             _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
// // // //         }

// // // //         [HttpPost("login")]
// // // //         public async Task<IActionResult> Login(LoginDto loginDto)
// // // //         {
// // // //             if (loginDto == null)
// // // //                 return BadRequest("Invalid login data");

// // // //             if (!ModelState.IsValid)
// // // //                 return BadRequest(ModelState);

// // // //             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

// // // //             if (user == null)
// // // //                 return Unauthorized("Invalid username!");

// // // //             var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

// // // //             if (!result.Succeeded)
// // // //                 return Unauthorized("Username not found and/or password incorrect");

// // // //             return Ok(new NewUserDto
// // // //             {
// // // //                 // UserName = user.UserName,
// // // //                 // Email = user.Email,
// // // //                 Token = _tokenService.CreateToken(user)
// // // //             });
// // // //         }

// // // //         [HttpPost("register")]
// // // //         public async Task<IActionResult> Register(RegisterDto registerDto)
// // // //         {
// // // //             if (registerDto == null)
// // // //                 return BadRequest("Invalid registration data");

// // // //             if (!ModelState.IsValid)
// // // //                 return BadRequest(ModelState);

// // // //             var appUser = new AppUser
// // // //             {
// // // //                 UserName = registerDto.Username,
// // // //                 Email = registerDto.Email
// // // //             };

// // // //             var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

// // // //             if (createdUser.Succeeded)
// // // //             {
// // // //                 var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
// // // //                 // var data = [];

// // // //                 if (roleResult.Succeeded)
// // // //                 {
// // // //                     return Ok(new NewUserDto
// // // //                     {
// // // //                         // UserName = appUser.UserName,
// // // //                         // Email = appUser.Email,
// // // //                         // data = appUser,
// // // //                         Token = _tokenService.CreateToken(appUser)
// // // //                     });
// // // //                 }
// // // //                 else
// // // //                 {
// // // //                     return StatusCode(500, "Failed to assign role to user");
// // // //                 }
// // // //             }
// // // //             else
// // // //             {
// // // //                 return StatusCode(500, "Failed to create user");
// // // //             }
// // // //         }
// // // //     }
// // // // }



// // // using System;
// // // using System.Threading.Tasks;
// // // using api.Dtos.Account;
// // // using api.Interfaces;
// // // using api.Models;
// // // using Microsoft.AspNetCore.Identity;
// // // using Microsoft.AspNetCore.Mvc;
// // // using Microsoft.EntityFrameworkCore;

// // // namespace api.Controllers
// // // {
// // //     [Route("api/account")]
// // //     [ApiController]
// // //     public class AccountController : ControllerBase
// // //     {
// // //         private readonly UserManager<AppUser> _userManager;
// // //         private readonly ITokenService _tokenService;
// // //         private readonly SignInManager<AppUser> _signInManager;

// // //         public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
// // //         {
// // //             _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
// // //             _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
// // //             _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
// // //         }

// // //         [HttpPost("login")]
// // //         public async Task<IActionResult> Login(LoginDto loginDto)
// // //         {
// // //             if (loginDto == null)
// // //                 return BadRequest("Invalid login data");

// // //             if (!ModelState.IsValid)
// // //                 return BadRequest(ModelState);

// // //             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

// // //             if (user == null)
// // //                 return Unauthorized("Invalid username!");

// // //             var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

// // //             if (!result.Succeeded)
// // //                 return Unauthorized("Username not found and/or password incorrect");

// // //             return Ok(new NewUserDto
// // //             {
// // //                 Token = _tokenService.CreateToken(user)
// // //             });
// // //         }

// // //         [HttpPost("register")]
// // //         public async Task<IActionResult> Register(RegisterDto registerDto)
// // //         {
// // //             if (registerDto == null)
// // //                 return BadRequest("Invalid registration data");

// // //             if (string.IsNullOrEmpty(registerDto.Password))
// // //                 return BadRequest("Password cannot be null or empty");

// // //             if (!ModelState.IsValid)
// // //                 return BadRequest(ModelState);

// // //             var appUser = new AppUser
// // //             {
// // //                 UserName = registerDto.Username,
// // //                 Email = registerDto.Email
// // //             };

// // //             var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

// // //             if (createdUser.Succeeded)
// // //             {
// // //                 var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

// // //                 if (roleResult.Succeeded)
// // //                 {
// // //                     return Ok(new NewUserDto
// // //                     {
// // //                         Token = _tokenService.CreateToken(appUser)
// // //                     });
// // //                 }
// // //                 else
// // //                 {
// // //                     // Rollback user creation if role assignment fails
// // //                     await _userManager.DeleteAsync(appUser);
// // //                     return StatusCode(500, "Failed to assign role to user");
// // //                 }
// // //             }
// // //             else
// // //             {
// // //                 return StatusCode(500, "Failed to create user");
// // //             }
// // //         }
// // //     }
// // // }



// // using System;
// // using System.Threading.Tasks;
// // using api.Dtos.Account;
// // using api.Interfaces;
// // using api.Models;
// // using Microsoft.AspNetCore.Identity;
// // using Microsoft.AspNetCore.Mvc;
// // using Microsoft.EntityFrameworkCore;

// // namespace api.Controllers
// // {
// //     [Route("api/account")]
// //     [ApiController]
// //     public class AccountController : ControllerBase
// //     {
// //         private readonly UserManager<AppUser> _userManager;
// //         private readonly ITokenService _tokenService;
// //         private readonly SignInManager<AppUser> _signInManager;

// //         public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
// //         {
// //             _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
// //             _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
// //             _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
// //         }

// //         [HttpPost("login")]
// //         public async Task<IActionResult> Login(LoginDto loginDto)
// //         {
// //             if (loginDto == null)
// //                 return BadRequest("Invalid login data");

// //             if (!ModelState.IsValid)
// //                 return BadRequest(ModelState);

// //             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

// //             if (user == null)
// //                 return Unauthorized("Invalid username!");

// //             var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

// //             if (!result.Succeeded)
// //                 return Unauthorized("Username not found and/or password incorrect");

// //             return Ok(new NewUserDto
// //             {
// //                 UserName = user.UserName,
// //                 Email = user.Email,
// //                 Token = _tokenService.CreateToken(user)
// //             });
// //         }

// //         [HttpPost("register")]
// //         public async Task<IActionResult> Register(RegisterDto registerDto)
// //         {
// //             if (registerDto == null)
// //                 return BadRequest("Invalid registration data");

// //             if (string.IsNullOrEmpty(registerDto.Password))
// //                 return BadRequest("Password cannot be null or empty");

// //             if (!ModelState.IsValid)
// //                 return BadRequest(ModelState);

// //             var appUser = new AppUser
// //             {
// //                 UserName = registerDto.Username,
// //                 Email = registerDto.Email
// //             };

// //             var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

// //             if (createdUser.Succeeded)
// //             {
// //                 var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

// //                 if (roleResult.Succeeded)
// //                 {
// //                     return Ok(new NewUserDto
// //                     {
// //                         UserName = appUser.UserName,
// //                         Email = appUser.Email,
// //                         Token = _tokenService.CreateToken(appUser)
// //                     });
// //                 }
// //                 else
// //                 {
// //                     // Rollback user creation if role assignment fails
// //                     await _userManager.DeleteAsync(appUser);
// //                     return StatusCode(500, "Failed to assign role to user");
// //                 }
// //             }
// //             else
// //             {
// //                 return StatusCode(500, "Failed to create user");
// //             }
// //         }
// //     }
// // }

// using System;
// using System.Threading.Tasks;
// using api.Dtos.Account;
// using api.Interfaces;
// using api.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace api.Controllers
// {
//     [Route("api/account")]
//     [ApiController]
//     public class AccountController : ControllerBase
//     {
//         private readonly UserManager<AppUser> _userManager;
//         private readonly ITokenService _tokenService;
//         private readonly SignInManager<AppUser> _signInManager;

//         public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
//         {
//             _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
//             _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
//             _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
//         }

//         [HttpPost("login")]
//         public async Task<IActionResult> Login(LoginDto loginDto)
//         {
//             if (loginDto == null)
//                 return BadRequest("Invalid login data");

//             if (!ModelState.IsValid)
//                 return BadRequest(ModelState);

//             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

//             if (user == null)
//                 return Unauthorized("Invalid username!");

//             var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

//             if (!result.Succeeded)
//                 return Unauthorized("Username not found and/or password incorrect");

//             var token = _tokenService.CreateToken(user);
//             if (token == null)
//                 return StatusCode(500, "Failed to generate token");

//             return Ok(new NewUserDto
//             {
//                 UserName = user.UserName,
//                 Email = user.Email,
//                 Token = token
//             });
//         }

//         [HttpPost("register")]
//         public async Task<IActionResult> Register(RegisterDto registerDto)
//         {
//             if (registerDto == null)
//                 return BadRequest("Invalid registration data");

//             if (string.IsNullOrEmpty(registerDto.Password))
//                 return BadRequest("Password cannot be null or empty");

//             if (!ModelState.IsValid)
//                 return BadRequest(ModelState);

//             var appUser = new AppUser
//             {
//                 UserName = registerDto.Username,
//                 Email = registerDto.Email
//             };

//             var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

//             if (createdUser.Succeeded)
//             {
//                 var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

//                 if (roleResult.Succeeded)
//                 {
//                     var token = _tokenService.CreateToken(appUser);
//                     if (token == null)
//                     {
//                         // Rollback user creation if token generation fails
//                         await _userManager.DeleteAsync(appUser);
//                         return StatusCode(500, "Failed to generate token");
//                     }

//                     return Ok(new NewUserDto
//                     {
//                         UserName = appUser.UserName,
//                         Email = appUser.Email,
//                         Token = token
//                     });
//                 }
//                 else
//                 {
//                     // Rollback user creation if role assignment fails
//                     await _userManager.DeleteAsync(appUser);
//                     return StatusCode(500, "Failed to assign role to user");
//                 }
//             }
//             else
//             {
//                 return StatusCode(500, "Failed to create user");
//             }
//         }
//     }
// }


using System;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto == null)
                return BadRequest("Invalid login data");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null)
                return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Username not found and/or password incorrect");

            var token = _tokenService.CreateToken(user);
            if (token == null)
                return StatusCode(500, "Failed to generate token");

            return Ok(new NewUserDto
            {
                UserName = user.UserName ?? throw new InvalidOperationException("User name cannot be null"),
                Email = user.Email ?? throw new InvalidOperationException("Email cannot be null"),
                Token = token
            });
        }

        // [HttpPost("register")]
        // public async Task<IActionResult> Register(RegisterDto registerDto)
        // {
        //     if (registerDto == null)
        //         return BadRequest("Invalid registration data");

        //     if (string.IsNullOrEmpty(registerDto.Password))
        //         return BadRequest("Password cannot be null or empty");

        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var appUser = new AppUser
        //     {
        //         UserName = registerDto.Username ?? throw new ArgumentNullException(nameof(registerDto.Username), "Username cannot be null"),
        //         Email = registerDto.Email ?? throw new ArgumentNullException(nameof(registerDto.Email), "Email cannot be null")
        //     };

        //     var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
        //     Console.WriteLine($"Created user: {appUser.UserName}, Email: {appUser.Email}, Succeeded: {createdUser.Succeeded}");
        //     if (createdUser.Succeeded)
        //     {
        //         var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
        //         if (roleResult.Succeeded)
        //         {
        //             var token = _tokenService.CreateToken(appUser);
        //             if (token == null)
        //             {
        //                 // Rollback user creation if token generation fails
        //                 await _userManager.DeleteAsync(appUser);
        //                 return StatusCode(500, "Failed to generate token");
        //             }

        //             return Ok(new NewUserDto
        //             {
        //                 UserName = appUser.UserName,
        //                 Email = appUser.Email,
        //                 Token = token
        //             });
        //         }
        //         else
        //         {
        //             // Rollback user creation if role assignment fails
        //             await _userManager.DeleteAsync(appUser);
        //             return StatusCode(500, "Failed to assign role to user");
        //         }
        //     }
        //     else
        //     {
        //         foreach (var error in createdUser.Errors)
        //         {
        //             // Log each error message
        //             Console.WriteLine($"Error: {error.Description}");
        //         }
        //         return StatusCode(500, "Failed to create user");
        //     }
        // }


[HttpPost("register")]
public async Task<IActionResult> Register(RegisterDto registerDto)
{
    if (registerDto == null)
        return BadRequest("Invalid registration data");

    if (string.IsNullOrEmpty(registerDto.Password))
        return BadRequest("Password cannot be null or empty");

    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var appUser = new AppUser
    {
        UserName = registerDto.Username ?? throw new ArgumentNullException(nameof(registerDto.Username), "Username cannot be null"),
        Email = registerDto.Email ?? throw new ArgumentNullException(nameof(registerDto.Email), "Email cannot be null")
    };

    // Hash the password
    var passwordHasher = new PasswordHasher<AppUser>();
    appUser.PasswordHash = passwordHasher.HashPassword(appUser, registerDto.Password);

    var createdUser = await _userManager.CreateAsync(appUser);
    Console.WriteLine($"Created user: {appUser.UserName}, Email: {appUser.Email}, Succeeded: {createdUser.Succeeded}");
    if (createdUser.Succeeded)
    {
        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
        if (roleResult.Succeeded)
        {
            var token = _tokenService.CreateToken(appUser);
            if (token == null)
            {
                // Rollback user creation if token generation fails
                await _userManager.DeleteAsync(appUser);
                return StatusCode(500, "Failed to generate token");
            }

            return Ok(new NewUserDto
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                Token = token
            });
        }
        else
        {
            // Rollback user creation if role assignment fails
            await _userManager.DeleteAsync(appUser);
            return StatusCode(500, "Failed to assign role to user");
        }
    }
    else
    {
        foreach (var error in createdUser.Errors)
        {
            // Log each error message
            Console.WriteLine($"Error: {error.Description}");
        }
        return StatusCode(500, "Failed to create user");
    }
}

    }
}
