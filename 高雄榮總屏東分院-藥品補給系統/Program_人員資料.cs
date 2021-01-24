using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic;
using MyUI;
namespace 高雄榮總屏東分院_訂單管理系統
{
    public partial class Form1 : Form
    {
        int 人員資料_Data_Length = Enum.GetValues(typeof(enum_人員資料)).Length;
        public enum enum_人員資料 : int
        {
            ID, 姓名, 性別, 密碼, 單位, 權限等級
        }

        public string[] SQL_人員資料_Data
        {
            get
            {
                string[] SQL_人員資料_Data = new string[人員資料_Data_Length];
                SQL_人員資料_Data[(int)enum_人員資料.ID] = this.textBox_人員資料_ID.Text;
                SQL_人員資料_Data[(int)enum_人員資料.姓名] = this.textBox_人員資料_姓名.Text;
                SQL_人員資料_Data[(int)enum_人員資料.性別] = this.comboBox_人員資料_性別.Text;
                SQL_人員資料_Data[(int)enum_人員資料.密碼] = this.textBox_人員資料_密碼.Text;
                SQL_人員資料_Data[(int)enum_人員資料.單位] = this.textBox_人員資料_單位.Text;
                SQL_人員資料_Data[(int)enum_人員資料.權限等級] = this.comboBox_人員資料_權限等級.Text;

                return SQL_人員資料_Data;
            }
            set
            {
                this.textBox_人員資料_ID.Text = value[(int)enum_人員資料.ID];
                this.textBox_人員資料_姓名.Text = value[(int)enum_人員資料.姓名];
                this.comboBox_人員資料_性別.Text = value[(int)enum_人員資料.性別];
                this.textBox_人員資料_密碼.Text = value[(int)enum_人員資料.密碼];
                this.textBox_人員資料_單位.Text = value[(int)enum_人員資料.單位];
                this.comboBox_人員資料_權限等級.Text = value[(int)enum_人員資料.權限等級];

                if (this.comboBox_人員資料_性別.Text == "") this.comboBox_人員資料_性別.SelectedIndex = 0;
                if (this.comboBox_人員資料_權限等級.Text == "") this.comboBox_人員資料_權限等級.SelectedIndex = 0;
            }
        }

        private void Program_人員資料_Init()
        {
            this.sqL_DataGridView_人員資料.Init();
            if (!this.sqL_DataGridView_人員資料.SQL_IsTableCreat())
            {
                this.sqL_DataGridView_人員資料.SQL_CreateTable();
            }
            this.sqL_DataGridView_人員資料.RowDoubleClickEvent += sqL_DataGridView_人員資料_RowDoubleClickEvent;

            this.sqL_DataGridView_人員資料.SQL_GetAllRows(true);

            this.comboBox_人員資料_性別.SelectedIndex = 0;
            this.comboBox_人員資料_權限等級.SelectedIndex = 0;
        }
        private void sub_Program_人員資料()
        {
            sub_PLC_Program_人員資料_頁面更新();

        }
        #region PLC_Program_人員資料_頁面更新
        PLC_Device PLC_Program_人員資料_頁面更新 = new PLC_Device("Y510");
        void sub_PLC_Program_人員資料_頁面更新()
        {
            if (this.PLC_Program_人員資料_頁面更新.Bool)
            {
                this.sqL_DataGridView_人員資料.SQL_GetAllRows(true);
                this.PLC_Program_人員資料_頁面更新.Bool = false;
            }
        }
        #endregion
        #region Function
        private bool Function_人員資料_確認欄位正確(bool IsMyMessageBoxShow)
        {
            return this.Function_人員資料_確認欄位正確(this.SQL_人員資料_Data, true);
        }
        private bool Function_人員資料_確認欄位正確(string[] SQL_Data, bool IsMyMessageBoxShow)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            if (SQL_Data[(int)enum_人員資料.ID] == "")
            {
                List_error_msg.Add("'ID'欄位空白");
            }
            else
            {
            
            }

            if (SQL_Data[(int)enum_人員資料.姓名] == "")
            {
                List_error_msg.Add("'姓名'欄位空白");
            }

