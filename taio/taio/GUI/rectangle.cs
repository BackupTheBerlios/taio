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
                //effect = this.DoDragDrop(this, DragDropEffects.All);
            }
            else
            {
                effect = this.DoDragDrop(this, DragDropEffects.All);
                editSolution.selectedRectangle = this;
                BackColor = Color.Red;
                editSolution.updateColors();
            }
        }

        private void rectangle_DoubleClick(object sender, EventArgs e)
        {
            if (this.owner == 1)
            {
                this.Hide();
                GUI.rectangle r2 = new rectangle(this.Index, this.OriginalWidth, this.OriginalHeight, 2, this.editSolution);
                r2.Location = new System.Drawing.Point(0, 0);
                r2.Width = Convert.ToInt32(this.OriginalWidth * editSolution.factor);
                r2.Height = Convert.ToInt32(this.OriginalHeight * editSolution.factor);
                r2.Anchor = (AnchorStyles.None);
                r2.Owner = 2;
                r2.color = this.BackColor;
                r2.BackColor = Color.Red;
                editSolution.selectedRectangle = r2;
                editSolution.splitContainer1.Panel2.Controls.Add(r2);
                editSolution.rectangles.Add(r2);
                editSolution.updateColors();
            }
    //else
    //{
    //    foreach (Control c in editSolution.splitContainer1.Panel1.Controls)
    //       {
    //           if (c.GetType() == typeof(GUI.rectangle))
    //           {
    //               GUI.rectangle r = (GUI.rectangle)c;
    //               if (r.Index == this.Index)
    //               {
    //                   r.Show();
    //                   editSolution.rectangles.Remove(r);
    //                   editSolution.splitContainer1.Panel2.Controls.Remove(r);
    //               } 
    //           }
    //      }
    //}
        }


        }
}
