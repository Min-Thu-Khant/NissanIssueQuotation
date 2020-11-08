using AmigoPaperWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigoPaperWorkProcessSystem.Controllers.PurchaseOrder
{
    public class frmPurchaseOrderPreviewController
    {
        #region SubmitPurchaseOrder
        public DataTable Submit(DataTable list, string filepath, string extension)
        {
            string url = Properties.Settings.Default.SubmitPurchaseOrder;
            return WebUtility.PostWithFile(url, list, filepath, extension);
        }
        #endregion
    }
}
