using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Albums.API.Dtos;
using Newtonsoft.Json;

namespace Albums.API.Data
{
    public class AlbumsRepository : IAlbumsRepository
    {
        private HttpClient _httpClient = new HttpClient();
        private List<AlbumDto> _albums;
        private List<PhotoDto> _photos;
        private List<CommentDto> _comments;

        public AlbumsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<AlbumDto>> GetAlbums()
        {
            return await GetAlbumsFromService();
        }

        public async Task <IEnumerable<CommentDto>> GetComments(int photoId)
        {
            var comments = await GetCommentsFromService();
            comments = comments.Where(c => c.PostId == photoId).ToList();
            return comments;
        }

        public async Task <IEnumerable<PhotoDto>> GetPhotos(int albumId)
        {
            var photos = await GetPhotosFromService();
            photos = photos.Where(p => p.AlbumId == albumId).ToList();
            return photos;
        }

        private async Task<IEnumerable<AlbumDto>> GetAlbumsFromService() 
        {
            if (_albums == null) 
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/albums");
                if(response.IsSuccessStatusCode) 
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    _albums = JsonConvert.DeserializeObject<List<AlbumDto>>(jsonString);
                }
            }
            return _albums;
        }

        private async Task<IEnumerable<PhotoDto>> GetPhotosFromService()
        {
            if (_photos == null)
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    _photos = JsonConvert.DeserializeObject<List<PhotoDto>>(jsonString);
                }
            }
            return _photos;
        }

        private async Task<IEnumerable<CommentDto>> GetCommentsFromService()
        {
            if (_comments == null)
            {
                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments");
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    _comments = JsonConvert.DeserializeObject<List<CommentDto>>(jsonString);
                }
            }
            return _comments;
        }
    }
}