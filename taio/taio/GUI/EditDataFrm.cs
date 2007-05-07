using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace taio.GUI
{
    public partial class EditDataFrm : Form
    {
        public static int counter = 0;
        private MainFrm mainFrm;
        private bool flag = false;

        public EditDataFrm(MainFrm mainFrm)
        {
            this.mainFrm = mainFrm;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (datRectangles.Rows.Count < 2)
                    return;
                if (this.mainFrm.Engine.Rectangles != null)
                    if (this.mainFrm.Engine.Rectangles.Count > 0 || this.mainFrm.Engine.Solutions.Count > 0)
                        if (MessageBox.Show("Istniej¹ce w pamiêci prostok¹ty zostan¹ nadpisane,\na rozwi¹zania skasowane !\nKontynuowaæ?", "Ostrze¿enie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                this.mainFrm.Engine.Rectangles = new List<taio.Data.Rectangle>();
                this.mainFrm.Engine.Rectangles.Clear();
                this.mainFrm.Engine.Solutions.Clear();

                for (int i = 0; i<=(datRectangles.Rows.Count - 2); i++)
                {
                    Data.Rectangle rect = new taio.Data.Rectangle(Convert.ToInt32(datRectangles.Rows[i].Cells[1].Value), Convert.ToInt32(datRectangles.Rows[i].Cells[2].Value));
                    this.mainFrm.Engine.Rectangles.Add(rect);
                }

                MessageBox.Show("Stworzono " + Convert.ToString(datRectangles.Rows.Count-1) + " nowych prostok¹tów", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mainFrm.Engine.Rectangles.Clear();
                this.mainFrm.Engine.Solutions.Clear();
            }
        }

        private void EditDataFrm_Load(object sender, EventArgs e)
        {
            counter++;
            btnSave.Enabled = false;
            String[] row = new string[3];

            try
            {
                for (int i = 0; i < mainFrm.Engine.Rectangles.Count; i++)
                {
                    row[0] = Convert.ToString(i + 1);
                    row[1] = Convert.ToString(mainFrm.Engine.Rectangles[i].Width);
                    row[2] = Convert.ToString(mainFrm.Engine.Rectangles[i].Height);
                    datRectangles.Rows.Add(row);
                  
                }
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditDataFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            counter--;
        }

        private void datRectangles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (e.RowIndex !=(datRectangles.Rows.Count-1)) )
            {
                datRectangles.Rows.RemoveAt(e.RowIndex);
                btnSave.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            datRectangles.ClearSelection();
            datRectangles.Rows[datRectangles.Rows.Count-1].Selected = true;
        }

        private void datRectangles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            if (datRectangles.RowCount > 0 && e.ColumnIndex != 3 && flag)
            {
                int temp;
                if (!Int32.TryParse(datRectangles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out temp))
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