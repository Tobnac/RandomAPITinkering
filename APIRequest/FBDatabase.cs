using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequest
{
    class FBDatabase
    {
        private readonly string sqlUrl = "filterblnm498.mysql.db";
        private readonly string sqlUser = "filterblnm498";
        private readonly string sqlPw = null;
        private readonly string sqlDB = "filterblnm498";

        private SqlConnection sql;

        public void Run()
        {
            this.BuildConnectionObj();
            this.OpenConnection();

            this.ExecuteSQLQuery();

            this.CloseConnection();
        }

        private void ExecuteSQLQuery(string command)
        {
            var cmd = new SqlCommand(command, this.sql);

            try
            {
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    Console.WriteLine(sqlReader["Column1"].ToString());
                    Console.WriteLine(sqlReader["Column2"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void BuildConnectionObj()
        {
            var loginParams = "";
            loginParams += "user id=" + this.sqlUser + ";";
            loginParams += "password=" + this.sqlPw + ";";
            loginParams += "server=" + this.sqlUrl + ";";
            loginParams += "Trusted_Connection=yes;";
            loginParams += "database=" + this.sqlDB + "; ";
            loginParams += "connection timeout=30";

            this.sql = new SqlConnection(loginParams);
        }

        private void ExecuteSQLQuery()
        {
            this.ExecuteSQLQuery("SELECT TOP 10 save_file_name FROM publicsaves");
        }

        private void OpenConnection()
        {
            try
            {
                Console.WriteLine("Connecting to DB...");
                this.sql.Open();
                Console.WriteLine("Connection established!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while connecting to DB");
                Console.WriteLine(e.ToString());
                return;
            }
        }

        private void CloseConnection()
        {
            try
            {
                this.sql.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while closing connection to DB");
                Console.WriteLine(e.ToString());
            }
        }

    }
}
