using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using TwitterCloneAPI.Data.Interface;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Controllers
{
    [Controller]
    [Route("api/users")]
    //[EnableCors("CorsPolicy")]

    public class UserController : ControllerBase
    {
        private readonly IRepository _repo;
        public UserController(IRepository repo)
        {
            _repo = repo;
        }

        /** Get **/
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsersAsync()
        {
            try
            {
                List<UserDTO> res = await _repo.GetAllUsersAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{handle}")]
        public async Task<ActionResult<UserDTO>> GetUserByHandle(string handle)
        {
            try
            {
                UserDTO res = await _repo.GetUserByHandleAsync(handle);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                UserDTO res = await _repo.GetUserByIdAsync(id);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(res);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /** Post **/

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repo.CreateUserAsync(user);
                    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /** Put **/

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                User res = await _repo.UpdateUserAsync(id, user);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = res.Id }, res);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("follow/{id}")]
        public async Task<IActionResult> UpdateUserFollows(int id, [FromBody] User user)
        {
            try
            {

   

                User res = await _repo.UpdateUserFollowsAsync(id, user);

                if (res == null || id == res.Id)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = res.Id }, res);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }



        /** Delete **/

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                bool res = await _repo.DeleteUserAsync(id);
                if (!res)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
