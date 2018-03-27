using BoptimusPrime.Models;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace BoptimusPrime.Services
{
    public class CardPersonalizedService
    {
        public HeroCard CreateCard(MediaSearch media)
        {
            var heroCard = new HeroCard
            {
                Title = media.title,
                Subtitle = media.overview,
                Images = new List<CardImage>
                {
                    new CardImage(media.Image,
                    media.title)
                }
            };
            return heroCard;
        }
    }
}