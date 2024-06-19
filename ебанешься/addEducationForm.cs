using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static ебанешься.Form1;

namespace ебанешься
{
    public partial class addEducationForm : Form
    {
        
        public addEducationForm()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addEducationForm_Load(object sender, EventArgs e)
        {
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string combosql = "SELECT \"Full_Name\", \"passcard_number\", \"id_of_employee\" FROM \"Employers\"";
            DataTable ddt = baza.getdata(combosql);

            comboBox2.Items.Clear(); // Clear any existing items

            foreach (DataRow row in ddt.Rows)
            {
                string displayText = row["Full_Name"].ToString() + " (" + row["passcard_number"].ToString() + ")";
                int employeeId = Convert.ToInt32(row["id_of_employee"]);
                // Store the employee ID as part of the ComboBox item
                comboBox2.Items.Add(new ComboBoxItem(displayText, employeeId));
            }

            // Optionally, set the first item as selected
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);

            // Шаг 1: Получение выбранного employee_id из ComboBox
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox2.SelectedItem;
            int employee_id = selectedItem.Value;

            // Шаг 2: Изменение записи в базе данных
            string updateSql = $"SELECT add_education({employee_id}, \'{comboBox1.Text}\', '{textBox1.Text}')";
            baza.getdata(updateSql);

            // Шаг 3: Обновление DataGridView в MainForm
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
        }

    }
}
