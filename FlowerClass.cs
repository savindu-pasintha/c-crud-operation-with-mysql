using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using System.IO;
using System.Drawing;

namespace BusinessLogic
{
    public class FlowerClass
    {
        public string flowerId { get; set; }
        public string flowerName { get; set; }
        public string flowerDescription { get; set; }
        public string flowerQuentity { get; set; }//database colum datatype is int ---> convert string to int y=Convert.ToInt32(flowerQuentity);
        public byte[] flowerImageFile { get; set; }     // please image datatype
        public static Bitmap Img;
        public string flowerPriceone { get; set; }// database eke store karddi convert krnn intiger --> Convert.ToDouble(flowerPriceone) 
        public string flowerCategory { get; set; }
        public string flowerNo { get; set; }// this want to set in the search method id value
        int x;
    //    public int flowerImageFile { get; set; }



        public int flowerAdd()
        {
           

            try
            {
                    
                    String sql = "INSERT INTO FlowerTable(code,name,description,quentity,categoryNameOrCode,price) VALUES('" + flowerId + "','" + flowerName + "' ,'" + flowerDescription + "' ," + Convert.ToInt32(flowerQuentity) + " , '" + flowerCategory + "' ,"+Convert.ToDouble(flowerPriceone)+" )";
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

        public int flowerUpdate()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT code FROM [BlackLotusDB].[dbo].[FlowerTable] WHERE  code= '" + flowerId + "' ";
                String Coluame = "code";
                String Check = flowerId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    String sql = " UPDATE FlowerTable  SET  name='" + flowerName + "' ,description='" + flowerDescription + "' ,quentity=" + Convert.ToInt32(flowerQuentity) + "  , categoryNameOrCode='" + flowerCategory + "' ,price=" + Convert.ToDouble(flowerPriceone) + "  WHERE code= '" + flowerId + "' ";
                    //executenonquery return true=1 false 0 DATALAYER 
                  //image='" + flowerImageFile + "',
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

        public int flowerDelete()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT code FROM [BlackLotusDB].[dbo].[FlowerTable] WHERE  code= '" + flowerId + "' ";
                String Coluame = "code";
                String Check = flowerId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    string sql = "DELETE From  FlowerTable WHERE code= '" + flowerId + "'  ";
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

        //search Flower Id one record
        public int flowerSearch()
        {
            try
            {
                

                String SelectStatement = " SELECT  code FROM [BlackLotusDB].[dbo].[FlowerTable] WHERE  [code] = '" + flowerId + "'  ";
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String Coluame = "code";
                String Check = flowerId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    String sql = " SELECT code,name,description,quentity,categoryNameOrCode,price FROM [BlackLotusDB].[dbo].[FlowerTable] WHERE  [code] = '" + flowerId + "'  ";
                    SqlDataReader dr = DBClass.DataAdapterMethod(sql);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //database colum value assign to new variable
                            flowerId = dr["code"].ToString();
                            flowerName = dr["name"].ToString();
                            flowerDescription = dr["description"].ToString();
                            flowerQuentity = dr["quentity"].ToString(); //out put int value
                            flowerCategory = dr["categoryNameOrCode"].ToString();
                            flowerPriceone = dr["price"].ToString();
                            //flowerNo = dr["id"].ToString();

                            //Image read
                            //MemoryStream mss = new MemoryStream((byte[])dr["image"]);
                            //Img = new Bitmap(mss);

 
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

       // search Flower All one record Using DataSet classs retrun to desing page
        public DataSet flowerViewAll()
        {
            try
            {
                String sql = " SELECT  * FROM [BlackLotusDB].[dbo].[FlowerTable] ";
                DataSet ds = DBClass.DataSetMethod(sql);// return wenne dataset obj ekk

                return ds;//agin return the design page thsi object
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable IflowerViewAll()
        {
            try
            {
                String sql = " SELECT  * FROM [BlackLotusDB].[dbo].[FlowerTable] ";
                DataTable dtl = DBClass.DataTableMethod(sql);// return wenne dataset obj ekk

                return dtl;//agin return the design page thsi object
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
