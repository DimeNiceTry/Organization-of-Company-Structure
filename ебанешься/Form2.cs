using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ебанешься.Baza;

namespace ебанешься
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            Baza baza = new Baza(user, pass);

            if (baza.TestConnection())
            {
                UserCredentials.UserId = user;
                UserCredentials.Password = pass;

                this.Hide(); 
               
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

    }
}
