namespace taio.GUI
{
    partial class tab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labTime = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.labAlgorytm = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.labTime);
            this.splitContainer1.Panel1.Controls.Add(this.btnStop);
            this.splitContainer1.Panel1.Controls.Add(this.labAlgorytm);
            this.splitContainer1.Panel1.Controls.Add(this.btnStart);
            this.splitContainer1.Panel1.Click += new System.EventHandler(this.splitContainer1_Panel1_Click);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(457, 295);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 0;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(3, 30);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(33, 13);
            this.labTime.TabIndex = 0;
            this.labTime.Text = "Czas:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(140, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labAlgorytm
            // 
            this.labAlgorytm.AutoSize = true;
            this.labAlgorytm.Location = new System.Drawing.Point(3, 5);
            this.labAlgorytm.Name = "labAlgorytm";
            this.labAlgorytm.Size = new System.Drawing.Size(50, 13);
            this.labAlgorytm.TabIndex = 0;
            this.labAlgorytm.Text = "Algorytm:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(59, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "tab";
            this.Size = new System.Drawing.Size(457, 295);
            this.Load += new System.EventHandler(this.tab_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnStart;

        public System.Windows.Forms.Button BtnStart
        {
            get { return btnStart; }
            set { btnStart = value; }
        }
        private System.Windows.Forms.Label labAlgorytm;

        public System.Windows.Forms.Label LabAlgorytm
        {
            get { return labAlgorytm; }
            set { labAlgorytm = value; }
        }
        private System.Windows.Forms.Button btnStop;

        public System.Windows.Forms.Button BtnStop
        {
            get { return btnStop; }
            set { btnStop = value; }
        }
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Timer timer;

        public System.Windows.Forms.Label LabTime
        {
            get { return labTime; }
            set { labTime = value; }
        }

    }
}
