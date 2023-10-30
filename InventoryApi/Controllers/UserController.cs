using Inventory.BAL.Services;
using Inventory.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        
            private UserInfoService _userInfoService;
            public UserController(UserInfoService userInfoService)
            {
                _userInfoService = userInfoService;
            }
           
           
            
            [HttpPost("Register")]
            public IActionResult Register([FromBody] UserInfo userInfo)
            {
                _userInfoService.Register(userInfo);
                return Ok(" Registered successfully!");
            }

            [HttpPost("Login")]
            public IActionResult Login([FromBody] UserInfo userInfo)
            {
                UserInfo user = _userInfoService.Login(userInfo);
                if(user!=null)

                      return Ok("Login Successfull!");
                else 
                      return NotFound();
            }
        }
}
