namespace taio.GUI
{
    partial class SolutionsFrm
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
            this.tabSolutons = new System.Windows.Forms.TabControl();
            this.trFactor = new System.Windows.Forms.TrackBar();
            this.chAuto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chColor = new System.Windows.Forms.CheckBox();
            this.chNumbers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSolutons
            // 
            this.tabSolutons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSolutons.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabSolutons.Location = new System.Drawing.Point(12, 55);
            this.tabSolutons.Name = "tabSolutons";
            this.tabSolutons.SelectedIndex = 0;
            this.tabSolutons.Size = new System.Drawing.Size(568, 499);
            this.tabSolutons.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabSolutons.TabIndex = 0;
            this.tabSolutons.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tab_Changed);
            this.tabSolutons.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Tab_Added);
            // 
            // trFactor
            // 
            this.trFactor.Location = new System.Drawing.Point(83, 4);
            this.trFactor.Maximum = 100000;
            this.trFactor.Minimum = 1;
            this.trFactor.Name = "trFactor";
            this.trFactor.Size = new System.Drawing.Size(214, 45);
            this.trFactor.TabIndex = 1;
            this.trFactor.Value = 1;
            this.trFactor.Scroll += new System.EventHandler(this.trFactor_Scroll);
            // 
            // chAuto
            // 
            this.chAuto.AutoSize = true;
            this.chAuto.Checked = true;
            this.chAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAuto.Location = new System.Drawing.Point(303, 12);
            this.chAuto.Name = "chAuto";
            this.chAuto.Size = new System.Drawing.Size(48, 17);
            this.chAuto.TabIndex = 2;
            this.chAuto.Text = "Auto";
            this.chAuto.UseVisualStyleBackColor = true;
            this.chAuto.CheckedChanged += new System.EventHandler(this.chAuto_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Skalowanie:";
            // 
            // chColor
            // 
            this.chColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chColor.AutoSize = true;
            this.chColor.Location = new System.Drawing.Point(525, 12);
            this.chColor.Name = "chColor";
            this.chColor.Size = new System.Drawing.Size(55, 17);
            this.chColor.TabIndex = 4;
            this.chColor.Text = "Kolory";
            this.chColor.UseVisualStyleBackColor = true;
            this.chColor.CheckedChanged += new System.EventHandler(this.chColor_CheckedChanged);
            // 
            // chNumbers
            // 
            this.chNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chNumbers.AutoSize = true;
            this.chNumbers.Checked = true;
            this.chNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chNumbers.Location = new System.Drawing.Point(457, 12);
            this.chNumbers.Name = "chNumbers";
            this.chNumbers.Size = new System.Drawing.Size(62, 17);
            this.chNumbers.TabIndex = 5;
            this.chNumbers.Text = "Numery";
            this.chNumbers.UseVisualStyleBackColor = true;
            this.chNumbers.CheckedChanged += new System.EventHandler(this.chNumbers_CheckedChanged);
            // 
            // SolutionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 566);
            this.Controls.Add(this.chNumbers);
            this.Controls.Add(this.chColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chAuto);
            this.Controls.Add(this.trFactor);
            this.Controls.Add(this.tabSolutons);
            this.Name = "SolutionsFrm";
            this.Text = "Rozwi¹zania";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SolutionsFrm_FormClosed);
            this.Load += new System.EventHandler(this.SolutionsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSolutons;
        private System.Windows.Forms.TrackBar trFactor;
        private System.Windows.Forms.CheckBox chAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chColor;
        private System.Windows.Forms.CheckBox chNumbers;

        public System.Windows.Forms.CheckBox ChNumbers
        {
            get { return chNumbers; }
            set { chNumbers = value; }
        }

        public System.Windows.Forms.CheckBox ChColor
        {
            get { return chColor; }
            set { chColor = value; }
        }
    }
}