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
            this.SuspendLayout();
            // 
            // tabSolutons
            // 
            this.tabSolutons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSolutons.Location = new System.Drawing.Point(12, 12);
            this.tabSolutons.Name = "tabSolutons";
            this.tabSolutons.SelectedIndex = 0;
            this.tabSolutons.Size = new System.Drawing.Size(568, 542);
            this.tabSolutons.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabSolutons.TabIndex = 0;
            this.tabSolutons.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tab_Changed);
            this.tabSolutons.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Tab_Added);
            // 
            // SolutionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 566);
            this.Controls.Add(this.tabSolutons);
            this.Name = "SolutionsFrm";
            this.Text = "Rozwi¹zania";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SolutionsFrm_FormClosed);
            this.Load += new System.EventHandler(this.SolutionsFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSolutons;
    }
}