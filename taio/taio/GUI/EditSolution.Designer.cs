namespace taio.GUI
{
    partial class EditSolution
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragDrop);
            this.splitContainer1.Panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel1_DragEnter);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.DragOver += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragOver);
            this.splitContainer1.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragDrop);
            this.splitContainer1.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragEnter);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(792, 345);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // EditSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 437);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "EditSolution";
            this.Text = "Edycja rozwi¹zania";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditSolution_FormClosed);

            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditSolution_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditSolution_KeyDown);
            this.Load += new System.EventHandler(this.EditSolution_Load);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer splitContainer1;

    }
}