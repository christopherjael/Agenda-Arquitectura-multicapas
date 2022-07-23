using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace Presentation_Layer
{
    public partial class frmMain : Form
    {
        Business business;
        DataGridViewRow selectedRow;
        public frmMain()
        {
            InitializeComponent();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmAddContact().ShowDialog();
            dgvContacts.DataSource = business.ListAllContacts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
            string name = selectedRow.Cells[1].Value.ToString();
            string lastName = selectedRow.Cells[2].Value.ToString();
            string dateBirth = selectedRow.Cells[3].Value.ToString();
            string address = selectedRow.Cells[4].Value.ToString();
            string gender = selectedRow.Cells[5].Value.ToString();
            string civilState = selectedRow.Cells[6].Value.ToString();
            string mobile = selectedRow.Cells[7].Value.ToString();
            string phone = selectedRow.Cells[8].Value.ToString();
            string email = selectedRow.Cells[9].Value.ToString();
            new frmUpdateContact(id, name, lastName, dateBirth, address, gender, civilState, mobile, phone, email).ShowDialog();
            dgvContacts.DataSource = business.ListAllContacts();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            business = new Business();
            dgvContacts.DataSource = business.ListAllContacts();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            business = new Business();
            dgvContacts.DataSource = business.Populate(txbSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            business = new Business();
            const string message = "Are you sure that you want deleted this row?";
            const string caption = "Delete row";
            DialogResult result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                business.DeleteContact(id);
                dgvContacts.DataSource = business.ListAllContacts();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int idx = e.RowIndex;
            selectedRow = dgvContacts.Rows[idx];

        }
    }
}
