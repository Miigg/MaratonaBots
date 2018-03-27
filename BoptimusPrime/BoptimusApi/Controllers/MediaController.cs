using BoptimusApi.API.Domain;
using BoptimusApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BoptimusApi.Controllers
{

    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        private IMediaRepository mediaRepository;
        public MediaController(IMediaRepository mediaRepository)
        {
            this.mediaRepository = mediaRepository;
        }

       
        [Authorize("Bearer")]
        [HttpGet]
        public List<MediaSearch> Get(int genreId)
        {
            if (genreId == 98754321)
                return mediaRepository.GetRandomMedia();
            else

                return mediaRepository.GetMedia(genreId);

        }

    }

}

