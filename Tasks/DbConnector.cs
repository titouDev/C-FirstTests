using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

/*
TUTORIAL
    http://zetcode.com/db/mysqlcsharptutorial/

*/

namespace Tasks
{
    class DbConnector
    {
        public DbConnector()
        {
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            string myConnectionString;

            myConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};",
                "127.0.0.1",
                "root",
                "root",
                "tasks");

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                Console.WriteLine("\n\nMySQL version : {0}", conn.ServerVersion);

                insertExample(conn);

                //selectExample(conn, rdr);
                selectExample02(conn);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr!= null)
                {
                    rdr.Close();
                }
            }
        }

        public void insertExample(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO test(Name) VALUES(@Name)";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@Name", "test Name");
            cmd.ExecuteNonQuery();
        }

        public void selectExample(MySqlConnection conn, MySqlDataReader rdr)
        {
            string stm = @"SELECT * FROM test";

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            rdr = cmd.ExecuteReader();

            string[] tableFields = new string[rdr.FieldCount];

            for (int i = 0; i < rdr.FieldCount; i++)
            {
                tableFields[i] = rdr.GetName(i);
                
            }

            Console.WriteLine("{0} {1}", rdr.GetName(0),
                rdr.GetName(1).PadLeft(18));

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetString(0).PadRight(18) +
                    rdr.GetString(1));
            }
        }
        public void selectExample02(MySqlConnection conn)
        {
            string stm = "SELECT * FROM test";
            MySqlDataAdapter da = new MySqlDataAdapter(stm, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "Authors");
            DataTable dt = ds.Tables["Authors"];

            dt.WriteXml("authors.xml");

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine(row[col]);
                }

                Console.WriteLine("".PadLeft(20, '='));
            }
        }

    }
}
