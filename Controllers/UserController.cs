using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiAuth.DTO;
using WebApiAuth.Models;

namespace WebApiAuth.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly AuthDBContext _authDBContext;

        public UserController(AuthDBContext authDBContext)
        {
            _authDBContext = authDBContext;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await _authDBContext.User.Select(s => new UserDTO
            {
                AuthId = s.AuthId,
                FistName = s.FistName,
                LastName = s.LastName,
                Username = s.Username,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }

            ).ToListAsync();

            if(List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }

        }

        [HttpGet("GetUsersById")]
        public async Task<ActionResult<UserDTO>> GetUsersById(int AuthId)
        {
            UserDTO user = await _authDBContext.User.Select(s => new UserDTO
            {
                AuthId = s.AuthId,
                FistName = s.FistName,
                LastName = s.LastName,
                Username = s.Username,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }

            ).FirstOrDefaultAsync(s => s.AuthId == AuthId);

            if(User == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }

        [HttpPost("PostUsers")]
        public async Task<HttpStatusCode> PostUsers(UserDTO User)
        {
            var Entities = new User()
            {
                FistName = User.FistName,
                LastName = User.LastName,
                Username = User.Username,
                Password = User.Password,
                EnrollmentDate = User.EnrollmentDate
            };

            _authDBContext.User.Add(Entities);
            await _authDBContext.SaveChangesAsync();

            return HttpStatusCode.Created;

        }

        [HttpPut]
        public async Task<HttpStatusCode> UpdateUsers(UserDTO User)
        {
            var Entities = await _authDBContext.User.FirstOrDefaultAsync(s => s.AuthId == User.AuthId);

            Entities.FistName = User.FistName;
            Entities.LastName = User.LastName;
            Entities.Username = User.Username;
            Entities.Password = User.Password;
            Entities.EnrollmentDate = User.EnrollmentDate;

            await _authDBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
