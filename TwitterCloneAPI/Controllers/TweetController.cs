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
    [Route("api/tweets")]
    public class TweetController : ControllerBase
    {
        private readonly IRepository _repo;
        public TweetController(IRepository repo)
        {
            _repo = repo;
        }


        /** Get **/

        [HttpGet]
        public async Task<ActionResult<List<Tweet>>> GetAllTweetsAsync()
        {
            try
            {
                List<Tweet> res = await _repo.GetAllTweetsAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Tweet>> GetTweetById(int id)
        {
            try
            {
                Tweet res = await _repo.GetTweetByIdAsync(id);
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

        public async Task<IActionResult> CreateTweet([FromBody] Tweet tweet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repo.CreateTweetAsync(tweet);
                    return CreatedAtAction(nameof(GetTweetById), new { id = tweet.Id }, tweet);
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
        public async Task<IActionResult> UpdateTweetContent(int id, [FromBody] Tweet tweet)
        {
            try
            {
                Tweet res = await _repo.UpdateTweetContentAsync(id, tweet);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTweetById), new { id = res.Id }, res);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("like/{id}")]
        public async Task<IActionResult> UpdateTweetLike(int id, [FromBody] User user)
        {
            try
            {
                Tweet res = await _repo.UpdateTweetLikesAsync(id, user);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTweetById), new { id = res.Id }, res);
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
        public async Task<IActionResult> DeleteTweet(int id)
        {
            try
            {
                bool res = await _repo.DeleteTweetAsync(id);
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
