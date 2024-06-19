using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace ебанешься
{
    internal class Baza
    {
        string vStrConnection;
        public Baza(string user, string pass)
        {
            vStrConnection = $"Server=localhost; port=5432; user id={user}; password={pass}; database=kursovaya";
        }
        public static class UserCredentials
        {
            public static string UserId { get; set; }
            public static string Password { get; set; }
        }

        NpgsqlConnection vCon;
        NpgsqlCommand vCmd;
        public void connection()
        {
            vCon = new NpgsqlConnection(vStrConnection);
            if (vCon.State == ConnectionState.Closed)
            {
                vCon.Open();
            }
        }
        public bool TestConnection()
        {
            try
            {
                connection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (vCon != null && vCon.State == ConnectionState.Open)
                {
                    vCon.Close();
                }
            }
        }
        public DataTable getdata(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection();
                vCmd = new NpgsqlCommand(sql, vCon);
                NpgsqlDataReader dr = vCmd.ExecuteReader();
                dt.Load(dr);
                
            }
            catch (Exception ex)
            {
                if (ex.Message == "Недопустимый вид хранилища: DBNull.")
                {

                }
                else
                {

                }

            }
            
            return dt;
        }
        
    }
}
