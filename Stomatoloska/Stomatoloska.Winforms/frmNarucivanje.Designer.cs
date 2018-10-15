namespace Stomatoloska
{
    partial class frmNarucivanje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.naručivanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledNarudžbiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosNarudžbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radnoVrijemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledRadnogVremenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthView1
            // 
            this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(32, 237);
            this.monthView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.WorkWeek;
            this.monthView1.Size = new System.Drawing.Size(173, 139);
            this.monthView1.TabIndex = 0;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            // 
            // calendar1
            // 
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(248, 237);
            this.calendar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.calendar1.MaximumSize = new System.Drawing.Size(750, 812);
            this.calendar1.MinimumSize = new System.Drawing.Size(75, 81);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(663, 596);
            this.calendar1.TabIndex = 1;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemTextEditing += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemTextEditing);
            this.calendar1.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.naručivanjeToolStripMenuItem,
            this.radnoVrijemeToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1012, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // naručivanjeToolStripMenuItem
            // 
            this.naručivanjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledNarudžbiToolStripMenuItem,
            this.unosNarudžbeToolStripMenuItem});
            this.naručivanjeToolStripMenuItem.Name = "naručivanjeToolStripMenuItem";
            this.naručivanjeToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.naručivanjeToolStripMenuItem.Text = "Naručivanje";
            // 
            // pregledNarudžbiToolStripMenuItem
            // 
            this.pregledNarudžbiToolStripMenuItem.Name = "pregledNarudžbiToolStripMenuItem";
            this.pregledNarudžbiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pregledNarudžbiToolStripMenuItem.Text = "Pregled narudžbi";
            this.pregledNarudžbiToolStripMenuItem.Click += new System.EventHandler(this.pregledNarudžbiToolStripMenuItem_Click);
            // 
            // unosNarudžbeToolStripMenuItem
            // 
            this.unosNarudžbeToolStripMenuItem.Name = "unosNarudžbeToolStripMenuItem";
            this.unosNarudžbeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unosNarudžbeToolStripMenuItem.Text = "Unos narudžbe";
            // 
            // radnoVrijemeToolStripMenuItem
            // 
            this.radnoVrijemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledRadnogVremenaToolStripMenuItem});
            this.radnoVrijemeToolStripMenuItem.Name = "radnoVrijemeToolStripMenuItem";
            this.radnoVrijemeToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.radnoVrijemeToolStripMenuItem.Text = "Radno vrijeme";
            // 
            // pregledRadnogVremenaToolStripMenuItem
            // 
            this.pregledRadnogVremenaToolStripMenuItem.Name = "pregledRadnogVremenaToolStripMenuItem";
            this.pregledRadnogVremenaToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pregledRadnogVremenaToolStripMenuItem.Text = "Pregled radnog vremena";
            this.pregledRadnogVremenaToolStripMenuItem.Click += new System.EventHandler(this.pregledRadnogVremenaToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test1ToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.testToolStripMenuItem.Text = "test";
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.test1ToolStripMenuItem.Text = "test1";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.test1ToolStripMenuItem_Click);
            // 
            // frmNarucivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 862);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.monthView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmNarucivanje";
            this.Text = "Naručivanje pacijenata";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Calendar.MonthView monthView1;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem naručivanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledNarudžbiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosNarudžbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radnoVrijemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledRadnogVremenaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
    }
}

