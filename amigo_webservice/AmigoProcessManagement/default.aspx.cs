using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AmigoProcessManagement.Controller;

namespace AmigoProcessManagement
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindData();
        }

        protected void bindData()
        {
            //opt_3A o3A = new opt_3A();
            //o3A.do_3A(Properties.Settings.Default.APITEST);

            opt_3B o3B = new opt_3B();
            o3B.do_3B();
            //Controller3B o3B = new Controller3B(Properties.Settings.Default.MyConnection);
            //Response.Write(o3B.do3B_BatchProcess());
            //DataTable dt = o3B.do3B_BatchProcess();
            //gv.DataSource = dt;
            //gv.DataBind();
            //opt_3A o3A = new opt_3A();
            //o3A.do_3A(Properties.Settings.Default.APITEST);
            //Controller.Controller3A o3A = new Controller.Controller3A(Properties.Settings.Default.APITEST,Properties.Settings.Default.MyConnection);
            //Response.Write("Total Row :" + o3A.dtUploadData.Rows.Count.ToString() + "<br/>");
            //Response.Write("Amigo Row :" + o3A.lstAmigo.Count.ToString() + "<br/>");
            //Response.Write("Non Amigo Row :" + o3A.lstNonAmigo.Count.ToString() + "<br/>");
            //gv.DataSource = o3A.dtUploadData;
            //gv.DataBind();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("tbl");
            //dt.Columns.Add("CustomerName");
            //dt.Columns.Add("Error");
            //string strMSG = "";
            //for (int i = 0; i < o3A.lstAmigo.Count; i++)
            //{
            //    strMSG = "";
            //    o3A.lstAmigo[i].insert(out strMSG);
            //    if (strMSG != "")
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["tbl"] = "Amigo";
            //        dr["CustomerName"] =o3A.lstAmigo[i].CUSTOMER_NAME;
            //        dr["Error"] = strMSG;
            //        dt.Rows.Add(dr);
            //    }
            //}

            //for (int i = 0; i < o3A.lstNonAmigo.Count; i++)
            //{
            //    strMSG = "";
            //    o3A.lstNonAmigo[i].insert(out strMSG);
            //    if (strMSG != "")
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["tbl"] = "Amigo";
            //        dr["CustomerName"] = o3A.lstNonAmigo[i].CUSTOMER_NAME;
            //        dr["Error"] = strMSG;
            //        dt.Rows.Add(dr);
            //    }
            //}

            //gv.DataSource = dt;
            //gv.DataBind();
        }
    }
}