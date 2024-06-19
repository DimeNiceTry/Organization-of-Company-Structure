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
    public partial class editEducationForm : Form
    {
        public Education educationn { get; set; }
        public editEducationForm(Education education)
        {
            InitializeComponent();
            educationn = education;
            comboBox1.Text = education.Degree.ToString();
            textBox1.Text = education.Institution.ToString();
        }

        private void editEducationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Application.OpenForms["MainForm"];
            Baza baza = new Baza(Baza.UserCredentials.UserId, Baza.UserCredentials.Password);
            string degree = comboBox1.Text;
            string institution = textBox1.Text;

            string updateSql = $"SELECT update_education({educationn.Id}, '{degree}', '{institution}')";
            baza.getdata(updateSql);
            

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
