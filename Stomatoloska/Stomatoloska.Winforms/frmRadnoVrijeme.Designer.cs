﻿namespace Stomatoloska
{
    partial class frmRadnoVrijeme
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radni_dan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocetak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kraj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radni_dan,
            this.pocetak,
            this.kraj});
            this.dataGridView1.Location = new System.Drawing.Point(30, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(573, 317);
            this.dataGridView1.TabIndex = 1;
            // 
            // radni_dan
            // 
            this.radni_dan.HeaderText = "Radni dan";
            this.radni_dan.Name = "radni_dan";
            // 
            // pocetak
            // 
            this.pocetak.HeaderText = "Početak";
            this.pocetak.Name = "pocetak";
            // 
            // kraj
            // 
            this.kraj.HeaderText = "Kraj";
            this.kraj.Name = "kraj";
            // 
            // frmRadnoVrijeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 1045);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmRadnoVrijeme";
            this.Text = "frmRadnoVrijeme";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn radni_dan;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetak;
        private System.Windows.Forms.DataGridViewTextBoxColumn kraj;
    }
}