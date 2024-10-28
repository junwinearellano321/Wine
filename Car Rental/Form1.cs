using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace Car_Rental
{
    public partial class Form1 : Form
    {
        private List<User> users;
        private DataTable userTable;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            SetupDataGridView();
        }
        private void LoadData()
        {

            users = new List<User>
            {


            };
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnadd_Click(object sender, EventArgs e)
        {

            string firstName = txtbox2.Text;
            string lastName = txtbox3.Text;

            string CarSerial = txtbox1.Text;
            DateTime rent = dateTimePicker1.Value;
            DateTime back = dateTimePicker2.Value;

            if (!string.IsNullOrWhiteSpace(firstName) &&
                !string.IsNullOrWhiteSpace(lastName)&&
                    !string.IsNullOrWhiteSpace(CarSerial)&&(CarSerial==btn1.Text|| CarSerial == button8.Text ||CarSerial ==button9.Text||CarSerial==button10.Text||CarSerial==button11.Text||CarSerial==button12.Text))
            {

                DialogResult result = MessageBox.Show("Pls Review your details \nFirst Name: "+firstName+"\nLast Name: "+lastName+ "\nSerial #: " + CarSerial + "\nRent : " + dateTimePicker1.Value+"\nReturn : " + dateTimePicker2.Value , "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int newId = userTable.Rows.Count;


                    userTable.Rows.Add(newId, firstName, lastName, CarSerial, rent, back);


                    dataGridView1.DataSource = userTable;


                    txtbox1.Clear();
                    txtbox2.Clear();
                    txtbox3.Clear();
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }
               
                
                
                
                
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly.");
            }
        }

        private void SetupDataGridView()
        {
            userTable = new DataTable();


            userTable.Columns.Add("ID", typeof(int));
            userTable.Columns.Add("First Name");
            userTable.Columns.Add("Last Name");
            userTable.Columns.Add("Car Serial #");


            userTable.Columns.Add("Date of Rent", typeof(DateTime));
            userTable.Columns.Add("Date of Return", typeof(DateTime));
          
            

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                userTable.Rows.Add(i, user.FirstName, user.LastName, user.CarSerial, user.rent, user.back);
            }

            dataGridView1.DataSource = userTable;


            dataGridView1.Columns["ID"].Visible = false;
        }
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string CarSerial { get; set; }
            public DateTime rent { get; set; }
            public DateTime back { get; set; }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtsearch.Text.ToLower();
            DataView dv = userTable.DefaultView;


            dv.RowFilter = string.Format(
                "Convert([First Name], 'System.String') LIKE '%{0}%' OR Convert([Last Name], 'System.String') LIKE '%{0}%'",
                searchTerm);

            dataGridView1.DataSource = dv.ToTable();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {

                    int originalId = (int)row.Cells["ID"].Value;


                    DataRow[] rowsToDelete = userTable.Select("ID = " + originalId);
                    foreach (DataRow rowToDelete in rowsToDelete)
                    {
                        userTable.Rows.Remove(rowToDelete);

                        txtsearch.Clear();
                        string searchTerm = txtsearch.Text.ToLower();
                        DataView dv = userTable.DefaultView;
                        dv.RowFilter = string.Format(
              "Convert([First Name], 'System.String') LIKE '%{0}%' OR Convert([Last Name], 'System.String') LIKE '%{0}%'",
              searchTerm);
                        dataGridView1.DataSource = dv.ToTable();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void btnus_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtbox1.Text = button9.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtbox1.Text = btn1.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtbox1.Text = button8.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtbox1.Text = button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtbox1.Text = button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtbox1.Text = button12.Text;
        }
    }
}
