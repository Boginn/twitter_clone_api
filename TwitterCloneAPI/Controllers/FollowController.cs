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
    [Route("api/follows")]

    public class FollowController : ControllerBase
    {
        private readonly IRepository _repo;
        public FollowController(IRepository repo)
        {
            _repo = repo;
        }

        /** Get **/
        [HttpGet]
        public async Task<ActionResult<List<Follow>>> GetAllFollowsAsync()
        {
            try
            {
                List<Follow> res = await _repo.GetAllFollowsAsync();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
