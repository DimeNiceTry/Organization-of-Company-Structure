using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ебанешься.Form1;

namespace ебанешься
{
    public partial class editUserForm : Form
    {
        public User SelectedUser { get; set; }
        public Post Post { get; set; }
        public editUserForm(User user)
        {
            InitializeComponent();
            SelectedUser = user;
            famEdit.Text = user.Name.Split()[0];
            nameEdit.Text = user.Name.Split()[1];
            fathEdit.Text = user.Name.Split()[2];
            dolzhAdd.SelectedItem = dolzhAdd.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Text == user.Post);
            otdelAddd.SelectedItem = otdelAddd.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Text == user.Department);
            telEdit.Text = user.Tel;
            numericUpDown2.Text =user.Age;
            numericUpDown1.Text = user.Experience;
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void telAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void postAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fathAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nameAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void famAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void editUserForm_Load(object sender, EventArgs e)
        {
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);

            // Загрузка данных для должностей
            string postComboSql = "SELECT \"name\", \"id_of_post\" FROM \"posts\"";
            DataTable postDataTable = baza.getdata(postComboSql);
            dolzhAdd.Items.Clear();
            foreach (DataRow row in postDataTable.Rows)
            {
                string displayText = row["name"].ToString();
                int postId = Convert.ToInt32(row["id_of_post"]);
                dolzhAdd.Items.Add(new ComboBoxItem(displayText, postId));
            }

            // Загрузка данных для отделов
            string depComboSql = "SELECT \"name\", \"id_of_department\" FROM \"departments\"";
            DataTable depDataTable = baza.getdata(depComboSql);
            otdelAddd.Items.Clear();
            foreach (DataRow row in depDataTable.Rows)
            {
                string displayText = row["name"].ToString();
                int depID = Convert.ToInt32(row["id_of_department"]);
                otdelAddd.Items.Add(new ComboBoxItem(displayText, depID));
            }

            // Установка выбранных элементов после загрузки данных
            if (dolzhAdd.Items.Count > 0)
            {
                dolzhAdd.SelectedItem = dolzhAdd.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Text == SelectedUser.Post);
            }

            if (otdelAddd.Items.Count > 0)
            {
                otdelAddd.SelectedItem = otdelAddd.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Text == SelectedUser.Department);
            }

            // Установка значений полей ввода
            famEdit.Text = SelectedUser.Name.Split()[0];
            nameEdit.Text = SelectedUser.Name.Split()[1];
            fathEdit.Text = SelectedUser.Name.Split()[2];
            telEdit.Text = SelectedUser.Tel;
            numericUpDown2.Text = SelectedUser.Age.ToString();
            numericUpDown1.Text = SelectedUser.Experience.ToString();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);
            string fio = nameEdit.Text + ' ' + famEdit.Text + ' ' + fathEdit.Text;
            int employeeId = SelectedUser.Id;

            string post = dolzhAdd.Text;
            string tel = telEdit.Text;
            string otdel = otdelAddd.Text;
            decimal exp = numericUpDown1.Value;
            decimal age = numericUpDown2.Value;



            string idOtd = $"select id_of_department from departments where name = '{otdel}'";
            DataTable deptTable = baza.getdata(idOtd);
            int id_of_department = (int)deptTable.Rows[0]["id_of_department"];

            string idPost = $"select id_of_post from posts where name = '{post}'";
            DataTable postTable = baza.getdata(idPost);
            int id_of_post = (int)postTable.Rows[0]["id_of_post"];
            // Шаг 1: Изменение записи в базе данных
            string updateSql = $"select update_employee({employeeId}, {id_of_post},{id_of_department}, '{fio}','{tel}', {exp},{age})";
            baza.getdata(updateSql);

            // Шаг 2: Обновление DataGridView
            string selectSql = @"
                    SELECT 
                        e.id_of_employee,
                        p.name AS Должность,
                        e.""Full_Name"" AS ФИО,
                        e.""Telephone"" AS Телефон,
                        e.""Age"" AS Возраст,
                        e.""experience"" AS ""Опыт работы"",
                        d.""name"" AS Отдел
                    FROM
                        ""Employers"" e
                    JOIN
                        ""departments"" d ON e.id_of_department = d.id_of_department
                    JOIN
                        ""posts"" p ON e.id_of_post = p.id_of_post;
                ";
            DataTable dt = baza.getdata(selectSql);
            form.dgData.DataSource = dt;
            if (form.dgData.Columns["id_of_employee"] != null)
            {
                form.dgData.Columns["id_of_employee"].Visible = false;
            }
        }
    }
}
