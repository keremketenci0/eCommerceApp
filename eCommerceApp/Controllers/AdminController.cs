using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Data.Services;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id, string? firstName, string? lastName, int? count, bool? userStatus = null)
        {
            if (id != null)
            {
                var user = _service.DetailsUser(id);
                return Ok(user);
            }

            IQueryable<AppUser> query = _service.GetUsers();

            query = _service.UserStatus(query, userStatus);

            query = _service.TakeUsers(query, count);

            query = _service.FilterUsers(query, firstName, lastName);

            var result = await query.ToListAsync();

            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserPostRequest userPostRequest, string password)
        {
            var result = await _service.AddUser(userPostRequest, password);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserPutRequest userPutRequest, string id)
        {
            var result = await _service.UpdateUser(userPutRequest, id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = _service.DeleteUser(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}