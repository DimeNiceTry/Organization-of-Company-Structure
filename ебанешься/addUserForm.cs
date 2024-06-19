using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static ебанешься.Form1;

namespace ебанешься
{
    public partial class Add_user : Form
    {
        public Add_user()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);
            string fio = nameAdd.Text + ' ' + famAdd.Text + ' ' + fathAdd.Text;
            string post = dolzhAdd.Text;
            string tel = telAdd.Text;
            string otdel = otdelAdd.Text;
            decimal exp = numericUpDown1.Value;
            decimal age = numericUpDown2.Value;
            string idOtd = $"select id_of_department from departments where name = '{otdel}'";
            DataTable deptTable = baza.getdata(idOtd);
            int id_of_department = (int)deptTable.Rows[0]["id_of_department"];

            string idPost = $"select id_of_post from posts where name = '{post}'";
            DataTable postTable = baza.getdata(idPost);
            int id_of_post = (int)postTable.Rows[0]["id_of_post"];
            // Шаг 1: Добавление новой записи в базу данных
            string insertSql = $"SELECT add_employee({id_of_post},{id_of_department},'{fio}','{tel}',{exp},{age})";
            baza.getdata(insertSql);
            // Шаг 2: Обновление DataGridView в MainForm
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

        private void Add_user_Load(object sender, EventArgs e)
        {
            try
            {
                Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);
                string postComboSql = "SELECT \"name\", \"id_of_post\" FROM \"posts\"";
                DataTable postDataTable = baza.getdata(postComboSql);

                dolzhAdd.Items.Clear(); // Очищаем предыдущие элементы

                foreach (DataRow row in postDataTable.Rows)
                {
                    string displayText = row["name"].ToString();
                    int postId = Convert.ToInt32(row["id_of_post"]);
                    // Сохраняем ID должности как часть элемента ComboBox
                    dolzhAdd.Items.Add(new ComboBoxItem(displayText, postId));
                }

                // Устанавливаем первый элемент по умолчанию
                if (dolzhAdd.Items.Count > 0)
                {
                    dolzhAdd.SelectedIndex = 0;
                }

                string depComboSql = "SELECT \"name\", \"id_of_department\" FROM \"departments\"";
                DataTable depDataTable = baza.getdata(depComboSql);

                otdelAdd.Items.Clear(); // Очищаем предыдущие элементы

                foreach (DataRow row in depDataTable.Rows)
                {
                    string displayText = row["name"].ToString();
                    int depID = Convert.ToInt32(row["id_of_department"]);
                    // Сохраняем ID отдела как часть элемента ComboBox
                    otdelAdd.Items.Add(new ComboBoxItem(displayText, depID));
                }

                // Устанавливаем первый элемент по умолчанию
                if (otdelAdd.Items.Count > 0)
                {
                    otdelAdd.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если выбран первый элемент в ComboBox
            if (comboBox1.SelectedIndex == 0)
            {
                // Отключаем TextBox
                textBox1.Enabled = false;
            }
            else
            {
                // Включаем TextBox
                textBox1.Enabled = true;
            }
        }
    }
}
