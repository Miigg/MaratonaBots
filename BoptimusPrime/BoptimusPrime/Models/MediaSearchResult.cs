﻿using Microsoft.Bot.Builder.FormFlow;
using System.Collections.Generic;

namespace BoptimusPrime.Models
{
    public class MediaSearchResult
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<MediaSearch> results { get; set; }
    }

    public class MediaSearch : Media
    {
        public string original_name { get; set; }
        public string media_type { get; set; }
        public string name { get; set; }
        public string first_air_date { get; set; }
        public float popularity { get; set; }
        public List<string> origin_country { get; set; }
    }

    public enum Category
    {
        [Describe("tv")]
        serie = 1,
        [Describe("movie")]
        filme,
        [Describe("movie")]
        anyway
    }
}





