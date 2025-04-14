using System.Data;
using System.Data.SqlClient;

namespace WinFormsAppCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Visible = false;
                }
                else if (control is Label)
                {
                    control.Visible = false;
                }
                else if (control is NumericUpDown)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CGE7EDRA\\SQLEXPRESS;Initial Catalog=WinFormsAppCRUD;Integrated Security=True;TrustServerCertificate=True");
            string readQuery = "SELECT * FROM Crud";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(readQuery, con);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isAnyEmpty = false;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text.Length == 0)
                    {
                        isAnyEmpty = true;
                        break;
                    }
                }
                if (isAnyEmpty)
                {
                    MessageBox.Show("Please fill all fields", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-CGE7EDRA\\SQLEXPRESS;Initial Catalog=WinFormsAppCRUD;Integrated Security=True;TrustServerCertificate=True");
                    con.Open();
                    string InsertQuery = "INSERT INTO Crud (Email, name, username, password) VALUES (@email, @name, @username, @password)";

                    SqlCommand sqlCommand = new SqlCommand(InsertQuery, con);
                    sqlCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    sqlCommand.Parameters.AddWithValue("@name", txtName.Text);
                    sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                    sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);

                    int count = sqlCommand.ExecuteNonQuery();
                    con.Close();
                    if (count > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data Not Inserted", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is DataGridView)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CGE7EDRA\\SQLEXPRESS;Initial Catalog=WinFormsAppCRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string updateQuery = "UPDATE Crud SET Email=@Email, name=@name, username=@username, password=@password WHERE id=@id";
            SqlCommand sqlCommand = new SqlCommand(updateQuery, con);
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCommand.Parameters.AddWithValue("@name", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@username", txtUsername.Text);
            sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);
            sqlCommand.Parameters.AddWithValue("@id", numericUpDown1.Value);
            int count = sqlCommand.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                MessageBox.Show("Data Updated Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Not Updated", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CGE7EDRA\\SQLEXPRESS;Initial Catalog=WinFormsAppCRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string deleteQuery = "DELETE FROM Crud WHERE id=@id";
            SqlCommand sqlCommand = new SqlCommand(deleteQuery, con);
            sqlCommand.Parameters.AddWithValue("@id", numericUpDown1.Value);
            int count = sqlCommand.ExecuteNonQuery();
            con.Close();
            if (count > 0) 
            {
                MessageBox.Show("Data Deleted Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
