using System;
using System.Data;
using System.Windows.Forms;

namespace ебанешься
{
    public partial class editTasksEmpl : Form
    {
        public Zadacha Selected_zadacha { get; set; }
        public User zadaUser { get; set; }
        public editTasksEmpl(Zadacha zadacha, User zadUser)
        {
            InitializeComponent();
            Selected_zadacha = zadacha;
            zadaUser = zadUser;
            zadName.Text = zadacha.Name;
            zadoneFlag.Checked = zadacha.Status;
            zadataOfDead.Text = zadacha.Deadline;
            zavalueOfWork.Value = Convert.ToInt64(zadacha.Value);
            zadId = zadacha.Id;
            usId = zadUser.Id;
        }
        public int zadId;
        public int usId;

        private void addTask_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);
            string zadoneFlagg;
            string nameOfZad = zadName.Text;
            if (zadoneFlag.Checked)
            {
                zadoneFlagg = "Выполнено";
            }
            else { zadoneFlagg = "Не Выполнено"; }

            string dataofDead = zadataOfDead.Value.ToString("yyyy-MM-dd");
            decimal valueOfWork = zavalueOfWork.Value;
            string getIdEmplTaskSql = $"SELECT id_empl_task FROM \"Employee_Task\" WHERE id_of_employee = {usId} AND id_of_task = {zadId}";
            DataTable idEmplTaskTable = baza.getdata(getIdEmplTaskSql);

            int id_empl_task = Convert.ToInt32(idEmplTaskTable.Rows[0]["id_empl_task"]);
            MessageBox.Show(id_empl_task.ToString());
            // Шаг 1: Изменение записи в базе данных
            string x = $"SELECT update_task({zadId},{dataofDead},{valueOfWork},{zadoneFlag.Checked})";
            string z = $"SELECT update_employee_task({id_empl_task},{usId},{zadId})";
            baza.getdata(x);
            baza.getdata(z);


            // Шаг 2: Обновление DataGridView
            string selectSql = "SELECT id_of_task, id_of_employee, \"Task\" as Задача, \"Status\" as Статус, \"Full_Name\" as ФИО, \"Deadline\" as \"Срок выполнения\", \"Value\" as \"Объем работы\" FROM \"Tasks_and_Employee\"\r\n";
            DataTable dt = baza.getdata(selectSql);
            form.dgData.DataSource = dt;
        }
    }
}
