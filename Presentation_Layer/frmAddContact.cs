using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity_Layer;
using Business_Layer;

namespace Presentation_Layer
{
    public partial class frmAddContact : Form
    {
        public frmAddContact()
        {
            InitializeComponent();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "")
            {
                MessageBox.Show("Name is required");
                return;
            }

            if(!txbPhoneNum.MaskFull && !txbMobileNum.MaskFull)
            {
                MessageBox.Show("Phone or Mobile cant be empty");
                return;
            }

            Contacts contact = new Contacts()
            {
                Name = txbName.Text.Trim().ToString(),
                LastName = txbLastName.Text.Trim().ToString(),
                DateBirth = dtpDateBirth.Value.Date,
                Address = txbAddress.Text.Trim().ToString(),
                Gender = this.cbGender.GetItemText(this.cbGender.SelectedItem),
                CivilState = this.cbCivilState.GetItemText(this.cbCivilState.SelectedItem),
                MobileNum = txbMobileNum.Text.Trim().ToString(),
                PhoneNum = txbPhoneNum.Text.Trim().ToString(),
                Email = txbEmail.Text.Trim().ToString(),
            };


            Business business = new Business();
            business.CreateContact(contact);
            

            txbName.Clear();
            txbLastName.Clear();
            txbAddress.Clear();
            this.cbGender.Text = null;
            this.cbCivilState.Text = null;
            txbMobileNum.Clear();
            txbPhoneNum.Clear();
            txbEmail.Clear();

        }

        private void txbMobileNum_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmAddContact_Load(object sender, EventArgs e)
        {

        }
    }
}
