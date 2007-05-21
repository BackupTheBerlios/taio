using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace taio.GUI
{
    public partial class rectangle : UserControl
    {
        private int index, originalWidth, originalHeight, oldUly;

        public int OldUly
        {
            get { return oldUly; }
            set { oldUly = value; }
        }
        internal Color color;

        public int OriginalHeight
        {
            get { return originalHeight; }
            set { originalHeight = value; }
        }

        public int OriginalWidth
        {
            get { return originalWidth; }
            set { originalWidth = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        byte owner;

        public byte Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        GUI.EditSolution editSolution;
        
        public rectangle(int index,int width, int height,byte owner,GUI.EditSolution editSolution)
        {
            this.index = index;
            this.originalWidth = width;
            this.originalHeight = height;
            this.owner = owner;
            this.editSolution = editSolution;
            InitializeComponent();
        }

        private void rectangle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int min = this.Height;
            
            if (this.Height > this.Width)
                min = this.Width;
            float em = (float)(0.5f * min);

            if (em > 10f)
                em = 10f;
            if (em < 0.1f)
                em = 0.1f;

            Font f = new Font(FontFamily.GenericSansSerif, em);
            if(owner ==2)
            g.DrawString(index.ToString(), f, Brushes.Black, (float)(this.Width / 2), (float)(this.Height / 2));
            ////System.Drawing.Rectangle r = new Rectangle(0,0,this.Width,this.Height);
            ////g.DrawRectangle(Pens.Yellow,r);
        }

        private void rectangle_MouseDown(object sender, MouseEventArgs e)
        {
            DragDropEffects effect;

            if (owner == 1)
            {
                effect = this.DoDragDrop(this, DragDropEffects.All);
            }
            else
            {
                effect = this.DoDragDrop(this, DragDropEffects.All);
                editSolution.selectedRectangle = this;
                BackColor = Color.Red;
                editSolution.updateColors();
            }
        }


        }
}
