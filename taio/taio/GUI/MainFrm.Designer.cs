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
            this.algorytmyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrutalAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstAppAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SecondAppAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.¹zaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poka¿Rozwi¹zaniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lab2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.algorytmyToolStripMenuItem,
            this.¹zaniaToolStripMenuItem});
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
            // algorytmyToolStripMenuItem
            // 
            this.algorytmyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrutalAlgorithmToolStripMenuItem,
            this.FirstAppAlgorithmToolStripMenuItem,
            this.SecondAppAlgorithmToolStripMenuItem});
            this.algorytmyToolStripMenuItem.Name = "algorytmyToolStripMenuItem";
            this.algorytmyToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.algorytmyToolStripMenuItem.Text = "Algorytmy";
            // 
            // BrutalAlgorithmToolStripMenuItem
            // 
            this.BrutalAlgorithmToolStripMenuItem.Name = "BrutalAlgorithmToolStripMenuItem";
            this.BrutalAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.BrutalAlgorithmToolStripMenuItem.Text = "Algorytm brutalny";
            this.BrutalAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.BrutalAlgorithmToolStripMenuItem_Click);
            // 
            // FirstAppAlgorithmToolStripMenuItem
            // 
            this.FirstAppAlgorithmToolStripMenuItem.Name = "FirstAppAlgorithmToolStripMenuItem";
            this.FirstAppAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.FirstAppAlgorithmToolStripMenuItem.Text = "Pierwszy";
            this.FirstAppAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.FirstAppAlgorithmToolStripMenuItem_Click);
            // 
            // SecondAppAlgorithmToolStripMenuItem
            // 
            this.SecondAppAlgorithmToolStripMenuItem.Name = "SecondAppAlgorithmToolStripMenuItem";
            this.SecondAppAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.SecondAppAlgorithmToolStripMenuItem.Text = "Drugi";
            this.SecondAppAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.SecondAppAlgorithmToolStripMenuItem_Click_1);
            // 
            // ¹zaniaToolStripMenuItem
            // 
            this.¹zaniaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poka¿Rozwi¹zaniaToolStripMenuItem});
            this.¹zaniaToolStripMenuItem.Name = "¹zaniaToolStripMenuItem";
            this.¹zaniaToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.¹zaniaToolStripMenuItem.Text = "Rozwi¹zania";
            // 
            // poka¿Rozwi¹zaniaToolStripMenuItem
            // 
            this.poka¿Rozwi¹zaniaToolStripMenuItem.Name = "poka¿Rozwi¹zaniaToolStripMenuItem";
            this.poka¿Rozwi¹zaniaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.poka¿Rozwi¹zaniaToolStripMenuItem.Text = "Poka¿ rozwi¹zania";
            this.poka¿Rozwi¹zaniaToolStripMenuItem.Click += new System.EventHandler(this.poka¿Rozwi¹zaniaToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lab2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(472, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Bezczynny";
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem algorytmyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrutalAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstAppAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SecondAppAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ¹zaniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poka¿Rozwi¹zaniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszDaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem losujDaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujDaneToolStripMenuItem;


        private System.Windows.Forms.ToolStripStatusLabel lab2;

        public System.Windows.Forms.ToolStripStatusLabel Lab2
        {
            get { return lab2; }
            set { lab2 = value; }
        }
    }
}

