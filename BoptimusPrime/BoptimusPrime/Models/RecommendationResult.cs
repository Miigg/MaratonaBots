﻿using System.Collections.Generic;

namespace BoptimusPrime.Models
{
    public class RecommendationResult
    {
        public int page { get; set; }
        public List<Media> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }


    public class Media
    {
        public bool adult { get; set; }
        public int id { get; set; }
        public string Image { get => $"https://image.tmdb.org/t/p/w600_and_h900_bestv2{this.poster_path}"; }
        public string overview { get; set; }
        public int?[] genre_ids { get; set; }
        public string original_language { get; set; }
        public string backdrop_path { get; set; }
        public string original_title { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

    }
}