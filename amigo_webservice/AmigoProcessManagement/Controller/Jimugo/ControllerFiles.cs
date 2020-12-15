using AmigoProcessManagement.Utility;
using DAL_AmigoProcess.BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AmigoProcessManagement.Controller.Jimugo
{

    public class ControllerFiles
    {
        #region Declare
        string con = Properties.Settings.Default.MyConnection;
        #endregion

        #region GetFile
        public byte[] GetFile(string PATH, string FILENAME)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(PATH + "/" + FILENAME, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }
        #endregion

        #region GetTempFile
        public byte[] GetTempFile(string FILENAME)
        {
            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            return GetFile(tempStorageFolder, FILENAME);
        }
        #endregion

        #region DeleteTempFile
        public Response DeleteTempFile(string FILENAME)
        {
            BOL_CONFIG config = new BOL_CONFIG("SYSTEM", con);
            String tempStorageFolder = config.getStringValue("temp.dir");
            Response response = new Response();
            string[] filenames = FILENAME.Split(';');
            response.Status = 1;
            for (int i = 0; i < filenames.Length; i++)
            {
                try
                {
                    System.IO.File.Delete(tempStorageFolder + "/" + filenames[i]);
                }
                catch (Exception)
                {
                    response.Status = 0;
                }
            }
           
            return response;
        }
        #endregion
    }
}