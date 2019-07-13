using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albums.API.Controllers
{
    [Route("api/albums/{albumId}/photos")]
    public class PhotosController : ControllerBase
    {

        private readonly IAlbumsRepository _repo;

        public PhotosController(IAlbumsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/albums/id/photos
        [HttpGet]
        public async Task<IActionResult> Get(int albumId)
        {
            var photos = await _repo.GetPhotos(albumId);
            if(photos.Count() > 0)
            {
                return Ok(photos);
            }
            else
            {
                return NotFound();
            }
        }
    }
}