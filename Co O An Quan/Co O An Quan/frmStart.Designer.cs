
namespace Co_O_An_Quan
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.btStart = new System.Windows.Forms.Button();
            this.btThongTin = new System.Windows.Forms.Button();
            this.picNen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picNen)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btStart.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btStart, "btStart");
            this.btStart.ForeColor = System.Drawing.Color.Red;
            this.btStart.Name = "btStart";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btThongTin
            // 
            this.btThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btThongTin.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.btThongTin, "btThongTin");
            this.btThongTin.ForeColor = System.Drawing.Color.Red;
            this.btThongTin.Name = "btThongTin";
            this.btThongTin.UseVisualStyleBackColor = false;
            this.btThongTin.Click += new System.EventHandler(this.btThongTin_Click);
            // 
            // picNen
            // 
            this.picNen.Image = global::Co_O_An_Quan.Properties.Resources.Cờ_Ô_Ăn_Quan;
            resources.ApplyResources(this.picNen, "picNen");
            this.picNen.Name = "picNen";
            this.picNen.TabStop = false;
            // 
            // frmStart
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btThongTin);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.picNen);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmStart";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.picNen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btThongTin;
        private System.Windows.Forms.PictureBox picNen;
    }
}