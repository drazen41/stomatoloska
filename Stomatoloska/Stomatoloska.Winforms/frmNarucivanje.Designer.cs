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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange11 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange12 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange13 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange14 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange15 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.naručivanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radnoVrijemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledNarudžbiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosNarudžbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledRadnogVremenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.monthView1.Location = new System.Drawing.Point(42, 292);
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.SelectionMode = System.Windows.Forms.Calendar.MonthView.MonthViewSelection.WorkWeek;
            this.monthView1.Size = new System.Drawing.Size(231, 171);
            this.monthView1.TabIndex = 0;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            // 
            // calendar1
            // 
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange11.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange11.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange11.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange12.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange12.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange12.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange13.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange13.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange13.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange14.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange14.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange14.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange15.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange15.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange15.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange11,
        calendarHighlightRange12,
        calendarHighlightRange13,
        calendarHighlightRange14,
        calendarHighlightRange15};
            this.calendar1.Location = new System.Drawing.Point(330, 292);
            this.calendar1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.calendar1.MinimumSize = new System.Drawing.Size(100, 100);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(884, 734);
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
            this.radnoVrijemeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1350, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // naručivanjeToolStripMenuItem
            // 
            this.naručivanjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledNarudžbiToolStripMenuItem,
            this.unosNarudžbeToolStripMenuItem});
            this.naručivanjeToolStripMenuItem.Name = "naručivanjeToolStripMenuItem";
            this.naručivanjeToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.naručivanjeToolStripMenuItem.Text = "Naručivanje";
            // 
            // radnoVrijemeToolStripMenuItem
            // 
            this.radnoVrijemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledRadnogVremenaToolStripMenuItem});
            this.radnoVrijemeToolStripMenuItem.Name = "radnoVrijemeToolStripMenuItem";
            this.radnoVrijemeToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.radnoVrijemeToolStripMenuItem.Text = "Radno vrijeme";
            // 
            // pregledNarudžbiToolStripMenuItem
            // 
            this.pregledNarudžbiToolStripMenuItem.Name = "pregledNarudžbiToolStripMenuItem";
            this.pregledNarudžbiToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.pregledNarudžbiToolStripMenuItem.Text = "Pregled narudžbi";
            this.pregledNarudžbiToolStripMenuItem.Click += new System.EventHandler(this.pregledNarudžbiToolStripMenuItem_Click);
            // 
            // unosNarudžbeToolStripMenuItem
            // 
            this.unosNarudžbeToolStripMenuItem.Name = "unosNarudžbeToolStripMenuItem";
            this.unosNarudžbeToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.unosNarudžbeToolStripMenuItem.Text = "Unos narudžbe";
            // 
            // pregledRadnogVremenaToolStripMenuItem
            // 
            this.pregledRadnogVremenaToolStripMenuItem.Name = "pregledRadnogVremenaToolStripMenuItem";
            this.pregledRadnogVremenaToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.pregledRadnogVremenaToolStripMenuItem.Text = "Pregled radnog vremena";
            this.pregledRadnogVremenaToolStripMenuItem.Click += new System.EventHandler(this.pregledRadnogVremenaToolStripMenuItem_Click);
            // 
            // frmNarucivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 1112);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.monthView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

