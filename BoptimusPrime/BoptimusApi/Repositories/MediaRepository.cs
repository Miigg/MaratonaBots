using System.Collections.Generic;
using BoptimusApi.API.Domain;
using BoptimusPrime.Mocks;
using Newtonsoft.Json;
using System.Linq;

namespace BoptimusApi.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        public List<MediaSearch> GetMedia(int genre_id)
        {
            var media = JsonConvert.DeserializeObject<MediaSearchResult>(MoviesMock.Content);
            return media.results.Where(x => x.genre_ids.Contains(genre_id)).ToList();
            
        }

        public List<MediaSearch> GetRandomMedia()
        {
            var media = JsonConvert.DeserializeObject<MediaSearchResult>(MoviesMock.Content);
            return media.results;
        }

    }
}
