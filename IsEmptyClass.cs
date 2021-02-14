using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class IsEmptyClass
    {
        
        public int x;
       /*
        THIS METHOD USED USED TO  CHECK
       OUR INPUT COMUM ID OR PRIMARY KEY VALUE IS EMPTY OR NOR OR SAME INPUT DATA ?
       DELETE UPDATE QUERY TO USED 
        */
        public int IsValidColumData(String sqlSelectStatement,String checking, String databaseColumame)
        {
            try
            {
               
                //DBClass dataAdapterMethod execute
                SqlDataReader dr = DBClass.DataAdapterMethod(sqlSelectStatement);
                if (dr.HasRows)
                {
                    String outPut = "";

                    while (dr.Read())
                    {
                        //database colum value assign to new variable
                        outPut = dr[databaseColumame].ToString(); 

                    }

                    if (checking == outPut)
                    {
                        x = 1;
                        Console.WriteLine(" valid primary key value ");
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
    }
}
