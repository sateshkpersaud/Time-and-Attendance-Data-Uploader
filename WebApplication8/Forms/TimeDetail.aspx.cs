using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Collections;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication8
{
    public partial class TimeDetail : System.Web.UI.Page
    {
        public DataTier DataTier = new DataTier();
        public BusinessLogic.BusinessTier BusinessTier = new BusinessLogic.BusinessTier();

        public int serverID
        {
            get
            {
                return (int)ViewState["serverID"];
            }
            set
            {
                ViewState["serverID"] = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return (string)ViewState["ConnectionString"];
            }
            set
            {
                ViewState["ConnectionString"] = value;
            }
        }

        public List<string> EstateID
        {
            get
            {
                return (List<string>)ViewState["EstateID"];
            }
            set
            {
                ViewState["EstateID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string isLoaded = Request.Cookies["loaded"].Value;
                if (isLoaded == "1")
                {
                    serverID = Convert.ToInt32(Request.Cookies["ServerID"].Value);
                    if (serverID > 0)
                    {
                        if (serverID == 1)
                        {
                            //DEMERARA DEV
                            ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=bss2)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=psdem1))); User Id = payadminwde; Password=demadpwde;";
                        }
                        else if (serverID == 2)
                        {
                            //BERBICE DEV
                            ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=bss2)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=psber1))); User Id = payadminebe; Password=beradpebe;";
                        }
                        else if (serverID == 3)
                        {
                            //BERBICE
                            ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=psberlive)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=psber1))); User Id = payadminswr; Password=ber_payswr;";
                        }
                        else if (serverID == 4)
                        {
                            //DEMERARA
                            ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=psdemlive)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=psdem1))); User Id = payadminwde; Password=dem_paywde;";
                        }
                        EstateID = DataTier.getLocationID(serverID, BusinessTier.loggedInUser());
                        loadGridviewData();
                        lblServerName.Text = " :: " + Request.Cookies["ServerName"].Value;
                        bool isAdmin = DataTier.IsAdmin(BusinessTier.loggedInUser());
                        if (isAdmin) lblAdmin.Visible = true;
                        else lblAdmin.Visible = false;
                        return;
                    }
                    else Response.Redirect("~/Login.aspx", true);
                }
                else Response.Redirect("~/Login.aspx", true);
            }
        }

        private void toggleEndableDisable(bool value)
        {
            btnRefresh.Visible = value;
            btnSTUpload2.Visible = value;
            btnSTUpload.Visible = value;
            btnRefresh2.Visible = value;
            lbCheckAll.Visible = value;
            lbCheckAll2.Visible = value;
            lbUncheckAll.Visible = value;
            lbUnheckAll2.Visible = value;
            gvTime.Visible = value;
            lblSlash.Visible = value;
            lblSlash2.Visible = value;
        }

        protected void btnSTUpload_Click(object sender, EventArgs e)
        {
            //Upload checked rows to oracle and set status to uploaded in sql database
            string failedRecords = "";
            int failedCommits = 0;
            int checkedCount = 0;


            foreach (GridViewRow rows in gvTime.Rows)
            {
                CheckBox cbSelect = (CheckBox)rows.FindControl("cbSelect");
                if (cbSelect.Checked)
                {
                    checkedCount++;
                    int recordId = 0;
                    if (gvTime.DataKeys[rows.RowIndex].Values[0] != null)
                    {
                        recordId = Convert.ToInt32(gvTime.DataKeys[rows.RowIndex].Values[0]);
                    }
                    int shiftId = 0;
                    if (gvTime.DataKeys[rows.RowIndex].Values[1] != null)
                    {
                        shiftId = Convert.ToInt32(gvTime.DataKeys[rows.RowIndex].Values[1]);
                    }

                    decimal rate = 0;
                    string sRate = rows.Cells[15].Text.TrimEnd(' ');
                    rate = sRate == "-" ? 0 : Convert.ToDecimal(sRate);

                    int estEmpNo = Convert.ToInt32(rows.Cells[6].Text.TrimEnd(' '));
                    //string firstName = rows.Cells[3].Text == "-" ? "" : rows.Cells[3].Text.TrimEnd(' ');
                    //string activityMaster = rows.Cells[16].Text == "-" ? "" : rows.Cells[16].Text.TrimEnd(' ');
                    //string holdingAccCode = rows.Cells[18].Text == "-" ? "" : rows.Cells[18].Text.TrimEnd(' ');
                    //string locationID = rows.Cells[19].Text == "-" ? "" : rows.Cells[19].Text.TrimEnd(' ');
                    //string chargedTo = rows.Cells[20].Text == "-" ? "" : rows.Cells[20].Text.TrimEnd(' ');
                    //string hasSplit = rows.Cells[12].Text.TrimEnd(' ');
                    //string typeOfEntry = rows.Cells[23].Text == "-" ? "" : rows.Cells[23].Text.TrimEnd(' ');
                    //string ssFromtime = "";
                    //string ssTOTime = "";
                    //if (hasSplit == "Y")
                    //{
                    //    ssFromtime = rows.Cells[13].Text;
                    //    ssTOTime = rows.Cells[14].Text;
                    //}
                    //else if (hasSplit == "N")
                    //{
                    //    ssFromtime = "";
                    //    ssTOTime = "";
                    //}

                    //Query to insert into table
                    string insertQuery = "INSERT INTO TBL_2_EXPORT_TIMEDETAILS (" +
                                         "RECORDID," +
                                         "FIRSTNAME," +
                                         "LASTNAME," +
                                         "EMP_SEQ_NO," +
                                         "WORKDATE," +
                                         "SHIFTID," +
                                         "FROMTIME," +
                                         "TOTIME," +
                                         "OVERNIGHT," +
                                         "HASSPLIT," +
                                         "SS_FROMTIME," +
                                         "SS_TOTIME," +
                                         "RATE, " +
                                         "ACTIVITYMASTER, " +
                                         "ACTIVITYCODE," +
                                         "HOLDING_ACC_CODE," +
                                         "LOCATIONID," +
                                         "CHARGEDTO," +
                                         "ESTATELOCATIONID," +
                                         "ESTATEID," +
                                         "TYPEOFENTRY," +
                                         "EST_EMP_NO," +
                                         "TEMPORARYGANG," +
                                         "TEMPORARYGANGOPTION," +
                                         "VEHICLE," +
                                         "RECOVERABLE," +
                                         "QUANTITY)" + 
                                          "VALUES(" +
                                          recordId + ",'" +
                                          rows.Cells[3].Text.TrimEnd(' ') +"','" +
                                          rows.Cells[4].Text + "'," +
                                          rows.Cells[5].Text + ",'" +
                                          rows.Cells[7].Text + "'," +
                                          shiftId + ",'" +
                                          rows.Cells[9].Text + "','" +
                                          rows.Cells[10].Text + "','" +
                                          rows.Cells[11].Text + "','" +
                                          rows.Cells[12].Text + "','" +
                                          rows.Cells[13].Text + "','" +
                                          rows.Cells[14].Text + "'," +
                                          rate + ",'" +
                                          rows.Cells[16].Text + "','" +
                                          rows.Cells[17].Text + "','" +
                                          rows.Cells[18].Text + "','" +
                                          rows.Cells[19].Text + "','" +
                                          rows.Cells[20].Text + "','" +
                                          rows.Cells[21].Text + "','" +
                                          rows.Cells[22].Text + "','" +
                                          rows.Cells[23].Text + "'," +
                                          estEmpNo + ",'" +
                                          rows.Cells[24].Text + "','" +
                                          rows.Cells[25].Text + "','" +
                                          rows.Cells[26].Text + "','" +
                                          rows.Cells[27].Text + "','" +
                                          rows.Cells[28].Text + "')";

                    DataTier.export_to_Oracle(ConnectionString, insertQuery);
                    if (!DataTier.successfulCommit)
                    {
                        failedCommits++;
                        failedRecords += rows.Cells[5].Text + ",";
                    }
                    else
                    {
                        //set upload status
                        DataTier.setUploadStatus_TimeDetails(recordId, BusinessTier.loggedInUser());
                        if (!DataTier.successfulCommit)
                        {
                            failedCommits++;
                            failedRecords += rows.Cells[5].Text + ",";
                            DataTier.deleteRecord(ConnectionString, "TBL_2_EXPORT_TIMEDETAILS", recordId);
                        }
                    }
                }
            }

            if (checkedCount > 0)
            {
                loadGridviewData();
                if (failedCommits > 0)
                {
                    mpeMessage.Show();
                    lblHeader.Text = "ERROR MESSAGE";
                    lblHeader.ForeColor = System.Drawing.Color.Maroon;
                    lblMessage.Text = "An error occured during upload. The following records were not uploaded: " + failedRecords.TrimEnd(',') + ". Kindly retry and if the error persists, contact ISD's HelpDesk for assistance.";
                }
            }
            else
            {
                mpeMessage.Show();
                lblHeader.Text = "MESSAGE";
                lblHeader.ForeColor = System.Drawing.Color.DarkGray;
                lblMessage.Text = "No record checked for upload!";
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            loadGridviewData();
        }

        protected void lbCheckAll_Click(object sender, EventArgs e)
        {
            //set all rows to unchecked
            for (int i = 0; i < gvTime.Rows.Count; i++)
            {
                CheckBox cbSelect = (CheckBox)gvTime.Rows[i].FindControl("cbSelect");
                cbSelect.Checked = true;
            }
        }

        protected void lbUncheckAll_Click(object sender, EventArgs e)
        {
            //set all rows to unchecked
            for (int i = 0; i < gvTime.Rows.Count; i++)
            {
                CheckBox cbSelect = (CheckBox)gvTime.Rows[i].FindControl("cbSelect");
                cbSelect.Checked = false;
            }
        }

        protected void gvTime_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell2 = new TableCell();

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "#";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Select";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Name";
                HeaderCell2.ColumnSpan = 2;
                HeaderCell2.RowSpan = 1;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Emp. Seq No";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Est. Emp No";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Work Date";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Time";
                HeaderCell2.ColumnSpan = 2;
                HeaderCell2.RowSpan = 1;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Over Night";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Has Split";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "SS";
                HeaderCell2.ColumnSpan = 2;
                HeaderCell2.RowSpan = 1;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Rate";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Activity";
                HeaderCell2.ColumnSpan = 2;
                HeaderCell2.RowSpan = 1;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Holding AccCode";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Location";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Charged To";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Estate Location";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Estate";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Type of Entry";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Temporary";
                HeaderCell2.ColumnSpan = 2;
                HeaderCell2.RowSpan = 1;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Vehicle";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Recoverable";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Quantity";
                HeaderCell2.ColumnSpan = 1;
                HeaderCell2.RowSpan = 2;
                HeaderRow.Cells.Add(HeaderCell2);

                //ADDS THE HEADER TO THE GRID
                HeaderRow.Attributes.Add("class", "gvHeader");
                HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                gvTime.Controls[0].Controls.AddAt(0, HeaderRow);

                //THIS IS THE SUB HEADER
                GridViewRow HeaderRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "First";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Last";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "From";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "To";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "From";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "To";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Master";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Code";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Gang";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Gang Option";
                HeaderRow1.Cells.Add(HeaderCell);

                //SETS STYLING FOR THE HEADER
                HeaderRow1.Attributes.Add("class", "gvHeader");
                HeaderRow1.HorizontalAlign = HorizontalAlign.Center;
                //ADDS THE SUB-HEADER TO THE GRID
                gvTime.Controls[0].Controls.AddAt(1, HeaderRow1);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Set the label for the pager -- Page X of X
                int m = e.Row.Cells.Count;

                for (int i = m - 1; i >= 1; i += -1)
                {
                    e.Row.Cells.RemoveAt(i);
                }
                e.Row.Cells[0].ColumnSpan = m;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Text = "Page " + (gvTime.PageIndex + 1) + " of " + gvTime.PageCount;
            }
        }

        protected void gvTime_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //set highlight color when hover over row on grid
                e.Row.Attributes["onmouseover"] = "javascript:SetMouseOver(this)";
                e.Row.Attributes["onmouseout"] = "javascript:SetMouseOut(this)";
            }
        }

        protected void gvTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set new page index when click on page number
            gvTime.PageIndex = e.NewPageIndex;
            loadGridviewData();
        }

        private void loadGridviewData()
        {
            List<string> estates = new List<string>() ;
            if (EstateID.Count > 0)
            {
                foreach (string li in EstateID)
                {
                    estates.Add(li);
                }
            }
            //estates = estates.TrimEnd(',');
            //Select from Entity Data Model to Bind gridview with all records not uploaded.
            var context = new App_Data.AcuPayEntities();

            var query1 = (from a in context.tbl_2_Export_TimeDetails
                          where a.Uploaded.Contains("N") && estates.Contains(a.EstateID)
                          orderby a.WorkDate descending 
                          select new
                          {
                              a.RecordId,
                              a.FirstName,
                              a.LastName,
                              a.Emp_seq_no,
                              a.est_emp_no,
                              a.WorkDate,
                              a.ShiftId,
                              a.FromTime,
                              a.ToTime,
                              a.OverNight,
                              a.HasSplit,
                              a.SS_FromTime,
                              a.SS_ToTime,
                              a.Rate,
                              a.ActivityMaster,
                              a.ActivityCode,
                              a.Holding_Acc_Code,
                              a.LocationId,
                              a.ChargedTo,
                              a.EstateLocationID,
                              a.EstateID,
                              a.TypeOfEntry,
                              a.TemporaryGang,
                              a.TemporaryGangOption,
                              a.Vehicle,
                              a.Recoverable,
                              a.Quantity
                          }).ToList();

            gvTime.DataSource = query1;
            gvTime.DataBind();

            if (gvTime.Rows.Count == 0)
            {
                toggleEndableDisable(false);
                lblTime.Text = "No data available for upload.";
            }
            else if (gvTime.Rows.Count > 0)
            {
                toggleEndableDisable(true);
                lblTime.Text = "Records available for upload: " + query1.Count;
            }
        }

        protected void lbChangeServer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", true);
        }

        protected void lblAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Admin.aspx", true);
        }

        protected void ibClosePopUp_Click(object sender, ImageClickEventArgs e)
        {
            mpeMessage.Hide();
        }
    }

}