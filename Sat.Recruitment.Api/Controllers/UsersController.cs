using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.Builder;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserBuilder _userbulider;

        private IUserServicies _userServicies;
        public UsersController(IUserBuilder userBuilder, IUserServicies userServicies)
        {
            this._userbulider = userBuilder;
            this._userServicies = userServicies;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            var Newuser = _userbulider.Build(user);
            try
            {
                if (!await _userServicies.ExistUser(Newuser))
                {
                    await _userServicies.AddUser(Newuser);
                    return CreatedAtAction(nameof(Get), new { email = user.Email }, user);
                }
                else
                {
                    return Conflict(new { message = $"The user is duplicated" });

                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]

        public async Task<IActionResult> Get(string email)
        {
            return Ok(await _userServicies.FindByEmailAsync(email));
        }
    }
}
