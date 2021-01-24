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
        int 藥品資料_Data_Length = Enum.GetValues(typeof(enum_藥品資料)).Length;
        public enum enum_藥品資料 : int
        {
            藥品碼,
            合約項次,
            藥品名稱,
            藥品學名,
            品項,
            廠牌,     
            健保碼,
            健保價,
            庫存,
            安全庫存,
            包裝單位,
            藥品條碼,
            已訂購總價,
            最新訂購單價,
            訂購商,
            合約廠商,
        }
        public string[] SQL_藥品資料_Data
        {
            get
            {
                string[] SQL_藥品資料_Data = new string[藥品資料_Data_Length];
                SQL_藥品資料_Data[(int)enum_藥品資料.藥品碼] = this.textBox_藥品資料_藥品碼.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.合約項次] = this.textBox_藥品資料_合約項次.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.藥品名稱] = this.textBox_藥品資料_藥品名稱.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.藥品學名] = this.textBox_藥品資料_藥品學名.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.品項] = this.textBox_藥品資料_品項.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.廠牌] = this.textBox_藥品資料_廠牌.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.健保碼] = this.textBox_藥品資料_健保碼.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.健保價] = this.textBox_藥品資料_健保價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.庫存] = this.textBox_藥品資料_庫存.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.安全庫存] = this.textBox_藥品資料_安全庫存.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.包裝單位] = this.textBox_藥品資料_包裝單位.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.藥品條碼] = this.textBox_藥品資料_藥品條碼.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.已訂購總價] = this.textBox_藥品資料_已訂購總價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.最新訂購單價] = this.textBox_藥品資料_最新訂購單價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.訂購商] = this.textBox_藥品資料_訂購商.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.合約廠商] = this.textBox_藥品資料_合約廠商.Text;
                return SQL_藥品資料_Data;
            }
            set
            {
                this.textBox_藥品資料_藥品碼.Text = value[(int)enum_藥品資料.藥品碼];
                this.textBox_藥品資料_合約項次.Text = value[(int)enum_藥品資料.合約項次];
                this.textBox_藥品資料_藥品名稱.Text = value[(int)enum_藥品資料.藥品名稱];
                this.textBox_藥品資料_藥品學名.Text = value[(int)enum_藥品資料.藥品學名];
                this.textBox_藥品資料_品項.Text = value[(int)enum_藥品資料.品項];
                this.textBox_藥品資料_廠牌.Text = value[(int)enum_藥品資料.廠牌];
                this.textBox_藥品資料_健保碼.Text = value[(int)enum_藥品資料.健保碼];
                this.textBox_藥品資料_健保價.Text = value[(int)enum_藥品資料.健保價];
                this.textBox_藥品資料_庫存.Text = value[(int)enum_藥品資料.庫存];
                this.textBox_藥品資料_安全庫存.Text = value[(int)enum_藥品資料.安全庫存];
                this.textBox_藥品資料_包裝單位.Text = value[(int)enum_藥品資料.包裝單位];
                this.textBox_藥品資料_已訂購總價.Text = value[(int)enum_藥品資料.已訂購總價];
                this.textBox_藥品資料_最新訂購單價.Text = value[(int)enum_藥品資料.最新訂購單價];
                this.textBox_藥品資料_訂購商.Text = value[(int)enum_藥品資料.訂購商];
                this.textBox_藥品資料_合約廠商.Text = value[(int)enum_藥品資料.合約廠商];
            }
        }

        private void Program_藥品資料_Init()
        {
            this.sqL_DataGridView_藥品資料.Init();
            if (!this.sqL_DataGridView_藥品資料.SQL_IsTableCreat())
            {
                this.sqL_DataGridView_藥品資料.SQL_CreateTable();
            }
            this.sqL_DataGridView_藥品資料.RowDoubleClickEvent += sqL_DataGridView_藥品資料_RowDoubleClickEvent;
            this.sqL_DataGridView_藥品資料.DataGridRefreshEvent += sqL_DataGridView_藥品資料_DataGridRefreshEvent;
            this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);

        }
        private void sub_Program_藥品資料()
        {
            sub_PLC_Program_藥品資料_頁面更新();

        }
        #region PLC_Program_藥品資料_頁面更新
        PLC_Device PLC_Program_藥品資料_頁面更新 = new PLC_Device("Y506");
        void sub_PLC_Program_藥品資料_頁面更新()
        {
            if (this.PLC_Program_藥品資料_頁面更新.Bool)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
                this.PLC_Program_藥品資料_頁面更新.Bool = false;
            }
        }
        #endregion

        #region Function
        public string Function_藥品資料_從藥品條碼取得藥品碼(string 藥品條碼)
        {
            string str = null;
            List<object[]> list_obj = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品條碼.GetEnumName(), 藥品條碼, false);
            if(list_obj.Count > 0)
            {
                str = list_obj[0][(int)enum_藥品資料.藥品碼].ObjectToString();
            }
            return str;
        }
        private void Function_藥品資料_登錄資料()
        {

            List<object[]> List_obj_目的資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), this.textBox_藥品資料_藥品碼.Text, false);
            List<object> List_str_來源資料 = new List<object>();
            for (int i = 0; i < SQL_藥品資料_Data.Length; i++)
            {
                List_str_來源資料.Add(SQL_藥品資料_Data[i]);
            }
            if (this.sqL_DataGridView_藥品資料.SQL_IsHaveMember(enum_藥品資料.藥品碼.GetEnumName(), this.textBox_藥品資料_藥品碼.Text))
            {
                Dialog_IsReplaceData Dialog_IsReplaceData = new Dialog_IsReplaceData();
                Dialog_IsReplaceData.Set_SourceDataList(this.Function_藥品資料_取得資料ListItems(List_str_來源資料.ToArray()));
                Dialog_IsReplaceData.Set_TargetDataList(this.Function_藥品資料_取得資料ListItems(List_obj_目的資料[0].ToArray()));
                Dialog_IsReplaceData.Is_ShowAllYes_Button = false;
                Dialog_IsReplaceData.Is_ShowAllNo_Button = false;
                Dialog_IsReplaceData.ShowDialog();
                if (Dialog_IsReplaceData.Result == 高雄榮總屏東分院_訂單管理系統.Dialog_IsReplaceData.enum_Result.Yes)
                {
                    this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), this.textBox_藥品資料_藥品碼.Text, this.SQL_藥品資料_Data, true);
                }
            }
            else
            {
                this.sqL_DataGridView_藥品資料.SQL_AddRow(this.SQL_藥品資料_Data, true);
            }
            
        }
        private List<string> Function_藥品資料_取得資料ListItems(object[] data)
        {
            List<string> List_str = new List<string>();
            List_str.Add("01.藥品碼      : " + data[0].ObjectToString());
            List_str.Add("02.合約項次    : " + data[1].ObjectToString());
            List_str.Add("03.藥品名稱    : " + data[2].ObjectToString());
            List_str.Add("04.藥品學名    : " + data[3].ObjectToString());
            List_str.Add("05.品項        : " + data[4].ObjectToString());
            List_str.Add("06.廠牌        : " + data[5].ObjectToString());
            List_str.Add("07.健保碼      : " + data[6].ObjectToString());
            List_str.Add("08.健保價      : " + data[7].ObjectToString());
            List_str.Add("09.庫存        : " + data[8].ObjectToString());
            List_str.Add("10.安全庫存    : " + data[9].ObjectToString());
            List_str.Add("11.單位        : " + data[10].ObjectToString());
            List_str.Add("12.藥品條碼    : " + data[11].ObjectToString());
            List_str.Add("13.已訂購總價  : " + data[12].ObjectToString());
            List_str.Add("14.最新訂購單價: " + data[13].ObjectToString());
            List_str.Add("15.訂購商      : " + data[14].ObjectToString());
            List_str.Add("15.合約廠商    : " + data[15].ObjectToString());
            return List_str;
        }
        private bool Function_藥品資料_檢查覆寫欄位重複(string[] SQL_Data, enum_藥品資料 _enum_藥品資料, bool IsMyMessageBoxShow)
        {
          
            bool flag_欄位重複 = true;
            string ColunmName = _enum_藥品資料.GetEnumName();
            if (SQL_Data[(int)_enum_藥品資料] == "") return false;
            List<object[]> obj_array = this.sqL_DataGridView_藥品資料.SQL_GetRows(ColunmName, SQL_Data[(int)_enum_藥品資料], false);
            if (obj_array.Count == 0)
            {
                flag_欄位重複 = false;
            }
            else if (obj_array.Count == 1)
            {
                foreach(object[] obj in obj_array)
                {
                    if (obj[(int)enum_藥品資料.藥品碼].ObjectToString() == SQL_Data[(int)enum_藥品資料.藥品碼]) flag_欄位重複 = false;
                }
            }
            else if (obj_array.Count > 1)
            {
                flag_欄位重複 = true;
            }
            if (flag_欄位重複 && IsMyMessageBoxShow)
            {
                MyMessageBox.ShowDialog("'" + ColunmName + "'" + "已被註冊" +",藥品碼 :" + obj_array[0][(int)enum_藥品資料.藥品碼].ObjectToString());
            }
            return flag_欄位重複;
        }
        private bool Function_藥品資料_確認欄位正確(bool IsMyMessageBoxShow)
        {
            return this.Function_藥品資料_確認欄位正確(this.SQL_藥品資料_Data, true);
        }
        private bool Function_藥品資料_確認欄位正確(string[] SQL_Data, bool IsMyMessageBoxShow)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            if (SQL_Data[(int)enum_藥品資料.藥品碼] == "")
            {
                List_error_msg.Add("'藥品碼'欄位空白");
            }

            if (SQL_Data[(int)enum_藥品資料.藥品名稱] == "")
            {
                List_error_msg.Add("'藥品名稱'欄位空白");
            }
            if (SQL_Data[(int)enum_藥品資料.健保碼] == "")
            {
                List_error_msg.Add("'健保碼'欄位空白");
            }
            if (SQL_Data[(int)enum_藥品資料.健保價] == "")
            {
                SQL_Data[(int)enum_藥品資料.健保價] = "0";
            }
            else
            {
                double temp = 0;
                if (!double.TryParse(SQL_Data[(int)enum_藥品資料.健保價], out temp))
                {
                    List_error_msg.Add("'健保價'為非法字元");
                }
            }
            SQL_Data[(int)enum_藥品資料.庫存] = "0";
            if (SQL_Data[(int)enum_藥品資料.庫存] == "")
            {
                List_error_msg.Add("'庫存'欄位空白");
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.庫存], out temp))
                {
                    List_error_msg.Add("'庫存'為非法字元");
                }
            }
            SQL_Data[(int)enum_藥品資料.安全庫存] = "0";
            if (SQL_Data[(int)enum_藥品資料.安全庫存] == "")
            {
                List_error_msg.Add("'安全庫存'欄位空白");
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.安全庫存], out temp))
                {
                    List_error_msg.Add("'安全庫存'為非法字元");
                }
            }
            if (SQL_Data[(int)enum_藥品資料.已訂購總價] == "")
            {
                SQL_Data[(int)enum_藥品資料.已訂購總價] = "0";
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.已訂購總價], out temp))
                {
                    SQL_Data[(int)enum_藥品資料.已訂購總價] = "0";
                }
            }
            if (SQL_Data[(int)enum_藥品資料.廠牌] == "")
            {
                List_error_msg.Add("'廠牌'欄位空白");
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
        #endregion
        #region Event
        private void radioButton_藥品資料_資料查詢_顯示全部_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_顯示全部.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = false;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = false;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = false;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = false;
                this.textBox_藥品資料_資料查詢_藥品條碼.Enabled = false;
            }
        }
        private void radioButton_藥品資料_資料查詢_藥品條碼_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_藥品條碼.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = false;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = false;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = false;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = false;
                this.textBox_藥品資料_資料查詢_藥品條碼.Enabled = true;
                this.textBox_藥品資料_資料查詢_藥品條碼.Focus();
            }
        }
        private void radioButton_藥品資料_資料查詢_藥品碼_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_藥品碼.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = true;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = false;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = false;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = false;
                this.textBox_藥品資料_資料查詢_藥品條碼.Enabled = false;
            }
        }
        private void radioButton_藥品資料_資料查詢_藥品名稱_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_藥品名稱.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = false;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = true;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = false;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = false;
                this.textBox_藥品資料_資料查詢_藥品條碼.Enabled = false;
            }
        }
        private void radioButton_藥品資料_資料查詢_品項_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_品項.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = false;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = false;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = true;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = false;
                this.textBox_藥品資料_資料查詢_藥品條碼.Enabled = false;
            }
        }
        private void radioButton_藥品資料_資料查詢_廠牌_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_廠牌.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = false;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = false;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = false;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = true;
                this.textBox_藥品資料_資料查詢_藥品條碼.Enabled = false;
            }
        }
        private void textBox_藥品資料_資料查詢_藥品條碼_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (textBox_藥品資料_資料查詢_藥品條碼.Text != "")
                {
                    this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品條碼.GetEnumName(), textBox_藥品資料_資料查詢_藥品條碼.Text, true);
                }            
            }
        }
        private void plC_Button_藥品資料_資料查詢_btnClick(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_藥品碼.Checked)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), comboBox_藥品資料_資料查詢_藥品碼.Text, true);
            }
            else if (radioButton_藥品資料_資料查詢_藥品名稱.Checked)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品名稱.GetEnumName(), comboBox_藥品資料_資料查詢_藥品名稱.Text, true);
            }

            else if (radioButton_藥品資料_資料查詢_品項.Checked)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.品項.GetEnumName(), comboBox_藥品資料_資料查詢_品項.Text, true);
            }
            else if (radioButton_藥品資料_資料查詢_廠牌.Checked)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.廠牌.GetEnumName(), comboBox_藥品資料_資料查詢_廠牌.Text, true);
            }
            else if (radioButton_藥品資料_資料查詢_藥品條碼.Checked)
            {
                if (textBox_藥品資料_資料查詢_藥品條碼.Text != "")
                {
                    this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品條碼.GetEnumName(), textBox_藥品資料_資料查詢_藥品條碼.Text, true);
                }    
            }
            else if (radioButton_藥品資料_資料查詢_顯示全部.Checked)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
            }
        }
        private void plC_Button_藥品資料_登錄資料_btnClick(object sender, EventArgs e)
        {
         
            if (this.Function_藥品資料_確認欄位正確(true))
            {
                if(this.Function_藥品資料_檢查覆寫欄位重複(SQL_藥品資料_Data, enum_藥品資料.健保碼, true))
                {
                    return;
                }
                if (this.Function_藥品資料_檢查覆寫欄位重複(SQL_藥品資料_Data, enum_藥品資料.藥品條碼, true))
                {
                    return;
                }
                this.Function_藥品資料_登錄資料();
                this.SQL_藥品資料_Data = new string[藥品資料_Data_Length];
            }
        }
        private void plC_Button_藥品資料_清除欄位_btnClick(object sender, EventArgs e)
        {
            this.SQL_藥品資料_Data = new string[藥品資料_Data_Length];
        }
        private void plC_Button_藥品資料_刪除資料_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否刪除選取欄位資料?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                object[] obj_temp = this.sqL_DataGridView_藥品資料.GetRowValues();
                if (obj_temp != null)
                {
                    this.sqL_DataGridView_藥品資料.SQL_Delete(enum_藥品資料.藥品碼.GetEnumName(), obj_temp[(int)enum_藥品資料.藥品碼].ObjectToString(), true);
                }

            }
        }
        private void plC_Button_藥品資料_匯出檔案_btnClick(object sender, EventArgs e)
        {
            saveFileDialog_SaveExcel.OverwritePrompt = false;
            if (saveFileDialog_SaveExcel.ShowDialog(this) == DialogResult.OK)
            {

                DataTable datatable = new DataTable();
                datatable = sqL_DataGridView_藥品資料.GetDataTable();
                MyOffice.ExcelClass.SaveFile(datatable, saveFileDialog_SaveExcel.FileName);
                MyMessageBox.ShowDialog("匯出完成!");
            } 
        }
        private void plC_Button_藥品資料_匯入檔案_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
            {

                DataTable datatable_buf = new DataTable();
                DataTable datatable = new DataTable();
                datatable = MyOffice.ExcelClass.LoadFile(openFileDialog_LoadExcel.FileName);

                if (datatable.Columns.Count != 藥品資料_Data_Length)
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

                    List<object[]> List_obj_目的資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), str_來源資料[(int)enum_藥品資料.藥品碼], false);
                    string[] str_目的資料 = new string[藥品資料_Data_Length];
                    if (List_obj_目的資料.Count > 0)
                    {
                        for (int i = 0; i < List_obj_目的資料[0].Length; i++)
                        {
                            str_目的資料[i] = List_obj_目的資料[0][i].ObjectToString();
                        }
                    }


                    if (this.Function_藥品資料_檢查覆寫欄位重複(str_來源資料, enum_藥品資料.健保碼, true))
                    {
                        continue;
                    }
                    if (this.Function_藥品資料_檢查覆寫欄位重複(str_來源資料, enum_藥品資料.藥品條碼, true))
                    {
                        continue;
                    }
                    if (this.Function_藥品資料_確認欄位正確(str_來源資料, false))
                    {
                        if (this.sqL_DataGridView_藥品資料.SQL_IsHaveMember(enum_藥品資料.藥品碼.GetEnumName(), str_來源資料[(int)enum_藥品資料.藥品碼]))
                        {         
                            if (flag_AllNo)
                            {
                                continue;
                            }
                            if (flag_AllYes)
                            {
                                this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), str_來源資料[(int)enum_藥品資料.藥品碼], str_來源資料, false);
                                continue;
                            }

                            Dialog_IsReplaceData Dialog_IsReplaceData = new Dialog_IsReplaceData();
                            Dialog_IsReplaceData.Set_SourceDataList(this.Function_藥品資料_取得資料ListItems(str_來源資料));
                            Dialog_IsReplaceData.Set_TargetDataList(this.Function_藥品資料_取得資料ListItems(List_obj_目的資料[0].ToArray()));
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
                                this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), str_來源資料[(int)enum_藥品資料.藥品碼], str_來源資料, false);
                            }
                            Dialog_IsReplaceData.Dispose();

                        }
                        else
                        {
  
                            this.sqL_DataGridView_藥品資料.SQL_AddRow(str_來源資料, false);
                        }
                    }
                }
                Dialog_Loading.Dispose();
                datatable_buf.Dispose();
                datatable.Dispose();

                this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
                MyMessageBox.ShowDialog("匯入完成!");
            }
        }
        private void sqL_DataGridView_藥品資料_RowDoubleClickEvent(object[] RowValue)
        {
            string[] Array_str = new string[RowValue.Length];
            for (int i = 0; i < RowValue.Length; i++)
            {
                Array_str[i] = RowValue[i].ObjectToString();
            }
            this.SQL_藥品資料_Data = Array_str;
        }
        private void sqL_DataGridView_藥品資料_DataGridRefreshEvent()
        {
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.藥品碼.GetEnumName(), true, comboBox_藥品資料_資料查詢_藥品碼);
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.藥品名稱.GetEnumName(), true, comboBox_藥品資料_資料查詢_藥品名稱);
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.品項.GetEnumName(), true, comboBox_藥品資料_資料查詢_品項);
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.廠牌.GetEnumName(), true, comboBox_藥品資料_資料查詢_廠牌);
        }
        #endregion
    }
}
