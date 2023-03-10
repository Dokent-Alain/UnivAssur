using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UnivAssurance.webAPI.Authentification;
using UnivAssurance.webAPI.Authentification.Models;


namespace UnivAssurance.webAPI.Controllers;

    [ApiController]
    [Route("[controller]")]  
    public class AuthentificationController: ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IConfiguration _configuration;
        private object username;

        public AuthentificationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration _configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._configuration = _configuration;
        }


        [HttpPost("AddUser")]

        

    public async Task<IActionResult> AddUser(NewUser newUser)
    {
        var user = new ApplicationUser()
        {
            Email = newUser.Email,
            UserName = newUser.UserName,
        };
        var Resultat = await userManager.CreateAsync(user, newUser.Password);
      return Ok(Resultat);
    }

[HttpPost("Login")]
       public async Task<IActionResult> Login( Login login)
    {
      var ut = await userManager.FindByNameAsync(login.UserName);
      if (ut != null)
      {
        var pV = await userManager.CheckPasswordAsync(ut, login.Password);
        if (pV)
        {

          var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, ut.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

          var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"));
          var token = new JwtSecurityToken(
                  issuer: "http://localhost:5097",
                  audience: "http://localhost:5097",
                  expires: DateTime.Now.AddHours(1),
                  claims: authClaims,
                  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                  );

          return Ok(new
          {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
          });
        }
      }
      return Unauthorized();
    
}
    }