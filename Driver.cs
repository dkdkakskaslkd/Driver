using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivers1
{
    public partial class Driver : Form
    {
        public Driver()
        {
            InitializeComponent();
        }

        private void driverBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.driverBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.base1DataSet);

        }

        private void base_Load(object sender, EventArgs e)
        {
          this.driverTableAdapter.Fill(this.base1DataSet.Driver);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Authorization f = new Authorization();
            f.Show();
        }

        
    }
}
