using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication8.Account
{
    public partial class Login : Page
    {

        public BusinessLogic.BusinessTier BusinessTier = new BusinessLogic.BusinessTier();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check if the browser supports cookies
                if (Request.Browser.Cookies)
                {
                    lblMessage.Visible = false;
                    tblLogin.Visible = true;
                    
                    HttpCookie cloaded = new HttpCookie("loaded");
                    Response.Cookies.Remove("loaded");
                    cloaded.Value = "0";
                    Response.Cookies.Add(cloaded);

                    loadServers(BusinessTier.loggedInUser());
                    
                }
                else
                {
                    //browser does not support cookies
                    lblMessage.Visible = true;
                    lblMessage.Text = "Your browser does not have cookies enabled. Kindly contact your location's Net Admin or ISD's HelpDesk for assistance.";
                    tblLogin.Visible = false;
                }
            }
        }

        private void loadServers(string loggedInUser)
        {
            //Select from Entity Data Model to Bind gridview with all records not uploaded.
            var context = new App_Data.AcuPayEntities();

            var query1 = (from a in context.tbl_Servers
                          join b in context.tbl_Users_Servers on a.ServerID equals b.ServerID
                          join c in context.tbl_Users on b.UserID equals c.UserID
                          where c.UserName == loggedInUser && c.Active == true
                          select new 
                          {
                              a.ServerID,
                              a.Server
                          }).ToList();

           

            if (query1.Count == 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "You are not authorized for this application. Kindly contact ISD's HelpDesk for assistance.";
                tblLogin.Visible = false;
            }
            else if (query1.Count == 1)
            {
                var sortedResult = query1.Distinct().ToList();
                ddlServers.DataSource = sortedResult;
                ddlServers.DataTextField = "Server";
                ddlServers.DataValueField = "ServerID";
                ddlServers.DataBind();

                //Auto login if the user only has one server attached to them for upload
                HttpCookie cServerID = new HttpCookie("ServerID");
                Response.Cookies.Remove("ServerID");
                cServerID.Value = ddlServers.SelectedValue;
                Response.Cookies.Add(cServerID);

                HttpCookie cServerName = new HttpCookie("ServerName");
                Response.Cookies.Remove("ServerName");
                cServerName.Value = ddlServers.SelectedItem.Text;
                Response.Cookies.Add(cServerName);

                HttpCookie cloaded = new HttpCookie("loaded");
                Response.Cookies.Remove("loaded");
                cloaded.Value = "1";
                Response.Cookies.Add(cloaded);

                Response.Redirect("~/Forms/TimeDetail.aspx", false);
            }
            else if (query1.Count > 0)
            {
                var sortedResult = query1.Distinct().ToList();
                ddlServers.DataSource = sortedResult;
                ddlServers.DataTextField = "Server";
                ddlServers.DataValueField = "ServerID";
                ddlServers.DataBind();

                lblMessage.Visible = false;
                tblLogin.Visible = true;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
             HttpCookie cServerID = new HttpCookie("ServerID");
             Response.Cookies.Remove("ServerID");
             cServerID.Value = ddlServers.SelectedValue;
             Response.Cookies.Add(cServerID);

             HttpCookie cServerName = new HttpCookie("ServerName");
             Response.Cookies.Remove("ServerName");
             cServerName.Value = ddlServers.SelectedItem.Text;
             Response.Cookies.Add(cServerName);

             HttpCookie cloaded = new HttpCookie("loaded");
             Response.Cookies.Remove("loaded");
             cloaded.Value = "1";
             Response.Cookies.Add(cloaded);

             Response.Redirect("~/Forms/TimeDetail.aspx", false);
        }
    }
}