using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoryClass
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNo { get; set; }//database id colum output value assign in vie method
        int x;

        public int CategoryAdd() {
            try
            {
                String sql = "INSERT INTO CategoryTable(code,name) VALUES('" + CategoryId + "','" + CategoryName + "')";
                if (DBClass.ExecuteMethod(sql) > 0)
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

        public int  CategoryUpdate()
        {
           
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT code FROM [BlackLotusDB].[dbo].[CategoryTable] WHERE  code= '" + CategoryId + "' ";
                String Coluame = "code";
                String Check = CategoryId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    String sql= " UPDATE CategoryTable  SET name= '" + CategoryName + "' WHERE code= '" + CategoryId + "' ";
                //executenonquery return true=1 false 0 DATALAYER 
                if (DBClass.ExecuteMethod(sql) > 0)
                    {
                        x = 1;
                        Console.WriteLine("updated");
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public int CategoryDelete()
        {

            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT code FROM [BlackLotusDB].[dbo].[CategoryTable] WHERE  code= '" + CategoryId + "' ";
                String Coluame = "code";
                String Check = CategoryId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    string sql = "DELETE From  CategoryTable WHERE code= '" + CategoryId + "'  ";
                    //executenonquery return true=1 false 0 DATALAYER 
                    if (DBClass.ExecuteMethod(sql) > 0)
                    {
                        x = 1;
                        Console.WriteLine("Deleted");
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
      
      //search category  
       public int CategorySearch()
        {
            try
            {
                String SelectStatement = " SELECT code FROM [BlackLotusDB].[dbo].[CategoryTable] WHERE  code= '" + CategoryId + "' ";
                String Coluame = "code";
                String Check = CategoryId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1
                    String sql = " SELECT code,name FROM [BlackLotusDB].[dbo].[CategoryTable] WHERE  code= '" + CategoryId + "' OR name='"+CategoryName+"' ";
                    SqlDataReader dr = DBClass.DataAdapterMethod(sql);
                    if (dr.HasRows)
                    {


                        while (dr.Read())
                        {
                            //database colum value assign to new variable
                            //dataReader Obj[String DataBaseTablecolumName].ToString();
                            CategoryId = dr["code"].ToString();
                            CategoryName = dr["name"].ToString();
                          //  CategoryNo = dr["id"].ToString();


                        }
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

        //search Category All one record Using DataSet classs
        public DataSet categoryViewAll()
        {
            try
            {
                String sql = " SELECT  * FROM [BlackLotusDB].[dbo].[CategoryTable] ";
                DataSet  dss = DBClass.DataSetMethod(sql);// return wenne dataset obj ekk

                return dss;//agin return the design page thsi object
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
