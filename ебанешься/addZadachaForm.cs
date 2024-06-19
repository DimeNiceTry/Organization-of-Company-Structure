using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ебанешься
{
    public partial class addZadachaForm : Form
    {
        public addZadachaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);
            string insertSql = $"select add_task(\'{textBox1.Text}\', \'{zadataOfDead.Value.ToString("yyyy-MM-dd")}\', {numericUpDown1.Value}, false)";
            var dt = baza.getdata(insertSql);   
        }
    }
}
