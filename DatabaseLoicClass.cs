using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;//sql dtabase connection class
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace DataLayer
{
    public class DatabaseLoicClass
    {
          
            
            //how to insert data execute
            public void sqlCommandclass()
            {

                //  SqlConnection con = new SqlConnection(@"server=DESKTOP-E69Q7DF; database=db_SMS; integrity security=true");
            //sql connection obj create    
            SqlConnection con = new SqlConnection();

                try
                {

                    //1-this used to MSSQLSERVER to WIndowsAuthenticathion login
                    con.ConnectionString = "server=DESKTOP-E69Q7DF; database=db_SMS; integrity security=true";

                   
                    string username = "savindu@gmail.com";
                    string password = "545445";
                    string compass = "5454445";


                String sql = "INSERT INTO LoginTable(user_name,password,comfrim_password) VALUES(" + username + ",'" + password + "'," + compass + ")";
                    //2-sqlcomman class TO PASS SQL QUERY AND CONNECTION CLASS CON
                    SqlCommand sc = new SqlCommand(sql, con);

                    con.Open();
                    Console.WriteLine("CONNECTION OPEN");

                    //this method used to execute aftre the sql query then intiger return intiger value
                    /*
                     ExecuteNonQuery() if worked return value=1  ,  else return value=0
                     */
                    if (sc.ExecuteNonQuery() > 0)
                    {
                       MessageBox.Show("---INSERTED DATA---");
                      //  Console.WriteLine("---INSERTED DATA---");
                    }
                    else
                    {
                    MessageBox.Show("---EXECUTE ERROR---");
                    // Console.WriteLine("---EXECUTE ERROR---");
                }
                }
                catch (Exception ex)
                {

                MessageBox.Show("---ERROR IN SQL CONNECTION---" + "/n" + ex);

                // Console.WriteLine("---ERROR IN SQL CONNECTION---");
                //    Console.WriteLine(ex);
                }
                finally
                {
                    con.Close();
                    Console.WriteLine("CONNECTION CLOSE");
                }
            }

       
        }
    
}
