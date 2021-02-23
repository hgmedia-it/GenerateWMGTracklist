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
        public static List<string> popularity = GetDataFromGoogleSheet.GetPopularity();
        public static List<string> releaseSongs = GetDataFromGoogleSheet.GetReleaseSongs();
        List<Song> songs = GetDataFromGoogleSheet.GetSongFromTextFile();
        Rate rate = new Rate();
        string ARTIST = "Ca sỹ";
        string GENRE = "Thể loại";
        string REGION = "Thị trường";
        string YEAR = "Năm phát hành";
        string POPULARITY = "Độ phổ biến";
        string RELEASESONG = "Bản phát hành";
        public Form1()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);
            InitializeComponent();

            listBoxGenre.Items.Add("All");
            listBoxGenre.Items.Add("Other");
            genres.Sort();
            listBoxGenre.Items.AddRange(genres.ToArray());
            listBoxGenre.ColumnWidth = 150;


            listBoxArtist.Items.Add("All");
            listBoxArtist.Items.Add("Other");
            artists.Sort();
            listBoxArtist.Items.AddRange(artists.ToArray());
            listBoxArtist.ColumnWidth = 150;


            listBoxRegion.Items.Add("All");
            listBoxRegion.Items.Add("Other");
            regions.Sort();
            listBoxRegion.Items.AddRange(regions.ToArray());


            listBoxYear.Items.Add("All");
            listBoxYear.Items.Add("Other");
            years.Sort();
            listBoxYear.Items.AddRange(years.ToArray());

            listBoxPopularity.Items.Add("All");
            popularity.Sort();
            listBoxPopularity.Items.AddRange(popularity.ToArray());

            listBoxReleaseSong.Items.Add("All");
            listBoxReleaseSong.Items.Add("Other");
            releaseSongs.Sort();
            listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());

            cbMainFilter.Items.AddRange((new List<string>() { ARTIST, GENRE, REGION, YEAR, POPULARITY, RELEASESONG }).ToArray());
            cbMainFilter.SelectedIndex = 0;

            //txtViewLastRate.Text = "50";
            //txtDifferenceRate.Text = "0";
            //txtGenreRate.Text = "20";
            //txtRegionRate.Text = "30";
            //rate.ViewCountLastRate = int.Parse(txtViewLastRate.Text);
            //rate.DiffrenceRate = int.Parse(txtDifferenceRate.Text);
            //rate.GenreRate = int.Parse(txtGenreRate.Text);
            //rate.RegionRate = int.Parse(txtRegionRate.Text);

            dataGird.ColumnCount = 8;
            dataGird.Columns[0].Name = "STT";
            dataGird.Columns[1].Name = "Track Name";
            dataGird.Columns[2].Name = "Code";
            dataGird.Columns[3].Name = "Artist";
            dataGird.Columns[4].Name = "Popularity";
            dataGird.Columns[5].Name = "View Spotify";
            dataGird.Columns[6].Name = "Link Spotify";
            dataGird.Columns[7].Name = "Genre";

            radioBtnAuto.Checked = false;
            radioBtnHand.Checked = true;

            txtTotalSongs.Text = "10";
            txtTop1.Text = "4";
            txtTop2.Text = "4";
            txtTop3.Text = "2";
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
                    listBoxGenre.Items.Add("Other");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    popularity.Sort();
                    listBoxPopularity.Items.AddRange(popularity.ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    releaseSongs.Sort();
                    listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());
                }
                else
                {
                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(ARTIST, GENRE).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(ARTIST, REGION).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(ARTIST, YEAR).ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    listBoxPopularity.Items.AddRange(GetAllFilterByAnotherList(ARTIST, POPULARITY).ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    listBoxReleaseSong.Items.AddRange(GetAllFilterByAnotherList(ARTIST, RELEASESONG).ToArray());

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
                    listBoxArtist.Items.Add("Other");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    popularity.Sort();
                    listBoxPopularity.Items.AddRange(popularity.ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    releaseSongs.Sort();
                    listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(GENRE, ARTIST).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(GENRE, REGION).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(GENRE, YEAR).ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    listBoxPopularity.Items.AddRange(GetAllFilterByAnotherList(GENRE, POPULARITY).ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    listBoxReleaseSong.Items.AddRange(GetAllFilterByAnotherList(GENRE, RELEASESONG).ToArray());
                }
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
                    listBoxArtist.Items.Add("Other");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    popularity.Sort();
                    listBoxPopularity.Items.AddRange(popularity.ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    releaseSongs.Sort();
                    listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(REGION, ARTIST).ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(REGION, GENRE).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(REGION, YEAR).ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    listBoxPopularity.Items.AddRange(GetAllFilterByAnotherList(REGION, POPULARITY).ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    listBoxReleaseSong.Items.AddRange(GetAllFilterByAnotherList(REGION, RELEASESONG).ToArray());

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
                    listBoxArtist.Items.Add("Other");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    popularity.Sort();
                    listBoxPopularity.Items.AddRange(popularity.ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    releaseSongs.Sort();
                    listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(YEAR, ARTIST).ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(YEAR, GENRE).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(YEAR, REGION).ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    listBoxPopularity.Items.AddRange(GetAllFilterByAnotherList(YEAR, POPULARITY).ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    listBoxReleaseSong.Items.AddRange(GetAllFilterByAnotherList(YEAR, RELEASESONG).ToArray());
                }
            }

        }

        private void listBoxPopularity_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (cbMainFilter.SelectedItem.ToString().Equals(POPULARITY))
            {
                if (listBoxPopularity.SelectedItems.Contains("All"))
                {
                    //do nothing
                }
                else if (listBoxPopularity.SelectedItems.Count == 0)
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    releaseSongs.Sort();
                    listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(POPULARITY, ARTIST).ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(POPULARITY, GENRE).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(POPULARITY, REGION).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(POPULARITY, YEAR).ToArray());

                    listBoxReleaseSong.Items.Clear();
                    listBoxReleaseSong.Items.Add("All");
                    listBoxReleaseSong.Items.Add("Other");
                    listBoxReleaseSong.Items.AddRange(GetAllFilterByAnotherList(POPULARITY, RELEASESONG).ToArray());

                }
            }

        }
        private void listBoxReleaseSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            if (cbMainFilter.SelectedItem.ToString().Equals(RELEASESONG))
            {
                if (listBoxReleaseSong.SelectedItems.Contains("All"))
                {
                    //do nothing
                }
                else if (listBoxReleaseSong.SelectedItems.Count == 0)
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    artists.Sort();
                    listBoxArtist.Items.AddRange(artists.ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    genres.Sort();
                    listBoxGenre.Items.AddRange(genres.ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    regions.Sort();
                    listBoxRegion.Items.AddRange(regions.ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    popularity.Sort();
                    listBoxPopularity.Items.AddRange(popularity.ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    years.Sort();
                    listBoxYear.Items.AddRange(years.ToArray());
                }
                else
                {
                    listBoxArtist.Items.Clear();
                    listBoxArtist.Items.Add("All");
                    listBoxArtist.Items.Add("Other");
                    listBoxArtist.Items.AddRange(GetAllFilterByAnotherList(RELEASESONG, ARTIST).ToArray());

                    listBoxGenre.Items.Clear();
                    listBoxGenre.Items.Add("All");
                    listBoxGenre.Items.Add("Other");
                    listBoxGenre.Items.AddRange(GetAllFilterByAnotherList(RELEASESONG, GENRE).ToArray());

                    listBoxRegion.Items.Clear();
                    listBoxRegion.Items.Add("All");
                    listBoxRegion.Items.Add("Other");
                    listBoxRegion.Items.AddRange(GetAllFilterByAnotherList(RELEASESONG, REGION).ToArray());

                    listBoxYear.Items.Clear();
                    listBoxYear.Items.Add("All");
                    listBoxYear.Items.Add("Other");
                    listBoxYear.Items.AddRange(GetAllFilterByAnotherList(RELEASESONG, YEAR).ToArray());

                    listBoxPopularity.Items.Clear();
                    listBoxPopularity.Items.Add("All");
                    listBoxPopularity.Items.AddRange(GetAllFilterByAnotherList(RELEASESONG, POPULARITY).ToArray());

                }
            }
        }
        private async void btnGenTrackList_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            bool checkNull = CheckNullOfAllFilter();
            if (!CheckCountSong())
            {
                lblWarning.Text = "Tổng bài hát không chính xác";
                lblWarning.ForeColor = Color.Red;
            }
            if (!checkNull && CheckCountSong())
            {
                List<Song> allSongs = GetSongsFromFilter();
                int coutn = int.Parse(txtTotalSongs.Text);
                if (allSongs.Count < coutn)
                {
                    lblWarning.Text = "";
                    lblWarning.Text = $"Số lượng bài hát lọc được: {allSongs.Count}. Chọn lại các filter";
                }
                else
                {
                    if (radioBtnAuto.Checked)
                    {
                        try
                        {
                            lblWarning.Text = "Wating.....";
                            lblWarning.ForeColor = Color.Blue;
                            var songForTracklist =  GenerateTracklist.GetSongByPopularityPoint(allSongs, int.Parse(txtTotalSongs.Text), int.Parse(txtTop1.Text),
                                int.Parse(txtTop2.Text), int.Parse(txtTop3.Text));
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
 
                            if (string.IsNullOrEmpty(txtSeletedCode.Text.Trim()))
                            {
                                    lblWarning.Text = "";
                                    lblWarning.Text = $"Vui lòng nhập mã code cho tracklist";
                                    lblWarning.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblWarning.Text = "Wating.....";
                                lblWarning.ForeColor = Color.Blue;
                                var lines = txtSeletedCode.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList().Distinct();
                                var song = new List<Song>();
                                foreach(var item in lines)
                                {
                                    var i = new Song();
                                    i = songs.FirstOrDefault(x => x.Code.Equals(item));
                                    song.Add(i);
                                }
                                //var song = new List<Song>(dataGird.SelectedRows.Count);
                                //foreach(DataGridViewRow item in dataGird.SelectedRows)
                                //{
                                //    var i = new Song();
                                //    i.TrackName = item.Cells[1].Value.ToString();
                                //    i.TrackArtist = item.Cells[2].Value.ToString();
                                //    i.Code = item.Cells[4].Value.ToString();
                                //    song.Add(i);
                                //}
                                //song.Reverse();
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
                List<string> popularitySelectedItem = new List<string>();
                List<string> releaseSongSelectedItem = new List<string>();
                List<Song> listAllSongs = new List<Song>();
                foreach (var item in listBoxArtist.SelectedItems)
                {
                    if (item.Equals("Other"))
                    {
                        artistSelectedItem.Add("");
                    }
                    else
                    {
                        artistSelectedItem.Add(item.ToString());
                    }

                }
                foreach (var item in listBoxGenre.SelectedItems)
                {
                    if (item.Equals("Other"))
                    {
                        genreSelectedItem.Add("");
                    }
                    else
                    {
                        genreSelectedItem.Add(item.ToString());
                    }

                }
                foreach (var item in listBoxRegion.SelectedItems)
                {
                    if (item.Equals("Other"))
                    {
                        regionSelectedItem.Add("");
                    }
                    else
                    {
                        regionSelectedItem.Add(item.ToString());
                    }

                }
                foreach (var item in listBoxYear.SelectedItems)
                {
                    if (item.Equals("Other"))
                    {
                        yearSelectedItem.Add("");
                    }
                    else
                    {
                        yearSelectedItem.Add(item.ToString());
                    }

                }
                foreach (var item in listBoxPopularity.SelectedItems)
                {
                    if (item.Equals("Other"))
                    {
                        popularitySelectedItem.Add("");
                    }
                    else
                    {
                        popularitySelectedItem.Add(item.ToString());
                    }

                }
                foreach (var item in listBoxReleaseSong.SelectedItems)
                {
                    if (item.Equals("Other"))
                    {
                        releaseSongSelectedItem.Add("");
                    }
                    else
                    {
                        releaseSongSelectedItem.Add(item.ToString());
                    }

                }
                //if (listBoxArtist.SelectedItems.Contains("All"))
                //{
                //    listAllSongs = songs;
                //}
                //else
                //{
                //    songs.ForEach(item =>
                //    {
                //        if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(p => item.TrackArtist.Contains(p)) == true)
                //        {
                //            listAllSongs.Add(item);
                //        }
                //    }
                //    );
                //}

                return GenerateTracklist.GetListSongAfterFilter(artistSelectedItem, genreSelectedItem, regionSelectedItem, yearSelectedItem,popularitySelectedItem,releaseSongSelectedItem,songs);
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
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
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
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(item => song.TrackArtist.Contains(item) && !string.IsNullOrEmpty(song.ReleaseYear)))
                            {
                                resultList.Add(song.ReleaseYear.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(POPULARITY))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(item => song.TrackArtist.Contains(item) && !string.IsNullOrEmpty(song.Popularity.ToString())))
                            {
                                resultList.Add(song.Popularity.ToString().Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(RELEASESONG))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxArtist.SelectedItems.Cast<string>().ToList().Any(item => song.TrackArtist.Contains(item) && !string.IsNullOrEmpty(song.ReleaseSong)))
                            {
                                resultList.Add(song.ReleaseSong.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                }
                else if (mainFilter.Equals(GENRE))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item) && !string.IsNullOrEmpty(song.TrackArtist)))
                            {
                                resultList.Add(song.TrackArtist.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
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
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item) && !string.IsNullOrEmpty(song.ReleaseYear)))
                            {
                                resultList.Add(song.ReleaseYear.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(POPULARITY))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item) && !string.IsNullOrEmpty(song.Popularity.ToString())))
                            {
                                resultList.Add(song.Popularity.ToString().Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(RELEASESONG))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxGenre.SelectedItems.Cast<string>().ToList().Any(item => song.Genres.Contains(item) && !string.IsNullOrEmpty(song.ReleaseSong)))
                            {
                                resultList.Add(song.ReleaseSong.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                }
                else if (mainFilter.Equals(REGION))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item) && !string.IsNullOrEmpty(song.TrackArtist)))
                            {
                                resultList.Add(song.TrackArtist.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
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
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item) && !string.IsNullOrEmpty(song.ReleaseYear)))
                            {
                                resultList.Add(song.ReleaseYear.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(POPULARITY))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item) && !string.IsNullOrEmpty(song.Popularity.ToString())))
                            {
                                resultList.Add(song.Popularity.ToString().Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(RELEASESONG))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxRegion.SelectedItems.Cast<string>().ToList().Any(item => song.Region.Contains(item) && !string.IsNullOrEmpty(song.ReleaseSong)))
                            {
                                resultList.Add(song.ReleaseSong.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                }
                else if (mainFilter.Equals(YEAR))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxYear.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseYear.Contains(item) && !string.IsNullOrEmpty(song.TrackArtist)))
                            {
                                resultList.Add(song.TrackArtist.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
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
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
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
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(POPULARITY))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxYear.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseYear.Contains(item)
                            && !string.IsNullOrEmpty(song.Popularity.ToString())))
                            {
                                resultList.Add(song.Popularity.ToString().Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(RELEASESONG))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxYear.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseYear.Contains(item) && !string.IsNullOrEmpty(song.ReleaseSong)))
                            {
                                resultList.Add(song.ReleaseSong.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }

                }
                else if (mainFilter.Equals(POPULARITY))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxPopularity.SelectedItems.Cast<string>().ToList().Any(item => song.Popularity.ToString().Contains(item) && !string.IsNullOrEmpty(song.TrackArtist)))
                            {
                                resultList.Add(song.TrackArtist.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(GENRE))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxPopularity.SelectedItems.Cast<string>().ToList().Any(item => song.Popularity.ToString().Contains(item)))
                            {
                                string[] lines = song.Genres.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(REGION))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxPopularity.SelectedItems.Cast<string>().ToList().Any(item => song.Popularity.ToString().Contains(item)))
                            {
                                string[] lines = song.Region.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxPopularity.SelectedItems.Cast<string>().ToList().Any(item => song.Popularity.ToString().Contains(item)
                            && !string.IsNullOrEmpty(song.ReleaseYear)))
                            {
                                resultList.Add(song.ReleaseYear.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(RELEASESONG))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxPopularity.SelectedItems.Cast<string>().ToList().Any(item => song.Popularity.ToString().Contains(item) && !string.IsNullOrEmpty(song.ReleaseSong)))
                            {
                                resultList.Add(song.ReleaseSong.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }

                }
                else if (mainFilter.Equals(RELEASESONG))
                {
                    if (resultFilter.Equals(ARTIST))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxReleaseSong.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseSong.Contains(item) && !string.IsNullOrEmpty(song.TrackArtist)))
                            {
                                resultList.Add(song.TrackArtist.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(GENRE))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxReleaseSong.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseSong.Contains(item)))
                            {
                                string[] lines = song.Genres.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(REGION))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxReleaseSong.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseSong.Contains(item)))
                            {
                                string[] lines = song.Region.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var line in lines)
                                {
                                    resultList.Add(line.Trim());
                                }
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(YEAR))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxReleaseSong.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseSong.Contains(item)
                            && !string.IsNullOrEmpty(song.ReleaseYear)))
                            {
                                resultList.Add(song.ReleaseYear.Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }
                    else if (resultFilter.Equals(POPULARITY))
                    {
                        songs.ForEach(song =>
                        {
                            if (listBoxReleaseSong.SelectedItems.Cast<string>().ToList().Any(item => song.ReleaseSong.Contains(item) && !string.IsNullOrEmpty(song.Popularity.ToString())))
                            {
                                resultList.Add(song.Popularity.ToString().Trim());
                            }
                        });
                        return resultList.Distinct().ToList();
                    }

                }
                return resultList.Distinct().ToList();
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
            if (listBoxPopularity.SelectedItems.Count == 0)
            {
                lblWarning.Text = "";
                lblWarning.Text = "Độ phổ biến chưa được chọn";
                check = true;
            }
            if (listBoxReleaseSong.SelectedItems.Count == 0)
            {
                lblWarning.Text = "";
                lblWarning.Text = "Bản phát hành chưa được chọn";
                check = true;
            }
            lblWarning.ForeColor = Color.Red;
            lblWarning.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            return check;
        }
        public bool CheckCountSong()
        {
            try
            {
                int total = int.Parse(txtTotalSongs.Text);
                int top1 = int.Parse(txtTop1.Text);
                int top2 = int.Parse(txtTop2.Text);
                int top3 = int.Parse(txtTop3.Text);
                if(total == (top1+top2 + top3))
                {
                    return true;
                }
                return false;

            }catch(Exception ex)
            {
                return false;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            listBoxGenre.Items.Clear();
            listBoxGenre.Items.Add("All");
            listBoxGenre.Items.Add("Other");
            listBoxGenre.Items.AddRange(genres.ToArray());

            listBoxArtist.Items.Clear();
            listBoxArtist.Items.Add("All");
            listBoxArtist.Items.Add("Other");
            listBoxArtist.Items.AddRange(artists.ToArray());

            listBoxRegion.Items.Clear();
            listBoxRegion.Items.Add("All");
            listBoxRegion.Items.Add("Other");
            listBoxRegion.Items.AddRange(regions.ToArray());

            listBoxYear.Items.Clear();
            listBoxYear.Items.Add("All");
            listBoxYear.Items.Add("Other");
            listBoxYear.Items.AddRange(years.ToArray());

            listBoxPopularity.Items.Clear();
            listBoxPopularity.Items.Add("All");
            listBoxPopularity.Items.AddRange(popularity.ToArray());

            listBoxReleaseSong.Items.Clear();
            listBoxReleaseSong.Items.Add("All");
            listBoxReleaseSong.Items.Add("Other");
            listBoxReleaseSong.Items.AddRange(releaseSongs.ToArray());

            dataGird.Rows.Clear();
            listSelectedArtist.Items.Clear();

            txtSearchCode.Text = "";
            txtSeletedCode.Text = "";
        }

        private void btnDisplayTracklist_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            bool checkNull = CheckNullOfAllFilter();
            if (!checkNull)
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
                                if(songs[i].SpotifyStreamCountSecond == 0)
                        {
                            songs[i].SpotifyStreamCountSecond = songs[i].SpotifyStreamCountFirst;
                        }
                                dataGird.Rows.Add(i + 1, songs[i].TrackName, songs[i].Code, songs[i].TrackArtist,songs[i].Popularity,songs[i].SpotifyStreamCountSecond,songs[i].LinkSpotify,songs[i].Genres);

                        }
                    }
                    catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }
                //}
            }
        }

        private void radioBtnHand_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnHand.Checked)
            {
                txtTotalSongs.Enabled = false;
                txtTop1.Enabled = false;
                txtTop2.Enabled = false;
                txtTop3.Enabled = false;
                radioBtnAuto.Checked = false;
            }
            else
            {
                txtTotalSongs.Enabled = true;
                txtTop1.Enabled = true;
                txtTop2.Enabled = true;
                txtTop3.Enabled = true;
                radioBtnAuto.Checked = true;
            }
        }

        private void radioBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnAuto.Checked)
            {
                txtTotalSongs.Enabled = true;
                txtTop1.Enabled = true;
                txtTop2.Enabled = true;
                txtTop3.Enabled = true;
                radioBtnHand.Checked = false;
            }
            else
            {
                txtTotalSongs.Enabled = false;
                txtTop1.Enabled = false;
                txtTop2.Enabled = false;
                txtTop3.Enabled = false;
                radioBtnHand.Checked = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            //bool checkNull = CheckNullOfAllFilter();

            var lines = txtSearchCode.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList().Distinct();
            var list = new List<Song>();
            foreach (var line in lines)
            {
                list.AddRange(songs.Where(x => x.Code.Equals(line.Trim())));
            }
            try
            {
                dataGird.Rows.Clear();
                dataGird.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].SpotifyStreamCountSecond == 0)
                    {
                        list[i].SpotifyStreamCountSecond = songs[i].SpotifyStreamCountFirst;
                    }
                    dataGird.Rows.Add(i + 1, list[i].TrackName, list[i].Code, list[i].TrackArtist, list[i].Popularity, list[i].SpotifyStreamCountSecond, list[i].LinkSpotify,list[i].Genres);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //}

        }
    }
    }
