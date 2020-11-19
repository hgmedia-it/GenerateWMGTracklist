using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xabe.FFmpeg;

namespace GenerateWMGTracklist
{
    public static class SaveTracklistToFile
    {
        static string currentDir = Directory.GetCurrentDirectory();
        public static List<Song> GetSongDuration(List<Song> songs)
        {
            try
            {
                FFmpeg.SetExecutablesPath(currentDir);
                string route = "http://1.53.252.34:9001/film_video_processing/List?length=100000";
                List<SongInfo> webSongInfos = new List<SongInfo>();
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = client.GetAsync(route).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = response.Content.ReadAsStringAsync().Result;
                        webSongInfos = Newtonsoft.Json.JsonConvert.DeserializeObject<WebResponse>(jsonResponse).Data;
                    }
                    else
                    {
                        throw new Exception("Get web data failed");
                    }
                }
                foreach (var item in songs)
                {
                    foreach (var p in webSongInfos)
                    {
                        if (p.Title.ToLower().Equals(item.TrackName.ToLower()))
                        {
                            var rawString = p.upload_file;
                            string url = "http://1.53.252.34:13000/" + rawString.Substring(rawString.IndexOf("hg_wmg"));
                            item.Duration = GetFileDurarion(url);
                        }
                    }
                }
                return songs;
            }
            catch
            {
                return null;
            }

        }
        private static int GetFileDurarion(string mp3Path)
        {
            try
            {
                IMediaInfo mediaInfo = FFmpeg.GetMediaInfo(mp3Path).Result;
                return (int)mediaInfo.Duration.TotalSeconds;
            }
            catch(Exception ex)
            {
                return default(int);
            }

        }
        public static void PrintTracklist(List<Song> songs)
        {
            try
            {
                double time = 0;
                string timespan = "00:00";
                int index = 1;
                string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
                string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"Result");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string file = Path.Combine(directory, @$"tracklist_{fileName}.txt");
                foreach (var song in songs)
                {
                    File.AppendAllText(file, timespan + " | " + $"{index}. " + song.TrackName + " - " + song.TrackArtist + "\r\n");
                    time += (double)song.Duration;
                    if (time <= 3599)
                    {
                        timespan = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
                    }
                    else
                    {
                        timespan = TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public static void PrintExcelFile(List<Song> songs)
        {
            try
            {
                string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
                string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Result");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string file = Path.Combine(directory, @$"info_{fileName}.txt");
                File.AppendAllText(file, "STT" + "\t" + "Tên bài hát" + "\t" + "Code" + "\r\n");
                var index = 1;
                foreach (var song in songs)
                {
                    File.AppendAllText(file, $"{index}" + "\t" + song.TrackName.Trim() + "\t" + song.Code.Trim() + "\r\n");
                    index++;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public class SongInfo
        {
            public string Title { get; set; }
            public string Code { get; set; }
            public int? Duration { get; set; }
            public string Actor { get; set; }
            public string Url { get; set; }
            public string upload_file { get; set; }
        }
        public class WebResponse
        {
            public List<SongInfo> Data { get; set; }
        }
    }
}
