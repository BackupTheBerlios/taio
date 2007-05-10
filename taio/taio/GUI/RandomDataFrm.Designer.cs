namespace taio.GUI
{
    partial class RandomDataFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.datRectangles = new System.Windows.Forms.DataGridView();
            this.colNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datRectangles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liczba prostok¹tów:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQuantity.Location = new System.Drawing.Point(120, 6);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(63, 20);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "0";
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 36);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(86, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Max. Szerokoœæ:";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtWidth.Location = new System.Drawing.Point(120, 36);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(63, 20);
            this.txtWidth.TabIndex = 4;
            this.txtWidth.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max. Wysokoœæ:";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHeight.Location = new System.Drawing.Point(120, 62);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(63, 20);
            this.txtHeight.TabIndex = 6;
            this.txtHeight.Text = "0";
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDraw.Location = new System.Drawing.Point(12, 392);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 7;
            this.btnDraw.Text = "Losuj";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(93, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Zachowaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // datRectangles
            // 
            this.datRectangles.AllowUserToAddRows = false;
            this.datRectangles.AllowUserToDeleteRows = false;
            this.datRectangles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.datRectangles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.datRectangles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datRectangles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datRectangles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNr,
            this.colWidth,
            this.colHeight});
            this.datRectangles.Location = new System.Drawing.Point(12, 105);
            this.datRectangles.Name = "datRectangles";
            this.datRectangles.Size = new System.Drawing.Size(216, 281);
            this.datRectangles.TabIndex = 9;
            this.datRectangles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datRectangles_CellValueChanged);
            // 
            // colNr
            // 
            this.colNr.HeaderText = "Nr.";
            this.colNr.Name = "colNr";
            this.colNr.ReadOnly = true;
            this.colNr.Width = 32;
            // 
            // colWidth
            // 
            this.colWidth.HeaderText = "Szerokoœæ";
            this.colWidth.Name = "colWidth";
            this.colWidth.Width = 62;
            // 
            // colHeight
            // 
            this.colHeight.HeaderText = "Wysokoœæ";
            this.colHeight.Name = "colHeight";
            this.colHeight.Width = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wylosowane prostok¹ty(kliknij w celu edycji):";
            // 
            // RandomDataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(239, 427);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datRectangles);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label1);
            this.Name = "RandomDataFrm";
            this.Text = "Losowanie danych";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RandomData_FormClosed);
            this.Load += new System.EventHandler(this.RandomData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datRectangles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView datRectangles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.Label label3;
    }
}