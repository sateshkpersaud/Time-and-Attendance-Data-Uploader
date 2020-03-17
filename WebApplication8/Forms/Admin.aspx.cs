using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client; 

namespace WebApplication8
{
    public partial class Admin : System.Web.UI.Page
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
                        if ((serverID == 1) || (serverID == 2))
                        {
                            ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=bss2)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=psdem1))); User Id = payadminwde; Password=demadpwde;";
                            EstateID = DataTier.getLocationID(serverID, BusinessTier.loggedInUser());
                        }
                    }
                    else Response.Redirect("~/Login.aspx", true);
                }
                else Response.Redirect("~/Login.aspx", true);
            }
        }

        private void toggleEndableDisable(bool value)
        {
            //btnRefresh.Visible = value;
            //btnSTUpload2.Visible = value;
            //btnSTUpload.Visible = value;
            //btnRefresh2.Visible = value;
            //lbCheckAll.Visible = value;
            //lbCheckAll2.Visible = value;
            //lbUncheckAll.Visible = value;
            //lbUnheckAll2.Visible = value;
            //gvTime.Visible = value;
            //lblSlash.Visible = value;
            //lblSlash2.Visible = value;
        }

       
    }
}