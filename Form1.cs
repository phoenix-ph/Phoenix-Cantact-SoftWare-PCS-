using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contact
{
    public partial class Form1 : Form
    {
        contactrepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new contactrepository(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            DGView.AutoGenerateColumns = false;
            //DGView.CurrentRow.Cells[0].Visible = false;
            DGView.DataSource = repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            FRMAddOrEdite fram = new FRMAddOrEdite();
            fram.ShowDialog();
            if (fram.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (DGView.CurrentRow != null)
            {
                string name = DGView.CurrentRow.Cells[1].Value.ToString();
                string family = DGView.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + family;
                if (MessageBox.Show("مطمئن هستید " + " " + fullname + " " + "آیا از حذف", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                {
                    int conid= int.Parse(DGView.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(conid);
                    BindGrid();


                }
            }
            else
            {
                MessageBox.Show("لطفا یک نفر را انتخاب کنید");
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (DGView.CurrentRow != null)
            {
                int ContactID = int.Parse(DGView.CurrentRow.Cells[0].Value.ToString());
                FRMAddOrEdite fram = new FRMAddOrEdite();
                fram.ConID = ContactID;
                if (fram.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DGView.DataSource = repository.Search(txtsearch.Text);
        }
    }
}
