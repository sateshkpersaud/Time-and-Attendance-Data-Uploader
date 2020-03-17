using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Net.Mail;
using Oracle.DataAccess.Client;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Collections;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace WebApplication8
{
    public class DataTier
    {
        public bool successfulCommit = true;
       
        public void export_to_Oracle(string oraDB, string oraQuery)
        {
            string ebsConStr = oraDB;

            using (OracleConnection ebsConn = new OracleConnection(ebsConStr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = ebsConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = oraQuery;

                    try
                    {
                        ebsConn.Open();
                        OracleDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        successfulCommit = true;
                    }
                    catch (System.Exception excec)
                    {
                        successfulCommit = false;
                        writetoAlertLog(excec.ToString().ToUpper());
                    }
                    finally
                    {
                        ebsConn.Close();
                    }
                }
            }
        }

        public void deleteRecord(string oraDB, string tableName, int recordId)
        {
            string ebsConStr = oraDB;

            using (OracleConnection ebsConn = new OracleConnection(ebsConStr))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = ebsConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = ("DELETE FROM " + tableName + " WHERE recordid = " + recordId);

                    try
                    {
                        ebsConn.Open();
                        OracleDataReader dr = cmd.ExecuteReader();
                        successfulCommit = true;
                    }
                    catch (System.Exception excec)
                    {
                        successfulCommit = false;
                        writetoAlertLog(excec.ToString().ToUpper());
                    }
                    finally
                    {
                        ebsConn.Close();
                    }
                }
            }
        }

        //Updated uploaded record for Time Details to show it was uploaded
        public void setUploadStatus_TimeDetails(int recordID, string updatedBy)
        {
            var contex = new App_Data.AcuPayEntities();

            try
            {
                var recordToUpdate = (from a in contex.tbl_2_Export_TimeDetails
                                      where a.RecordId == recordID
                                      select a).First();
                recordToUpdate.Uploaded = "Y";
                recordToUpdate.UploadedBy = updatedBy;
                recordToUpdate.UploadedOn = DateTime.Now;
                contex.SaveChanges();
                successfulCommit = true;
            }
            catch (System.Exception excec)
            {
                successfulCommit = false;
                writetoAlertLog(excec.ToString().ToUpper());
            }
        }

        //Updated uploaded record for Split Time table to show it was uploaded
        public void setUploadStatus_SplitTime(int recordID, string updatedBy)
        {
            var contex = new App_Data.AcuPayEntities();

            try
            {
                var recordToUpdate = (from a in contex.tbl_4_Export_SplitTime
                                      where a.RecordId == recordID
                                      select a).First();
                recordToUpdate.Uploaded = "Y";
                recordToUpdate.UploadedBy = updatedBy;
                recordToUpdate.UploadedOn = DateTime.Now;
                contex.SaveChanges();
                successfulCommit = true;
            }
            catch (System.Exception excec)
            {
                successfulCommit = false;
                writetoAlertLog(excec.ToString().ToUpper());
            }
        }

        //Updated uploaded record for Not Required table to show it was uploaded
        public void setUploadStatus_NotRequired(int recordID, string updatedBy)
        {
            var contex = new App_Data.AcuPayEntities();
            try
            {
                var recordToUpdate = (from a in contex.tbl_6_Export_NotRequired
                                      where a.RecordId == recordID
                                      select a).First();
                recordToUpdate.Uploaded = "Y";
                recordToUpdate.UploadedBy = updatedBy;
                recordToUpdate.UploadedOn = DateTime.Now;
                contex.SaveChanges();
                successfulCommit = true;
            }
            catch (System.Exception excec)
            {
                successfulCommit = false;
                writetoAlertLog(excec.ToString().ToUpper());
            }
        }

        //Updated uploaded record for Piece Time table to show it was uploaded
        public void setUploadStatus_PieceTime(int recordID, string updatedBy)
        {
            var contex = new App_Data.AcuPayEntities();

            try
            {
                var recordToUpdate = (from a in contex.tbl_5_Export_PieceTime
                                      where a.RecordId == recordID
                                      select a).First();
                recordToUpdate.Uploaded = "Y";
                recordToUpdate.UploadedBy = updatedBy;
                recordToUpdate.UploadedOn = DateTime.Now;
                contex.SaveChanges();
                successfulCommit = true;
            }
            catch (System.Exception excec)
            {
                successfulCommit = false;
                writetoAlertLog(excec.ToString().ToUpper());
            }
        }

        //Updated uploaded record for Other Earnings table to show it was uploaded
        public void setUploadStatus_OtherEarnings(int recordID, string updatedBy)
        {
            var contex = new App_Data.AcuPayEntities();

            try
            {
                var recordToUpdate = (from a in contex.tbl_3_Export_OtherEarnings
                                      where a.RecordId == recordID
                                      select a).First();
                recordToUpdate.Uploaded = "Y";
                recordToUpdate.UploadedBy = updatedBy;
                recordToUpdate.UploadedOn = DateTime.Now;
                contex.SaveChanges();
                successfulCommit = true;
            }
            catch (System.Exception excec)
            {
                successfulCommit = false;
                writetoAlertLog(excec.ToString().ToUpper());
            }
        }

        //Updated uploaded record for Piece Work to show it was uploaded
        public void setUploadStatus_PieceWork(int recordID, string updatedBy)
        {
            var contex = new App_Data.AcuPayEntities();
            try
            {
                var recordToUpdate = (from a in contex.tbl_1_Export_PieceWork
                                      where a.RecordId == recordID
                                      select a).First();
                recordToUpdate.Uploaded = "Y";
                recordToUpdate.UploadedBy = updatedBy;
                recordToUpdate.UploadedOn = DateTime.Now;
                contex.SaveChanges();
                successfulCommit = true;
            }
            catch (System.Exception excec)
            {
                successfulCommit = false;
                writetoAlertLog(excec.ToString().ToUpper());
            }
        }

        //public string getConnectionString(int serverID)
        //{
        //    //Get the connection string for the selected database
        //    var context = new App_Data.AcuPayEntities();

        //    var query1 = (from a in context.tbl_Servers
        //                  where a.ServerID == serverID
        //                  select new
        //                  {
        //                      a.ConnectionString
        //                  }).ToString();
        //    return query1;     
        //}

        public List<string> getLocationID(int serverID, string loggedInUser)
        {
            //Get the locations the user is assigned to
            var context = new App_Data.AcuPayEntities();

            var query1 = (from a in context.tbl_Users_Servers
                                   join b in context.tbl_Estate on a.EstatesID equals b.EstateID
                                   join c in context.tbl_Users on a.UserID equals c.UserID
                          where a.ServerID == serverID && c.UserName == loggedInUser
                          select new
                          {
                              b.Guy_EstateCode
                          }).ToList();

            List<string> results = new List<string>();
            if (query1.Count > 0)
            {
                foreach (var item in query1)
                {
                    string val = item.ToString();
                    val = val.Remove(0, 19);
                    val = val.TrimEnd('}');
                    results.Add(val.TrimEnd(' '));
                }
            }
            else results.Add("NoLocation");

            return results;
        }

        public bool IsAdmin(string loggedInUser)
        {
            //Check if the loggedinuser is an Admin
            var context = new App_Data.AcuPayEntities();

            var query1 = (from a in context.tbl_Users
                          where a.UserName == loggedInUser
                          select new
                          {
                              a.Admin
                          }).ToList();

            string result = "";
            bool adminStatus = new bool();
            if (query1.Count > 0)
            {
                foreach (var item in query1)
                {
                    string val = item.ToString();
                    val = val.Remove(0, 10);
                    val = val.TrimEnd('}');
                    result = val.TrimEnd(' ');
                }
            }

            if (result != "")
            {
                if (result == "True") adminStatus = true;
                else adminStatus = false;
            }
            else adminStatus = false;

            return adminStatus;
        }

        //Write errors to alert log
        public void writetoAlertLog(string errorMessage)
        {
            string path = @"C:\\inetpub\\wwwroot\\TA\\Log\\Alert_Log.txt";

            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter str = new StreamWriter(fs);
            str.BaseStream.Seek(0, SeekOrigin.End);
            str.WriteLine("------------------------------WAT UPPP--------------------------------- ");
            str.Write("ACUPAY ERROR (" + DateTime.Now + "): " + errorMessage);
            str.WriteLine(" " + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString());
            str.Flush();
            str.Close();
            fs.Close();
        }
    }
}