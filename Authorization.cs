using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivers1
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public int I;
        private int count = 1;

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ADMIN\source\repos\drivers1\base1.mdf; Integrated Security = True");
            I = 0;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Authorization] WHERE Login ='" + textBox3.Text + "' AND Password ='" + textBox4.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            I = Convert.ToInt32(dt.Rows.Count.ToString());
            if (I == 0)
            {
                MessageBox.Show("Authentication error!");
                if (count++ == 5)
                {
                    this.Close();
                }
            }
            else
            {
                this.Hide();
                Driver f = new Driver();
                f.Show();
            }
            con.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




