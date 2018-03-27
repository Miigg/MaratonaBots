using BoptimusApi.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoptimusApi.Repositories
{
    public interface IMediaRepository
    {
        List<MediaSearch> GetRandomMedia();

        List<MediaSearch> GetMedia(int genre_id);
    }
}
