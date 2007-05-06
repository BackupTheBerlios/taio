using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace taio.GUI
{
    public partial class RandomDataFrm : Form
    {
        public static int counter = 0;
        private MainFrm mainFrm;
        private int quantity=0, width=0, height=0;

        public RandomDataFrm(MainFrm mainFrm)
        {
            InitializeComponent();
            this.mainFrm = mainFrm;
        }

        private void RandomData_Load(object sender, EventArgs e)
        {
            counter++;
            
        }

        private void RandomData_FormClosed(object sender, FormClosedEventArgs e)
        {
            counter--;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                if (parse())
                {
                    int w, h;
                    String[] row = new string[3];
                    Random rand = new Random(DateTime.UtcNow.Millisecond);

                    datRectangles.Rows.Clear();

                    for (int i = 0; i < quantity; i++)
                    {
                        w = rand.Next(1, width + 1);
                        h = rand.Next(1, height + 1);

                        row[0] = i.ToString();
                        row[1] = w.ToString();
                        row[2] = h.ToString();
                        datRectangles.Rows.Add(row);
                    }
                    this.btnSave.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.mainFrm.Engine.Rectangles != null)
                    if (this.mainFrm.Engine.Rectangles.Count > 0 || this.mainFrm.Engine.Solutions.Count > 0)
                        if (MessageBox.Show("Istniej¹ce w pamiêci prostok¹ty zostan¹ nadpisane,\na rozwi¹zania skasowane !\nKontynuowaæ?", "Ostrze¿enie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                    this.mainFrm.Engine.Rectangles = new List<taio.Data.Rectangle>();
                    this.mainFrm.Engine.IsFromFile = false;
                    this.mainFrm.Engine.Rectangles.Clear();
                    this.mainFrm.Engine.Solutions.Clear();

                    foreach (DataGridViewRow row in datRectangles.Rows)
                    {
                        Data.Rectangle rect = new taio.Data.Rectangle(Convert.ToInt32( row.Cells[1].Value),Convert.ToInt32( row.Cells[2].Value));
                        this.mainFrm.Engine.Rectangles.Add(rect);
                    }
                    
                    MessageBox.Show("Stworzono "+datRectangles.Rows.Count.ToString()+" nowych prostok¹tów", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mainFrm.Engine.Rectangles.Clear();
                this.mainFrm.Engine.Solutions.Clear();
            }
        }
        private bool parse()
        {
            if(!(Int32.TryParse(txtQuantity.Text,out quantity)))
            { 
                MessageBox.Show("B³êdnie podana liczba prostok¹tów", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!(Int32.TryParse(txtWidth.Text, out width)))
            {
                MessageBox.Show("B³êdnie podana max. szerokoœæ", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!(Int32.TryParse(txtHeight.Text, out height)))
            {
                MessageBox.Show("B³êdnie podana max. wysokoœæ", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (quantity<=0)
            {
                MessageBox.Show("Liczba prostok¹tów musi byæ > 0", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (width <= 0)
            {
                MessageBox.Show("Max. Szerokoœæ musi byæ > 0", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (height <= 0)
            {
                MessageBox.Show("Max. Wysokoœæ musi byæ > 0", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
           return true;        
        }

        private void datRectangles_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void datRectangles_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void datRectangles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (datRectangles.RowCount >0)
            {
                int temp;
                if(!Int32.TryParse(datRectangles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),out temp))
                {
                    MessageBox.Show("B³êdnie podana wartoœæ komórki", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (temp <= 0)
                    MessageBox.Show("Wartoœæ komórki musi byæ > 0", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
            } 
       }


    }
}