using AmigoPaperWorkProcessSystem.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Threading;
using System.Net.Http;

namespace AmigoPaperWorkProcessSystem._3A.Controllers
{
    class _3AController
    {
        #region Declare;
        private string read_file_name;
        #endregion

        #region Methods

        #region ReadFile
        private String ReadTheInputFile()
        {
            FileInfo[] fiArray;
            DirectoryInfo path;

            //get files in amigo directory
            path = new DirectoryInfo(Utility.ImportFolderPath);
            fiArray = path.GetFiles();

            //sorty files my date
            Array.Sort(fiArray, (x, y) => Comparer<DateTime>.Default.Compare(x.CreationTime, y.CreationTime));

            try
            {
               
                read_file_name = fiArray[0].ToString();
                var apiFile = File.ReadAllBytes(Utility.ImportFolderPath + "\\\\" + read_file_name);
                var apitext = Encoding.UTF8.GetString(apiFile);
                if (apitext.Contains("\uFFFD")) // Unicode replacement character
                {
                    apitext = Encoding.GetEncoding(932).GetString(apiFile);
                }
                return apitext;
            }
            catch (IndexOutOfRangeException)
            {
                // no file to read
                MessageBox.Show(Messages.ImportBankDepositData.NoImportFileFound);
                Utility.ExitApp();
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                // reading the file error
                MessageBox.Show(Messages.General.ThereWasAnError);
            }

            return null;

        }
        #endregion

        #region MoveFile
        private void MoveReadFile()
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                File.Move(Utility.ImportFolderPath + "\\\\" + read_file_name, Utility.ProcessedFolderPath + "\\\\" + timestamp + "_" + read_file_name);
            }
            catch (Exception)
            {
                MessageBox.Show(Messages.ImportBankDepositData.FileIsNotMoved);
                Utility.ExitApp();
            }

        }
        #endregion

        #region Do3A
        private async Task<bool> PostFile(ArrayList list)
        {
            try
            {
                //convert arraylist to json object
                String json = JsonConvert.SerializeObject( list );
                //change arraylist json object to string
                json = JsonConvert.SerializeObject(new { file_name = read_file_name, strData = json });
                //encode content
                var data = new StringContent( json, Encoding.UTF8, "application/json");

                //post data
                var client = new HttpClient();

                var byteArray = Encoding.ASCII.GetBytes(Utility.Id + ":" + Utility.Password);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = client.PostAsync(Properties.Settings.Default.ImportBankData, data);

                string content = response.Result.Content.ReadAsStringAsync().Result;

                dynamic result = JsonConvert.DeserializeObject(content);
                //log error message
                if (result.Status == 0)
                {
                    Utility.WriteErrorLog(result.Message.ToString(), null, true);
                }
                return result.Status;

            }
            catch (System.TimeoutException)
            {
                MessageBox.Show(Messages.General.ServerTimeOut);
                Utility.ExitApp();
                return false;
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show(Messages.General.NoConnection);
                Utility.ExitApp();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region ReadFile
        public async Task<bool> ExecuteBatchProcessAsync()
        {
            try
            {
                bool success = true;
                FileInfo[] fiArray;
                DirectoryInfo path;

                //get files in amigo directory
                path = new DirectoryInfo(Utility.ImportFolderPath);
                fiArray = path.GetFiles();

                //sorty files my date
                Array.Sort(fiArray, (x, y) => Comparer<DateTime>.Default.Compare(x.CreationTime, y.CreationTime));

                if (fiArray.Count() > 0)
                {
                    foreach (FileInfo file in fiArray)
                    {
                        read_file_name = file.ToString();
                        var apiFile = File.ReadAllBytes(Utility.ImportFolderPath + "\\\\" + read_file_name);
                        var apitext = Encoding.UTF8.GetString(apiFile);
                        if (apitext.Contains("\uFFFD")) // Unicode replacement character
                        {
                            apitext = Encoding.GetEncoding(932).GetString(apiFile);
                        }

                        ArrayList data = new ArrayList();

                        int lineNumber = 0;
                        int startReadDataLineNumber = 5;

                        foreach (var tempRawData in apitext.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            lineNumber++;
                            if (lineNumber >= startReadDataLineNumber)
                            {
                                // split by tab key
                                data.Add(tempRawData.Split('\t'));

                            }

                        }

                        //push to webservice
                        success = await PostFile(data);
                        if (success)
                        {
                            //move file to processed folder
                            MoveReadFile();

                        }
                        else
                        {
                            success = false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show(Messages.ImportBankDepositData.NoImportFileFound);
                    Utility.ExitApp();
                    return false;
                }
                return success;
            }
            catch (IndexOutOfRangeException)
            {
                // no file to read
                MessageBox.Show(Messages.ImportBankDepositData.NoImportFileFound);
                Utility.ExitApp();
                return false;
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(ex.Message, ex, false);
                // reading the file error
                MessageBox.Show(Messages.General.ThereWasAnError);
                return false;
            }
        }
        #endregion

        #endregion
    }
}
