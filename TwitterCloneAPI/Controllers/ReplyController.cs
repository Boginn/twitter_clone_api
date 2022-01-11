using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Data.Interface;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.Controllers
{
    [Controller]
    [Route("api/replies")]
    public class ReplyController : ControllerBase
    {
        private readonly IRepository _repo;
        public ReplyController(IRepository repo)
        {
            _repo = repo;
        }


        /** Get **/
        
        [HttpGet]
        public async Task<ActionResult<List<Reply>>> GetAllRepliesAsync()
        {
            try
            {
                List<Reply> res = await _repo.GetAllRepliesAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Reply>> GetReplyById(int id)
        {
            try
            {
                Reply res = await _repo.GetReplyByIdAsync(id);
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
        public async Task<IActionResult> CreateReply([FromBody] Reply reply)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repo.CreateReplyAsync(reply);
                    return CreatedAtAction(nameof(GetReplyById), new { id = reply.Id }, reply);
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
        public async Task<IActionResult> UpdateReplyContent(int id, [FromBody] Reply reply)
        {
            try
            {
                Reply res = await _repo.UpdateReplyContentAsync(id, reply);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetReplyById), new { id = res.Id }, res);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("like/{id}")]
        public async Task<IActionResult> UpdateReplyLike(int id, [FromBody] User user)
        {
            try
            {
                Reply res = await _repo.UpdateReplyLikesAsync(id, user);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetReplyById), new { id = res.Id }, res);
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
        public async Task<IActionResult> DeleteReply(int id)
        {
            try
            {
                bool res = await _repo.DeleteReplyAsync(id);
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
