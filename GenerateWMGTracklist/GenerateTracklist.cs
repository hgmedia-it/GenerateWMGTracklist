using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GenerateWMGTracklist
{
    public static class GenerateTracklist
    {
        static int viewTop1 = 350000000; 
        static int viewTop2 = 100000000;  
        static int viewTop3 = 10000000;  
        static int viewTop4 = 1000000;
        static double rateTop1 = 0.5;
        static double rateTop2 = 0.35;
        static double rateTop3 = 0.15;
        static int top1SongNumber = 5;
        static int top2SongNumber = 10;
        static int top3SongNumber = 5;
        static int totalSong = 20;
        static List<string> GenreTop1 = GetGenreRateBySongsNumber(min: 60);
        static List<string> GenreTop2 = GetGenreRateBySongsNumber(max: 60, min: 10);
        public static List<Song> GetListSongAfterFilter(List<string> artirst, List<string> genre, List<string> region, List<string> year, List<Song> listAllSongs)
        {
            try
            {
                if (artirst.Contains("All"))
                {
                    artirst = new List<string>();
                }
                if (genre.Contains("All"))
                {
                    genre = new List<string>();
                }
                if (region.Contains("All"))
                {
                    region = new List<string>();
                }
                if (year.Contains("All"))
                {
                    year = new List<string>();
                }
                List<Song> listSong = new List<Song>();
                if (artirst.Count == 0 && genre.Count == 0 && region.Count == 0 && year.Count == 0)
                {
                    return listAllSongs;
                }

                foreach (var song in listAllSongs)
                {
                    if ((artirst.Count == 0 || artirst.Any(item => song.TrackArtist.Contains(item))) && (genre.Count == 0 || genre.Any(item => song.Genres.Contains(item)))
                        && (region.Count == 0 || region.Any(item => song.Region.Contains(item))) && (year.Count == 0 || year.Any(item => song.ReleaseYear.Contains(item))))
                    {
                        listSong.Add(song);
                    }
                }
                return listSong;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Song> GetListSongByRating(List<Song> listSongs, Rate rate)
        {
            try
            {
                listSongs.ForEach(song =>
                {
                    if (song.SpotifyStreamCountSecond == 0)
                    {
                        song.SpotifyStreamCountSecond = song.SpotifyStreamCountFirst;
                        song.SpotifyStreamCountFirst = 0;
                    }
                }
                );
                if (rate.DiffrenceRate == 0)
                {
                    foreach (var song in listSongs)
                    {
                        double point = 0;
                        point += GetPointOfViewCountSecond(song, rate);
                        point += GetPointOfRegion(song, rate);
                        point += GetPointOfGenre(song, rate);
                        song.Point = point;
                    }
                }
                else
                {
                    foreach(var song in listSongs)
                    {
                        if(song.SpotifyStreamCountSecond - song.SpotifyStreamCountFirst == song.SpotifyStreamCountSecond)
                        {
                            double point = 0;
                            rate.ViewCountLastRate = rate.ViewCountLastRate + (rate.DiffrenceRate / 2);
                            rate.RegionRate = rate.RegionRate + (rate.DiffrenceRate / 4);
                            rate.GenreRate = rate.GenreRate + (rate.DiffrenceRate / 4);
                            point += GetPointOfViewCountSecond(song, rate);
                            point += GetPointOfRegion(song, rate);
                            point += GetPointOfGenre(song, rate);
                            song.Point = point;
                        }
                        else
                        {
                            double point = 0;
                            point += GetPointOfViewCountSecond(song, rate);
                            point += GetPointOfRegion(song, rate);
                            point += GetPointOfGenre(song, rate);
                            point += GetPointOfViewDiffrence(song, rate);
                            song.Point = point;
                        }
                    }
                }

                return listSongs.OrderByDescending(item => item.Point).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<string> GetGenreRateBySongsNumber(int max = 0, int min = 0)
        {
            List<string> genre = new List<string>();
            Dictionary<string, int> keyValuePairs = GetDataFromGoogleSheet.GetNumberOfSongContainGenre();
            if (max == 0)
            {

            }
            foreach (KeyValuePair<string, int> entry in keyValuePairs)
            {
                if (max == 0)
                {
                    if (entry.Value >= min)
                    {
                        genre.Add(entry.Key);
                    }
                }
                else if (min == 0)
                {
                    if (entry.Value < max)
                    {
                        genre.Add(entry.Key);
                    }
                }
                else
                {
                    if (entry.Value < max && entry.Value >= min)
                    {
                        genre.Add(entry.Key);
                    }
                }

            }
            return genre;
        }

        public static double GetPointOfViewCountSecond(Song song, Rate rate)
        {
            try
            {
                double point = 0;
                //view
                if (song.SpotifyStreamCountSecond >= viewTop1)
                {
                    point += 0.4 * (rate.ViewCountLastRate);
                }
                else if (song.SpotifyStreamCountSecond >= viewTop2 && song.SpotifyStreamCountSecond < viewTop1)
                {
                    point += 0.3 * (rate.ViewCountLastRate);
                }
                else if (song.SpotifyStreamCountSecond >= viewTop3 && song.SpotifyStreamCountSecond < viewTop2)
                {
                    point += 0.15 * (rate.ViewCountLastRate);
                }
                else if (song.SpotifyStreamCountSecond >= viewTop4 && song.SpotifyStreamCountSecond < viewTop3)
                {
                    point += 0.1 * (rate.ViewCountLastRate);
                }
                else
                {
                    point += 0.05 * (rate.ViewCountLastRate);
                }
                return point;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static double GetPointOfRegion(Song song, Rate rate)
        {
            try
            {
                double point = 0;
                //region
                if (song.Region.Contains(Enum.GetName(typeof(Region), Region.US)) || song.Region.Contains(Enum.GetName(typeof(Region), Region.UK)))
                {
                    point += rateTop1 * (rate.RegionRate);
                }
                else if (song.Region.Contains(Enum.GetName(typeof(Region), Region.Spain)) || song.Region.Contains(Enum.GetName(typeof(Region), Region.Mexico)) ||
                    song.Region.Contains(Enum.GetName(typeof(Region), Region.Australia)) || song.Region.Contains(Enum.GetName(typeof(Region), Region.Brazil)))
                {
                    point += rateTop2 * (rate.RegionRate);
                }
                else
                {
                    point += rateTop3 * (rate.RegionRate);
                }
                return point;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public static double GetPointOfGenre(Song song, Rate rate)
        {
            try
            {
                double point = 0;
                //genre
                if (GenreTop1.Any(item => song.Genres.Contains(item)))
                {
                    point += rateTop1 * (rate.GenreRate);
                }
                else if (GenreTop2.Any(item => song.Genres.Contains(item)))
                {
                    point += rateTop2 * (rate.GenreRate);
                }
                else
                {
                    point += rateTop3 * (rate.GenreRate);
                }
                return point;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static double GetPointOfViewDiffrence(Song song, Rate rate)
        {
            try
            {
                double point = 0;
                long count = song.SpotifyStreamCountSecond - song.SpotifyStreamCountFirst;
                if(count >= 1000000)
                {
                    point += rateTop1 * (rate.DiffrenceRate);
                }else if (count < 1000000 & count >= 100000)
                {
                    point += rateTop2 * (rate.DiffrenceRate);
                }
                else
                {
                    point += rateTop3 * (rate.DiffrenceRate);
                }
                return point;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static List<Song> GetSongForTracklistByRate(List<Song> songs)
        {
            try
            {
                List<Song> listSongFinal = new List<Song>();
                if (songs.Count == 20)
                {
                    return songs;
                }
                else
                {
                    List<KeyValuePair<double, int>> keyValuePairs = GetPoint(songs);
                    if(keyValuePairs.Count == 1)
                    {
                        listSongFinal = songs.OrderBy(arg => Guid.NewGuid()).Take(totalSong).ToList();
                    }
                    else if(keyValuePairs.Count == 2)
                    {
                        if(keyValuePairs.First().Value >= top1SongNumber)
                        {
                            var randomSong = songs.Where(p => p.Point == keyValuePairs.First().Key).ToList();
                            listSongFinal.AddRange(randomSong.OrderBy(arg => Guid.NewGuid()).Take(top1SongNumber).ToList());
                        }
                        else
                        {
                            int count = songs.Where(p => p.Point == keyValuePairs.First().Key).Count();
                            for(int i = 0; i < count; i++)
                            {
                                listSongFinal.Add(songs[i]);
                            }
                            var randomSong = new List<Song>();
                            for(int i= count; i< songs.Count; i++)
                            {
                                randomSong.Add(songs[i]);
                            }
                            listSongFinal.AddRange(randomSong.OrderBy(arg => Guid.NewGuid()).Take(top1SongNumber-count).ToList());
                        }
                    }
                    else
                    {
                        if (keyValuePairs.First().Value >= top1SongNumber)
                        {
                            var randomSongTop1 = songs.Where(p => p.Point == keyValuePairs.First().Key).ToList();
                            listSongFinal.AddRange(randomSongTop1.OrderBy(arg => Guid.NewGuid()).Take(top1SongNumber).ToList());
                            var randomSongTop2 = songs.Where(p => p.Point != keyValuePairs.First().Key).ToList();
                            listSongFinal.AddRange(randomSongTop2.OrderBy(arg => Guid.NewGuid()).Take(top2SongNumber + top3SongNumber).ToList());
                        }
                        else
                        {
                            var songTop1 = songs.Where(p => p.Point == keyValuePairs.First().Key).ToList();
                            listSongFinal.AddRange(songTop1);
                            var songTop2 = songs.Where(p => p.Point != keyValuePairs.First().Key).ToList();
                            listSongFinal.AddRange(songTop2.OrderBy(arg => Guid.NewGuid()).Take(top2SongNumber + top3SongNumber + (top1SongNumber - songTop1.Count)).ToList());
                        }
                    }
                    return listSongFinal;
                }
              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<KeyValuePair<double,int>> GetPoint(List<Song> songs)
        {
            try
            {
                List<double> listPoint = new List<double>();
                List<double> listPointMigrate = new List<double>();
                List<KeyValuePair <double, int>> keyValuePairs = new List<KeyValuePair<double, int>>();
                foreach (var song in songs)
                {
                    listPoint.Add(song.Point);

                }
                for (int i = 0; i < listPoint.Count; i++)
                {
                    bool existItem = listPointMigrate.Any(item => item.Equals(listPoint[i]));
                    if (existItem == false)
                    {
                        listPointMigrate.Add(listPoint[i]);
                    }
                }
                foreach(var item in listPointMigrate)
                {
                    int count = songs.Where(p => p.Point == item).ToList().Count();
                    keyValuePairs.Add(new KeyValuePair<double, int> ( item,count));
                }
                return keyValuePairs.OrderByDescending(item => item.Key).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
