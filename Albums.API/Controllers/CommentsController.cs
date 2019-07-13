using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albums.API.Controllers
{
    [Route("api/albums/{albumId}/photos/{photoId}/comments")]
    public class CommentsController : ControllerBase
    {

        private readonly IAlbumsRepository _repo;

        public CommentsController(IAlbumsRepository repo)
        {
            _repo = repo;
        }

        // GET:  api/albums/id/photos/id/comments
        [HttpGet]
        public async Task<IActionResult> Get(int photoId)
        {
            var comments = await _repo.GetComments(photoId);
            if(comments.Count() > 0)
            {
                return Ok(comments);
            }
            else
            {
                return NotFound();
            }
        }
    }
}