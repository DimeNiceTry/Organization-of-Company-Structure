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
    public partial class Form1 : Form
    {
        public User SelectedUser { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
        private void addTask_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string nameOfZadacha = nameOfTask.Text;

            // Получение ID выбранного сотрудника из ComboBox
            int id_sotr = ((ComboBoxItem)fio.SelectedItem).Value;

            try
            {
                // Шаг 1: Найти id задачи по имени
                string selectSql = $"SELECT id_of_task FROM \"Tasks\" WHERE \"Task\" = '{nameOfZadacha}'";
                DataTable taskData = baza.getdata(selectSql);

                if (taskData.Rows.Count > 0)
                {
                    // Предполагается, что имя задачи уникально, поэтому берем первый результат
                    int id_task = Convert.ToInt32(taskData.Rows[0]["id_of_task"]);

                    // Шаг 2: Добавление новой записи в базу данных
                    string insertSql = $"SELECT add_employee_task({id_sotr}, {id_task});";
                    baza.getdata(insertSql);

                    // Если дошли до этой точки без выброса исключения, значит запрос выполнен успешно
                    MessageBox.Show("Запрос выполнен успешно!");
                }
                else
                {
                    // Если задача с указанным именем не найдена
                    MessageBox.Show("Задача с указанным именем не найдена.");
                }
            }
            catch (Exception ex)
            {
                // Если произошло исключение, показываем MessageBox с ошибкой
                MessageBox.Show("Ошибка выполнения запроса: " + ex.Message);
            }
        }


        public int id_zad;
        public int id_sotr;
        public List<string> tasks;
        public void Form1_Load(object sender, EventArgs e)
        {
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string combosql = "SELECT \"Full_Name\", \"passcard_number\", \"id_of_employee\" FROM \"Employers\"";
            DataTable ddt = baza.getdata(combosql);

            fio.Items.Clear(); // Clear any existing items

            foreach (DataRow row in ddt.Rows)
            {
                string displayText = row["Full_Name"].ToString() + "(" + row["passcard_number"].ToString() + ")";
                int employeeId = Convert.ToInt32(row["id_of_employee"]);
                // Store the employee ID as part of the ComboBox item
                fio.Items.Add(new ComboBoxItem(displayText, employeeId));
            }

            // Optionally, set the first item as selected
            if (fio.Items.Count > 0)
            {
                fio.SelectedIndex = 0;
            }

            string combosql1 = "SELECT \"id_of_task\", \"Task\" FROM \"Tasks\"";
            DataTable ddtt = baza.getdata(combosql1);

            nameOfTask.Items.Clear(); // Clear any existing items

            foreach (DataRow row in ddtt.Rows)
            {
                nameOfTask.Items.Add(new ComboBoxItem(row["Task"].ToString(), Convert.ToInt32(row["id_of_task"])));
            }

            // Optionally, set the first item as selected
            if (nameOfTask.Items.Count > 0)
            {
                nameOfTask.SelectedIndex = 0;
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

        private void nameOfTask_SelectedValueChanged(object sender, EventArgs e)
        {

        }


        private void fio_SelectedValueChanged(object sender, EventArgs e)
        {

        }

    }
}
