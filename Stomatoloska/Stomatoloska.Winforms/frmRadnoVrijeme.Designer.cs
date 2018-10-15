namespace Stomatoloska
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.radni_dan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radno_vrijeme_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.od_dana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocetak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kraj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.radni_dan,
            this.radno_vrijeme_id,
            this.od_dana,
            this.pocetak,
            this.kraj});
            this.dataGridView2.Location = new System.Drawing.Point(28, 149);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(439, 150);
            this.dataGridView2.TabIndex = 0;
            // 
            // radni_dan
            // 
            this.radni_dan.HeaderText = "Radni dan";
            this.radni_dan.Name = "radni_dan";
            // 
            // radno_vrijeme_id
            // 
            this.radno_vrijeme_id.HeaderText = "radno_vrijeme_id";
            this.radno_vrijeme_id.Name = "radno_vrijeme_id";
            this.radno_vrijeme_id.Visible = false;
            // 
            // od_dana
            // 
            this.od_dana.HeaderText = "Od dana";
            this.od_dana.Name = "od_dana";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 849);
            this.Controls.Add(this.dataGridView2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmRadnoVrijeme";
            this.Text = "frmRadnoVrijeme";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn radni_dan;
        private System.Windows.Forms.DataGridViewTextBoxColumn radno_vrijeme_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn od_dana;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetak;
        private System.Windows.Forms.DataGridViewTextBoxColumn kraj;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}