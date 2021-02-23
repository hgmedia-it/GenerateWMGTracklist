using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.GetRequest;

namespace GenerateWMGTracklist
{
    public static class GetDataFromGoogleSheet
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Lọc nhạc - WMG (IT)";
        static string spreadsheetId = "1fwHPiN_TuL99Spk0t9qnX0ry26pZaDgGHGX3OtcYwwk";
        static string range = "Lọc nhạc";
        static string fileNameResult = "all_songs.txt";
        static string otherValue = "Other";

        private static ValueRange GetDataByColumnFromGoogleSheet()
        {
            try
            {
                UserCredential credential;

                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });
                SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum valueRenderOption = (SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum)0;  // TODO: Update placeholder value.
                SpreadsheetsResource.ValuesResource.GetRequest.DateTimeRenderOptionEnum dateTimeRenderOption = (SpreadsheetsResource.ValuesResource.GetRequest.DateTimeRenderOptionEnum)0;  // TODO: Update placeholder value.
                SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                request.ValueRenderOption = valueRenderOption;
                request.DateTimeRenderOption = dateTimeRenderOption;
                request.MajorDimension = MajorDimensionEnum.ROWS;
                // To execute asynchronously in an async method, replace `request.Execute()` as shown:
                Google.Apis.Sheets.v4.Data.ValueRange response = request.Execute();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }
        public static void GetSongFromGoogleSheet()
        {
            try
            {
                IList<IList<Object>> values = GetDataByColumnFromGoogleSheet().Values;
                List<Song> songs = new List<Song>();
                for (int i = 1; i < values.Count; i++)
                {
                    Song song = new Song();
                    for (int j = 1; j < values[i].Count; j++)
                    {
                        if (j == 1)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.TrackName = values[i][j].ToString();
                            }

                        }
                        if (j == 2)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Code = values[i][j].ToString();
                            }
                        }
                        if (j == 3)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.TrackArtist = values[i][j].ToString();
                            }
                        }
                        if (j == 4)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.LinkSpotify = values[i][j].ToString();
                                song.TrackId = values[i][j].ToString().Split(new string[] { "=" }, StringSplitOptions.None)[1].Split(new string[] { ":" }, StringSplitOptions.None)[2];
                                song.AlbumId = values[i][j].ToString().Split(new string[] { "?" }, StringSplitOptions.None)[0].Split(new string[] { "https://open.spotify.com/album/" }, StringSplitOptions.None)[1];
                            }
                        }
                        //if (j == 5)
                        //{
                        //    if (!string.IsNullOrEmpty(values[i][j].ToString()))
                        //    {
                        //        song.Genres = values[i][j].ToString();
                        //    }
                        //}
                        if (j == 6)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Region = values[i][j].ToString();
                            }
                        }
                        if (j == 7)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.ReleaseYear = values[i][j].ToString();
                            }
                        }
                        if (j == 8)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Popularity = int.Parse(values[i][j].ToString());
                            }
                        }
                        if (j == 9)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.SpotifyStreamCountFirst = long.Parse(values[i][j].ToString());
                            }

                        }
                        if(j == 10)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Claim = true;
                            }
                        }
                        if (j == 11)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Expired = true;
                            }
                        }
                        if (j == 12 || j == 13)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Genres += values[i][j].ToString() + ";";
                            }
                        }
                        if (j == 14)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.Mood = values[i][j].ToString();
                            }
                        }
                        if (j == 15)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.ArtistRange = values[i][j].ToString();
                            }
                        }
                        if(j == 17)
                        {
                            if (!string.IsNullOrEmpty(values[i][j].ToString()))
                            {
                                song.ReleaseSong = values[i][j].ToString();
                            }
                        }
                        //if (values[i].Count > 10)
                        //{
                        //    if (j == values[i].Count - 1)
                        //    {
                        //        if (!string.IsNullOrEmpty(values[i][j].ToString()))
                        //        {
                        //            song.SpotifyStreamCountSecond = long.Parse(values[i][values[j].Count - 1].ToString());
                        //        }

                        //    }
                        //    if(j== values[i].Count - 2)
                        //    {
                        //        if (!string.IsNullOrEmpty(values[i][j].ToString()))
                        //        {
                        //            song.SpotifyStreamCountFirst = long.Parse(values[i][values[j].Count - 2].ToString());
                        //        }                               
                        //    }
                        //}
                    }
                    songs.Add(song);
                }
                var list = songs.GroupBy(x => x.Code).Select(g => g.First()).ToList();
                list = list.Where(item => item.Claim == false && item.Expired == false).ToList();
                var lines = new List<string>();
                foreach (var song in list)
                {
                    lines.Add(song.TrackName + "\t"
                        + song.Code + "\t"
                        + song.TrackArtist + "\t"
                        + song.LinkSpotify + "\t"
                        + song.Genres + "\t"
                        + song.Region + "\t"
                        + song.ReleaseYear + "\t"
                        + song.Popularity + "\t"
                        + song.SpotifyStreamCountFirst + "\t"
                        + song.Claim.ToString() + "\t"
                        + song.Expired.ToString() + "\t"
                        + song.Mood + "\t"
                        + song.ArtistRange + "\t"
                        + song.ReleaseSong);
                }
                if (File.Exists(fileNameResult))
                {
                    File.Delete(fileNameResult);
                }
                File.AppendAllLines(fileNameResult, lines);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static List<Song> GetSongFromTextFile()
        {
            try
            {
                List<Song> songs = new List<Song>();
                var lines = File.ReadAllLines(fileNameResult);
                foreach (var line in lines)
                {
                    var parts = line.Split(new string[] { "\t" }, StringSplitOptions.None);
                    songs.Add(new Song
                    {
                        TrackName = parts[0],
                        Code = parts[1],
                        TrackArtist = parts[2],
                        LinkSpotify = parts[3],
                        Genres = parts[4],
                        Region = parts[5],
                        ReleaseYear = parts[6],
                        Popularity = int.Parse(parts[7]),
                        SpotifyStreamCountFirst = long.Parse(parts[8]),
                        Claim = bool.Parse(parts[9]),
                        Expired = bool.Parse(parts[10]),
                        Mood = parts[11],
                        ArtistRange = parts[12],
                        ReleaseSong = parts[13]
                        
                    });
                }
                return songs;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetGenre()
        {
            try
            {
                List<string> listGenre = new List<string>();
                var songs = GetSongFromTextFile();
                foreach(var song in songs)
                {
                    string[] lines = song.Genres.ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(var item in lines)
                    {

                        listGenre.Add(item.Trim());

                    }
                }
                return listGenre.Distinct().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetRegion()
        {
            try
            {
                List<string> listRegion = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                    string[] lines = song.Region.ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in lines)
                    {

                        listRegion.Add(item.Trim());

                    }
                }
                return listRegion.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetYear()
        {
            try
            {
                List<string> listYear = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song.ReleaseYear))
                    {
                        listYear.Add(song.ReleaseYear.ToString());
                    }


                }
                return listYear.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetArtist()
        {
            try
            {
                List<string> listArtist = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song.TrackArtist))
                    {
                        listArtist.Add(song.TrackArtist);
                    }

                }
                return listArtist.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetPopularity()
        {
            try
            {
                List<string> listPopularity = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song.Popularity.ToString()))
                    {
                        listPopularity.Add(song.Popularity.ToString());
                    }

                }
                return listPopularity.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetArtistRange()
        {
            try
            {
                var songs = GetSongFromTextFile();
                var listResult = new List<string>();
                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song.ArtistRange))
                    {
                        listResult.Add(song.ArtistRange);
                    }

                }
                return listResult.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetReleaseSongs()
        {
            try
            {
                var songs = GetSongFromTextFile();
                var listResult = new List<string>();
                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song.ReleaseSong))
                    {
                        listResult.Add(song.ReleaseSong);
                    }

                }
                return listResult.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<string> GetMood()
        {
            try
            {
                var songs = GetSongFromTextFile();
                var listResult = new List<string>();
                foreach (var song in songs)
                {
                    if (!string.IsNullOrEmpty(song.Mood))
                    {
                        listResult.Add(song.Mood);
                    }

                }
                return listResult.Distinct().ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Dictionary<string,int> GetNumberOfSongContainGenre()
        {
            List<string> listCount = new List<string>();
            List<string> genre = GetGenre();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            List<Song> songs = GetSongFromTextFile();
            foreach (var gen in genre)
            {
                int count = songs.Where(item => item.Genres.Contains(gen)).ToList().Count;
                keyValuePairs.Add(gen, count);
            }
            return keyValuePairs;
        }
    }
}
