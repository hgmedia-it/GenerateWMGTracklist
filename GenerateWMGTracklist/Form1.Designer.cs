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
            this.txtViewLastRate = new System.Windows.Forms.TextBox();
            this.txtDifferenceRate = new System.Windows.Forms.TextBox();
            this.txtGenreRate = new System.Windows.Forms.TextBox();
            this.txtRegionRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGird = new System.Windows.Forms.DataGridView();
            this.btnDisplayTracklist = new System.Windows.Forms.Button();
            this.listSelectedArtist = new System.Windows.Forms.ListBox();
            this.listSelectedGenre = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radioBtnHand = new System.Windows.Forms.RadioButton();
            this.radioBtnAuto = new System.Windows.Forms.RadioButton();
            this.txtSelectedRows = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGird)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(639, 366);
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
            this.lblRegion.Location = new System.Drawing.Point(638, 71);
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
            this.listBoxGenre.MultiColumn = true;
            this.listBoxGenre.Name = "listBoxGenre";
            this.listBoxGenre.ScrollAlwaysVisible = true;
            this.listBoxGenre.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxGenre.Size = new System.Drawing.Size(338, 244);
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
            this.listBoxRegion.Location = new System.Drawing.Point(639, 104);
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
            this.listBoxYear.Location = new System.Drawing.Point(639, 403);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxYear.Size = new System.Drawing.Size(124, 139);
            this.listBoxYear.TabIndex = 11;
            this.listBoxYear.SelectedIndexChanged += new System.EventHandler(this.listBoxYear_SelectedIndexChanged);
            // 
            // btnGenTrackList
            // 
            this.btnGenTrackList.Location = new System.Drawing.Point(689, 665);
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
            this.lblWarning.Location = new System.Drawing.Point(980, 684);
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
            // txtViewLastRate
            // 
            this.txtViewLastRate.Location = new System.Drawing.Point(399, 34);
            this.txtViewLastRate.Name = "txtViewLastRate";
            this.txtViewLastRate.Size = new System.Drawing.Size(83, 23);
            this.txtViewLastRate.TabIndex = 16;
            // 
            // txtDifferenceRate
            // 
            this.txtDifferenceRate.Location = new System.Drawing.Point(522, 34);
            this.txtDifferenceRate.Name = "txtDifferenceRate";
            this.txtDifferenceRate.Size = new System.Drawing.Size(85, 23);
            this.txtDifferenceRate.TabIndex = 16;
            // 
            // txtGenreRate
            // 
            this.txtGenreRate.Location = new System.Drawing.Point(652, 34);
            this.txtGenreRate.Name = "txtGenreRate";
            this.txtGenreRate.Size = new System.Drawing.Size(85, 23);
            this.txtGenreRate.TabIndex = 16;
            // 
            // txtRegionRate
            // 
            this.txtRegionRate.Location = new System.Drawing.Point(781, 34);
            this.txtRegionRate.Name = "txtRegionRate";
            this.txtRegionRate.Size = new System.Drawing.Size(77, 23);
            this.txtRegionRate.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "View mới nhất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Độ chênh view";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Thể loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Thị trường";
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
            this.btnReset.Location = new System.Drawing.Point(536, 665);
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
            this.dataGird.Location = new System.Drawing.Point(781, 106);
            this.dataGird.Name = "dataGird";
            this.dataGird.Size = new System.Drawing.Size(626, 436);
            this.dataGird.TabIndex = 19;
            this.dataGird.Text = "dataGridView1";
            this.dataGird.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGird_RowStateChanged);
            // 
            // btnDisplayTracklist
            // 
            this.btnDisplayTracklist.Location = new System.Drawing.Point(372, 665);
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
            // listSelectedGenre
            // 
            this.listSelectedGenre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.listSelectedGenre.FormattingEnabled = true;
            this.listSelectedGenre.ItemHeight = 15;
            this.listSelectedGenre.Location = new System.Drawing.Point(399, 401);
            this.listSelectedGenre.Name = "listSelectedGenre";
            this.listSelectedGenre.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listSelectedGenre.Size = new System.Drawing.Size(120, 139);
            this.listSelectedGenre.TabIndex = 21;
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
            this.label7.Location = new System.Drawing.Point(399, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Thể loại được chọn";
            // 
            // radioBtnHand
            // 
            this.radioBtnHand.AutoSize = true;
            this.radioBtnHand.Location = new System.Drawing.Point(870, 707);
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
            this.radioBtnAuto.Location = new System.Drawing.Point(870, 655);
            this.radioBtnAuto.Name = "radioBtnAuto";
            this.radioBtnAuto.Size = new System.Drawing.Size(69, 19);
            this.radioBtnAuto.TabIndex = 23;
            this.radioBtnAuto.TabStop = true;
            this.radioBtnAuto.Text = "Tự động";
            this.radioBtnAuto.UseVisualStyleBackColor = true;
            this.radioBtnAuto.CheckedChanged += new System.EventHandler(this.radioBtnAuto_CheckedChanged);
            // 
            // txtSelectedRows
            // 
            this.txtSelectedRows.Location = new System.Drawing.Point(921, 564);
            this.txtSelectedRows.Name = "txtSelectedRows";
            this.txtSelectedRows.Size = new System.Drawing.Size(77, 23);
            this.txtSelectedRows.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(781, 567);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số bài được chọn: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 744);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSelectedRows);
            this.Controls.Add(this.radioBtnAuto);
            this.Controls.Add(this.radioBtnHand);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listSelectedGenre);
            this.Controls.Add(this.listSelectedArtist);
            this.Controls.Add(this.btnDisplayTracklist);
            this.Controls.Add(this.dataGird);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRegionRate);
            this.Controls.Add(this.txtGenreRate);
            this.Controls.Add(this.txtDifferenceRate);
            this.Controls.Add(this.txtViewLastRate);
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
            this.Text = "Form1";
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
        private System.Windows.Forms.TextBox txtViewLastRate;
        private System.Windows.Forms.TextBox txtDifferenceRate;
        private System.Windows.Forms.TextBox txtGenreRate;
        private System.Windows.Forms.TextBox txtRegionRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGird;
        private System.Windows.Forms.Button btnDisplayTracklist;
        private System.Windows.Forms.ListBox listSelectedArtist;
        private System.Windows.Forms.ListBox listSelectedGenre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioBtnHand;
        private System.Windows.Forms.RadioButton radioBtnAuto;
        private System.Windows.Forms.TextBox txtSelectedRows;
        private System.Windows.Forms.Label label8;
    }
}

