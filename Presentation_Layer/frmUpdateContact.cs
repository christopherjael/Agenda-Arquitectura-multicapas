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
    public partial class frmUpdateContact : Form
    {
        int idContact=0;
        string Name;
        string Lastname;
        string DateBirth;
        string Address;
        string Gender;
        string CivilState;
        string MobileNum;
        string PhoneNum;
        string Email;
        public frmUpdateContact(int IdContact, string Name, string Lastname, string DateBirth, string Address, string Gender,
            string CivilState, string MobileNum, string PhoneNum, string Email)
        {
            InitializeComponent();
            this.idContact=IdContact;
            this.Name=Name;
            this.Lastname=Lastname;
            this.DateBirth=DateBirth;
            this.Address=Address;
            this.Gender=Gender;
            this.CivilState=CivilState;
            this.MobileNum=MobileNum;
            this.PhoneNum=PhoneNum;
            this.Email=Email;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "")
            {
                MessageBox.Show("Name is required");
                return;
            }

            if (!txbPhoneNum.MaskFull && !txbMobileNum.MaskFull)
            {
                MessageBox.Show("Phone or Mobile cant be empty");
                return;
            }

            Contacts contact = new Contacts()
            {
                Id = idContact,
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
            business.UpdateContact(contact);
        }

        private void frmUpdateContact_Load(object sender, EventArgs e)
        {
            txbName.Text = Name;
            txbLastName.Text = Lastname;
            dtpDateBirth.Value = DateTime.Parse(DateBirth);
            txbAddress.Text = Address;
            this.cbGender.Text = Gender;
            this.cbCivilState.Text = CivilState;
            txbMobileNum.Text = MobileNum;
            txbPhoneNum.Text = PhoneNum;
            txbEmail.Text = Email;
        }
    }
}
