using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateWMGTracklist
{
    public class Song
    {
        public string TrackName { get; set; }
        public string TrackId { get; set; }
        public string Code { get; set; }
        public string AlbumId { get; set; }
        public string TrackArtist { get; set; }
        public string Genres { get; set; }
        public string ReleaseYear { get; set; }
        public long SpotifyStreamCountFirst { get; set; }
        public long SpotifyStreamCountSecond { get; set; }
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
        Indonesia,
        China,
        Japan,
        Finland,
        Malaysia,
        Denmark

    }

}
