using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataLayer
{
    public class DBClass 
    {
        //SQL CONNECTION Create
        public static SqlConnection con;
        public static SqlDataReader sdr;
        public static SqlCommand sc;
        public static SqlDataAdapter sda;
        public static DataSet ds;
        public static string connectionStr= "Data Source =.; Initial Catalog = BlackLotusDB; Integrated Security = True ";

        //execute Inset Statement ExecuteNoneQuery execute delet|update|insert queries
        public static int ExecuteMethod(string sqlQuery)
        {

            try
            {
                con = new SqlConnection(connectionStr);// avoid this erro  to use--> connectionstring property has not been initialized.
                con.Open();
                sc = new SqlCommand(sqlQuery, con);
                //new lines
               // sc.CommandType = CommandType.Text;
                //after execution return 0=false or 1=true as a intiger value
                return sc.ExecuteNonQuery();
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
               // con.Dispose();
                Console.WriteLine("DataLayer CONNECTION CLOSE");
            }
        }

        //SqlDataReader class using view|check|search data select statement  execute selectquery
        public static SqlDataReader DataAdapterMethod(string sqlQuery)
        {

            try
            {
                con = new SqlConnection(connectionStr);// avoid this erro  to use--> connectionstring property has not been initialized.
                con.Open();
                sc = new SqlCommand(sqlQuery, con);
                //{
                //    //new lines
                //    CommandType = CommandType.Text
                //};
                sdr = sc.ExecuteReader();

                return sdr; //datareader object return with database table data
                
            }
            catch (Exception)
            {
                throw; 
            } 
            finally
            {
                // avoid this erro  to use-->  Invalid attempt to call Read when reader is closed 

                //   con.Close();
                //   con.Close();
                // con.Dispose();
                Console.WriteLine("DataLayer DataAdapterMethod CONNECTION CLOSE");
            }
        }

        //Dataset class using view|check|search data select statement  execute  selectquery
        public static DataSet DataSetMethod(string sqlQuery)
        {

            try
            {
                con = new SqlConnection(connectionStr);// avoid this erro  to use--> connectionstring property has not been initialized.
                con.Open();
                sda = new SqlDataAdapter(sqlQuery, con);
                ds = new DataSet();
                sda.Fill(ds);

                return ds;//dataset object return with database table data
            }
            catch (Exception)
            {
               ////MessageBox.Show("---dataSetMethod() execution error in Datalayer---" + "\n \n" + ex);
               // Console.WriteLine(ex);
                throw;
            }
            finally
            {
            //    con.Close();
                Console.WriteLine("DataLayer DataSetMethod CONNECTION CLOSE");
            }
        }

        //DataTable class using view|check|search data select statement  execute  selectquery
        public static DataTable DataTableMethod(string sqlSelectQuery)
        {

            try
            {
                con = new SqlConnection(connectionStr);// avoid this erro  to use--> connectionstring property has not been initialized.
                con.Open();
                sc = new SqlCommand(sqlSelectQuery, con);
                DataTable dt = new DataTable("Table Name Give");
                dt.Load(sc.ExecuteReader());

                return dt;//dataset object return with database table data
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //    con.Close();
                Console.WriteLine("DataLayer DataTable Method ");
            }
        }

    }
}
