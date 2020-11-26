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
        static string ApplicationName = "Statistic WMG";
        static string spreadsheetId = "1XsrVqD-Fz1ggj2VX6wEbpt_FO0qguTMJR5YWnytYXV4";
        static string range = "Sheet1";
        static string fileNameResult = "all_songs.txt";

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
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
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
                            song.TrackName = values[i][j].ToString();
                        }
                        if (j == 2)
                        {
                            song.TrackId = values[i][j].ToString();
                        }
                        if (j == 3)
                        {
                            song.AlbumId = values[i][j].ToString();
                        }
                        if (j == 4)
                        {
                            song.Code = values[i][j].ToString();
                        }
                        if (j == 5)
                        {
                            song.TrackArtist = values[i][j].ToString();
                        }
                        if (j == 6)
                        {
                            song.Genres = values[i][j].ToString();
                        }
                        if (j == 7)
                        {
                            song.Region = values[i][j].ToString();
                        }
                        if (j == 8)
                        {
                            song.ReleaseYear = values[i][j].ToString();
                        }
                        if (j == 9)
                        {
                            song.SpotifyStreamCountFirst = long.Parse(values[i][j].ToString());
                        }
                        if (values[i].Count > 10)
                        {
                            if (j == values[i].Count - 1)
                            {
                                song.SpotifyStreamCountSecond = long.Parse(values[i][values[i].Count - 1].ToString());
                            }
                            if(j== values[i].Count - 2)
                            {
                                song.SpotifyStreamCountFirst = long.Parse(values[i][values[i].Count - 2].ToString());
                                
                            }
                        }
                    }
                    songs.Add(song);
                }
                string[] text = File.ReadAllLines("ExceptionSongs.txt");
                if(text.Length > 0)
                {
                    var listExceptionSongs = new List<string>();
                    foreach (var item in text)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            listExceptionSongs.Add(item);
                        }
                    }
                    var newSongs = new List<Song>();
                    newSongs.AddRange(songs);
                    foreach (var item in newSongs)
                    {
                        foreach (var i in listExceptionSongs)
                        {
                            if (i.ToLower().Equals(item.Code.ToLower()))
                            {
                                songs.Remove(item);
                            }
                        }
                    }
                }
                var list = songs.GroupBy(x => x.Code).Select(g => g.First()).ToList();
                var lines = new List<string>();
                    foreach (var song in list)
                    {
                        lines.Add(song.TrackName + "\t"
                            + song.TrackId + "\t"
                            + song.AlbumId + "\t"
                            + song.Code + "\t"
                            + song.TrackArtist + "\t"
                            + song.Genres + "\t"
                            + song.Region + "\t"
                            + song.ReleaseYear + "\t"
                            +song.SpotifyStreamCountFirst + "\t"
                            + song.SpotifyStreamCountSecond);
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
                        TrackId = parts[1],
                        AlbumId = parts[2],
                        Code = parts[3],
                        TrackArtist = parts[4],
                        Genres = parts[5],
                        Region = parts[6],
                        ReleaseYear = parts[7],
                        SpotifyStreamCountFirst = long.Parse(parts[8]),
                        SpotifyStreamCountSecond = long.Parse(parts[9]),
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
                List<string> listGenreMigrate = new List<string>();
                var songs = GetSongFromTextFile();
                foreach(var song in songs)
                {
                    string[] lines = song.Genres.ToString().Split(new string[] { ";" }, StringSplitOptions.None);
                    foreach(var item in lines)
                    {
                        listGenre.Add(item);
                    }
                }
                for (int i = 0; i < listGenre.Count; i++)
                {
                    if (!string.IsNullOrEmpty(listGenre[i]))
                    {
                        string existItem = listGenreMigrate.Any(item => item.Equals(listGenre[i])).ToString();
                        if (!existItem.Equals("True"))
                        {
                            listGenreMigrate.Add(listGenre[i]);
                        }
                    }
                }
                return listGenreMigrate;

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
                List<string> listRegionMigrate = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                    string[] lines = song.Region.ToString().Split(new string[] { ";" }, StringSplitOptions.None);
                    foreach (var item in lines)
                    {
                        listRegion.Add(item);
                    }
                }
                for (int i = 0; i < listRegion.Count; i++)
                {
                    if (!string.IsNullOrEmpty(listRegion[i]))
                    {
                        string existItem = listRegionMigrate.Any(item => item.Equals(listRegion[i])).ToString();
                        if (!existItem.Equals("True"))
                        {
                            listRegionMigrate.Add(listRegion[i]);
                        }
                    }
                }
                return listRegionMigrate;

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
                List<string> listYearMigrate = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                    listYear.Add(song.ReleaseYear.ToString());

                }
                for (int i = 0; i < listYear.Count; i++)
                {
                    if (!string.IsNullOrEmpty(listYear[i]))
                    {
                        string existItem = listYearMigrate.Any(item => item.Equals(listYear[i])).ToString();
                        if (!existItem.Equals("True"))
                        {
                            listYearMigrate.Add(listYear[i]);
                        }
                    }
                }
                return listYearMigrate;

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
                List<string> listArtistMigrate = new List<string>();
                var songs = GetSongFromTextFile();
                foreach (var song in songs)
                {
                  listArtist.Add(song.TrackArtist);
                }
                for (int i = 0; i < listArtist.Count; i++)
                {
                    if (!string.IsNullOrEmpty(listArtist[i]))
                    {
                        string existItem = listArtistMigrate.Any(item => item.Equals(listArtist[i])).ToString();
                        if (!existItem.Equals("True"))
                        {
                            listArtistMigrate.Add(listArtist[i]);
                        }
                    }
                }
                return listArtistMigrate;

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
