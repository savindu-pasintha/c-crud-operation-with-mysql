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
    public class OrderClass
    {
        public string orderId { get; set; }

        public string flowerId { get; set; }
        public string flowerName { get; set; }
        public string flowerPriceone { get; set; }
        public string totalPrice { get; set; }
        public string flowerQuentity { get; set; }
        public string flowercategoryNameOrCode { get; set; }


        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
       

        public string addressLineOne { get; set; }
        public string addressLineTwo { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }

        public int x;

        //order details
        public int orderAdd()
        {
            try
            {
            //    " + Convert.ToInt64(orderId) + "
                    String sql = " INSERT INTO [OrderTable] (OrderC,code,name,totalPrice,quentity,categoryNameOrCode,price) VALUES(" + Convert.ToInt32(orderId) + ",' " + flowerId + " ','" + flowerName + "' ," + Convert.ToDouble(totalPrice) + " ," + Convert.ToInt32(flowerQuentity) + ",'"+ flowercategoryNameOrCode + "'  ," + Convert.ToDouble(flowerPriceone) + " )";
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
     
        public int orderUpdate()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT OrderC FROM [BlackLotusDB].[dbo].[OrderTable] WHERE  OrderC =  " + Convert.ToInt32(orderId) + " ";
                String Coluame = "OrderC";
                String Check = orderId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    String sql = " UPDATE OrderTable  SET  code='" + flowerId + "',name='" + flowerName + "' ,totalPrice=" + Convert.ToDouble(totalPrice) + " ,quentity=" + Convert.ToInt32(flowerQuentity) + ",categoryNameOrCode='" + flowercategoryNameOrCode + "' , price=" + Convert.ToDouble(flowerPriceone) + " WHERE OrderC = " + Convert.ToInt32(orderId) + ")";
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
     
        public int orderDelete()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT [OrderC] FROM [BlackLotusDB].[dbo].[OrderTable] WHERE OrderC=  " + Convert.ToInt32(orderId) + " ";
                String Coluame = "OrderC";
                String Check = orderId.ToString();

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if Check Valid  true  if return value = 1


                    //  1--customer Table Row delete becourse order id is a primary key 
                    // customerDelete();

                    //2-- Shipind details row delete order id is a primary key 
                    //  shipinDelatilsDelete();


                    //3-- order table delete order id is a primary key 

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    string sql = " DELETE FROM [OrderTable] WHERE OrderC = " + Convert.ToInt32(orderId) + "   ";
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

        //search Orderr All one record Using DataSet classs
        public DataSet orderViewAll()
        {
            try
            {
                String sql = " SELECT  * FROM [BlackLotusDB].[dbo].[OrderTable] ";
                DataSet dso = DBClass.DataSetMethod(sql);// return wenne dataset obj ekk

                return dso;//agin return the design page thsi object
            }
            catch (Exception)
            {
                throw;
            }
        }


        //customer part
        public int customerAdd()
        {
            try
            {
               
                    String sql = "INSERT INTO CustomerTable(cusOrder,firstName,lastName,mobileNumber,email) VALUES(" + Convert.ToInt32(orderId) + " ,'" + firstName + "','" + lastName + "' ,'" + mobileNumber + "' ,'" + email + "'  )";
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
       
        public int customerUpdate()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT cusOrder FROM [BlackLotusDB].[dbo].[CustomerTable] WHERE  cusOrder= " + Convert.ToInt32(orderId) + " ";
                String Coluame = "cusOrder";
                String Check = orderId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    String sql = " UPDATE CustomerTable  SET firstName='" + firstName + "',lastName='" + lastName + "' , mobileNumber='" + mobileNumber + "' ,email='" + email + "' WHERE cusOrder=" + Convert.ToInt32(orderId) + "  )";
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
       
        public int customerDelete()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT cusOrder FROM [BlackLotusDB].[dbo].[CustomerTable] WHERE  cusOrder= " + Convert.ToInt32(orderId) + " ";
                String Coluame = "cusOrder";
                String Check = orderId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    string sql = "DELETE From  CustomerTable WHERE cusOrder= " + Convert.ToInt32(orderId) + "  ";
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
        //search Customer All one record Using DataSet classs retrun to Desing pages
        public DataSet customerViewAll()
        {
            try
            {
                String sql = " SELECT  * FROM [BlackLotusDB].[dbo].[CustomerTable] ";
                DataSet ds = DBClass.DataSetMethod(sql);// return wenne dataset obj ekk

                return ds;//agin return the design page thsi object
            }
            catch (Exception)
            {
                throw;
            }
        }


        //shiping address part
        public int shipinDelatilsAdd()
        {
           
                try
                {
                    String sql = "INSERT INTO ShipinTable(shiOrder,addressLineOne,addressLineTwo,city, postalCode, country) VALUES(" + Convert.ToInt32(orderId) + ",'" + addressLineOne + "','" + addressLineTwo + "' ,'" + city + "' ,'" + postalCode + "'  , '" + country + "' )";
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

        public int shipinDelatilsUpdate()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT shiOrder FROM [BlackLotusDB].[dbo].[ShipinTable] WHERE  shiOrder= " + Convert.ToInt32(orderId) + " ";
                String Coluame = "shiOrder";
                String Check = orderId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    String sql = " UPDATE ShipinTable  SET  addressLineOne='" + addressLineOne + "',addressLineTwo='" + addressLineTwo + "' ,city='" + city + "' ,postalCode='" + postalCode + "'  , country='" + country + "' WHERE shiOrder=" + Convert.ToInt32(orderId) + " ";
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
      
        public int shipinDelatilsDelete()
        {
            try
            {
                //check valid primary key value or not using   IsEmptyClass-->isValidColumData(sqlSelectStatement, Checking, databaseColumName) method
                String SelectStatement = " SELECT shiOrder FROM [BlackLotusDB].[dbo].[ShipinTable] WHERE  shiOrder= " + Convert.ToInt32(orderId) + " ";
                String Coluame = "shiOrder";
                String Check = orderId;


                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1

                    //String sql = "UPDATE   se //code = '" + categoryId + "' ,
                    string sql = "DELETE From  ShipinTable WHERE shiOrder= " + Convert.ToInt32(orderId) + "  ";
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

        //search Customer All one record Using DataSet classs
        public DataSet shipinViewAll()
        {
            try
            {
                String sql = " SELECT  * FROM [BlackLotusDB].[dbo].[ShipinTable] ";
                DataSet dss = DBClass.DataSetMethod(sql);// return wenne dataset obj ekk

                return dss;//agin return the design page thsi object data grid view
            }
            catch (Exception)
            {
                throw;
            }
        }
        //order id pass
        public int orderIdChec()
        {
            try
            {
                String SelectStatement = " SELECT OrderC FROM [BlackLotusDB].[dbo].[OrderTable] WHERE OrderC = '" + orderId + "' ";
                String Coluame = "OrderC";
                String Check = orderId;

                ////Check primary key colum value == input value
                IsEmptyClass obj = new IsEmptyClass();

                if (obj.IsValidColumData(SelectStatement, Check, Coluame) == 1)
                { //if CheckValidusername() return value = 1
                    String sql = " SELECT OrderC FROM [BlackLotusDB].[dbo].[OrderTable] WHERE OrderC = '" + orderId + "' ";
                    SqlDataReader dr = DBClass.DataAdapterMethod(sql);
                    if (dr.HasRows)
                    {


                        while (dr.Read())
                        {
                            //database colum value assign to new variable
                            //dataReader Obj[String DataBaseTablecolumName].ToString();
                            orderId = dr["order"].ToString();
                           
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

        

    }
}
