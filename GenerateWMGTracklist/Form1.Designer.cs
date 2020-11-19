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
            this.lblGenre.Location = new System.Drawing.Point(399, 71);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(48, 15);
            this.lblGenre.TabIndex = 5;
            this.lblGenre.Text = "Thể loại";
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(29, 372);
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
            this.listBoxGenre.Location = new System.Drawing.Point(399, 104);
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
            this.listBoxArtist.Size = new System.Drawing.Size(280, 244);
            this.listBoxArtist.TabIndex = 9;
            this.listBoxArtist.SelectedIndexChanged += new System.EventHandler(this.listBoxArtist_SelectedIndexChanged);
            // 
            // listBoxRegion
            // 
            this.listBoxRegion.FormattingEnabled = true;
            this.listBoxRegion.ItemHeight = 15;
            this.listBoxRegion.Location = new System.Drawing.Point(29, 401);
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
            this.listBoxYear.Location = new System.Drawing.Point(399, 401);
            this.listBoxYear.Name = "listBoxYear";
            this.listBoxYear.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxYear.Size = new System.Drawing.Size(124, 139);
            this.listBoxYear.TabIndex = 11;
            this.listBoxYear.SelectedIndexChanged += new System.EventHandler(this.listBoxYear_SelectedIndexChanged);
            // 
            // btnGenTrackList
            // 
            this.btnGenTrackList.Location = new System.Drawing.Point(27, 584);
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
            this.lblWarning.Location = new System.Drawing.Point(221, 603);
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
            this.btnReset.Location = new System.Drawing.Point(631, 584);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 53);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 713);
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
    }
}

