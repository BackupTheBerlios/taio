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
            this.labSquare = new System.Windows.Forms.Label();
            this.labRatio = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.labWidth = new System.Windows.Forms.Label();
            this.labHeight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
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
            // labSquare
            // 
            this.labSquare.AutoSize = true;
            this.labSquare.Location = new System.Drawing.Point(12, 9);
            this.labSquare.Name = "labSquare";
            this.labSquare.Size = new System.Drawing.Size(31, 13);
            this.labSquare.TabIndex = 1;
            this.labSquare.Text = "Pole:";
            // 
            // labRatio
            // 
            this.labRatio.AutoSize = true;
            this.labRatio.Location = new System.Drawing.Point(99, 9);
            this.labRatio.Name = "labRatio";
            this.labRatio.Size = new System.Drawing.Size(118, 13);
            this.labRatio.TabIndex = 2;
            this.labRatio.Text = "Szerokoœæ/Wysokoœæ: ";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(729, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Zachowaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labWidth
            // 
            this.labWidth.AutoSize = true;
            this.labWidth.Location = new System.Drawing.Point(12, 32);
            this.labWidth.Name = "labWidth";
            this.labWidth.Size = new System.Drawing.Size(60, 13);
            this.labWidth.TabIndex = 4;
            this.labWidth.Text = "Szerokoœæ:";
            // 
            // labHeight
            // 
            this.labHeight.AutoSize = true;
            this.labHeight.Location = new System.Drawing.Point(12, 55);
            this.labHeight.Name = "labHeight";
            this.labHeight.Size = new System.Drawing.Size(60, 13);
            this.labHeight.TabIndex = 5;
            this.labHeight.Text = "Wysokoœæ:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(655, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nazwa:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(704, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 7;
            // 
            // EditSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 437);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labHeight);
            this.Controls.Add(this.labWidth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labRatio);
            this.Controls.Add(this.labSquare);
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
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labSquare;
        private System.Windows.Forms.Label labRatio;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labWidth;
        private System.Windows.Forms.Label labHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;

    }
}