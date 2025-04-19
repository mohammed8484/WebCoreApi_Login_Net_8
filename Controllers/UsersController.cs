using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCoreApi_Login_Net8.Models;

namespace WebCoreApi_Login_Net8.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly mydbcontext _context;
        public UsersController(mydbcontext _context)
        {
            this._context = _context;
                
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objUser = _context.Users.FirstOrDefault(x => x.Username == userDTO.Username);
            if (objUser == null)
            {
                _context.Add(new Users
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Username = userDTO.Username,
                    Password = userDTO.Password
                }
                    );
                _context.SaveChanges();
                return Ok("register is done!!!");
            }
            else
            {
                return BadRequest("user already is exist!!!");
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var objUser = _context.Users.FirstOrDefault(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password);

            if (objUser == null)
            {
                return Unauthorized("اسم المستخدم أو كلمة المرور غير صحيح!");
            }


            return Ok("تم الدخول بنجاح!");
        }

            [HttpPost]
        [Route("getUsers")]
        public IActionResult getUsers() { 
        return Ok(_context.Users.ToList());
        
        }

        [HttpGet]
        [Route("getUser")]
        public IActionResult getuser(string username) { 
        var user = _context.Users.FirstOrDefault(x=>x.Username == username);
            return Ok(user);

        }

    }
}
