using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ебанешься
{
    public partial class editOtdel : Form
    {
        public Otdel otdell { get; set; }

        public editOtdel(Otdel otdel)
        {
            otdell = otdel;
            InitializeComponent();
            nameEdit.Text = otdel.Name;
            telEdit.Text = otdel.Tel;
            moneyEdit.Text = otdel.Money;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);
            string naming = nameEdit.Text;
            string tel = telEdit.Text;
            string money = moneyEdit.Text;
            double monn = Convert.ToDouble(money);

            // Шаг 1: Изменение записи в базе данных
            string updateSql = $"SELECT update_department({otdell.Id},\'{naming}\',\'{tel}\',{monn})";
            baza.getdata(updateSql);
            MessageBox.Show(naming);
            // Шаг 2: Обновление DataGridView в MainForm

            // Шаг 2: Обновление DataGridView
            string TableSql = @"
                    SELECT 
                        e.id_of_employee,
                        e.""Full_Name"" AS ФИО,
                        ed.degree AS Степень,
                        ed.institution AS Учреждение
                    FROM
                        ""Employers"" e
                    JOIN
                        ""education"" ed ON e.id_of_employee = ed.id_of_employee;
                ";

            DataTable dt = baza.getdata(TableSql);
            form.dgData.DataSource = dt;
            if (form.dgData.Columns["id_of_employee"] != null)
            {
                form.dgData.Columns["id_of_employee"].Visible = false;
            }
            
            form.dgData.DataSource = dt;
        }
    }
}
