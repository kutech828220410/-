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
namespace 藥品補給系統
{
    public partial class Form1 : Form
    {
        public string[] enum_藥品資料_品項 = new string[] { "正式品項(高)", "正式品項(輔)", "學檢計畫", "零採", "專簽臨採", "蛇毒血清","管1-3級","停用"};

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
            基本量,
            消耗量,
            安全庫存,
            已訂購數量,
            包裝單位,
            藥品條碼,
            已訂購總價,
            已採購總價,
            已採購總量,
            已採購總量上限,
            契約價金,
            最新訂購單價,
            訂購商,
            合約廠商,
            維護到期日,
            最小包裝數量,
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
                SQL_藥品資料_Data[(int)enum_藥品資料.品項] = this.comboBox_藥品資料_品項.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.廠牌] = this.textBox_藥品資料_廠牌.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.健保碼] = this.textBox_藥品資料_健保碼.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.健保價] = this.textBox_藥品資料_健保價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.庫存] = this.textBox_藥品資料_庫存.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.基本量] = this.textBox_藥品資料_基本量.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.消耗量] = this.textBox_藥品資料_消耗量.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.安全庫存] = this.textBox_藥品資料_安全庫存.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.包裝單位] = this.textBox_藥品資料_包裝單位.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.藥品條碼] = this.textBox_藥品資料_藥品條碼.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.已訂購總價] = this.textBox_藥品資料_已訂購總價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.已採購總價] = this.textBox_藥品資料_已採購總價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.已採購總量] = this.textBox_藥品資料_已採購總量.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.已採購總量上限] = this.textBox_藥品資料_已採購總量上限.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.最新訂購單價] = this.textBox_藥品資料_最新訂購單價.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.契約價金] = this.textBox_藥品資料_契約價金.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.訂購商] = this.textBox_藥品資料_訂購商.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.合約廠商] = this.textBox_藥品資料_合約廠商.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.已訂購數量] = this.textBox_藥品資料_已訂購數量.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.維護到期日] = this.textBox_藥品資料_維護到期日.Text;
                SQL_藥品資料_Data[(int)enum_藥品資料.最小包裝數量] = this.textBox_藥品資料_最小包裝數量.Text;
                return SQL_藥品資料_Data;
            }
            set
            {
                this.textBox_藥品資料_藥品碼.Text = value[(int)enum_藥品資料.藥品碼];
                this.textBox_藥品資料_合約項次.Text = value[(int)enum_藥品資料.合約項次];
                this.textBox_藥品資料_藥品名稱.Text = value[(int)enum_藥品資料.藥品名稱];
                this.textBox_藥品資料_藥品學名.Text = value[(int)enum_藥品資料.藥品學名];
                this.comboBox_藥品資料_品項.Text = value[(int)enum_藥品資料.品項];
                this.textBox_藥品資料_廠牌.Text = value[(int)enum_藥品資料.廠牌];
                this.textBox_藥品資料_健保碼.Text = value[(int)enum_藥品資料.健保碼];
                this.textBox_藥品資料_健保價.Text = value[(int)enum_藥品資料.健保價];
                this.textBox_藥品資料_庫存.Text = value[(int)enum_藥品資料.庫存];
                this.textBox_藥品資料_基本量.Text = value[(int)enum_藥品資料.基本量];
                this.textBox_藥品資料_消耗量.Text = value[(int)enum_藥品資料.消耗量];
                this.textBox_藥品資料_安全庫存.Text = value[(int)enum_藥品資料.安全庫存];
                this.textBox_藥品資料_包裝單位.Text = value[(int)enum_藥品資料.包裝單位];
                this.textBox_藥品資料_藥品條碼.Text = value[(int)enum_藥品資料.藥品條碼];
                this.textBox_藥品資料_已訂購總價.Text = value[(int)enum_藥品資料.已訂購總價];
                this.textBox_藥品資料_已採購總價.Text = value[(int)enum_藥品資料.已採購總價];
                this.textBox_藥品資料_已採購總量.Text = value[(int)enum_藥品資料.已採購總量];
                this.textBox_藥品資料_已採購總量上限.Text = value[(int)enum_藥品資料.已採購總量上限];
                this.textBox_藥品資料_契約價金.Text = value[(int)enum_藥品資料.契約價金];
                this.textBox_藥品資料_最新訂購單價.Text = value[(int)enum_藥品資料.最新訂購單價];
                this.textBox_藥品資料_訂購商.Text = value[(int)enum_藥品資料.訂購商];
                this.textBox_藥品資料_合約廠商.Text = value[(int)enum_藥品資料.合約廠商];
                this.textBox_藥品資料_已訂購數量.Text = value[(int)enum_藥品資料.已訂購數量];
                this.textBox_藥品資料_維護到期日.Text = value[(int)enum_藥品資料.維護到期日];
                this.textBox_藥品資料_最小包裝數量.Text = value[(int)enum_藥品資料.最小包裝數量];
            }
        }

        private void Program_藥品資料_Init()
        {
            this.sqL_DataGridView_藥品資料.Init();
            if (!this.sqL_DataGridView_藥品資料.SQL_IsTableCreat())
            {
                Basic.MyMessageBox.ShowDialog("'藥品資料'Table未建立!");
                //this.sqL_DataGridView_藥品資料.SQL_CreateTable();
            }
            this.sqL_DataGridView_藥品資料.RowDoubleClickEvent += sqL_DataGridView_藥品資料_RowDoubleClickEvent;
            this.sqL_DataGridView_藥品資料.DataGridRefreshEvent += sqL_DataGridView_藥品資料_DataGridRefreshEvent;
            this.sqL_DataGridView_藥品資料.DataGridColumnHeaderMouseClickEvent += SqL_DataGridView_藥品資料_DataGridColumnHeaderMouseClickEvent;
            //this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
            this.comboBox_藥品資料_品項.DataSource = this.enum_藥品資料_品項;
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
                //this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
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
                if (Dialog_IsReplaceData.Result == Dialog_IsReplaceData.enum_Result.Yes)
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
            List_str.Add("01.藥品碼          : " + data[0].ObjectToString());
            List_str.Add("02.合約項次        : " + data[1].ObjectToString());
            List_str.Add("03.藥品名稱        : " + data[2].ObjectToString());
            List_str.Add("04.藥品學名        : " + data[3].ObjectToString());
            List_str.Add("05.品項            : " + data[4].ObjectToString());
            List_str.Add("06.廠牌            : " + data[5].ObjectToString());
            List_str.Add("07.健保碼          : " + data[6].ObjectToString());
            List_str.Add("08.健保價          : " + data[7].ObjectToString());
            List_str.Add("09.庫存            : " + data[8].ObjectToString());
            List_str.Add("10.基本量          : " + data[9].ObjectToString());
            List_str.Add("11.消耗量          : " + data[10].ObjectToString());
            List_str.Add("12.安全庫存        : " + data[11].ObjectToString());
            List_str.Add("13.已訂購數量      : " + data[12].ObjectToString());
            List_str.Add("14.單位            : " + data[13].ObjectToString());
            List_str.Add("15.藥品條碼        : " + data[14].ObjectToString());
            List_str.Add("16.已訂購總價      : " + data[15].ObjectToString());
            List_str.Add("17.已採購總價      : " + data[16].ObjectToString());
            List_str.Add("18.已採購總量      : " + data[17].ObjectToString());
            List_str.Add("19.已採購總量上限  : " + data[18].ObjectToString());
            List_str.Add("20.契約價金        : " + data[19].ObjectToString());
            List_str.Add("21.最新訂購單價    : " + data[20].ObjectToString());
            List_str.Add("22.訂購商          : " + data[21].ObjectToString());
            List_str.Add("23.合約廠商        : " + data[22].ObjectToString());
            List_str.Add("24.維護到期日      : " + data[23].ObjectToString());
            List_str.Add("25.最小包裝數量    : " + data[24].ObjectToString());
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
            bool flag_OK;
            string[] SQL_Data = this.SQL_藥品資料_Data;
            flag_OK = this.Function_藥品資料_確認欄位正確(ref SQL_Data, true);
            this.SQL_藥品資料_Data = SQL_Data;
            return flag_OK;
        }
        private bool Function_藥品資料_確認欄位正確(ref string[] SQL_Data, bool IsMyMessageBoxShow)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            if (SQL_Data[(int)enum_藥品資料.藥品碼].StringIsEmpty())
            {
                List_error_msg.Add("'藥品碼'欄位空白");
            }
            if (SQL_Data[(int)enum_藥品資料.藥品條碼].StringIsEmpty())
            {
                List_error_msg.Add("'藥品條碼'欄位空白");
            }
            if (SQL_Data[(int)enum_藥品資料.藥品名稱].StringIsEmpty())
            {
                List_error_msg.Add("'藥品名稱'欄位空白");
            }
            if (SQL_Data[(int)enum_藥品資料.健保碼].StringIsEmpty())
            {
                List_error_msg.Add("'健保碼'欄位空白");
            }
            if (SQL_Data[(int)enum_藥品資料.健保價].StringIsEmpty())
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
            if (SQL_Data[(int)enum_藥品資料.基本量].StringIsEmpty())
            {
                List_error_msg.Add("'安全庫存'欄位空白");
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.基本量], out temp))
                {
                    List_error_msg.Add("'基本量'為非法字元");
                }
            }
            if (SQL_Data[(int)enum_藥品資料.安全庫存].StringIsEmpty())
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
            if (SQL_Data[(int)enum_藥品資料.消耗量].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.消耗量] = "0";
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.消耗量], out temp))
                {
                    List_error_msg.Add("'消耗量'為非法字元");
                }
            }
            if (SQL_Data[(int)enum_藥品資料.已訂購總價].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.已訂購總價] = "0";
            }

            if (SQL_Data[(int)enum_藥品資料.已訂購數量].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.已訂購數量] = "0";
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.已訂購數量], out temp))
                {
                    List_error_msg.Add("'已訂購數量'為非法字元");
                }
            }
            if (SQL_Data[(int)enum_藥品資料.已訂購總價].StringIsEmpty())
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
            if (SQL_Data[(int)enum_藥品資料.已採購總價].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.已採購總價] = "0";
            }
            else
            {
                double temp = 0;
                if (!double.TryParse(SQL_Data[(int)enum_藥品資料.已採購總價], out temp))
                {
                    SQL_Data[(int)enum_藥品資料.已採購總價] = "0";
                }
            }


            if (SQL_Data[(int)enum_藥品資料.已採購總量].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.已採購總量] = "0";
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.已採購總量], out temp))
                {
                    SQL_Data[(int)enum_藥品資料.已採購總量] = "0";
                }
            }
            if (SQL_Data[(int)enum_藥品資料.已採購總量上限].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.已採購總量上限] = "0";
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.已採購總量上限], out temp))
                {
                    SQL_Data[(int)enum_藥品資料.已採購總量上限] = "0";
                }
            }
            if (SQL_Data[(int)enum_藥品資料.契約價金].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.契約價金] = "0";
            }
            else
            {
                double temp = 0;
                if (!double.TryParse(SQL_Data[(int)enum_藥品資料.契約價金], out temp))
                {
                    SQL_Data[(int)enum_藥品資料.契約價金] = "0";
                }
            }

            if (SQL_Data[(int)enum_藥品資料.廠牌].StringIsEmpty())
            {
                List_error_msg.Add("'廠牌'欄位空白");
            }

            if (SQL_Data[(int)enum_藥品資料.維護到期日] == string.Empty)
            {
                List_error_msg.Add("'" + enum_藥品資料.維護到期日.GetEnumName() + "'" + "欄位空白");
            }
            else
            {
                if (!SQL_Data[(int)enum_藥品資料.維護到期日].Check_Date_String())
                {
                    List_error_msg.Add("'" + enum_藥品資料.維護到期日.GetEnumName() + "'" + "欄位為非有效日期(XXXX/XX/XX)");
                }
            }
            if (SQL_Data[(int)enum_藥品資料.最小包裝數量].StringIsEmpty())
            {
                SQL_Data[(int)enum_藥品資料.最小包裝數量] = "0";
            }
            else
            {
                int temp = 0;
                if (!int.TryParse(SQL_Data[(int)enum_藥品資料.最小包裝數量], out temp))
                {
                    SQL_Data[(int)enum_藥品資料.最小包裝數量] = "0";
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
        private bool Function_藥品資料_檢查品項欄位正確(string text)
        {
            foreach (string value in this.enum_藥品資料_品項)
            {
                if (text == value)
                {
                    return true;
                }
            }
            return false;
        }
        private bool Function_藥品資料_檢查合約到期日是否到期(string Date)
        {
            if (Date == "" || Date == string.Empty) return false;
            int Year = 0;
            int Month = 0;
            int Day = 0;
            Date.Get_Date(ref Year, ref Month, ref Day, TypeConvert.Enum_Year_Type.Anno_Domini);
            DateTime date_維護到期日 = new DateTime(Year, Month, Day);
            DateTime date_Now = DateTime.Now;
            int 維護到期天數 = new TimeSpan(date_維護到期日.Ticks - date_Now.Ticks).Days;
            if (維護到期天數 < 0) return true;
            else return false;
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
        private void radioButton_藥品資料_資料查詢_低於安全量_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_藥品資料_資料查詢_低於安全量.Checked)
            {
                this.comboBox_藥品資料_資料查詢_藥品碼.Enabled = false;
                this.comboBox_藥品資料_資料查詢_藥品名稱.Enabled = false;
                this.comboBox_藥品資料_資料查詢_品項.Enabled = false;
                this.comboBox_藥品資料_資料查詢_廠牌.Enabled = false;
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
                this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), comboBox_藥品資料_資料查詢_藥品碼.Text.ToUpper(), true);
            }
            else if (radioButton_藥品資料_資料查詢_藥品名稱.Checked)
            {
                this.sqL_DataGridView_藥品資料.SQL_GetRowsByLike(enum_藥品資料.藥品名稱.GetEnumName(), comboBox_藥品資料_資料查詢_藥品名稱.Text, true);
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
            else if (radioButton_藥品資料_資料查詢_低於安全量.Checked)
            {
                List<object[]> list_value = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(false);
                List<object[]> list_value_buf00 = new List<object[]>();
                List<object[]> list_value_buf01 = new List<object[]>();
                int 安全庫存;
                int 庫存;
                bool flag = false;
                for (int i = 0; i < list_value.Count; i++)
                {
                    flag = false;
                    安全庫存 = list_value[i][(int)enum_藥品資料.安全庫存].StringToInt32();
                    庫存 = list_value[i][(int)enum_藥品資料.庫存].StringToInt32();
                    if (安全庫存 == -1 || 安全庫存 == 0) flag = true;
                    if (庫存 == -1) flag = true;
                    if (庫存 >= 安全庫存) flag = true;
                    if (this.Function_藥品資料_檢查合約到期日是否到期(list_value[i][(int)enum_藥品資料.維護到期日].ToDateString()))flag = true;
                    if (!flag)
                    {
                        list_value_buf00.Add(list_value[i].DeepClone());
                    }
                    else
                    {
                        list_value_buf01.Add(list_value[i].DeepClone());
                    }
                }
                list_value_buf00.Sort(new Icp());
                for (int i = 0; i < list_value_buf01.Count; i++)
                {
                    list_value_buf00.Add(list_value_buf01[i].DeepClone());
                }
                this.sqL_DataGridView_藥品資料.RefreshGrid(list_value_buf00);
            }
        }
        public class Icp : IComparer<object[]>
        {
            public int Compare(object[] x, object[] y)
            {
                return x[(int)enum_藥品資料.合約廠商].ObjectToString().CompareTo(y[(int)enum_藥品資料.合約廠商].ObjectToString());
            }
        }

        private void SqL_DataGridView_藥品資料_DataGridColumnHeaderMouseClickEvent(int ColumnIndex)
        {
            if(ColumnIndex == (int)enum_藥品資料.廠牌)
            {
                List<object[]> list_value = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(false);
                list_value.Sort(new Icp());
                this.sqL_DataGridView_藥品資料.RefreshGrid(list_value);
            }
            if (ColumnIndex == (int)enum_藥品資料.訂購商)
            {
                List<object[]> list_value = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(false);
                list_value.Sort(new Icp());
                this.sqL_DataGridView_藥品資料.RefreshGrid(list_value);
            }
        }
        private void plC_Button_藥品資料_登錄資料_btnClick(object sender, EventArgs e)
        {
         
            if (this.Function_藥品資料_確認欄位正確(true))
            {
        
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
                List<object[]> obj_temp = this.sqL_DataGridView_藥品資料.Get_All_Select_RowsValues();
                if (obj_temp != null)
                {
                    foreach (object[] value in obj_temp)
                    {
                        this.sqL_DataGridView_藥品資料.SQL_Delete(enum_藥品資料.藥品碼.GetEnumName(), value[(int)enum_藥品資料.藥品碼].ObjectToString(), false);
                    }
                   
                }
                this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
            }
        }
        private void plC_Button_藥品資料_匯出檔案_btnClick(object sender, EventArgs e)
        {
            saveFileDialog_SaveExcel.OverwritePrompt = false;
            if (saveFileDialog_SaveExcel.ShowDialog(this) == DialogResult.OK)
            {

                DataTable datatable = new DataTable();
                datatable = sqL_DataGridView_藥品資料.GetDataTable();
                CSVHelper.SaveFile(datatable, saveFileDialog_SaveExcel.FileName);

                MyMessageBox.ShowDialog("匯出完成!");
            } 
        }
        private void plC_Button_藥品資料_匯入檔案_btnClick(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate 
            {
                if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
                {

                    DataTable datatable_buf = new DataTable();
                    DataTable datatable = new DataTable();
                    CSVHelper.LoadFile(this.openFileDialog_LoadExcel.FileName, 0, datatable);

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
                            if (i == (int)enum_藥品資料.藥品碼)
                            {
                                str_來源資料[i] = this.Function_藥品碼檢查(dr.ItemArray[i].ObjectToString());
                            }
                        }

                        List<object[]> List_obj_目的資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), str_來源資料[(int)enum_藥品資料.藥品碼], false);
                        string[] str_目的資料 = new string[藥品資料_Data_Length];
                        if (List_obj_目的資料.Count > 0)
                        {
                            for (int i = 0; i < List_obj_目的資料[0].Length; i++)
                            {
                                str_目的資料[i] = List_obj_目的資料[0][i].ObjectToString();
                                if (i == (int)enum_藥品資料.維護到期日) str_目的資料[i] = List_obj_目的資料[0][i].ToDateString();
                            }
                        }

                        if (!checkBox_藥品資料_已訂購總價更動.Checked) str_來源資料[(int)enum_藥品資料.已訂購總價] = str_目的資料[(int)enum_藥品資料.已訂購總價];
                        if (!checkBox_藥品資料_已採購總價更動.Checked) str_來源資料[(int)enum_藥品資料.已採購總價] = str_目的資料[(int)enum_藥品資料.已採購總價];
                        if (!checkBox_藥品資料_已採購總量更動.Checked) str_來源資料[(int)enum_藥品資料.已採購總量] = str_目的資料[(int)enum_藥品資料.已採購總量];
                        //if (this.Function_藥品資料_檢查覆寫欄位重複(str_來源資料, enum_藥品資料.健保碼, true))
                        //{
                        //    continue;
                        //}
                        if (this.Function_藥品資料_檢查覆寫欄位重複(str_來源資料, enum_藥品資料.藥品條碼, true))
                        {
                            continue;
                        }
                        if (!this.Function_藥品資料_檢查品項欄位正確(str_來源資料[(int)enum_藥品資料.品項]))
                        {
                            MyMessageBox.ShowDialog(string.Format("'品項欄位'格式錯誤! 藥品碼:<{0}> 品項:<{1}>", str_來源資料[(int)enum_藥品資料.藥品碼], str_來源資料[(int)enum_藥品資料.品項]));
                            continue;
                        }
                        if (this.Function_藥品資料_確認欄位正確(ref str_來源資料, false))
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
                                if (Dialog_IsReplaceData.Result == Dialog_IsReplaceData.enum_Result.All_Yes)
                                {
                                    flag_AllYes = true;
                                }
                                if (Dialog_IsReplaceData.Result == Dialog_IsReplaceData.enum_Result.All_No)
                                {
                                    flag_AllNo = true;
                                }
                                if (Dialog_IsReplaceData.Result == Dialog_IsReplaceData.enum_Result.Yes || flag_AllYes)
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
            }));
           
        }
        private void sqL_DataGridView_藥品資料_RowDoubleClickEvent(object[] RowValue)
        {
            string[] Array_str = new string[RowValue.Length];
            for (int i = 0; i < RowValue.Length; i++)
            {
                Array_str[i] = RowValue[i].ObjectToString();
                if (i == (int)enum_藥品資料.維護到期日) Array_str[i] = RowValue[i].ToDateString();
            }
            this.SQL_藥品資料_Data = Array_str;
        }
        private void sqL_DataGridView_藥品資料_DataGridRefreshEvent()
        {
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.藥品碼.GetEnumName(), true, comboBox_藥品資料_資料查詢_藥品碼);
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.藥品名稱.GetEnumName(), true, comboBox_藥品資料_資料查詢_藥品名稱);
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.品項.GetEnumName(), true, comboBox_藥品資料_資料查詢_品項);
            this.sqL_DataGridView_藥品資料.SQL_GetColumnValues(enum_藥品資料.廠牌.GetEnumName(), true, comboBox_藥品資料_資料查詢_廠牌);
            double 已訂購總價 = 0;
            double 已採購總價 = 0;
            double 已採購總量 = 0;
            double 已採購總量上限 = 0;
            for (int i = 0; i < this.sqL_DataGridView_藥品資料.dataGridView.Rows.Count; i++)
            {
                已訂購總價 = this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[enum_藥品資料.已訂購總價.GetEnumName()].Value.ToString().StringToDouble();
                已採購總價 = this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[enum_藥品資料.已採購總價.GetEnumName()].Value.ToString().StringToDouble();

                if (已採購總價 > 0)
                {
                    if (已訂購總價 > 已採購總價 * 0.9)
                    {
                        //this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        //this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                已採購總量 = this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.已採購總量].Value.ToString().StringToInt32();
                已採購總量上限 = this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.已採購總量上限].Value.ToString().StringToInt32();

                if (已採購總量上限 > 0)
                {
                    if (已採購總量 > 已採購總量上限 * 0.9)
                    {
                        //this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                        //this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                if (this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.安全庫存].Value.ToString().StringToInt32() != 0)
                {
                    if (this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.庫存].Value.ToString().StringToInt32() < this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.安全庫存].Value.ToString().StringToInt32())
                    {
                        int Year = 0;
                        int Month = 0;
                        int Day = 0;
                        this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.維護到期日].Value.ObjectToString().Get_Date(ref Year, ref Month, ref Day, TypeConvert.Enum_Year_Type.Anno_Domini);
                        if (Year == 0 || Month == 0 || Day == 0) continue;
                        DateTime date_維護到期日 = new DateTime(Year, Month, Day);
                        DateTime date_Now = DateTime.Now;
                        int 維護到期天數 = new TimeSpan(date_維護到期日.Ticks - date_Now.Ticks).Days;
                        if (維護到期天數 < 0) continue;

                        if (this.Function_藥品資料_檢查合約到期日是否到期(this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].Cells[(int)enum_藥品資料.維護到期日].Value.ObjectToString())) continue;

                        this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        this.sqL_DataGridView_藥品資料.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
       
            }
        }

        private void plC_Button_藥品資料_匯入庫存_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
            {
                string 藥品碼 = "";
                string 庫存 = "";
                int temp = 0;
                DataTable datatable = new DataTable();
                List<object[]> list_value = new List<object[]>();
                try
                {
                    datatable = MyOffice.ExcelClass.LoadFile(openFileDialog_LoadExcel.FileName);
                }
                catch
                {
                    MyMessageBox.ShowDialog("資料表格匯入錯誤!");
                    return;
                }

                Dialog_Loading Dialog_Loading = new Dialog_Loading();
                Dialog_Loading.Show();
                Dialog_Loading.StepNum = datatable.Rows.Count;
                Dialog_Loading.Refresh_Processbar();
                Dialog_Loading.Location = new Point(500, 200);

                for (int i = 1; i < datatable.Rows.Count; i++)
                {
                    Dialog_Loading.StepValue++;
                    藥品碼 = datatable.Rows[i].ItemArray[2].ObjectToString();
                    庫存 = datatable.Rows[i].ItemArray[6].ObjectToString();
                    list_value = this.sqL_DataGridView_藥品資料.GetRows(enum_藥品資料.藥品碼.GetEnumName(), 藥品碼, false);
                    foreach (object[] value in list_value)
                    {
                        if (int.TryParse(庫存, out temp))
                        {
                            value[(int)enum_藥品資料.庫存] = 庫存;
                            this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), 藥品碼, value, false);
                        }
                    }

                }
                Dialog_Loading.Dispose();
                datatable.Dispose();
                this.sqL_DataGridView_藥品資料.RefreshGrid();
                MyMessageBox.ShowDialog("匯入完成!");
            }
        }
        private void plC_Button_藥品資料_匯入異動量_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
            {
                DataTable datatable = new DataTable();
                try
                {
                    datatable = MyOffice.ExcelClass.LoadFile(openFileDialog_LoadExcel.FileName);
                }
                catch
                {
                    MyMessageBox.ShowDialog("資料表格匯入錯誤!");
                    return;
                }

                DataTable datatable_new = new DataTable();
                datatable_new.Columns.Add("藥碼");
                datatable_new.Columns.Add("異動量");
                string str_藥碼 = "";
                string str_異動量 = "";
                int 異動量 = 0;
                bool flag_havemaember = false;
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    DataRow row = datatable_new.NewRow();
                    str_藥碼 = datatable.Rows[i][1].ToString();
                    str_異動量 = datatable.Rows[i][3].ToString();
                    異動量 = 0;
                    flag_havemaember = false;
                    if (str_藥碼 != "")
                    {
                        int.TryParse(str_異動量, out 異動量);
                        for (int k = 0; k < datatable_new.Rows.Count; k++)
                        {
                            if (datatable_new.Rows[k][0].ToString() == str_藥碼)
                            {
                                int 異動量_temp = 0;
                                if (int.TryParse(datatable_new.Rows[k][1].ToString(), out 異動量_temp))
                                {
                                    datatable_new.Rows[k][1] = (異動量_temp + 異動量).ToString();
                                }
                                flag_havemaember = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag_havemaember = true;
                    }
                    if (!flag_havemaember)
                    {
                        row["藥碼"] = str_藥碼;
                        row["異動量"] = str_異動量;
                        datatable_new.Rows.Add(row);
                    }
                }

                List<object[]> list_value = new List<object[]>();

                Dialog_Loading Dialog_Loading = new Dialog_Loading();
                Dialog_Loading.Show();
                Dialog_Loading.StepNum = datatable_new.Rows.Count;
                Dialog_Loading.Refresh_Processbar();
                Dialog_Loading.Location = new Point(500, 200);

                for (int i = 1; i < datatable_new.Rows.Count; i++)
                {
                    Dialog_Loading.StepValue++;
                    str_藥碼 = datatable_new.Rows[i]["藥碼"].ObjectToString();
                    str_異動量 = datatable_new.Rows[i]["異動量"].ObjectToString();
                    list_value = this.sqL_DataGridView_藥品資料.GetRows(enum_藥品資料.藥品碼.GetEnumName(), str_藥碼, false);
                    foreach (object[] value in list_value)
                    {
                        if (int.TryParse(str_異動量, out 異動量))
                        {
                            value[(int)enum_藥品資料.消耗量] = 異動量;
                            this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), str_藥碼, value, false);
                        }
                    }

                }
                Dialog_Loading.Dispose();
                datatable.Dispose();
                datatable_new.Dispose();
                this.sqL_DataGridView_藥品資料.RefreshGrid();
                MyMessageBox.ShowDialog("匯入完成!");
            }
        }
        private void plC_Button_藥品資料_已訂購總價重置_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("已訂購總價全部'歸零'?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                List<object[]> list_value = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(false);
                Dialog_Loading Dialog_Loading = new Dialog_Loading();
                Dialog_Loading.Show();
                Dialog_Loading.StepNum = list_value.Count;
                Dialog_Loading.Refresh_Processbar();
                Dialog_Loading.Location = new Point(500, 200);
                foreach (object[] value in list_value)
                {
                    Dialog_Loading.StepValue++;
                    value[(int)enum_藥品資料.已訂購總價] = 0.ToString();
                    this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), value[(int)enum_藥品資料.藥品碼].ObjectToString(), value, false);
                }
                Dialog_Loading.Dispose();
                this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
                MyMessageBox.ShowDialog("資料更新完成!");
            }
        }
        #endregion
    }
}
