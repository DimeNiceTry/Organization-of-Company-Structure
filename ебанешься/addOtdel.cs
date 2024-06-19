using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ебанешься
{
    public partial class addOtdel : Form
    {
        public addOtdel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);
            string naming = otdelAddName.Text;
            string money = otdelAddMoney.Text;
            string tel = otdelAddTel.Text;
            // Шаг 1: Добавление новой записи в базу данных
            string sql = $"select add_department(\'{naming}\',\'{tel}\', \'{money}\')";
            baza.getdata(sql);

            // Шаг 2: Обновление DataGridView
            string TableSql = $"SELECT id_of_department, \"name\" as Наименование, \"telephone\" as Телефон, \"profit_per_month\" as Доход FROM \"departments\"";
            DataTable dt = baza.getdata(TableSql);
            form.dgData.DataSource = dt;
            if (form.dgData.Columns["id_of_department"] != null)
            {
                form.dgData.Columns["id_of_department"].Visible = false;
            }
            
            form.dgData.DataSource = dt;
        }
    }
}
