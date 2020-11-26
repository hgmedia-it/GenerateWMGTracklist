using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateWMGTracklist
{
    public partial class Form1 : Form
    {
        public static List<string> genres = GetDataFromGoogleSheet.GetGenre();
        public static List<string> artists = GetDataFromGoogleSheet.GetArtist();
        public static List<string> regions = GetDataFromGoogleSheet.GetRegion();
        public static List<string> years = GetDataFromGoogleSheet.GetYear();
        List<Song> songs = GetDataFromGoogleSheet.GetSongFromTextFile();
        Rate rate = new Rate();
        string ARTIST = "Artist";
        string GENRE = "Genre";
        string REGION = "Region";
        string YEAR = "Year";
        public Form1()
        {
            InitializeComponent();

            listBoxGenre.Items.Add("All");
            genres.Sort();
            listBoxGenre.Items.AddRange(genres.ToArray());
            listBoxGenre.ColumnWidth = 150;
            listBoxArtist.Items.Add("All");
            artists.Sort();
            listBoxArtist.Items.AddRange(artists.ToArray());
            listBoxArtist.ColumnWidth = 150;


            listBoxRegion.Items.Add("All");
            regions.Sort();
            listBoxRegion.Items.AddRange(regions.ToArray());


            listBoxYear.Items.Add("All");
            years.Sort();
            listBoxYear.Items.AddRange(years.ToArray());

            cbMainFilter.Items.AddRange((new List<string>() { ARTIST, GENRE, REGION, YEAR }).ToArray());
            cbMainFilter.SelectedIndex = 0;

            txtViewLastRate.Text = "50";
            txtDifferenceRate.Text = "0";
            txtGenreRate.Text = "20";
            txtRegionRate.Text = "30";
            rate.ViewCountLastRate = int.Parse(txtViewLastRate.Text);
            rate.DiffrenceRate = int.Parse(txtDifferenceRate.Text);
            rate.GenreRate = int.Parse(txtGenreRate.Text);
            rate.RegionRate = int.Parse(txtRegionRate.Text);

            dataGird.ColumnCount = 5;
            dataGird.Columns[0].Name = "STT";
            dataGird.Columns[1].Name = "Track Name";
            dataGird.Columns[2].Name = "Artist";
            dataGird.Columns[3].Name = "View Spotify";
            dataGird.Columns[4].Name = "Code";

            radioBtnAuto.Checked = true;
            radioBtnHand.Checked = false;
        }

        private void listBoxArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            listSelectedArtist.Items.Clear();
            if (cbMainFilter.SelectedItem.ToString().Equals(ARTIST))
            {
                if (listBoxArtist.SelectedItems.Contains("All"))
                {
                    //do nothing
                }
                else if (listBoxArtist.SelectedItems.Count == 0)
                {
                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());
                }
                else
                {
                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(ARTIST, GENRE).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(ARTIST, REGION).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(ARTIST, YEAR).ToArray());

                }
            }
            foreach(var item in listBoxArtist.SelectedItems)
            {
                listSelectedArtist.Items.Add(item);
            }

        }

        private void listBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            listSelectedGenre.Items.Clear();
            if (cbMainFilter.SelectedItem.ToString().Equals(GENRE))
            {
                if (listBoxGenre.SelectedItems.Contains("All"))
                {
                    //do nothing
                }
                else if (listBoxGenre.SelectedItems.Count == 0)
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(GENRE, ARTIST).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(GENRE, REGION).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(GENRE, YEAR).ToArray());

                }
            }
            foreach (var item in listBoxGenre.SelectedItems)
            {
                listSelectedGenre.Items.Add(item);
            }

        }

        private void listBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (cbMainFilter.SelectedItem.Equals(REGION))
            {
                if (listBoxRegion.SelectedItems.Contains("All"))
                {

                }
                else if (listBoxRegion.SelectedItems.Count == 0)
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(REGION, ARTIST).ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(REGION, GENRE).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(REGION, YEAR).ToArray());

                }
            }
        }

        private void listBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (cbMainFilter.SelectedItem.ToString().Equals(YEAR))
            {
                if (listBoxYear.SelectedItems.Contains("All"))
                {
                    //do nothing
                }
                else if (listBoxYear.SelectedItems.Count == 0)
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(YEAR, ARTIST).ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(YEAR, GENRE).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(YEAR, REGION).ToArray());

                }
            }

        }
        private async void btnGenTrackList_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            bool checkNull = CheckNullOfAllFilter();
            if (!CheckRate())
            {
                lblWarning.Text = "Tổng rate phải bằng 100";
                lblWarning.ForeColor = Color.Red;
            }
            if (!checkNull && CheckRate())
            {
                List<Song> songs = GetSongsFromFilter();
                if (songs.Count < 20)
                {
                    lblWarning.Text = "";
                    lblWarning.Text = $"Số lượng bài hát lọc được: {songs.Count}. Chọn lại các filter";
                }
                else
                {
                    if (radioBtnAuto.Checked)
                    {
                        try
                        {
                            lblWarning.Text = "Wating.....";
                            lblWarning.ForeColor = Color.Blue;
                            rate.DiffrenceRate = double.Parse(txtDifferenceRate.Text);
                            rate.ViewCountLastRate = double.Parse(txtViewLastRate.Text);
                            rate.RegionRate = double.Parse(txtRegionRate.Text);
                            rate.GenreRate = double.Parse(txtGenreRate.Text);
                            List<Song> resultRate = GenerateTracklist.GetListSongByRating(songs, rate);
                            var songForTracklist = GenerateTracklist.GetSongForTracklistByRate(resultRate);
                            var finalSong = new List<Song>();
                            await Task.Factory.StartNew(() =>
                            {
                                finalSong = SaveTracklistToFile.GetSongDuration(songForTracklist);
                                SaveTracklistToFile.PrintTracklist(finalSong);
                                SaveTracklistToFile.PrintExcelFile(finalSong);
                            });
                            lblWarning.Text = "Tạo tracklist thành công. Xem kết quả tại Desktop/Result";
                            lblWarning.ForeColor = Color.Blue;
                        }
                        catch (Exception ex)
                        {
                            lblWarning.Text = "";
                            lblWarning.Text = "Lỗi khi tạo track list";
                            lblWarning.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        try
                        {
                            if(dataGird.SelectedRows.Count < 20)
                            {
                                lblWarning.Text = "";
                                lblWarning.Text = "Vui lòng chọn đủ 20 bài";
                                lblWarning.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblWarning.Text = "Wating.....";
                                lblWarning.ForeColor = Color.Blue;
                                var song = new List<Song>(dataGird.SelectedRows.Count);
                                foreach(DataGridViewRow item in dataGird.SelectedRows)
                                {
                                    var i = new Song();
                                    i.TrackName = item.Cells[1].Value.ToString();
                                    i.TrackArtist = item.Cells[2].Value.ToString();
                                    i.Code = item.Cells[4].Value.ToString();
                                    song.Add(i);
                                }
                                song.Reverse();
                                await Task.Factory.StartNew(() =>
                                {
                                    var finalSongs = SaveTracklistToFile.GetSongDuration(song);
                                    SaveTracklistToFile.PrintTracklist(finalSongs);
                                    SaveTracklistToFile.PrintExcelFile(finalSongs);
                                });
                                lblWarning.Text = "Tạo tracklist thành công. Xem kết quả tại Desktop/Result";
                                lblWarning.ForeColor = Color.Blue;
                            }

                        }
                        catch(Exception ex)
                        {

                        }
                    }

                }
            }

        }
        public List<Song> GetSongsFromFilter()
        {
            try
            {
                List<string> artistSelectedItem = new List<string>();
                List<string> genreSelectedItem = new List<string>();
                List<string> regionSelectedItem = new List<string>();
                List<string> yearSelectedItem = new List<string>();
                List<Song> listAllSongs = new List<Song>();
                foreach (var item in listBoxArtist.SelectedItems)
                {
                    artistSelectedItem.Add(item.ToString());
                }
                foreach (var item in listBoxGenre.SelectedItems)
                {
                    genreSelectedItem.Add(item.ToString());
                }
                foreach (var item in listBoxRegion.SelectedItems)
                {
                    regionSelectedItem.Add(item.ToString());
                }
                foreach (var item in listBoxYear.SelectedItems)
                {
                    yearSelectedItem.Add(item.ToString());
                }
                if (listBoxArtist.SelectedItems.Contains("All"))
                {
                    songs.ForEach(item =>
                    {
                        if (listBoxArtist.Items.Cast<string>().ToList().Any(p => item.TrackArtist.Contains(p)) == true)
                        {
                            listAllSongs.Add(item);
                        }
                    }
                    );
                }
                else
                {
                    songs.ForEach(item =>
                    {
                        if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(p => item.TrackArtist.Contains(p)) == true)
                        {
                            listAllSongs.Add(item);
                        }
                    }
                    );
                }

                return GenerateTracklist.GetListSongAfterFilter(artistSelectedItem, genreSelectedItem, regionSelectedItem, yearSelectedItem,listAllSongs);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<string> GetAllFilterByAnotherList(string mainFilter, string resultFilter)
        {
            try
            {
                List<string> resultList = new List<string>();
                List<string> resultListMigrate = new List<string>();
                if (mainFilter.Equals(ARTIST))
                {
                    if (resultFilter.Equals(GENRE))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(item => song.TrackArtist.Contains(item)))
                            {
                                string[] lines = song.Genres.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line);
                                }
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(REGION))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(item => song.TrackArtist.Contains(item)))
                            {
                                string[] lines = song.Region.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line);
                                }
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(item => song.TrackArtist.Contains(item)))
                            {
                                resultList.Add(song.ReleaseYear);
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false && !string.IsNullOrEmpty(item))
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                }
                else if (mainFilter.Equals(GENRE))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item)))
                            {
                                resultList.Add(song.TrackArtist);
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(REGION))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item)))
                            {
                                string[] lines = song.Region.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line);
                                }
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item)))
                            {
                                resultList.Add(song.ReleaseYear);
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false && !string.IsNullOrEmpty(item))
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                }
                else if (mainFilter.Equals(REGION))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item)))
                            {
                                resultList.Add(song.TrackArtist);
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(GENRE))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item)))
                            {
                                string[] lines = song.Genres.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line);
                                }
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item)))
                            {
                                resultList.Add(song.ReleaseYear);
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false && !string.IsNullOrEmpty(item))
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                }
                else if (mainFilter.Equals(YEAR))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxYear.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseYear.Contains(item)))
                            {
                                resultList.Add(song.TrackArtist);
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(GENRE))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxYear.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseYear.Contains(item)))
                            {
                                string[] lines = song.Genres.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line);
                                }
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false)
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                    else if (resultFilter.Equals(REGION))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxYear.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseYear.Contains(item)))
                            {
                                string[] lines = song.Region.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line);
                                }
                            }
                        });
                        resultList.ForEach(item =>
                        {
                            if (resultListMigrate.Any(p => p.Equals(item)) == false && !string.IsNullOrEmpty(item))
                            {
                                resultListMigrate.Add(item);
                            }
                        }
                        );
                        return resultListMigrate;
                    }
                }
                return resultListMigrate;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public bool CheckNullOfAllFilter()
        {
            bool check = false;
            if (listBoxArtist.SelectedItems.Count == 0)
            {
                lblWarning.Text = "";
                lblWarning.Text = "Ca sỹ chưa được chọn";
                check = true;
            }
            if (listBoxGenre.SelectedItems.Count == 0)
            {
                lblWarning.Text = "";
                lblWarning.Text = "Thể loại chưa được chọn";
                check = true;
            }
            if (listBoxRegion.SelectedItems.Count == 0)
            {
                lblWarning.Text = "";
                lblWarning.Text = "Thị trường chưa được chọn";
                check = true;
            }
            if (listBoxYear.SelectedItems.Count == 0)
            {
                lblWarning.Text = "";
                lblWarning.Text = "Năm phát hành chưa được chọn";
                check = true;
            }
            lblWarning.ForeColor = Color.Red;
            lblWarning.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            return check;
        }
        public bool CheckRate()
        {
            try
            {
                double rate = double.Parse(txtViewLastRate.Text.ToString()) + double.Parse(txtDifferenceRate.Text.ToString()) 
                    + double.Parse(txtGenreRate.Text.ToString()) + double.Parse(txtRegionRate.Text.ToString());
                if(rate == 100)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            listBoxGenre.Items.Clear();
            listBoxGenre.Items.Add("All");
            listBoxGenre.Items.AddRange(genres.ToArray());

            listBoxArtist.Items.Clear();
            listBoxArtist.Items.Add("All");
            listBoxArtist.Items.AddRange(artists.ToArray());

            listBoxRegion.Items.Clear();
            listBoxRegion.Items.Add("All");
            listBoxRegion.Items.AddRange(regions.ToArray());

            listBoxYear.Items.Clear();
            listBoxYear.Items.Add("All");
            listBoxYear.Items.AddRange(years.ToArray());

            dataGird.Rows.Clear();
            listSelectedGenre.Items.Clear();
            listSelectedArtist.Items.Clear();
        }

        private void btnDisplayTracklist_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            bool checkNull = CheckNullOfAllFilter();
            if (!CheckRate())
            {
                lblWarning.Text = "Tổng rate phải bằng 100";
                lblWarning.ForeColor = Color.Red;
            }
            if (!checkNull && CheckRate())
            {
                List<Song> songs = GetSongsFromFilter();
                //if (songs.Count < 20)
                //{
                //    lblWarning.Text = "";
                //    lblWarning.Text = $"Số lượng bài hát lọc được: {songs.Count}. Chọn lại các filter";
                //}
                //else
                //{
                    try
                    {
                        dataGird.Rows.Clear();
                        for(int i =0; i< songs.Count; i++)
                        {
                            if(songs[i].SpotifyStreamCountFirst == 0)
                            {
                                dataGird.Rows.Add(i + 1, songs[i].TrackName, songs[i].TrackArtist, songs[i].SpotifyStreamCountSecond, songs[i].Code);
                            }
                            else
                            {
                                dataGird.Rows.Add(i + 1, songs[i].TrackName, songs[i].TrackArtist, songs[i].SpotifyStreamCountFirst, songs[i].Code);
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                //}
            }
        }

        private void radioBtnHand_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnHand.Checked)
            {
                radioBtnAuto.Checked = false;
            }
            else
            {
                radioBtnAuto.Checked = true;
            }
        }

        private void radioBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnAuto.Checked)
            {
                radioBtnHand.Checked = false;
            }
            else
            {
                radioBtnHand.Checked = true;
            }
        }

        private void dataGird_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            txtSelectedRows.Text = dataGird.SelectedRows.Count.ToString();
        }
    }
}
