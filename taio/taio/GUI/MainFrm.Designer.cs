namespace taio
{
    partial class MainFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajDaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszDaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujDaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.losujDaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�zaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poka�Rozwi�zaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaRozwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lab2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.�zaniaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytajDaneToolStripMenuItem,
            this.zapiszDaneToolStripMenuItem,
            this.edytujDaneToolStripMenuItem,
            this.losujDaneToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.plikToolStripMenuItem.Text = "Dane";
            // 
            // wczytajDaneToolStripMenuItem
            // 
            this.wczytajDaneToolStripMenuItem.Name = "wczytajDaneToolStripMenuItem";
            this.wczytajDaneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.wczytajDaneToolStripMenuItem.Text = "Wczytaj dane";
            this.wczytajDaneToolStripMenuItem.Click += new System.EventHandler(this.wczytajDaneToolStripMenuItem_Click);
            // 
            // zapiszDaneToolStripMenuItem
            // 
            this.zapiszDaneToolStripMenuItem.Name = "zapiszDaneToolStripMenuItem";
            this.zapiszDaneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.zapiszDaneToolStripMenuItem.Text = "Zapisz dane";
            this.zapiszDaneToolStripMenuItem.Click += new System.EventHandler(this.zapiszDaneToolStripMenuItem_Click);
            // 
            // edytujDaneToolStripMenuItem
            // 
            this.edytujDaneToolStripMenuItem.Name = "edytujDaneToolStripMenuItem";
            this.edytujDaneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.edytujDaneToolStripMenuItem.Text = "Edytuj dane";
            this.edytujDaneToolStripMenuItem.Click += new System.EventHandler(this.edytujDaneToolStripMenuItem_Click);
            // 
            // losujDaneToolStripMenuItem
            // 
            this.losujDaneToolStripMenuItem.Name = "losujDaneToolStripMenuItem";
            this.losujDaneToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.losujDaneToolStripMenuItem.Text = "Losuj dane";
            this.losujDaneToolStripMenuItem.Click += new System.EventHandler(this.losujDaneToolStripMenuItem_Click);
            // 
            // �zaniaToolStripMenuItem
            // 
            this.�zaniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poka�Rozwi�zaniaToolStripMenuItem,
            this.edycjaRozwToolStripMenuItem});
            this.�zaniaToolStripMenuItem.Name = "�zaniaToolStripMenuItem";
            this.�zaniaToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.�zaniaToolStripMenuItem.Text = "Rozwi�zania";
            // 
            // poka�Rozwi�zaniaToolStripMenuItem
            // 
            this.poka�Rozwi�zaniaToolStripMenuItem.Name = "poka�Rozwi�zaniaToolStripMenuItem";
            this.poka�Rozwi�zaniaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.poka�Rozwi�zaniaToolStripMenuItem.Text = "Poka� rozwi�zania";
            this.poka�Rozwi�zaniaToolStripMenuItem.Click += new System.EventHandler(this.poka�Rozwi�zaniaToolStripMenuItem_Click);
            // 
            // edycjaRozwToolStripMenuItem
            // 
            this.edycjaRozwToolStripMenuItem.Name = "edycjaRozwToolStripMenuItem";
            this.edycjaRozwToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.edycjaRozwToolStripMenuItem.Text = "Edycja rozwi�zania";
            this.edycjaRozwToolStripMenuItem.Click += new System.EventHandler(this.edycjaRozwToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lab2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(472, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lab2
            // 
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(0, 17);
            this.lab2.Visible = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 356);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.Activated += new System.EventHandler(this.MainFrm_Activated);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajDaneToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;

        public System.Windows.Forms.StatusStrip StatusStrip1
        {
            get { return statusStrip1; }
            set { statusStrip1 = value; }
        }
        private System.Windows.Forms.ToolStripMenuItem �zaniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poka�Rozwi�zaniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszDaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem losujDaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujDaneToolStripMenuItem;


        private System.Windows.Forms.ToolStripStatusLabel lab2;
        private System.Windows.Forms.ToolStripMenuItem edycjaRozwToolStripMenuItem;

        public System.Windows.Forms.ToolStripStatusLabel Lab2
        {
            get { return lab2; }
            set { lab2 = value; }
        }
    }
}

