using AmigoPapaerWorkProcessSystem.Core;
using AmigoPaperWorkProcessSystem.Core.Model;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmigoPaperWorkProcessSystem.Core
{
    public class UIUtility
    {
        #region Declare
        public Meta MetaData = new Meta();
        public DataTable dtList;
        public DataTable dtOrigin;
        private DataGridView dgvList;
        private List<Validate> Insertable;
        private List<Validate> Copyable;
        private List<Validate> Modifiable;
        private string[] dummyColumns;
        private int index_key;

        public enum Direction { north, east, south, west };

        #endregion

        #region Constructors
        public UIUtility(
            DataGridView dvg,
            List<Validate> insertable,
            List<Validate> copyable,
            List<Validate> modifiable,
            string[] dummyColumns
            )
        {
            this.dgvList = dvg;
            this.Insertable = insertable;
            this.Copyable = copyable;
            this.Modifiable = modifiable;
            this.dummyColumns = dummyColumns;
            Utility.DoubleBuffered(dgvList,true);
        }

        public UIUtility()
        {

        }
        #endregion

        #region CalculatePagination
        public void CalculatePagination(Label lblcurrentPage, Label lblTotalPages, Label lblTotalRecords)
        {
            lblTotalRecords.Text = MetaData.Total + " 件見つかりました。( " + Math.Round(MetaData.Duration, 2).ToString() + " 秒 )";
            int currentPage = 0;
            if (MetaData.Total != 0)
            {
                currentPage = MetaData.Offset == 0 ? 1 : (MetaData.Offset / MetaData.Limit) + 1;
            }
            else
            {
                currentPage = 0;
            }
            lblcurrentPage.Text = currentPage.ToString();
            lblTotalPages.Text = (Math.Ceiling((decimal)MetaData.Total / (decimal)MetaData.Limit).ToString()) + " Pages";
            index_key = MetaData.Total;
            ResetReadOnlyProperty();
        }
        #endregion

        #region ResetReadOnlyProperty
        private void ResetReadOnlyProperty()
        {
            foreach (DataGridViewColumn col in dgvList.Columns)
            {
                if (col.Name == "colCK")
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
        }
        #endregion

        #region DisableAutoSort
        public void DisableAutoSort()
        {
            foreach (DataGridViewColumn col in dgvList.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion

        #region ResetCheckBoxSize
        public void ResetCheckBoxSize()
        {
            try
            {
                dgvList.Columns["colNo"].Width = 30;
                dgvList.Columns["colMK"].Width = 30;
                dgvList.Columns["colCK"].Width = 30;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region CheckSelectedRow
        public bool checkSelectedRow()
        {
            bool found = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                string checkvalue = row.Cells["colCK"].Value.ToString().Trim();
                if (String.IsNullOrEmpty(checkvalue) ? false : true)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        #endregion

        #region CheckMKValue
        public bool CheckMKValue()
        {
            bool found = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                string mkvalue = row.Cells["colMK"].Value.ToString().Trim();
                if (String.IsNullOrEmpty(mkvalue) ? false : true)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        #endregion

        #region IsInModifyMode
        public bool IsInModifyMode()
        {
            
            bool inEditMode = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                string mkValue = row.Cells["colMK"].Value.ToString();
                if (mkValue == "C" || mkValue == "I" || mkValue =="M" || mkValue == "D")
                {
                    var confirmResult = MetroMessageBox.Show(dgvList.Parent, "\n" + JimugoMessages.I000ZZ021, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        inEditMode = false;
                        break;
                    }
                    else
                    {
                        inEditMode = true;
                        break;
                    }
                }
            }
            return inEditMode;
        }
        #endregion

        #region IsInInsertOrCopyMode
        public bool IsInInsertOrCopyMode()
        {
            bool inInsertCopyMode = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                string mkValue = row.Cells["colMK"].Value == null ? null : row.Cells["colMK"].Value.ToString().Trim();
                string ckValue = row.Cells["colCK"].Value == null ? null : row.Cells["colCK"].Value.ToString().Trim();

                if ( (!string.IsNullOrEmpty(ckValue)) &&  (mkValue == "C" || mkValue == "I"))
                {
                    
                    inInsertCopyMode = true;
                    break;
                }
            }
            return inInsertCopyMode;
        }
        #endregion

        #region checkAll
        public void CheckAll(bool state)
        {
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                row.Cells["colCK"].Value = state==true? "true":" ";
            }
        }
        #endregion

        #region PopulateDropdowns

        #region DisplayCountCombo
        public void DisplayCountCombo(ComboBox cboLimit)
        {
            var displaycount = new[] {
                                    new { Text = "100", Value = "100" },
                                    new { Text = "500", Value = "500" },
                                  };

            cboLimit.DataSource = displaycount;
            cboLimit.DisplayMember = "Text";
            cboLimit.ValueMember = "Value";

            cboLimit.SelectedIndex = 0;
        }
        #endregion

        #region GDComboBOX
        public void GDCombo(ComboBox cboGD)
        {
            var displaycount = new[] {
                                    new { Text = "", Value = "" },
                                    new { Text = "未確認", Value = "0" },
                                    new { Text = "設定依頼中", Value = "1" },
                                    new { Text = "設定済み", Value = "2" },
                                    new { Text = "無し", Value = "9" }
                                  };

            cboGD.DataSource = displaycount;
            cboGD.DisplayMember = "Text";
            cboGD.ValueMember = "Value";
            cboGD.SelectedIndex = -1;
        }
        #endregion

        #region ApplicationStatusComboBox
        public void AppStatusCombo(ComboBox cboApplicationStatus)
        {
            var displaycount = new[] {
                                    new { Text = "", Value = "" },
                                    new { Text = "申請中", Value = "1" },
                                    new { Text = "承認済", Value = "2" },
                                    new { Text = "申請取消", Value = "9" },
                                  };

            cboApplicationStatus.DataSource = displaycount;
            cboApplicationStatus.DisplayMember = "Text";
            cboApplicationStatus.ValueMember = "Value";
            cboApplicationStatus.SelectedIndex = -1;
        }
        #endregion

        #region SystemSettingStatusCombobox
        public void SystemSettingStatusCombo(ComboBox cboSettingStatus)
        {
            var displaycount = new[] {
                                    new { Text = "", Value = ""},
                                    new { Text = "設定依頼中", Value = "1" },
                                    new { Text = "設定済み", Value = "2" },
                                  };

            cboSettingStatus.DataSource = displaycount;
            cboSettingStatus.DisplayMember = "Text";
            cboSettingStatus.ValueMember = "Value";
            cboSettingStatus.SelectedIndex = -1;
        }
        #endregion
        #endregion

        #region ResetHeader
        public void ResetHeader(int value = 0)
        {
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            if (value != 0)
            {
                dgvList.ColumnHeadersHeight = value;
            }
            else
            {
                dgvList.ColumnHeadersHeight = 40;
            }

            dgvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ResetCheckBoxSize();
        }
        #endregion

        #region ClearGrid
        public void ClearDataGrid()
        {
            //clear data except headers
            var empty = dgvList.DataSource as DataTable;
            try
            {
                empty.Rows.Clear();
            }
            catch (Exception)//handle null result on first search
            {

            }
            dgvList.DataSource = empty;
        }
        #endregion

        #region CheckPaginationButtons
        public void CheckPagination(Button btnFirst, Button btnPrev, Button btnNext, Button btnLast, string current, string totalPages)
        {
            string total = totalPages.Replace("Pages", "").Trim();
            if ((current == "1" && total == "1") || (current == "0" && total == "0")) //there is only one page or in last page
            {
                btnNext.Enabled = false;
                btnPrev.Enabled = false;
                btnFirst.Enabled = false;
                btnLast.Enabled = false;

            }
            else if (current == "1") //first page
            {
                btnNext.Enabled = true;
                btnPrev.Enabled = false;
                btnFirst.Enabled = false;
                btnLast.Enabled = true;

            }else if (current == total)
            {
                btnNext.Enabled = false;
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
            }
        }
        #endregion

        #region CheckForDisableFiled
        public void CheckForDisableField()
        {
            //check for disable flag
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                string disable_flg = dgvList.Rows[i].Cells["colDISABLED_FLG"].Value.ToString();
                string ck_value = dgvList.Rows[i].Cells["colCK"].Value == null ? "" : dgvList.Rows[i].Cells["colCK"].Value.ToString();
                if (disable_flg == "*" && ck_value.Trim() == "")
                {
                    ChangeToDisableColor(dgvList.Rows[i]);
                }
            }
        }
        #endregion

        #region InsertMode
        public void InsertMode(string Mode, DataGridViewRow row, bool above)
        {
            index_key++;
            DataRow drToAdd = dtList.NewRow();
            drToAdd["ROW_ID"] = index_key;
            int offset = 1;
            if (above)
            {
                dtList.Rows.InsertAt(drToAdd, row.Index);
                offset = -1;
            }
            else
            {
                dtList.Rows.InsertAt(drToAdd, row.Index + 1);
                
            }
            
            dgvList.Rows[row.Index + offset].Cells["colMK"].Value = Mode;


        }
        #endregion

        #region CopyMode
        public void CopyMode(string Mode, DataGridViewRow row, bool copy)
        {
            InsertMode(Mode, row, false);
          
        }
        #endregion

        #region InsertInitialRow
        public void InsertInitialRow(string Mode)
        {
            index_key++;
            int count = dtList.Rows.Count;

            DataRow drToAdd = dtList.NewRow();
            drToAdd["ROW_ID"] = index_key;
            dtList.Rows.InsertAt(drToAdd, count);
            dgvList.Rows[count].Cells["colMK"].Value = Mode;
        }
        #endregion

        #region WatchMKValue
        public void WatchMKValue(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvList.Columns["colMK"].Index)
                {
                    //reset to default colors
                    resetColors(dgvList.Rows[e.RowIndex]);

                    string value = dgvList.Rows[e.RowIndex].Cells["colMK"].Value.ToString();

                    switch (value)
                    {
                        case "M":
                            foreach (Validate item in Modifiable)
                            {
                                //change to insertMode
                                if (item.Edit)
                                {
                                    ChangeToEditColor(e.RowIndex, item.Name);
                                }
                            }
                           
                            break;
                        case "I":
                            #region InsertModeInitialValues
                            foreach (Validate item in Insertable)
                            {
                               
                                //change to insertMode
                                if (item.Edit)
                                {
                                    ChangeToEditColor(e.RowIndex, item.Name);
                                }

                                if (!String.IsNullOrEmpty(item.Initial))
                                {
                                    //insert initial values
                                    dgvList.Rows[e.RowIndex].Cells[item.Name].Value = item.Initial;
                                }
                            }
                            #endregion
                            break;
                        case "C":
                            #region CopyModeInitialValues
                            foreach (Validate item in Copyable)
                            {
                                //copymode
                                if (item.Edit)
                                {
                                    ChangeToEditColor(e.RowIndex, item.Name);
                                }
                                if (item.Initial == "copy")
                                {
                                    //copy from above row
                                    dgvList.Rows[e.RowIndex].Cells[item.Name].Value = dgvList.Rows[e.RowIndex-1].Cells[item.Name].Value;
                                }else if (!String.IsNullOrEmpty(item.Initial))
                                {
                                    //insert initial value
                                    dgvList.Rows[e.RowIndex].Cells[item.Name].Value = item.Initial;
                                }

                            }
                            #endregion
                            break;
                        case "D":
                            //change to delete mode color
                            ChangeToDeleteColor(dgvList.Rows[e.RowIndex]);
                            break;
                        case "O":
                            //change to success color
                            ChangeToSuccessColor(dgvList.Rows[e.RowIndex]);
                            break;
                        case "X":
                            //change to fail color
                            ChangeToDeleteColor(dgvList.Rows[e.RowIndex]);
                            break;
                        case "-":
                            //change to delete success color
                            ChangeToDeleteSuccessColor(dgvList.Rows[e.RowIndex]);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region ResetColors
        public void resetColors(DataGridViewRow row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                //set colors to default
                row.Cells[i].Style.BackColor = Color.White;
                row.Cells[i].Style.ForeColor = Color.Black;
                row.Cells[i].ReadOnly = true;
            }
            row.Cells["colCK"].ReadOnly = false;
        }
        #endregion

        #region ChangeToEditColor
        public void ChangeToEditColor(int index, string name)
        {
            foreach (DataGridViewCell cell in dgvList.Rows[index].Cells)
            {
                if (cell.OwningColumn.Name == name)
                {
                    //set colors for edit mode
                    if (cell.OwningColumn.Name != "colCK")
                    {
                        cell.Style.BackColor = Color.Yellow;
                        cell.ReadOnly = false;
                    }
                }
                cell.Style.ForeColor = Color.Blue;
            }
            dgvList.Rows[index].Cells["colCK"].ReadOnly = false;
        }
        #endregion

        #region ChangeToDeleteColor
        public void ChangeToDeleteColor(DataGridViewRow row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                //set read only to false
                if (dgvList.Columns[i].Name != "colCK")
                {
                    row.Cells[i].ReadOnly = true;
                }
                else
                {
                    row.Cells[i].ReadOnly = false;
                }

                //set color for delete mode
                row.Cells[i].Style.BackColor = Color.White;
                row.Cells[i].Style.ForeColor = Color.Red;
            }
        }
        #endregion

        #region ChangeToDisableColor
        public void ChangeToDisableColor(DataGridViewRow row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                //set read only to false
                if (dgvList.Columns[i].Name != "colCK")
                {
                    row.Cells[i].ReadOnly = true;
                }

                //set color for delete mode
                row.Cells[i].Style.BackColor = Color.Gray;
                row.Cells[i].Style.ForeColor = Color.Black;
            }
        }
        #endregion

        #region ChangeToDeleteSuccessColor
        public void ChangeToDeleteSuccessColor(DataGridViewRow row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                //set read only to false
                if (dgvList.Columns[i].Name!="colCK")
                {
                    row.Cells[i].ReadOnly = true;
                }

                //set color for delete mode
                row.Cells[i].Style.BackColor = Color.White;
                row.Cells[i].Style.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region ChangeToSuccessColor
        public void ChangeToSuccessColor(DataGridViewRow row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                //set read only to false
                if (dgvList.Columns[i].Name != "colCK")
                {
                    row.Cells[i].ReadOnly = true;
                }

                //set color for delete mode
                row.Cells[i].Style.BackColor = Color.White;
                row.Cells[i].Style.ForeColor = Color.Green;
            }
        }
        #endregion
     
        #region SubmitChanges
        public DataTable SubmitChanges()
        {
            //commit changes
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //clone grid table
            DataTable dt = dtList.Clone();

            if (CheckMKValue())
            {
                var confirmResult = MetroMessageBox.Show(dgvList.Parent, "\n" + "更新してもよろしいですか?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    //loop through DataGridView
                    for (int i = 0; i < dgvList.Rows.Count; i++)
                    {
                        //get MK value
                        string MK_value = dgvList.Rows[i].Cells["colMK"].Value == null ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString();
                        if (!String.IsNullOrEmpty(MK_value.Trim()))
                        {
                            switch (MK_value)
                            {
                                case "I":
                                    ValidateSubmit(dt, i, Insertable);
                                    break;
                                case "M":
                                    ValidateSubmit(dt, i, Modifiable);
                                    break;
                                case "C":
                                    ValidateSubmit(dt, i, Copyable);
                                    break;
                                case "D":
                                    dt.Rows.Add(dtList.Rows[i].ItemArray);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    dtOrigin = dtList;
                }
            }
            return dt;
        }
        #endregion

        #region GetCheckedValues
        public DataTable GetCheckedValuesForMail()
        {
            //commit changes
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            //clone grid table
            DataTable dt = dtList.Clone();

            //loop through DataGridView
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                //get MK value
                string CKvalue = Convert.ToString(dgvList.Rows[i].Cells["colCK"].Value).Trim();
                string MKvalue = Convert.ToString(dgvList.Rows[i].Cells["colMK"].Value).Trim();
                if (!string.IsNullOrEmpty(CKvalue))// if CK is not empty
                {
                    if (string.IsNullOrEmpty(MKvalue)) //if CM is also empty
                    {
                        dt.Rows.Add(dtList.Rows[i].ItemArray);
                    }
                    else
                    {
                        dgvList.Rows[i].Cells["colMK"].Value = "X";
                        dgvList.Rows[i].Cells["colUPDATE_MESSAGE"].Value = "MKにフラグがあると送信できません";
                    }
                }
            }
            dtOrigin = dtList;
            return dt;
        }
        #endregion

        #region Validate
        private void ValidateSubmit(DataTable dt, int index, List<Validate> items)
        {
            //check for require fields
            if (CheckUtility.RequireCheck(dgvList, index, items))
            {
                //check for data types
                if (CheckUtility.DataTypeCheck(dgvList, index, items))
                {
                    if (CheckUtility.LengthCheck(dgvList, index, items))
                    {
                        dt.Rows.Add(dtList.Rows[index].ItemArray);
                    }
                }
            }
        }
        #endregion

        #region CancelChanges
        public void CancelChanges()
        {
            //commit changes
            dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (checkSelectedRow())
            {

                for (int i = 0; i < dgvList.Rows.Count; i++)
                {

                    bool status = dgvList.Rows[i].Cells["colCK"].Value.ToString().Trim() == "" ? false : bool.Parse(dgvList.Rows[i].Cells["colCK"].Value.ToString());
                    if (status)
                    {
                        try
                        {
                            string operation = String.IsNullOrEmpty(dgvList.Rows[i].Cells["colMK"].Value.ToString().Trim()) ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString().Trim();
                            DataRow dr = dtList.Rows[i];

                            switch (operation)
                            {
                                case "I":
                                    dr.Delete(); //delete row
                                    i--;
                                    break;
                                case "C":
                                    dr.Delete(); //delete row
                                    i--;
                                    break;
                                case "M":
                                    //get index number by no
                                    int index = OriginFindIndexByKeyNumber(int.Parse(dgvList.Rows[i].Cells["ROW_ID"].Value.ToString()));

                                    //change MK value to trigger event
                                    dgvList.Rows[i].Cells["colMK"].Value = dtOrigin.Rows[index]["MK"].ToString();

                                    //replace modified datarow with original datarow
                                    dtList.Rows[i].ItemArray = dtOrigin.Rows[index].ItemArray;
                                    dgvList.Rows[i].Cells["colCK"].Value = "True";
                                    break;
                                case "D":
                                    //set MK to empty
                                    dgvList.Rows[i].Cells["colMK"].Value = " ";
                                    break;
                                default:
                                    break;
                            }
                            ResetReadOnlyProperty();
                        }
                        catch (Exception)
                        {

                        }

                    }
                    try
                    {
                        dgvList.Rows[i].Cells["colCK"].Value = " ";
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            else
            {
                MetroMessageBox.Show(dgvList.Parent, "\n" + JimugoMessages.E000ZZ004, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Find Record by Row Number
        public int OriginFindIndexByKeyNumber(int RowNo)
        {
            //search index from Original Table
            int index = dtOrigin.Rows.IndexOf(dtOrigin.Select("ROW_ID =" + RowNo)[0]);

            //incase of index -1
            return index < 0 ? 0 : index;
        }
        #endregion

        #region GenerateDefaultTalbe
        public void DummyTable(int value = 0)
        {
            dtList = new DataTable();

            for (int i = 0; i < dummyColumns.Length; i++)
            {
                dtList.Columns.Add(dummyColumns[i]);
            }
            dgvList.DataSource = dtList;
            ResetHeader(value);
        }
        #endregion

        #region MergeHeader
        public static void Merge_Header(PaintEventArgs e, int index, int count, string text, DataGridView dgvList)
        {
            try
            {
                //Offsets to adjust the position of the merged Header.
                int heightOffset = -4;
                int widthOffset = 0;
                int xOffset = 1;
                int yOffset = 2;

                //Index of Header column from where the merging will start.
                int columnIndex = index;

                //Number of Header columns to be merged.
                int columnCount = count;

                //Get the position of the Header Cell.
                Rectangle headerCellRectangle = dgvList.GetCellDisplayRectangle(columnIndex, -1, true);

                //X coordinate  of the merged Header Column.
                int xCord = headerCellRectangle.Location.X + xOffset;

                //Y coordinate  of the merged Header Column.
                int yCord = headerCellRectangle.Location.Y + yOffset;

                //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
                int all_column_width = 0;
                for (int i = 0; i < columnCount; i++)
                {
                    all_column_width += dgvList.Columns[columnIndex + i].Width;
                }
                int mergedHeaderWidth = all_column_width + widthOffset -2;

                //Generate the merged Header Column Rectangle.
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, (headerCellRectangle.Height / 2) + heightOffset);

                //draw rectangle border
                Pen pen = new Pen(Color.Silver, 1);
                e.Graphics.DrawRectangle(pen, mergedHeaderRect);

                ////Draw the merged Header Column Rectangle.
                Brush brush = new SolidBrush(Color.FromArgb(64, 64, 64));
                e.Graphics.FillRectangle(brush, mergedHeaderRect);

                //Draw the merged Header Column Text.
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(text, dgvList.ColumnHeadersDefaultCellStyle.Font, Brushes.Silver, mergedHeaderRect, format);

            }
            catch (Exception)
            {
            }
        }

        public static void Merge_Header(PaintEventArgs e, int index, int count, string text, DataGridView dgvList, int rowcount, int row)
        {
            try
            {
                //Offsets to adjust the position of the merged Header.
                int heightOffset = -1;
                int widthOffset = 0;
                int xOffset = 1;
                int yOffset = 2;

                //Index of Header column from where the merging will start.
                int columnIndex = index;

                //Number of Header columns to be merged.
                int columnCount = count;

                //Get the position of the Header Cell.
                Rectangle headerCellRectangle = dgvList.GetCellDisplayRectangle(columnIndex, -1, true);

                //X coordinate  of the merged Header Column.
                int xCord = headerCellRectangle.Location.X + xOffset;

                //Y coordinate  of the merged Header Column.
                int yCord = headerCellRectangle.Location.Y + yOffset;

                //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
                int all_column_width = 0;
                for (int i = 0; i < columnCount; i++)
                {
                    all_column_width += dgvList.Columns[columnIndex + i].Width;
                }
                int mergedHeaderWidth = all_column_width + widthOffset - 2;

                if (row == 1)
                {
                    yCord = yCord + (headerCellRectangle.Height / rowcount);
                }

                //Generate the merged Header Column Rectangle.
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, (headerCellRectangle.Height / rowcount) + heightOffset);

                //draw rectangle border
                Pen pen = new Pen(Color.Silver, 1);
                e.Graphics.DrawRectangle(pen, mergedHeaderRect);

                ////Draw the merged Header Column Rectangle.
                Brush brush = new SolidBrush(Color.FromArgb(64, 64, 64));
                e.Graphics.FillRectangle(brush, mergedHeaderRect);

                //Draw the merged Header Column Text.
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(text, dgvList.ColumnHeadersDefaultCellStyle.Font, Brushes.Silver, mergedHeaderRect, format);

            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region UpdateReturnedResults
        public bool UpdateReturnedresults(DataTable results)
        {
            for (int i = 0; i < results.Rows.Count; i++)
            {
                //find row index by no
                int key =  OriginFindIndexByKeyNumber(int.Parse(results.Rows[i]["ROW_ID"].ToString()));

                //to trigger cell value change event in datagrid
                dgvList.Rows[key].Cells["colMK"].Value = results.Rows[i]["MK"];

                //replace data row
                dtList.Rows[key].ItemArray = results.Rows[i].ItemArray;
            }
            return true;
        }
        #endregion

        #region CommonGridManage
        public void CommonGridManage(string operation)
        {
            //if there is no row in datagrid view and insert button is clicked
            bool Ischecked = checkSelectedRow();
            if ((dgvList.Rows.Count <= 0 && operation == "I") || (!Ischecked && operation == "I"))
            {
                InsertInitialRow(operation);
            }

            if (checkSelectedRow())
            {
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    string originalvalue = dgvList.Rows[i].Cells["colMK"].Value == null ? null : dgvList.Rows[i].Cells["colMK"].Value.ToString();
                    string checkvalue = dgvList.Rows[i].Cells["colCK"].Value.ToString().Trim();

                    if (String.IsNullOrEmpty(checkvalue) ? false : true)
                    {
                        switch (operation)
                        {
                            case "I":
                                InsertMode(operation, dgvList.Rows[i], true);
                                i++;
                                break;
                            case "M":
                                if (originalvalue != "D" || String.IsNullOrEmpty(originalvalue == null ? null : originalvalue.Trim()) || originalvalue == "O" || originalvalue == "X")
                                {
                                    dgvList.Rows[i].Cells["colMK"].Value = operation;
                                }
                                break;
                            case "D":
                                if (originalvalue == "I" || originalvalue == "C")
                                {
                                    dtList.Rows[i].Delete(); //delete row
                                    i--;
                                }
                                else
                                {
                                    dgvList.Rows[i].Cells["colMK"].Value = operation;
                                }
                                break;
                            case "C":
                                CopyMode(operation, dgvList.Rows[i], true);
                                try
                                {
                                    dgvList.Rows[i].Cells["colCK"].Value = " ";
                                }
                                catch (Exception)
                                {
                                }
                                i++;
                                break;
                            default:
                                break;
                        }
                    }
                    try
                    {
                        dgvList.Rows[i].Cells["colCK"].Value = " ";
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                if ((operation != "I"))
                {
                    MetroMessageBox.Show(dgvList.Parent, "\n" + JimugoMessages.E000ZZ004, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region FormatUpdatedAt
        public void FormatUpdatedat()
        {
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                    try
                    {
                        string value = dgvList.Rows[i].Cells["colUPDATED_AT"].Value == null ? null : dgvList.Rows[i].Cells["colUPDATED_AT"].Value.ToString();

                        DateTime dt = DateTime.ParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                        dgvList.Rows[i].Cells["colUPDATED_AT"].Value = dt.ToString("yyyy/MM/dd HH:mm");
                    }
                    catch (Exception)
                    {

                    }
            }
        }
        #endregion

        #region cboDesignModify
        public void setComboAlignCenter(DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DrawMode = DrawMode.OwnerDrawFixed;
                    cb.DrawItem += new DrawItemEventHandler(cboDesignModify);
                }
            }
        }
        public void cboDesignModify(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }
        #endregion
    }
}
