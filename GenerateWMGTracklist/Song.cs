using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateWMGTracklist
{
    public class Song
    {
        public string TrackName { get; set; }
        public string Code { get; set; }
        public string TrackArtist { get; set; }
        public string Genres { get; set; }
        public string YoutubeUrl { get; set; }
        public string ReleaseYear { get; set; }
        public long YoutubeViewCountFirst { get; set; }
        public long YoutubeViewCountSecond { get; set; }
        public string Region { get; set; }
        public double Point { get; set; }
        public int Duration { get; set; }
    }
    public enum Region
    {
        US,
        UK,
        Spain,
        Mexico,
        Brazil,
        France,
        Australia,
        Sweden,
        Scotland,
        Columbia,
        Germany,
        Italia,
        Korea,
        Russia,
        Canada,
        Indonesia
    }
}
