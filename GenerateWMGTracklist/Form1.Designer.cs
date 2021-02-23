namespace GenerateWMGTracklist
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblYear = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblRegion = new System.Windows.Forms.Label();
            this.listBoxGenre = new System.Windows.Forms.ListBox();
            this.listBoxArtist = new System.Windows.Forms.ListBox();
            this.listBoxRegion = new System.Windows.Forms.ListBox();
            this.listBoxYear = new System.Windows.Forms.ListBox();
            this.btnGenTrackList = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.cbMainFilter = new System.Windows.Forms.ComboBox();
            this.lblMainFilter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGird = new System.Windows.Forms.DataGridView();
            this.btnDisplayTracklist = new System.Windows.Forms.Button();
            this.listSelectedArtist = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radioBtnHand = new System.Windows.Forms.RadioButton();
            this.radioBtnAuto = new System.Windows.Forms.RadioButton();
            this.txtTotalSongs = new System.Windows.Forms.TextBox();
            this.txtTop1 = new System.Windows.Forms.TextBox();
            this.txtTop2 = new System.Windows.Forms.TextBox();
            this.txtTop3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxPopularity = new System.Windows.Forms.ListBox();
            this.listBoxReleaseSong = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSeletedCode = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearchCode = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGird)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(399, 366);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(89, 21);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Năm phát hành";
            this.lblYear.UseCompatibleTextRendering = true;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(29, 71);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(35, 15);
            this.lblArtist.TabIndex = 3;
            this.lblArtist.Text = "Ca sỹ";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(29, 372);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 15);
            this.lblGenre.TabIndex = 5;
            this.lblGenre.Text = "Thể loại";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(570, 71);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(62, 15);
            this.lblRegion.TabIndex = 7;
            this.lblRegion.Text = "Thị trường";
            // 
            // listBoxGenre
            // 
            this.listBoxGenre.FormattingEnabled = true;
            this.listBoxGenre.IntegralHeight = false;
            this.listBoxGenre.ItemHeight = 15;
            this.listBoxGenre.Location = new System.Drawing.Point(29, 403);
            this.listBoxGenre.Name = "listBoxGenre";
            this.listBoxGenre.ScrollAlwaysVisible = true;
            this.listBoxGenre.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxGenre.Size = new System.Drawing.Size(141, 160);
            this.listBoxGenre.TabIndex = 8;
            this.listBoxGenre.SelectedIndexChanged += new System.EventHandler(this.listBoxGenre_SelectedIndexChanged);
            // 
            // listBoxArtist
            // 
            this.listBoxArtist.FormattingEnabled = true;
            this.listBoxArtist.ItemHeight = 15;
            this.listBoxArtist.Location = new System.Drawing.Point(29, 104);
            this.listBoxArtist.MultiColumn = true;
            this.listBoxArtist.Name = "listBoxArtist";
            this.listBoxArtist.ScrollAlwaysVisible = true;
            this.listBoxArtist.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxArtist.Size = new System.Drawing.Size(338, 244);
            this.listBoxArtist.TabIndex = 9;
            this.listBoxArtist.SelectedIndexChanged += new System.EventHandler(this.listBoxArtist_SelectedIndexChanged);
            // 
            // listBoxRegion
            // 
            this.listBoxRegion.FormattingEnabled = true;
            this.listBoxRegion.ItemHeight = 15;
            this.listBoxRegion.Location = new System.Drawing.Point(570, 104);
            this.listBoxRegion.Name = "listBoxRegion";
            this.listBoxRegion.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxRegion.Size = new System.Drawing.Size(130, 139);
            this.listBoxRegion.TabIndex = 10;
            this.listBoxRegion.SelectedIndexChanged += new System.EventHandler(this.listBoxRegion_SelectedIndexChanged);
            // 
            // listBoxYear
            // 
            this.listBoxYear.FormattingEnabled = true;
            this.listBoxYear.ItemHeight = 15;
            this.listBoxYear.Location = new System.Drawing.Point(399, 403);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxYear.Size = new System.Drawing.Size(124, 154);
            this.listBoxYear.TabIndex = 11;
            this.listBoxYear.SelectedIndexChanged += new System.EventHandler(this.listBoxYear_SelectedIndexChanged);
            // 
            // btnGenTrackList
            // 
            this.btnGenTrackList.Location = new System.Drawing.Point(310, 729);
            this.btnGenTrackList.Name = "btnGenTrackList";
            this.btnGenTrackList.Size = new System.Drawing.Size(132, 53);
            this.btnGenTrackList.TabIndex = 12;
            this.btnGenTrackList.Text = "Tạo TrackList";
            this.btnGenTrackList.UseVisualStyleBackColor = true;
            this.btnGenTrackList.Click += new System.EventHandler(this.btnGenTrackList_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(448, 748);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 15);
            this.lblWarning.TabIndex = 13;
            // 
            // cbMainFilter
            // 
            this.cbMainFilter.FormattingEnabled = true;
            this.cbMainFilter.Location = new System.Drawing.Point(29, 34);
            this.cbMainFilter.Name = "cbMainFilter";
            this.cbMainFilter.Size = new System.Drawing.Size(121, 23);
            this.cbMainFilter.TabIndex = 14;
            // 
            // lblMainFilter
            // 
            this.lblMainFilter.AutoSize = true;
            this.lblMainFilter.Location = new System.Drawing.Point(29, 9);
            this.lblMainFilter.Name = "lblMainFilter";
            this.lblMainFilter.Size = new System.Drawing.Size(66, 15);
            this.lblMainFilter.TabIndex = 15;
            this.lblMainFilter.Text = "Filter chính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, -55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "%";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(176, 729);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 53);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dataGird
            // 
            this.dataGird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGird.Location = new System.Drawing.Point(796, 92);
            this.dataGird.Name = "dataGird";
            this.dataGird.Size = new System.Drawing.Size(766, 436);
            this.dataGird.TabIndex = 19;
            this.dataGird.Text = "dataGridView1";
            // 
            // btnDisplayTracklist
            // 
            this.btnDisplayTracklist.Location = new System.Drawing.Point(29, 729);
            this.btnDisplayTracklist.Name = "btnDisplayTracklist";
            this.btnDisplayTracklist.Size = new System.Drawing.Size(110, 53);
            this.btnDisplayTracklist.TabIndex = 20;
            this.btnDisplayTracklist.Text = "Hiển thị Tracklist";
            this.btnDisplayTracklist.UseVisualStyleBackColor = true;
            this.btnDisplayTracklist.Click += new System.EventHandler(this.btnDisplayTracklist_Click);
            // 
            // listSelectedArtist
            // 
            this.listSelectedArtist.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.listSelectedArtist.FormattingEnabled = true;
            this.listSelectedArtist.ItemHeight = 15;
            this.listSelectedArtist.Location = new System.Drawing.Point(399, 104);
            this.listSelectedArtist.Name = "listSelectedArtist";
            this.listSelectedArtist.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listSelectedArtist.Size = new System.Drawing.Size(120, 139);
            this.listSelectedArtist.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ca sỹ được chọn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Độ phổ biến";
            // 
            // radioBtnHand
            // 
            this.radioBtnHand.AutoSize = true;
            this.radioBtnHand.Location = new System.Drawing.Point(580, 597);
            this.radioBtnHand.Name = "radioBtnHand";
            this.radioBtnHand.Size = new System.Drawing.Size(74, 19);
            this.radioBtnHand.TabIndex = 22;
            this.radioBtnHand.TabStop = true;
            this.radioBtnHand.Text = "Chọn Tay";
            this.radioBtnHand.UseVisualStyleBackColor = true;
            this.radioBtnHand.CheckedChanged += new System.EventHandler(this.radioBtnHand_CheckedChanged);
            // 
            // radioBtnAuto
            // 
            this.radioBtnAuto.AutoSize = true;
            this.radioBtnAuto.Location = new System.Drawing.Point(580, 641);
            this.radioBtnAuto.Name = "radioBtnAuto";
            this.radioBtnAuto.Size = new System.Drawing.Size(69, 19);
            this.radioBtnAuto.TabIndex = 23;
            this.radioBtnAuto.TabStop = true;
            this.radioBtnAuto.Text = "Tự động";
            this.radioBtnAuto.UseVisualStyleBackColor = true;
            this.radioBtnAuto.CheckedChanged += new System.EventHandler(this.radioBtnAuto_CheckedChanged);
            // 
            // txtTotalSongs
            // 
            this.txtTotalSongs.Location = new System.Drawing.Point(105, 595);
            this.txtTotalSongs.Name = "txtTotalSongs";
            this.txtTotalSongs.Size = new System.Drawing.Size(65, 23);
            this.txtTotalSongs.TabIndex = 24;
            // 
            // txtTop1
            // 
            this.txtTop1.Location = new System.Drawing.Point(105, 655);
            this.txtTop1.Name = "txtTop1";
            this.txtTop1.Size = new System.Drawing.Size(65, 23);
            this.txtTop1.TabIndex = 24;
            // 
            // txtTop2
            // 
            this.txtTop2.Location = new System.Drawing.Point(399, 592);
            this.txtTop2.Name = "txtTop2";
            this.txtTop2.Size = new System.Drawing.Size(65, 23);
            this.txtTop2.TabIndex = 24;
            // 
            // txtTop3
            // 
            this.txtTop3.Location = new System.Drawing.Point(399, 663);
            this.txtTop3.Name = "txtTop3";
            this.txtTop3.Size = new System.Drawing.Size(65, 23);
            this.txtTop3.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 599);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tổng số bài";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 655);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Số bài top 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(310, 595);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "Số bài top 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(310, 663);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Số bài top 3";
            // 
            // listBoxPopularity
            // 
            this.listBoxPopularity.FormattingEnabled = true;
            this.listBoxPopularity.ItemHeight = 15;
            this.listBoxPopularity.Location = new System.Drawing.Point(223, 403);
            this.listBoxPopularity.Name = "listBoxPopularity";
            this.listBoxPopularity.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxPopularity.Size = new System.Drawing.Size(124, 154);
            this.listBoxPopularity.TabIndex = 11;
            this.listBoxPopularity.SelectedIndexChanged += new System.EventHandler(this.listBoxPopularity_SelectedIndexChanged);
            // 
            // listBoxReleaseSong
            // 
            this.listBoxReleaseSong.FormattingEnabled = true;
            this.listBoxReleaseSong.ItemHeight = 15;
            this.listBoxReleaseSong.Location = new System.Drawing.Point(580, 403);
            this.listBoxReleaseSong.Name = "listBoxReleaseSong";
            this.listBoxReleaseSong.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxReleaseSong.Size = new System.Drawing.Size(120, 154);
            this.listBoxReleaseSong.TabIndex = 27;
            this.listBoxReleaseSong.SelectedIndexChanged += new System.EventHandler(this.listBoxReleaseSong_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(580, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 15);
            this.label13.TabIndex = 28;
            this.label13.Text = "Bản phát hành";
            // 
            // txtSeletedCode
            // 
            this.txtSeletedCode.Location = new System.Drawing.Point(796, 624);
            this.txtSeletedCode.Name = "txtSeletedCode";
            this.txtSeletedCode.Size = new System.Drawing.Size(206, 139);
            this.txtSeletedCode.TabIndex = 29;
            this.txtSeletedCode.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(796, 578);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(171, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = "Danh sách mã code được chọn";
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Location = new System.Drawing.Point(796, 34);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(225, 52);
            this.txtSearchCode.TabIndex = 31;
            this.txtSearchCode.Text = "";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1097, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 53);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Search Code";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(796, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 15);
            this.label15.TabIndex = 30;
            this.label15.Text = "Danh sách mã code cần lọc";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1583, 799);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSeletedCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBoxReleaseSong);
            this.Controls.Add(this.listBoxPopularity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTop3);
            this.Controls.Add(this.txtTop2);
            this.Controls.Add(this.txtTop1);
            this.Controls.Add(this.txtTotalSongs);
            this.Controls.Add(this.radioBtnAuto);
            this.Controls.Add(this.radioBtnHand);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listSelectedArtist);
            this.Controls.Add(this.btnDisplayTracklist);
            this.Controls.Add(this.dataGird);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMainFilter);
            this.Controls.Add(this.cbMainFilter);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnGenTrackList);
            this.Controls.Add(this.listBoxYear);
            this.Controls.Add(this.listBoxRegion);
            this.Controls.Add(this.listBoxArtist);
            this.Controls.Add(this.listBoxGenre);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblYear);
            this.Name = "Form1";
            this.Text = "Generate Tracklist";
            ((System.ComponentModel.ISupportInitialize)(this.dataGird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.ListBox listBoxGenre;
        private System.Windows.Forms.ListBox listBoxArtist;
        private System.Windows.Forms.ListBox listBoxRegion;
        private System.Windows.Forms.ListBox listBoxYear;
        private System.Windows.Forms.Button btnGenTrackList;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.ComboBox cbMainFilter;
        private System.Windows.Forms.Label lblMainFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGird;
        private System.Windows.Forms.Button btnDisplayTracklist;
        private System.Windows.Forms.ListBox listSelectedArtist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioBtnHand;
        private System.Windows.Forms.RadioButton radioBtnAuto;
        private System.Windows.Forms.TextBox txtTotalSongs;
        private System.Windows.Forms.TextBox txtTop1;
        private System.Windows.Forms.TextBox txtTop2;
        private System.Windows.Forms.TextBox txtTop3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBoxPopularity;
        private System.Windows.Forms.ListBox listBoxReleaseSong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox txtSeletedCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox txtSearchCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label15;
    }
}