            if (SQL_Data[(int)enum_人員資料.性別] == "")
            {
                List_error_msg.Add("'性別'欄位空白");
            }
            else
            {
                if (!(SQL_Data[(int)enum_人員資料.性別] == "男" || SQL_Data[(int)enum_人員資料.性別] == "女"))
                {
                    List_error_msg.Add("'性別'欄位為非法字元");
                }
            }
            if (SQL_Data[(int)enum_人員資料.權限等級] == "")
            {
                List_error_msg.Add("'權限等級'欄位空白");
            }
            else
            {
                int 權限等級 = SQL_Data[(int)enum_人員資料.權限等級].StringToInt32();
                if (!(權限等級 != -1 && 權限等級 >= 1 && 權限等級 <= 9))
                {
                    List_error_msg.Add("'權限等級'欄位為非法字元");
                }
            }
            for (int i = 0; i < List_error_msg.Count; i++)
            {
                str_error_msg += i.ToString("00") + ". " + List_error_msg[i] + "\n\r";
            }
            if (str_error_msg == "") flag_OK = true;
            else
            {
                if (IsMyMessageBoxShow) MyMessageBox.ShowDialog(str_error_msg);
            }
            return flag_OK;
        }
        private void Function_人員資料_登錄資料()
        {

            List<object[]> List_obj_目的資料 = this.sqL_DataGridView_人員資料.SQL_GetRows(enum_人員資料.ID.GetEnumName(), this.textBox_人員資料_ID.Text, false);
            List<object> List_str_來源資料 = new List<object>();
            for (int i = 0; i < SQL_人員資料_Data.Length; i++)
            {
                List_str_來源資料.Add(SQL_人員資料_Data[i]);
            }
            if (this.sqL_DataGridView_人員資料.SQL_IsHaveMember(enum_人員資料.ID.GetEnumName(), this.textBox_人員資料_ID.Text))
            {
                DialogResult Result = MyMessageBox.ShowDialog("此'ID'已註冊,是否覆寫?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.sqL_DataGridView_人員資料.SQL_Replace(enum_人員資料.ID.GetEnumName(), this.textBox_人員資料_ID.Text, this.SQL_人員資料_Data, true);

                }
            }
            else
            {
                this.sqL_DataGridView_人員資料.SQL_AddRow(this.SQL_人員資料_Data, true);
            }

        }
        private List<string> Function_人員資料_取得資料ListItems(object[] data)
        {
            List<string> List_str = new List<string>();
            List_str.Add("01.ID        : " + data[(int)enum_人員資料.ID].ObjectToString());
            List_str.Add("02.姓名      : " + data[(int)enum_人員資料.姓名].ObjectToString());
            List_str.Add("03.性別      : " + data[(int)enum_人員資料.性別].ObjectToString());
            List_str.Add("04.單位      : " + data[(int)enum_人員資料.單位].ObjectToString());
            List_str.Add("05.權限等級  : " + data[(int)enum_人員資料.權限等級].ObjectToString());
            return List_str;
        }
        #endregion

