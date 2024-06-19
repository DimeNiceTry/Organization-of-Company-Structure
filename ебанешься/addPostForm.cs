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
    public partial class addPostForm : Form
    {
        public addPostForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);

            string postName = textBox1.Text;
            decimal neededExp = numericUpDown1.Value;

            // Шаг 1: Добавление новой записи в таблицу Posts
            string sql = $"select add_post('{postName}',{neededExp})";
            baza.getdata(sql);

            // Шаг 2: Обновление DataGridView
            string TableSql = $"SELECT id_of_post, name as Должность, \"needed_experience\" as \"Требуемый опыт\" FROM Posts";
            DataTable dt = baza.getdata(TableSql);
            form.dgData.DataSource = dt;
            if (form.dgData.Columns["id_of_post"] != null)
            {
                form.dgData.Columns["id_of_post"].Visible = false;
            }
        }

    }
}
