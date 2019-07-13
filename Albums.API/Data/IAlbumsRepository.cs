using System.Collections.Generic;
using System.Threading.Tasks;
using Albums.API.Dtos;

namespace Albums.API.Data
{
    public interface IAlbumsRepository
    {
         Task<IEnumerable<AlbumDto>> GetAlbums();
         Task<IEnumerable<PhotoDto>> GetPhotos(int albumId);
         Task<IEnumerable<CommentDto>> GetComments(int photoId);
    }
}