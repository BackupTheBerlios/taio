namespace taio.GUI
{
    partial class EditDataFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datRectangles = new System.Windows.Forms.DataGridView();
            this.colNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datRectangles)).BeginInit();
            this.SuspendLayout();
            // 
            // datRectangles
            // 
            this.datRectangles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.datRectangles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datRectangles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNr,
            this.colWidth,
            this.colHeight,
            this.colDelete});
            this.datRectangles.Location = new System.Drawing.Point(-2, -1);
            this.datRectangles.Name = "datRectangles";
            this.datRectangles.Size = new System.Drawing.Size(247, 371);
            this.datRectangles.TabIndex = 0;
            this.datRectangles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datRectangles_CellValueChanged);
            this.datRectangles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datRectangles_CellContentClick);
            // 
            // colNr
            // 
            this.colNr.HeaderText = "Nr.";
            this.colNr.Name = "colNr";
            this.colNr.ReadOnly = true;
            this.colNr.Width = 30;
            // 
            // colWidth
            // 
            this.colWidth.HeaderText = "Szerokoœæ";
            this.colWidth.Name = "colWidth";
            this.colWidth.Width = 60;
            // 
            // colHeight
            // 
            this.colHeight.HeaderText = "Wysokoœæ";
            this.colHeight.Name = "colHeight";
            this.colHeight.Width = 60;
            // 
            // colDelete
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDelete.HeaderText = "Usuñ";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "Usuñ";
            this.colDelete.ToolTipText = "Usuñ";
            this.colDelete.Width = 37;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(159, 376);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Zachowaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 377);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 22);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nowy";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // EditDataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(246, 411);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.datRectangles);
            this.Name = "EditDataFrm";
            this.Text = "Edycja prostok¹tów";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditDataFrm_FormClosed);
            this.Load += new System.EventHandler(this.EditDataFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datRectangles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datRectangles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.Button btnNew;
    }
}