using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ебанешься
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Подписываемся на событие CellValueChanged
           // dgData.CellValueChanged += dgData_CellValueChanged;
            // Подписываемся на событие CellClick, чтобы выделялась вся строка при клике на ячейку
            dgData.CellClick += dgData_CellClick;
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (NameOfTable.Text)
            {
                case "Сотрудники":
                    User selectedUser = new User();
                    selectedUser.Id = Convert.ToInt32(dgData.SelectedRows[0].Cells["id_of_employee"].Value);
                    selectedUser.Name = dgData.SelectedRows[0].Cells["ФИО"].Value.ToString();
                    selectedUser.Post = dgData.SelectedRows[0].Cells["Должность"].Value.ToString();
                    selectedUser.Tel = dgData.SelectedRows[0].Cells["Телефон"].Value.ToString();
                    selectedUser.Age = dgData.SelectedRows[0].Cells["Возраст"].Value.ToString();
                    selectedUser.Experience = dgData.SelectedRows[0].Cells["Опыт работы"].Value.ToString();
                    selectedUser.Department = dgData.SelectedRows[0].Cells["Отдел"].Value.ToString();
                    editUserForm editUserForm = new editUserForm(selectedUser);
                    editUserForm.Show();
                    break;
                case "Отделы":
                    Otdel otdel = new Otdel();
                    otdel.Id = Convert.ToInt32(dgData.SelectedRows[0].Cells["id_of_department"].Value);
                    otdel.Name = dgData.SelectedRows[0].Cells["Наименование"].Value.ToString();
                    otdel.Tel = dgData.SelectedRows[0].Cells["Телефон"].Value.ToString();
                    otdel.Money = dgData.SelectedRows[0].Cells["Доход"].Value.ToString();
                    editOtdel editOtdel = new editOtdel(otdel);
                    editOtdel.Show();
                    break;
                case "Образование":
                    Education education = new Education();
                    education.Id = Convert.ToInt32(dgData.SelectedRows[0].Cells["id_of_employee"].Value);
                    education.Degree = dgData.SelectedRows[0].Cells["Степень"].Value.ToString();
                    education.Institution = dgData.SelectedRows[0].Cells["Учреждение"].Value.ToString();
                    editEducationForm editEducationForm = new editEducationForm(education);
                    editEducationForm.Show();
                    break;
                case "Должности":
                    Post post = new Post();
                    post.Id = Convert.ToInt32(dgData.SelectedRows[0].Cells["id_of_post"].Value);
                    post.Name = dgData.SelectedRows[0].Cells["Наименование"].Value.ToString();
                    post.needed_experience = Convert.ToInt32(dgData.SelectedRows[0].Cells["Необходимый опыт"].Value);
                    editPostForm editPostForm = new editPostForm(post);
                    editPostForm.Show();
                    break;
                case "Организация задач":
                    Zadacha zadacha = new Zadacha();
                    zadacha.Id = Convert.ToInt32(dgData.SelectedRows[0].Cells["id_of_task"].Value);
                    zadacha.Name = dgData.SelectedRows[0].Cells["Задача"].Value.ToString();
                    zadacha.Deadline = dgData.SelectedRows[0].Cells["Срок Выполнения"].Value.ToString();
                    if (dgData.SelectedRows[0].Cells["Объем работы"].Value is DBNull)
                    {
                        zadacha.Value = 0;
                    }
                    else
                    {
                        zadacha.Value = Convert.ToInt32(dgData.SelectedRows[0].Cells["Объем работы"].Value);

                    }
                    if (dgData.SelectedRows[0].Cells["Статус"].Value.ToString() == "Выполнена")
                    {
                        zadacha.Status = true;
                    }
                    else { zadacha.Status = false; }

                    User zaduser = new User();
                    zaduser.Id = Convert.ToInt32(dgData.SelectedRows[0].Cells["id_of_employee"].Value);
                    zaduser.Name = dgData.SelectedRows[0].Cells["ФИО"].Value.ToString();

                    editTasksEmpl editTasksEmpl = new editTasksEmpl(zadacha, zaduser);
                    editTasksEmpl.Show();
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            enableButtons();
            try
            {
                TreeNode selectedNode = e.Node;
                string TableSql;
                string user = Baza.UserCredentials.UserId;
                string pass = Baza.UserCredentials.Password;
                Baza baza = new Baza(user, pass);
                DataTable dt;
                switch (selectedNode.Text)
                {
                    case "Сотрудники":
                        button3.Visible = false;
                        NameOfTable.Text = selectedNode.Text;
                        TableSql = @"
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
                        dt = baza.getdata(TableSql);
                        dgData.DataSource = dt;
                        if (dgData.Columns["id_of_employee"] != null)
                        {
                            dgData.Columns["id_of_employee"].Visible = false;
                        }
                        break;
                    case "Отделы":
                        button3.Visible = false;
                        NameOfTable.Text = selectedNode.Text;
                        TableSql = $"SELECT id_of_department, \"name\" as Наименование, \"telephone\" as Телефон, \"profit_per_month\" as Доход FROM \"departments\"";
                        dt = baza.getdata(TableSql);
                        dgData.DataSource = dt;
                        if (dgData.Columns["id_of_department"] != null)
                        {
                            dgData.Columns["id_of_department"].Visible = false;
                        }
                        break;
                    case "Организация задач":
                        button3.Visible = true;
                        NameOfTable.Text = selectedNode.Text;
                        TableSql = $"select id_of_task, id_of_employee, \"Task\" as Задача, \"Status\" as Статус, \"Full_Name\" as ФИО, \"Deadline\" as \"Срок Выполнения\", \"Value\" as \"Объем работы\" from \"Tasks_and_Employee\"";
                        dt = baza.getdata(TableSql);
                        dgData.DataSource = dt;
                        if (dgData.Columns["id_of_task"] != null)
                        {
                            dgData.Columns["id_of_task"].Visible = false;
                        }
                        if (dgData.Columns["id_of_employee"] != null)
                        {
                            dgData.Columns["id_of_employee"].Visible = false;
                        }
                        break;
                    case "Должности":
                        NameOfTable.Text = selectedNode.Text;
                        TableSql = $"SELECT id_of_post, \"name\" as Наименование, \"needed_experience\" as \"Необходимый опыт\" FROM \"posts\"";
                        dt = baza.getdata(TableSql);
                        dgData.DataSource = dt;
                        if (dgData.Columns["id_of_post"] != null)
                        {
                            dgData.Columns["id_of_post"].Visible = false;
                        }
                        break;

                    case "Количество сотрудников":
                        NameOfTable.Text = selectedNode.Text;
                        TableSql = $"select наименование, количество_сотрудников from public.отдел_сотрудники";
                        dt = baza.getdata(TableSql);
                        dgData.DataSource = dt;
                        break;
                    case "Образование":
                        button3.Visible = false;
                        NameOfTable.Text = selectedNode.Text;
                        TableSql = @"
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
                        dt = baza.getdata(TableSql);
                        dgData.DataSource = dt;
                        if (dgData.Columns["id_of_employee"] != null)
                        {
                            dgData.Columns["id_of_employee"].Visible = false;
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            switch (NameOfTable.Text)
            {
                case "Сотрудники":
                    Add_user addForm = new Add_user();
                    addForm.Show();
                    break;
                case "Отделы":
                    addOtdel addOtdel = new addOtdel();
                    addOtdel.Show();
                    break;
                case "Организация задач":
                    Form1 form = new Form1();
                    form.Show();
                    break;
                default:
                    break;
                case "Образование":
                    addEducationForm add=new addEducationForm();
                    add.Show();
                    break;
                case "Должности":
                    addPostForm addPostForm = new addPostForm();
                    addPostForm.Show();
                    break;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string tableName = NameOfTable.Text;
            string deleteSql = "";
            string idColumn = "";

            // Проверяем, что хотя бы одна строка выбрана
            if (dgData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgData.SelectedRows)
                {
                    // Определяем имя колонки с ID в зависимости от таблицы
                    switch (tableName)
                    {
                        case "Сотрудники":
                            idColumn = "id_of_employee";
                            break;
                        case "Отделы":
                            idColumn = "id_of_department";
                            break;
                        case "Организация задач":
                            idColumn = "id_of_task";
                            break;
                        case "Должности":
                            idColumn = "id_of_post";
                            break;
                        case "Образование":
                            idColumn = "id_of_employee";
                            break;

                        default:
                            MessageBox.Show("Неизвестная таблица.");
                            return;
                    }

                    // Получаем ID записи из DataGridView
                    int itemId = Convert.ToInt32(row.Cells[idColumn].Value);

                    // Формируем SQL-запрос для удаления
                    switch (tableName)
                    {
                        case "Сотрудники":
                            deleteSql = $"select delete_employee({itemId})";
                            break;
                        case "Отделы":
                            deleteSql = $"select delete_department({itemId})";
                            break;
                        case "Организация задач":
                            deleteSql = $"select delete_task({itemId})";
                            break;
                        case "Должности":
                            deleteSql = $"select delete_post({itemId})";
                            break;
                        case "Образование":
                            deleteSql = $"select delete_education({itemId})";
                            break;


                    }

                    // Выполняем запрос
                    try
                    {
                        string user = Baza.UserCredentials.UserId;
                        string pass = Baza.UserCredentials.Password;
                        Baza baza = new Baza(user, pass);
                        baza.getdata(deleteSql);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                    }
                }

                // Обновляем DataGridView, чтобы удаленная строка отобразилась
                LoadTableData();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void LoadTableData()
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string TableSql;
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);
            DataTable dt;
            button3.Visible = false;
            switch (selectedNode.Text)
            {
                case "Сотрудники":

                    TableSql = @"
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
                    dt = baza.getdata(TableSql);
                    dgData.DataSource = dt;
                    if (dgData.Columns["id_of_employee"] != null)
                    {
                        dgData.Columns["id_of_employee"].Visible = false;
                    }
                    break;
                case "Отделы":
                    TableSql = $"SELECT id_of_department, \"name\" as Наименование, \"telephone\" as Телефон, \"profit_per_month\" as Доход FROM \"departments\"";
                    dt = baza.getdata(TableSql);
                    dgData.DataSource = dt;
                    if (dgData.Columns["id_of_department"] != null)
                    {
                        dgData.Columns["id_of_department"].Visible = false;
                    }
                    break;
                case "Должности":
                    TableSql = $"SELECT id_of_post, \"name\" as Наименование, \"needed_experience\" as \"Необходимый опыт\" FROM \"posts\"";
                    dt = baza.getdata(TableSql);
                    dgData.DataSource = dt;
                    if (dgData.Columns["id_of_post"] != null)
                    {
                        dgData.Columns["id_of_post"].Visible = false;
                    }
                    break;

                case "Организация задач":
                    button3.Visible = true;
                    TableSql = $"select id_of_task, id_of_employee, \"Task\" as Задача, \"Status\" as Статус, \"Full_Name\" as ФИО, \"Deadline\" as \"Срок Выполнения\", \"Value\" as \"Объем работы\" from \"Tasks_and_Employee\"";
                    dt = baza.getdata(TableSql);
                    dgData.DataSource = dt;
                    if (dgData.Columns["id_of_task"] != null)
                    {
                        dgData.Columns["id_of_task"].Visible = false;
                    }
                    if (dgData.Columns["id_of_employee"] != null)
                    {
                        dgData.Columns["id_of_employee"].Visible = false;
                    }
                    break;
                case "Образование":
                    TableSql = @"
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
                    dt = baza.getdata(TableSql);
                    dgData.DataSource = dt;
                    if (dgData.Columns["id_of_employee"] != null)
                    {
                        dgData.Columns["id_of_employee"].Visible = false;
                    }
                    break;

            }
        }


        private void RefreshDataGridView()
        {
            string tableName = NameOfTable.Text;
            string selectSql = "";
            button3.Visible = false;
            switch (tableName)
            {
                case "Сотрудники":
                    selectSql = @"
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
                    break;
                case "Должности":
                    selectSql = @"
                        SELECT 
                            id_of_post, 
                            ""name"" AS Наименование, 
                            ""needed_experience"" AS ""Необходимый опыт"" 
                        FROM 
                            ""posts"";
                    ";
                    break;

                case "Отделы":
                    selectSql = @"
                SELECT 
                    id_of_department, 
                    ""name"" AS Наименование, 
                    ""telephone"" AS Телефон, 
                    ""profit_per_month"" AS Доход 
                FROM 
                    ""departments"";
            ";
                    break;
                case "Организация задач":
                    button3.Visible = true;
                    selectSql = @"
                SELECT 
                    id_of_task, 
                    id_of_employee, 
                    ""Task"" AS Задача, 
                    ""Status"" AS Статус, 
                    ""Full_Name"" AS ФИО, 
                    ""Deadline"" AS ""Срок Выполнения"", 
                    ""Value"" AS ""Объем работы"" 
                FROM 
                    ""Tasks_and_Employee"";
            ";
                    break;
                default:
                    MessageBox.Show("Неизвестная таблица.");
                    return;
            }

            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);
            DataTable dt;

            try
            {
                dt = baza.getdata(selectSql);
                dgData.DataSource = dt;

                // Скрываем столбцы с ID, если они существуют
                if (dgData.Columns.Contains("id_of_employee"))
                {
                    dgData.Columns["id_of_employee"].Visible = false;
                }
                if (dgData.Columns.Contains("id_of_department"))
                {
                    dgData.Columns["id_of_department"].Visible = false;
                }
                if (dgData.Columns.Contains("id_of_task"))
                {
                    dgData.Columns["id_of_task"].Visible = false;
                }
                if (dgData.Columns.Contains("id_of_employee"))
                {
                    dgData.Columns["id_of_employee"].Visible = false;
                }
                if (dgData.Columns.Contains("id_of_post"))
                {
                    dgData.Columns["id_of_post"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
            }
        }


        private void dgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass);
            string insertSql;

            switch (NameOfTable.Text)
            {
                case "Сотрудники":
                    insertSql = $@"
                SELECT 
                    e.id_of_employee,
                    p.name AS Должность,
                    e.""Full_Name"" AS ФИО,
                    e.""Telephone"" AS Телефон,
                    e.experience AS ""Опыт работы"",
                    d.""name"" AS Отдел,
                    e.""Age"" as Возраст
                FROM
                    ""Employers"" e
                JOIN
                    ""departments"" d ON e.id_of_department = d.id_of_department
                JOIN
                    ""posts"" p ON e.id_of_post = p.id_of_post
                WHERE
                    UPPER(e.""Full_Name"") LIKE UPPER('%{findBox.Text}%') 
                    OR UPPER(p.name) LIKE UPPER('%{findBox.Text}%')
                    OR UPPER(e.""Telephone"") LIKE UPPER('%{findBox.Text}%')
            ";
                    break;
                case "Должности":
                    insertSql = $@"
        SELECT 
            id_of_post AS ID,
            name AS Название_должности,
            ""needed_experience"" AS Требуемый_опыт
        FROM 
            ""posts""
        WHERE 
            UPPER(name) LIKE UPPER('%{findBox.Text}%')
    ";
                    break;
                case "Отделы":
                    insertSql = $@"
                SELECT 
                    id_of_department, 
                    ""name"" AS Наименование, 
                    ""telephone"" AS Телефон, 
                    ""profit_per_month"" AS Доход 
                FROM 
                    ""departments"" 
                WHERE 
                    UPPER(""name"") LIKE UPPER('%{findBox.Text}%') 
                    OR (""telephone""::text) LIKE ('%{findBox.Text}%') 
                    OR (""profit_per_month""::text) LIKE ('%{findBox.Text}%')
            ";
                    break;
                
                case "Организация задач":
                    insertSql = $@"
                SELECT 
                    t.id_of_task,
                    t.""Task"" AS Задача,
                    t.""Status"" AS Статус,
                    e.""Full_Name"" AS ФИО,
                    p.name AS Должность,
                    t.""Deadline"" AS ""Срок выполнения"",
                    t.""Value"" AS ""Объем работы""
                FROM 
                    ""Tasks"" t
                JOIN 
                    ""Employee_Task"" et ON t.id_of_task = et.id_of_task
                JOIN 
                    ""Employers"" e ON et.id_of_employee = e.id_of_employee
                JOIN 
                    ""posts"" p ON e.id_of_post = p.id_of_post
                WHERE 
                    UPPER(t.""Task"") LIKE UPPER('%{findBox.Text}%') 
                    
                    OR UPPER(e.""Full_Name"") LIKE UPPER('%{findBox.Text}%') 
                    OR UPPER(p.name) LIKE UPPER('%{findBox.Text}%') 
                    OR (t.""Deadline""::text) LIKE ('%{findBox.Text}%') 
                    OR (t.""Value""::text) LIKE ('%{findBox.Text}%')
            ";
                    break;
                case "Образование":
                    insertSql = $@"
        SELECT 
            ed.id_of_employee,
            e.""Full_Name"" AS ФИО,
            ed.degree AS Степень,
            ed.institution AS Учреждение
        FROM 
            ""education"" ed
        JOIN 
            ""Employers"" e ON ed.id_of_employee = e.id_of_employee
        WHERE 
            UPPER(ed.degree) LIKE UPPER('%{findBox.Text}%')
            OR UPPER(ed.institution) LIKE UPPER('%{findBox.Text}%')
            OR UPPER(e.""Full_Name"") LIKE UPPER('%{findBox.Text}%')
    ";
                    break;

                default:
                    insertSql = "";
                    break;
            }

            if (!string.IsNullOrEmpty(insertSql))
            {
                var dt = baza.getdata(insertSql);
                form.dgData.DataSource = dt;

                // Скрываем столбцы с ID, если они существуют
                if (form.dgData.Columns["id_of_employee"] != null)
                {
                    form.dgData.Columns["id_of_employee"].Visible = false;
                }
                if (form.dgData.Columns["id_of_department"] != null)
                {
                    form.dgData.Columns["id_of_department"].Visible = false;
                }
                if (form.dgData.Columns["id_of_task"] != null)
                {
                    form.dgData.Columns["id_of_task"].Visible = false;
                }
                if (form.dgData.Columns["id_of_employee"] != null)
                {
                    form.dgData.Columns["id_of_employee"].Visible = false;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgData.Rows[e.RowIndex].Selected = true;
            }
        }

     /*   private void dgData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            enableButtons();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string tableName = NameOfTable.Text;
                DataGridViewRow row = dgData.Rows[e.RowIndex];
                string columnName = dgData.Columns[e.ColumnIndex].Name;
                object newValue = row.Cells[e.ColumnIndex].Value;

                // Ищем скрытый столбец с ID
                string idColumnName = tableName == "Employers" ? "id_of_employee" : "id_of_department";
                int id = Convert.ToInt32(row.Cells[idColumnName].Value);

                string updateSql = $"UPDATE {tableName} SET {columnName} = @newValue WHERE {idColumnName} = @id";

                try
                {
                    connection();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateSql, vCon))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении записи: {ex.Message}");
                }
            }
        }
      */
        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        public void disableButtons()
        {
            button2.Enabled = false;
            button1.Enabled = false;
            btnOk.Enabled = false;
            deleteButton.Enabled = false;
            findBox.Enabled = false;
        }
        public void enableButtons()
        {
            button2.Enabled = true;
            button1.Enabled = true;
            btnOk.Enabled = true;
            deleteButton.Enabled = true;
            findBox.Enabled = true;
        }
        private void countzadButton_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT 
    e.""Full_Name"" AS Employee,
    CASE 
        WHEN UPPER(d.degree) IN (UPPER('Бакалавр'), UPPER('Магистратура'), UPPER('Специалитет'), UPPER('Аспирантура')) THEN 'Yes'
        ELSE 'No'
    END AS ""Наличие высшего образования""
FROM 
    ""Employers"" e
LEFT JOIN 
    education d ON e.id_of_employee = d.id_of_employee;

";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }


        private void dismissed_workersBut_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT * FROM public.dismissed_employees_anonymous";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void podzapSELECT_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT 
    e.""Full_Name"",
    (SELECT COUNT(*) 
     FROM ""Employee_Task"" et 
     WHERE et.id_of_employee = e.id_of_employee) AS task_count
FROM ""Employers"" e;";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void podzapWHERE_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = $" SELECT \"Full_Name\", \"Telephone\", experience\r\nFROM \"Employers\"\r\nWHERE id_of_employee IN (\r\n    SELECT id_of_employee\r\n    FROM \"Employers\"\r\n    WHERE experience > {satzh.Value}\r\n);\r\n";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }



        private void podzapfromm_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = $"SELECT t.\"Task\", t.\"Value\"\r\nFROM (\r\n    SELECT id_of_task, \"Task\", \"Deadline\", \"Value\"\r\n    FROM \"Tasks\"\r\n    WHERE \"Value\" > {priozad.Value} OR \"Value\" is null -- Предположим, что value >= 100 обозначает высокий приоритет\r\n) t";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void korelzap_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT 
    d.Name, 
    ROUND(AVG(num_tasks), 2) AS ""Avg_Tasks_Per_Employee""
FROM 
    Departments d
LEFT JOIN (
    SELECT 
        e.id_of_department, 
        e.id_of_employee, 
        COUNT(et.id_of_task) AS num_tasks
    FROM 
        ""Employers"" e
    LEFT JOIN 
        ""Employee_Task"" et ON e.id_of_employee = et.id_of_employee
    GROUP BY 
        e.id_of_department, e.id_of_employee
) sub ON d.id_of_department = sub.id_of_department
GROUP BY 
    d.name;


";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void korelzap2_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT d.""name"", (
    SELECT COUNT(*)
    FROM ""Employers"" e
    WHERE e.id_of_department = d.id_of_department
) AS ""Num_Of_Employees""
FROM departments d;


";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void kolzap3_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT 
    e.id_of_department,
    CASE 
        WHEN COUNT(e.id_of_employee) > 0 THEN 
            (SELECT 
                 COUNT(CASE WHEN ed.degree IN ('Специалитет', 'Магистратура', 'Бакалавр', 'Вспирантура') THEN 1 END) * 100.0 / NULLIF(COUNT(e2.id_of_employee), 0)
             FROM 
                 ""Employers"" e2
             JOIN 
                 education ed ON e2.id_of_employee = ed.id_of_employee
             WHERE 
                 e2.id_of_department = e.id_of_department)
        ELSE 
            0.0
    END AS percentage_higher_education
FROM 
    ""Employers"" e
GROUP BY 
    e.id_of_department;


";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void grouphaving_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT 
    e.id_of_employee,
    e.""Full_Name"",
    e.passcard_number,
    e.id_of_department,
    COUNT(t.id_of_task) AS task_count
FROM 
    ""Employers"" e
JOIN 
    ""Employee_Task"" et ON e.id_of_employee = et.id_of_employee
JOIN 
    ""Tasks"" t ON et.id_of_task = t.id_of_task
GROUP BY 
    e.id_of_employee, e.""Full_Name"", e.passcard_number, e.id_of_department
HAVING 
    COUNT(t.id_of_task) > 2;


";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void anyzap_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = $"SELECT e.*\r\nFROM \"Employers\" e\r\nWHERE e.id_of_employee = ANY (\r\n    SELECT et.id_of_employee\r\n    FROM \"Employee_Task\" et\r\n    JOIN \"Tasks\" t ON et.id_of_task = t.id_of_task\r\n    WHERE t.\"Deadline\" > '{anyzappick.Value.ToString("yyyy-MM-dd")}');";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void any_Click(object sender, EventArgs e)
        {
            disableButtons();
            string user = Baza.UserCredentials.UserId;
            string pass = Baza.UserCredentials.Password;
            Baza baza = new Baza(user, pass); // Передаем логин и полученный пароль
            string query = @"SELECT *
FROM Departments d
WHERE Profit_per_month > ALL (
    SELECT d2.Profit_per_month
    FROM Departments d2
    WHERE d2.Name LIKE 'Отдел продаж'
);


";

            DataTable dt = baza.getdata(query);
            dgData.DataSource = dt;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            addZadachaForm addZadachaForm = new addZadachaForm();
            addZadachaForm.Show();
        }
    }

}
