using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
      //inherite the data layer DBCLASS
   public class Logclass : DBClass
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Comfrimpassword { get; set; }
        public int x;

        //return to booleon value to sinupform.cs file in BLACKLOTUS
        public int Loginsignup()
        {           
            try
            {
                String sql = "INSERT INTO LoginTable(user_name,password,comfrim_password) VALUES('" + UserName + "','" + Password + "','" + Comfrimpassword + "')";
               if(DBClass.ExecuteMethod(sql) > 0)
                {
                    x = 1;
                }
                else
                {
                    x = 0;
                }
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //DataLayer DBClass dataAdapter object value get and check
        public int LoginSign()
        {
            try
            {
               
                String sql = " SELECT  [user_name] ,[password] FROM [BlackLotusDB].[dbo].[LoginTable] WHERE  [user_name] = '" + UserName + "' AND [password] = '" + Password + "' ";

                //return object value pass to new SqlDataReader dr obj
                SqlDataReader dr = DBClass.DataAdapterMethod(sql);
                if (dr.HasRows)
                {
                    String u = "", p = "";

                    while (dr.Read())
                    {

                        u = dr["user_name"].ToString();
                        p = dr["password"].ToString();
                    }

                    if ((UserName == u) && (Password == p))
                    {
                         x = 1;
                    }
                    else
                    {
                         x = 0;
                    }

                }

                else
                {
                     x = 0;
                }

                dr.Close();


                return x;
            }
            catch (Exception)
            {
                throw;
            }
           

        }

        public int LoginDelete()
        {
            try
            {
                string sql = "DELETE From TableNmae WHERE id='" + UserName + "'";
                return DBClass.ExecuteMethod(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //if login username and password match then return true boolen value
        public bool LoginSignin()
        {
          //  bool x = false;

            try
            {
                String sql = " SELECT  [user_name] , [password] FROM [BlackLotusDB].[dbo].[LoginTable] WHERE  [user_name] = '" + UserName + "' AND [password] = '" + Password + "' ";
              
                string u = "";
                string p = "";

                // SqlDataReader d = DBClass.dataAdapterMethod(sql);
                DataSet d = DBClass.DataSetMethod(sql);
                if (d.Tables[0].Rows.Count > 0)
                {
                    //data set  obj store vavue as a custom table
                    u = d.Tables[0].Rows[0][0].ToString();
                    p = d.Tables[0].Rows[0][1].ToString();


                    if ((UserName == u) && (Password == p))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception)
            {
                throw;
            }

        }

        // if username== eneter user name return 1 to Bussinesslayer loginResetPassword() methos
        public int CheckValidusername()
        {
           
            try
            {
                String sql = " SELECT   [user_name] FROM [BlackLotusDB].[dbo].[LoginTable] WHERE  [user_name] = '" + UserName + "'  ";
               SqlDataReader dr = DBClass.DataAdapterMethod(sql);
                if (dr.HasRows)
                {
                    String u = "";

                    while (dr.Read())
                    {
                        //database colum value assign to new variable
                        u = dr["user_name"].ToString();

                    }

                    if (UserName == u)
                    {
                        x = 1;
                    }
                    else
                    {
                        x = 0;
                    }

                }
                else
                {
                    x = 0;
                  
                }

              

                return x;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
               // dr.Close();
            }

            //try
            //{
            //    String sql = " SELECT   [user_name] FROM [BlackLotusDB].[dbo].[LoginTable] WHERE  [user_name] = '" + userName + "'  ";

            //    DataSet dr = DBClass.dataSetMethod(sql);
            //    if (dr.Tables[0].Rows.Count > 0)
            //    {
            //        String u = "";

            //        u = dr.Tables[0].Rows[0][1].ToString();


            //        if (userName == u)
            //        {
            //            x = 1;
            //            Console.WriteLine("valid user name");
            //        }
            //        else
            //        {
            //            x = 0;
            //        }

            //    }
            //    else
            //    {
            //        x = 0;
            //    }

            //    return x;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

        }

        //upade statement execute data pas to DBcLass and return excute value catch here
        public  int LoginResetPassword()
        {
            try
            {
                //if CheckValidusername() return value = 1
                if (CheckValidusername() == 1)
                {

                    String sql = "UPDATE [BlackLotusDB].[dbo].[LoginTable] SET  password= '" + Password + "' , comfrim_password= '" + Comfrimpassword + "' WHERE user_name= '" + UserName + "' ";
                   
                    //executenonquery return true=1 false 0 DATALAYER 
                    if (DBClass.ExecuteMethod(sql) > 0)
                    {
                        x = 1;
                    }
                    else
                    {
                        x = 0;
                    }

                }
                else
                {
                    x = 0;
                }

                return x;
            }
            catch (Exception)
            {
                throw;
            }

        }


       
        public void LoginView() { }
       
    }

}

