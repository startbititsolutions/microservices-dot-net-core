using AccountService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccountService.Controllers
{

    [ApiController]
    [Route("api/User/")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbcontext _context;
        private IConfiguration _config;

        public AccountController( ApplicationDbcontext _dbcontext,IConfiguration configuration1)
        {
           this._context = _dbcontext;
            _config = configuration1;
        }

        // GET: AccountController


        [HttpGet]
        [Route("All")]
        public IActionResult Index()
        {
           var users= _context.User.ToList();
            return Ok(users);
        }

        [HttpPost]
        [Route("Get/{id}")]
        public ActionResult Details(int id)
        {
            var user = _context.User.Where(x => x.Id==id).FirstOrDefault();
            if (user != null)
            {

            
            return Ok(user);
            }
            else
            {
                return Ok("No User Founnd With id="+id);
            }
        }

     
        
        // POST: AccountController/Create
        [HttpPost]
        [Route("Add")]
        public ActionResult Create(User user)
        {
            try
            {
                var added=_context.User.Add(user);
                _context.SaveChanges();
                return Ok("User Is Successfully Registered");
            }
            catch
            {
                return Ok("Something Went Wrong Please Try Again After Sometime");
            }
        }

        // GET: AccountController/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id,User newuser)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            if (user!=null)
            {
                user.UserName = newuser.UserName;
                user.Password = newuser.Password;
                user.Role= newuser.Role;
               _context.User.Update(user);
                _context.SaveChanges();
            return Ok();
            }
            else
            {
                return Ok("No User Found With id:"+id);
            }
        }



       

        // POST: AccountController/Delete/5
        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = _context.User.FirstOrDefault(y => y.Id == id);
                _context.User.Remove(user);
                _context.SaveChanges();
                return Ok("User Deleted Successfully");
            }
            catch
            {
                return Ok("Something Went Wrong");
            }
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            try
            {
                var loggedIn = _context.User.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if (loggedIn == null)
                {
                    return Ok(false);
                }
                else
                {
                    var token = GenerateToken(loggedIn);
                    UserResponseViewModel Response = new UserResponseViewModel();
                    Response.Id = loggedIn.Id;
                    Response.UserName = loggedIn.UserName;
                    Response.Role = loggedIn.Role;
                    Response.Token = token;

                    return Ok(Response);
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
               _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }

}
