using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceProject.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var identityuser=new IdentityUser
            {
                UserName=registerDto.Email,
                Email=registerDto.Email
            };
            var identityResult=await userManager.CreateAsync(identityuser,registerDto.PassWord); 
            if(identityResult.Succeeded)
          {
            if(registerDto.Role is not null && registerDto.Role.Any())
            {
                var identityResult2=await userManager.AddToRolesAsync(identityuser,registerDto.Role);
                if(identityResult2.Succeeded)
                {
                    return Ok("Succesfuly Registerd");
                }
            }
            
          }
          return NotFound("Some error");
       }

       [HttpPost]
       [Route("login")]
       public async Task<IActionResult> Login(LoginDto loginDto)
       {
            var user=await userManager.FindByEmailAsync(loginDto.Username);
            if(user != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(user,loginDto.PassWord);
                var roles=await userManager.GetRolesAsync(user);
                if(checkPassword)
                {
                    return Ok("Succesfully logined");

                }
                return BadRequest("wrong password");
            }
            return BadRequest("Wrong username");
       }
        }
    }
