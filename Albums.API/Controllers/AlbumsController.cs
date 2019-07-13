using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albums.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albums.API.Controllers
{
    [Route("api/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsRepository _repo;

        public AlbumsController(IAlbumsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/albums
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await _repo.GetAlbums();
            return Ok(albums);
        }
    }
}