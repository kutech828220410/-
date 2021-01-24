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
        int 供應商資料_Data_Length = Enum.GetValues(typeof(enum_供應商資料)).Length;
        public enum enum_供應商資料 : int
        {
            序號,
            全名,
            簡名,
            類別,
            電話,
            聯絡人,
            Email,
            地址,
            統一編號,
            備註,   
        }
        public string[] SQL_供應商資料_Data
        {
            get
            {
                string[] SQL_供應商資料_Data = new string[供應商資料_Data_Length];
                SQL_供應商資料_Data[(int)enum_供應商資料.序號] = this.textBox_供應商資料_序號.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.全名] = this.textBox_供應商資料_全名.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.簡名] = this.textBox_供應商資料_簡名.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.類別] = this.textBox_供應商資料_類別.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.電話] = this.textBox_供應商資料_電話.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.聯絡人] = this.textBox_供應商資料_聯絡人.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.Email] = this.textBox_供應商資料_Email.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.統一編號] = this.textBox_供應商資料_統一編號.Text;
                SQL_供應商資料_Data[(int)enum_供應商資料.備註] = this.textBox_供應商資料_備註.Text;
                return SQL_供應商資料_Data;
            }
            set
            {
                this.textBox_供應商資料_序號.Text = value[(int)enum_供應商資料.序號];
                this.textBox_供應商資料_全名.Text = value[(int)enum_供應商資料.全名];
                this.textBox_供應商資料_簡名.Text = value[(int)enum_供應商資料.簡名];
                this.textBox_供應商資料_類別.Text = value[(int)enum_供應商資料.類別];
                this.textBox_供應商資料_電話.Text = value[(int)enum_供應商資料.電話];
                this.textBox_供應商資料_聯絡人.Text = value[(int)enum_供應商資料.聯絡人];
                this.textBox_供應商資料_Email.Text = value[(int)enum_供應商資料.Email];
                this.textBox_供應商資料_統一編號.Text = value[(int)enum_供應商資料.統一編號];
                this.textBox_供應商資料_備註.Text = value[(int)enum_供應商資料.備註];
            }
        }
        private void Program_供應商資料_Init()
        {
            this.sqL_DataGridView_供應商資料.Init();
            if (!this.sqL_DataGridView_供應商資料.SQL_IsTableCreat())
            {
                this.sqL_DataGridView_供應商資料.SQL_CreateTable();
            }       
            this.sqL_DataGridView_供應商資料.RowDoubleClickEvent +=sqL_DataGridView_供應商資料_RowDoubleClickEvent;
            this.sqL_DataGridView_供應商資料.DataGridRefreshEvent += sqL_DataGridView_供應商資料_DataGridRefreshEvent;
    

        }
        void sub_Program_供應商資料()
        {
            sub_PLC_Program_供應商資料_頁面更新();
        }

        #region PLC_Program_供應商資料_頁面更新
        PLC_Device PLC_Program_供應商資料_頁面更新 = new PLC_Device("Y505");
        void sub_PLC_Program_供應商資料_頁面更新()
        {
            if (this.PLC_Program_供應商資料_頁面更新.Bool)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetAllRows(true);
                this.PLC_Program_供應商資料_頁面更新.Bool = false;
            }
        }
        #endregion
        #region Function
        public string Function_供應商資料_取得全名(string 序號)
        {
            string str = null;
            List<object[]> object_array = this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.序號.GetEnumName(), 序號, false);
            if (object_array.Count > 0)
            {
                str = object_array[0][1].ObjectToString();
            }
            return str;
        }

        private void Function_供應商資料_登錄資料()
        {
            List<object[]> List_obj_目的資料 = this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.序號.GetEnumName(), this.textBox_供應商資料_序號.Text, false);
            List<object> List_str_來源資料 = new List<object>();
            for (int i = 0; i < SQL_供應商資料_Data.Length; i++)
            {
                List_str_來源資料.Add(SQL_供應商資料_Data[i]);
            }
            if (this.sqL_DataGridView_供應商資料.SQL_IsHaveMember(enum_供應商資料.序號.GetEnumName(), this.textBox_供應商資料_序號.Text))
            {
                Dialog_IsReplaceData Dialog_IsReplaceData = new Dialog_IsReplaceData();
                Dialog_IsReplaceData.Set_SourceDataList(this.Function_供應商資料_取得資料ListItems(List_str_來源資料.ToArray()));
                Dialog_IsReplaceData.Set_TargetDataList(this.Function_供應商資料_取得資料ListItems(List_obj_目的資料[0].ToArray()));
                Dialog_IsReplaceData.Is_ShowAllYes_Button = false;
                Dialog_IsReplaceData.Is_ShowAllNo_Button = false;
                Dialog_IsReplaceData.ShowDialog();
                if (Dialog_IsReplaceData.Result == 高雄榮總屏東分院_訂單管理系統.Dialog_IsReplaceData.enum_Result.Yes)
                {
                    this.sqL_DataGridView_供應商資料.SQL_Replace(enum_供應商資料.序號.GetEnumName(), this.textBox_供應商資料_序號.Text, this.SQL_供應商資料_Data, false);
                }
            }
            else
            {
                this.sqL_DataGridView_供應商資料.SQL_AddRow(this.SQL_供應商資料_Data, true);
            }

        }
        private List<string> Function_供應商資料_取得資料ListItems(object[] data)
        {
            List<string> List_str = new List<string>();
            List_str.Add("01.序號    : " + data[(int)enum_供應商資料.序號].ObjectToString());
            List_str.Add("02.全名    : " + data[(int)enum_供應商資料.全名].ObjectToString());
            List_str.Add("03.簡名    : " + data[(int)enum_供應商資料.簡名].ObjectToString());
            List_str.Add("04.類別    : " + data[(int)enum_供應商資料.類別].ObjectToString());
            List_str.Add("05.電話    : " + data[(int)enum_供應商資料.電話].ObjectToString());
            List_str.Add("06.聯絡人  : " + data[(int)enum_供應商資料.聯絡人].ObjectToString());
            List_str.Add("07.Email   : " + data[(int)enum_供應商資料.Email].ObjectToString());
            List_str.Add("08.統一編號: " + data[(int)enum_供應商資料.統一編號].ObjectToString());
            List_str.Add("09.備註    : " + data[(int)enum_供應商資料.備註].ObjectToString());  
            return List_str;
        }
        private bool Function_供應商資料_確認欄位正確(bool IsMyMessageBoxShow)
        {
            return this.Function_供應商資料_確認欄位正確(this.SQL_供應商資料_Data, IsMyMessageBoxShow);
        }
        private bool Function_供應商資料_確認欄位正確(string[] SQL_Data, bool IsMyMessageBoxShow)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            if (SQL_Data[(int)enum_供應商資料.序號] == "")
            {
                List_error_msg.Add("'序號'欄位空白");
            }

            if (SQL_Data[(int)enum_供應商資料.電話] == "")
            {
                List_error_msg.Add("'電話'欄位空白");
            }
            if (SQL_Data[(int)enum_供應商資料.聯絡人] == "")
            {
                List_error_msg.Add("'聯絡人'欄位空白");
            }
            if (SQL_Data[(int)enum_供應商資料.Email] == "")
            {
                List_error_msg.Add("'Email'欄位空白");
            }
            else
            {
                if (!myEmail_Send_UI.Check_Email_Adress(SQL_Data[(int)enum_供應商資料.Email]))
                {
                    List_error_msg.Add("'Email'欄位為錯誤格式");
                }
            }
            for (int i = 0; i < List_error_msg.Count; i++)
            {
                str_error_msg += i.ToString("00") + ". " + List_error_msg[i] + "\n\r";
            }
            if (str_error_msg == "") flag_OK = true;
            else if (IsMyMessageBoxShow) MyMessageBox.ShowDialog(str_error_msg);
            return flag_OK;
 
        }
        #endregion
        #region Event
        private void radioButton_供應商資料_資料查詢_序號_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_序號.Checked)
            {
                comboBox_供應商資料_資料查詢_序號.Enabled = true;
                comboBox_供應商資料_資料查詢_全名.Enabled = false;
                comboBox_供應商資料_資料查詢_類別.Enabled = false;
                comboBox_供應商資料_資料查詢_聯絡人.Enabled = false;
                comboBox_供應商資料_資料查詢_Email.Enabled = false;
            }

        }
        private void radioButton_供應商資料_資料查詢_全名_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_全名.Checked)
            {
                comboBox_供應商資料_資料查詢_序號.Enabled = false;
                comboBox_供應商資料_資料查詢_全名.Enabled = true;
                comboBox_供應商資料_資料查詢_類別.Enabled = false;
                comboBox_供應商資料_資料查詢_聯絡人.Enabled = false;
                comboBox_供應商資料_資料查詢_Email.Enabled = false;
            }

        }
        private void radioButton_供應商資料_資料查詢_類別_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_類別.Checked)
            {
                comboBox_供應商資料_資料查詢_序號.Enabled = false;
                comboBox_供應商資料_資料查詢_全名.Enabled = false;
                comboBox_供應商資料_資料查詢_類別.Enabled = true;
                comboBox_供應商資料_資料查詢_聯絡人.Enabled = false;
                comboBox_供應商資料_資料查詢_Email.Enabled = false;
            }
        }
        private void radioButton_供應商資料_資料查詢_聯絡人_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_聯絡人.Checked)
            {
                comboBox_供應商資料_資料查詢_序號.Enabled = false;
                comboBox_供應商資料_資料查詢_全名.Enabled = false;
                comboBox_供應商資料_資料查詢_類別.Enabled = false;
                comboBox_供應商資料_資料查詢_聯絡人.Enabled = true;
                comboBox_供應商資料_資料查詢_Email.Enabled = false;
            }
        }
        private void radioButton_供應商資料_資料查詢_Email_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_Email.Checked)
            {
                comboBox_供應商資料_資料查詢_序號.Enabled = false;
                comboBox_供應商資料_資料查詢_全名.Enabled = false;
                comboBox_供應商資料_資料查詢_類別.Enabled = false;
                comboBox_供應商資料_資料查詢_聯絡人.Enabled = false;
                comboBox_供應商資料_資料查詢_Email.Enabled = true;
            }
        }
        private void radioButton_供應商資料_資料查詢_顯示全部_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_顯示全部.Checked)
            {
                comboBox_供應商資料_資料查詢_序號.Enabled = false;
                comboBox_供應商資料_資料查詢_全名.Enabled = false;
                comboBox_供應商資料_資料查詢_類別.Enabled = false;
                comboBox_供應商資料_資料查詢_聯絡人.Enabled = false;
                comboBox_供應商資料_資料查詢_Email.Enabled = false;
            }
        }
        private void plC_Button_供應商資料_登錄資料_btnClick(object sender, EventArgs e)
        {
            if (this.Function_供應商資料_確認欄位正確(true))
            {
                this.Function_供應商資料_登錄資料();
                this.SQL_供應商資料_Data = new string[供應商資料_Data_Length];
            }
        }
        private void plC_Button_供應商資料_清除欄位_btnClick(object sender, EventArgs e)
        {
            this.SQL_供應商資料_Data = new string[供應商資料_Data_Length];
        }
        private void plC_Button_供應商資料_刪除資料_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否刪除選取欄位資料?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                object[] obj_temp = this.sqL_DataGridView_供應商資料.GetRowValues();
                if (obj_temp!= null)
                {
                    this.sqL_DataGridView_供應商資料.SQL_Delete(enum_供應商資料.序號.GetEnumName(), obj_temp[(int)enum_供應商資料.序號].ObjectToString(), true);
                }
              
            }
        }
        private void plC_Button_供應商資料_匯出檔案_btnClick(object sender, EventArgs e)
        {
            saveFileDialog_SaveExcel.OverwritePrompt = false;
            if (saveFileDialog_SaveExcel.ShowDialog(this) == DialogResult.OK)
            {
                
                DataTable datatable = new DataTable();
                datatable = sqL_DataGridView_供應商資料.GetDataTable();
                MyOffice.ExcelClass.SaveFile(datatable, saveFileDialog_SaveExcel.FileName, new int[] { 10, 40, 15, 20, 15, 15, 40, 60 });
                MyMessageBox.ShowDialog("匯出完成!");
            } 
        }
        private void plC_Button_供應商資料_匯入檔案_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
            {

                DataTable datatable_buf = new DataTable();
                DataTable datatable = new DataTable();
                datatable = MyOffice.ExcelClass.LoadFile(openFileDialog_LoadExcel.FileName);

                if (datatable.Columns.Count != 供應商資料_Data_Length)
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

                    List<object[]> List_obj_目的資料 = this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.序號.GetEnumName(), str_來源資料[(int)enum_供應商資料.序號], false);
                    string[] str_目的資料 = new string[供應商資料_Data_Length];
                    if(List_obj_目的資料.Count > 0)
                    {                   
                        for (int i = 0; i < List_obj_目的資料[0].Length; i++)
                        {
                            str_目的資料[i] = List_obj_目的資料[0][i].ObjectToString();
                        }
                    }
                  


                    if (this.Function_供應商資料_確認欄位正確(str_來源資料, false))
                    {
                        if (this.sqL_DataGridView_供應商資料.SQL_IsHaveMember(enum_供應商資料.序號.GetEnumName(), str_來源資料[(int)enum_供應商資料.序號]))
                        {
                            if (flag_AllNo)
                            {
                                continue;
                            }
                            if (flag_AllYes)
                            {
                                this.sqL_DataGridView_供應商資料.SQL_Replace(enum_供應商資料.序號.GetEnumName(), str_來源資料[(int)enum_供應商資料.序號], str_來源資料, true);
                                continue;
                            }

                            Dialog_IsReplaceData Dialog_IsReplaceData = new Dialog_IsReplaceData();
                            Dialog_IsReplaceData.Set_SourceDataList(this.Function_供應商資料_取得資料ListItems(str_來源資料));
                            Dialog_IsReplaceData.Set_TargetDataList(this.Function_供應商資料_取得資料ListItems(List_obj_目的資料[0].ToArray()));
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
                                this.sqL_DataGridView_供應商資料.SQL_Replace(enum_供應商資料.序號.GetEnumName(), str_來源資料[(int)enum_供應商資料.序號], str_來源資料, true);
                            }
                            Dialog_IsReplaceData.Dispose();

                        }
                        else
                        {

                            this.sqL_DataGridView_供應商資料.SQL_AddRow(str_來源資料, false);
                        }
                    }
                }
                Dialog_Loading.Dispose();
                datatable_buf.Dispose();
                datatable.Dispose();

                this.sqL_DataGridView_供應商資料.SQL_GetAllRows(true);
                MyMessageBox.ShowDialog("匯入完成!");
            }
        }
        private void plC_Button_供應商資料_資料查詢_btnClick(object sender, EventArgs e)
        {
            if (radioButton_供應商資料_資料查詢_序號.Checked)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.序號.GetEnumName(), comboBox_供應商資料_資料查詢_序號.Text, true);
            }
            else if (radioButton_供應商資料_資料查詢_全名.Checked)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.全名.GetEnumName(), comboBox_供應商資料_資料查詢_全名.Text, true);
            }
            else if (radioButton_供應商資料_資料查詢_類別.Checked)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.類別.GetEnumName(), comboBox_供應商資料_資料查詢_類別.Text, true);
            }
            else if (radioButton_供應商資料_資料查詢_聯絡人.Checked)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.聯絡人.GetEnumName(), comboBox_供應商資料_資料查詢_聯絡人.Text, true);
            }
            else if (radioButton_供應商資料_資料查詢_Email.Checked)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetRows(enum_供應商資料.Email.GetEnumName(), comboBox_供應商資料_資料查詢_Email.Text, true);
            }
            else if (radioButton_供應商資料_資料查詢_顯示全部.Checked)
            {
                this.sqL_DataGridView_供應商資料.SQL_GetAllRows(true);
            }
        }
        private void sqL_DataGridView_供應商資料_RowDoubleClickEvent(object[] RowValue)
        {
            string[] Array_str = new string[RowValue.Length];
            for (int i = 0; i < RowValue.Length; i++)
            {
                Array_str[i] = RowValue[i].ObjectToString();
            }
            this.SQL_供應商資料_Data = Array_str;
        }
        private void sqL_DataGridView_供應商資料_DataGridRefreshEvent()
        {
            sqL_DataGridView_供應商資料.SQL_GetColumnValues(enum_供應商資料.序號.GetEnumName(), true, comboBox_供應商資料_資料查詢_序號);
            sqL_DataGridView_供應商資料.SQL_GetColumnValues(enum_供應商資料.全名.GetEnumName(), true, comboBox_供應商資料_資料查詢_全名);
            sqL_DataGridView_供應商資料.SQL_GetColumnValues(enum_供應商資料.類別.GetEnumName(), true, comboBox_供應商資料_資料查詢_類別);
            sqL_DataGridView_供應商資料.SQL_GetColumnValues(enum_供應商資料.聯絡人.GetEnumName(), true, comboBox_供應商資料_資料查詢_聯絡人);
            sqL_DataGridView_供應商資料.SQL_GetColumnValues(enum_供應商資料.Email.GetEnumName(), true, comboBox_供應商資料_資料查詢_Email);

        }
        #endregion
    }
}
