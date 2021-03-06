﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.DAL;

namespace AmigoProcessManagement.Controller
{
    public class ControllerJimugoMenu
    {
        #region Declare
        Response response;
        #endregion

        #region Constructor
        public ControllerJimugoMenu()
        {
            response = new Response();
        }
        #endregion

        #region GetJimugoTreeMenu
        public Response GetJimugoTreeMenu()
        {
            try
            {

                MENU_MASTER oRecpt = new MENU_MASTER(Properties.Settings.Default.MyConnection);
                string strMessage = "";
                DataTable dt = oRecpt.getTreeMenu(out strMessage);
                response.Data = Utility.Utility_Component.DtToJSon(dt, "Menu");
                if (dt.Rows.Count > 0)
                {
                    response.Status = 1;
                }
                else
                {
                    if (strMessage == "")
                    {
                        response.Status = 1;
                        response.Message = "There is no data to display.";
                    }
                    else
                    {
                        response.Status = 0;
                        response.Message = strMessage;
                    }
                }
                return response;
            }
            catch (Exception)
            {
                response.Status = 0;
                response.Message = " Unexpected error occour.";
                return response;
            }
        }
        #endregion
    }
}