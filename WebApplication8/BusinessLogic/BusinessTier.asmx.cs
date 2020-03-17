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

namespace WebApplication8.BusinessLogic
{
    /// <summary>
    /// Summary description for BusinessTier
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BusinessTier : System.Web.Services.WebService
    {

        //FUNCTION TO GET THE CURRENTLY LOGGED IN USER
        public string loggedInUser()
        {
            string vuser = this.Context.Request.LogonUserIdentity.Name;
            vuser = vuser.Remove(0, 8);
            //vuser = vuser + "@guysuco.com";
            vuser = (vuser.ToUpper());
            return vuser.ToString();
        }
    }
}