        #region Event
        private void plC_Button_人員資料_登錄資料_btnClick(object sender, EventArgs e)
        {

            if (this.Function_人員資料_確認欄位正確(true))
            {
                this.Function_人員資料_登錄資料();
                this.SQL_人員資料_Data = new string[人員資料_Data_Length];
                
            }
        }
        private void plC_Button_人員資料_清除欄位_btnClick(object sender, EventArgs e)
        {
            this.SQL_人員資料_Data = new string[人員資料_Data_Length];
        }
        private void plC_Button_人員資料_刪除資料_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否刪除選取欄位資料?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                object[] obj_temp = this.sqL_DataGridView_人員資料.GetRowValues();
                if (obj_temp != null)
                {
                    this.sqL_DataGridView_人員資料.SQL_Delete(enum_人員資料.ID.GetEnumName(), obj_temp[(int)enum_人員資料.ID].ObjectToString(), true);
                }

            }
        }
        private void plC_Button_人員資料_匯出檔案_btnClick(object sender, EventArgs e)
        {
            saveFileDialog_SaveExcel.OverwritePrompt = false;
            if (saveFileDialog_SaveExcel.ShowDialog(this) == DialogResult.OK)
            {

                DataTable datatable = new DataTable();
                datatable = sqL_DataGridView_人員資料.GetDataTable();
                MyOffice.ExcelClass.SaveFile(datatable, saveFileDialog_SaveExcel.FileName);
                MyMessageBox.ShowDialog("匯出完成!");
            }
        }

        private void plC_Button_人員資料_匯入檔案_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
            {

                DataTable datatable_buf = new DataTable();
                DataTable datatable = new DataTable();
                datatable = MyOffice.ExcelClass.LoadFile(openFileDialog_LoadExcel.FileName);

                if (datatable.Columns.Count != 人員資料_Data_Length)
                {
                    MyMessageBox.ShowDialog("匯入資料格式錯誤!");
                    return;
                }

                bool flag_AllYes = false;
                bool flag_AllNo = false;

                Dialog_Loading Dialog_Loading = new Dialog_Loading();
                Dialog_Loading.Show();
                Dialog_Loading.StepNum = datatable.Rows.Count;
                Dialog_Loading.Refresh_Processbar();
                Dialog_Loading.Location = new Point(500, 200);

                foreach (System.Data.DataRow dr in datatable.Rows)
                {

                    Dialog_Loading.StepValue++;
                    string[] str_來源資料 = new string[dr.ItemArray.Length];
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        str_來源資料[i] = dr.ItemArray[i].ObjectToString();
                    }

                    List<object[]> List_obj_目的資料 = this.sqL_DataGridView_人員資料.SQL_GetRows(enum_人員資料.ID.GetEnumName(), str_來源資料[(int)enum_人員資料.ID], false);
                    string[] str_目的資料 = new string[人員資料_Data_Length];
                    if (List_obj_目的資料.Count > 0)
                    {
                        for (int i = 0; i < List_obj_目的資料[0].Length; i++)
                        {
                            str_目的資料[i] = List_obj_目的資料[0][i].ObjectToString();
                        }
                    }



                    if (this.Function_人員資料_確認欄位正確(str_來源資料, false))
                    {
                        if (this.sqL_DataGridView_人員資料.SQL_IsHaveMember(enum_人員資料.ID.GetEnumName(), str_來源資料[(int)enum_人員資料.ID]))
                        {
                            if (flag_AllNo)
                            {
                                continue;
                            }
                            if (flag_AllYes)
                            {
                                this.sqL_DataGridView_人員資料.SQL_Replace(enum_人員資料.ID.GetEnumName(), str_來源資料[(int)enum_人員資料.ID], str_來源資料, true);
                                continue;
                            }

                            Dialog_IsReplaceData Dialog_IsReplaceData = new Dialog_IsReplaceData();
                            Dialog_IsReplaceData.Set_SourceDataList(this.Function_人員資料_取得資料ListItems(str_來源資料));
                            Dialog_IsReplaceData.Set_TargetDataList(this.Function_人員資料_取得資料ListItems(List_obj_目的資料[0].ToArray()));
                            Dialog_IsReplaceData.Is_ShowAllYes_Button = true;
                            Dialog_IsReplaceData.Is_ShowAllNo_Button = true;
                            Dialog_IsReplaceData.ShowDialog();
                            if (Dialog_IsReplaceData.Result == 高雄榮總屏東分院_訂單管理系統.Dialog_IsReplaceData.enum_Result.All_Yes)
                            {
                                flag_AllYes = true;
                            }
                            if (Dialog_IsReplaceData.Result == 高雄榮總屏東分院_訂單管理系統.Dialog_IsReplaceData.enum_Result.All_No)
                            {
                                flag_AllNo = true;
                            }
                            if (Dialog_IsReplaceData.Result == 高雄榮總屏東分院_訂單管理系統.Dialog_IsReplaceData.enum_Result.Yes || flag_AllYes)
                            {
                                this.sqL_DataGridView_人員資料.SQL_Replace(enum_人員資料.ID.GetEnumName(), str_來源資料[(int)enum_人員資料.ID], str_來源資料, true);
                            }
                            Dialog_IsReplaceData.Dispose();

                        }
                        else
                        {

                            this.sqL_DataGridView_人員資料.SQL_AddRow(str_來源資料, false);
                        }
                    }
                }
                Dialog_Loading.Dispose();
                datatable_buf.Dispose();
                datatable.Dispose();

                this.sqL_DataGridView_人員資料.SQL_GetAllRows(true);
                MyMessageBox.ShowDialog("匯入完成!");
            }
        }
        private void sqL_DataGridView_人員資料_RowDoubleClickEvent(object[] RowValue)
        {
            string[] Array_str = new string[RowValue.Length];
            for (int i = 0; i < RowValue.Length; i++)
            {
                Array_str[i] = RowValue[i].ObjectToString();
            }
            this.SQL_人員資料_Data = Array_str;
        }
        #endregion
    }
}
