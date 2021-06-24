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
    public partial class FRMAddOrEdite : Form 
    {
        Interface contact;
        public int ConID=0 ;

        public FRMAddOrEdite()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRMAddOrEdite_Load(object sender, EventArgs e)
        {
            contact = new contactrepository();

            if (ConID == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = contact.SelectRow(ConID);
                txtname.Text = dt.Rows[0][1].ToString();
                txtfamily.Text = dt.Rows[0][2].ToString();
                txtemail.Text = dt.Rows[0][3].ToString();
                txtmobail.Text = dt.Rows[0][4].ToString();
                txtage.Text = dt.Rows[0][5].ToString();
                txtaddress.Text = dt.Rows[0][6].ToString();
                btnSubmit.Text = "ویرایش";

                
            }
 

        }
        bool validaitinput()
        {
            

            if (txtname.Text == "")
            {
                
                MessageBox.Show("نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtfamily.Text == "")
            {

                MessageBox.Show("نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtemail.Text == "")
            {

                MessageBox.Show("ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtage.Value == 0)
            {

                MessageBox.Show("سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtmobail.Text == "")
            {

                MessageBox.Show("شماره را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

            return true;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validaitinput())
            {
                bool issucess;
                if (ConID == 0)
                {
                    issucess = contact.Insert(txtname.Text, txtfamily.Text, txtmobail.Text, txtemail.Text, (int)txtage.Value, txtaddress.Text, txtcountry.Text, txtnationality.Text, txtnationalitycode.Text);
                }
                else
                {
                    issucess = contact.Update(ConID, txtname.Text, txtfamily.Text, txtmobail.Text, txtemail.Text, (int)txtage.Value, txtaddress.Text, txtcountry.Text, txtnationality.Text, txtnationalitycode.Text);
                }
                if (issucess == true)
                {
                    MessageBox.Show("عملیات با موففقیت شد..", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد. لطفا دوباره امتحان کنید.","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
