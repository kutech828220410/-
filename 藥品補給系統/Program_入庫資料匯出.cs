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
        int enum_入庫資料匯出_中榮表單_Lenth = Enum.GetValues(typeof(enum_入庫資料匯出_中榮表單)).Length;
        public enum enum_入庫資料匯出_中榮表單
        {
            院所別,
            驗收日期,
            採購單編號,
            訂購日期,
            訂購數量,
            入庫數量,
            單位,
            採購價,
            物料編碼,
            物料名稱,
            新藥碼,
            裝量,
            效期,
            批號,
            藥碼,
        }
        int enum_入庫資料匯出_一般表單_Lenth = Enum.GetValues(typeof(enum_入庫資料匯出_一般表單)).Length;
        public enum enum_入庫資料匯出_一般表單
        {
            序號,
            合約項次,
            藥品碼,
            品項名稱,
            健保碼,
            健保價,
            單位,
            數量,
            單價,
            發票金額,
            折讓金額,
            折讓後總價,
            逾期罰金,
            短效罰金,
            庫存價差,
            付款金額,
            廠商,
            發票號碼,
            發票日期,
            訂購日期,
            入庫日期,
            登錄時間,
        }

        private void Program_入庫資料匯出_Init()
        {
            this.sqL_DataGridView_入庫資料匯出_發票資料.Init();
            this.sqL_DataGridView_入庫資料匯出_發票資料.DataGridRefreshEvent += SqL_DataGridView_入庫資料匯出_發票資料_DataGridRefreshEvent;

            this.sqL_DataGridView_入庫資料匯出_匯出表單.Init();
            this.sqL_DataGridView_入庫資料匯出_匯出表單.DataGridRefreshEvent += sqL_DataGridView_入庫資料匯出_匯出表單_DataGridRefreshEvent;
    
          
        }



        private void sub_Program_入庫資料匯出()
        {
            sub_PLC_Program_入庫資料匯出_頁面更新();
            sub_PLC_Program_入庫資料匯出_匯出表單();
        }
        #region PLC_Program_入庫資料匯出_頁面更新
        PLC_Device PLC_Program_入庫資料匯出_頁面更新 = new PLC_Device("Y507");
        void sub_PLC_Program_入庫資料匯出_頁面更新()
        {
            if (this.PLC_Program_入庫資料匯出_頁面更新.Bool)
            {
                this.Function_入庫資料匯出_計算總額();
                this.PLC_Program_入庫資料匯出_頁面更新.Bool = false;
            }
        }

        #endregion
        #region PLC_Program_入庫資料匯出_匯出表單
        PLC_Device PLC_Program_入庫資料匯出_匯出表單 = new PLC_Device("S4050");
        int cnt_sub_入庫資料匯出_匯出表單 = 65534;
        void sub_PLC_Program_入庫資料匯出_匯出表單()
        {
            if (cnt_sub_入庫資料匯出_匯出表單 == 65534)
            {
                PLC_Program_入庫資料匯出_匯出表單.Bool = false;
                cnt_sub_入庫資料匯出_匯出表單 = 65535;
            }
            if (cnt_sub_入庫資料匯出_匯出表單 == 65535) cnt_sub_入庫資料匯出_匯出表單 = 1;
            if (cnt_sub_入庫資料匯出_匯出表單 == 1) cnt_sub_入庫資料匯出_匯出表單_檢查按鈕按下(ref cnt_sub_入庫資料匯出_匯出表單);
            if (cnt_sub_入庫資料匯出_匯出表單 == 2) cnt_sub_入庫資料匯出_匯出表單_檢查匯出表單類型(ref cnt_sub_入庫資料匯出_匯出表單);

            if (cnt_sub_入庫資料匯出_匯出表單 == 100) cnt_sub_入庫資料匯出_匯出表單_100_中榮_開始匯出(ref cnt_sub_入庫資料匯出_匯出表單);
            if (cnt_sub_入庫資料匯出_匯出表單 == 101) cnt_sub_入庫資料匯出_匯出表單 = 65500;

            if (cnt_sub_入庫資料匯出_匯出表單 == 200) cnt_sub_入庫資料匯出_匯出表單_200_一般_開始匯出(ref cnt_sub_入庫資料匯出_匯出表單);
            if (cnt_sub_入庫資料匯出_匯出表單 == 201) cnt_sub_入庫資料匯出_匯出表單 = 65500;

            if (cnt_sub_入庫資料匯出_匯出表單 > 1) cnt_sub_入庫資料匯出_匯出表單_檢查按鈕放開(ref cnt_sub_入庫資料匯出_匯出表單);
            if (cnt_sub_入庫資料匯出_匯出表單 == 65500)
            {
                this.PLC_Program_入庫資料匯出_匯出表單.Bool = false;
                cnt_sub_入庫資料匯出_匯出表單 = 65535;
            }
        }
        void cnt_sub_入庫資料匯出_匯出表單_檢查按鈕按下(ref int cnt)
        {
            if (PLC_Program_入庫資料匯出_匯出表單.Bool) cnt++;
        }
        void cnt_sub_入庫資料匯出_匯出表單_檢查按鈕放開(ref int cnt)
        {
            if (!PLC_Program_入庫資料匯出_匯出表單.Bool) cnt = 65500;
        }
        void cnt_sub_入庫資料匯出_匯出表單_初始化(ref int cnt)
        {
            cnt++;
        }
        void cnt_sub_入庫資料匯出_匯出表單_檢查匯出表單類型(ref int cnt)
        {
            if(radioButton_入庫資料匯出_匯出選擇_中榮.Checked)
            {
                cnt = 100;
            }
            else if (radioButton_入庫資料匯出_匯出選擇_一般.Checked)
            {
                cnt = 200;
            }
        }
        void cnt_sub_入庫資料匯出_匯出表單_100_中榮_開始匯出(ref int cnt)
        {
            DataTable datatable = new DataTable();
            foreach (string str in enum_入庫資料匯出_中榮表單.入庫數量.GetEnumNames())
            {
                datatable.Columns.Add(str);
            }
            
            List<object[]> list_value = sqL_DataGridView_入庫資料匯出_匯出表單.GetAllRows();
            List<object[]> list_藥品;
            foreach(object[] value in list_value)
            {
                string[] value_out = new string[enum_入庫資料匯出_中榮表單_Lenth];
                value_out[(int)enum_入庫資料匯出_中榮表單.院所別] = textBox_入庫資料匯出_匯出選擇_院所別.Text;
                value_out[(int)enum_入庫資料匯出_中榮表單.驗收日期] = value[(int)enum_發票資料.登錄時間].ToDateString(TypeConvert.Enum_Year_Type.Republic_of_China, "");
                value_out[(int)enum_入庫資料匯出_中榮表單.採購單編號] =value[(int)enum_發票資料.發票號碼].ObjectToString() + value[(int)enum_發票資料.序號].ObjectToString();
                value_out[(int)enum_入庫資料匯出_中榮表單.訂購日期] = value[(int)enum_發票資料.訂購日期].ToDateString(TypeConvert.Enum_Year_Type.Republic_of_China, "");
                value_out[(int)enum_入庫資料匯出_中榮表單.訂購數量] = value[(int)enum_發票資料.數量].ObjectToString();
                value_out[(int)enum_入庫資料匯出_中榮表單.入庫數量] = value[(int)enum_發票資料.數量].ObjectToString();
                value_out[(int)enum_入庫資料匯出_中榮表單.單位] = "NULL";
                value_out[(int)enum_入庫資料匯出_中榮表單.採購價] = value[(int)enum_發票資料.折讓後單價].ObjectToString();
                value_out[(int)enum_入庫資料匯出_中榮表單.物料編碼] = "";
                value_out[(int)enum_入庫資料匯出_中榮表單.物料名稱] = "NULL";
                value_out[(int)enum_入庫資料匯出_中榮表單.新藥碼] = value[(int)enum_發票資料.藥品碼].ObjectToString();
                value_out[(int)enum_入庫資料匯出_中榮表單.裝量] = "1";
                value_out[(int)enum_入庫資料匯出_中榮表單.效期] = value[(int)enum_發票資料.效期].ToDateString(TypeConvert.Enum_Year_Type.Republic_of_China, "");
                value_out[(int)enum_入庫資料匯出_中榮表單.批號] = value[(int)enum_發票資料.批號].ObjectToString();
                value_out[(int)enum_入庫資料匯出_中榮表單.藥碼] = "";

                list_藥品 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_發票資料.藥品碼.GetEnumName(), value[(int)enum_發票資料.藥品碼].ObjectToString(), false);
                if(list_藥品.Count == 0)
                {
                    MyMessageBox.ShowDialog(string.Format("查無'{0}'藥品碼", value[(int)enum_發票資料.藥品碼].ObjectToString()));
                }
                foreach (object[] value_藥品 in list_藥品)
                {
                    value_藥品[(int)enum_藥品資料.已訂購數量] = (value_藥品[(int)enum_藥品資料.已訂購數量].StringToInt32() - value[(int)enum_發票資料.數量].StringToInt32()).ToString();
                    this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), value[(int)enum_發票資料.藥品碼].ObjectToString(), value_藥品, false);
                }
                if (this.plC_CheckBox_入庫資料匯出_設定已異動.GetValue()) value[(int)enum_發票資料.中榮匯出] = true.ToString();
                this.sqL_DataGridView_入庫資料匯出_匯出表單.SQL_Replace(new string[] { enum_發票資料.序號.GetEnumName(), enum_發票資料.發票號碼.GetEnumName() }, new string[] { value[(int)enum_發票資料.序號].ObjectToString() , value[(int)enum_發票資料.發票號碼].ObjectToString() }, value, false);
           
                datatable.Rows.Add(value_out);
            }
            CSVHelper.SaveFile(datatable, saveFileDialog_SaveExcel.FileName);
            MyMessageBox.ShowDialog("匯出完成!");
            cnt++;
        }
        void cnt_sub_入庫資料匯出_匯出表單_200_一般_開始匯出(ref int cnt)
        {
            DataTable datatable = new DataTable();
            object[] array_表單內容;
            List<object[]> list_藥品資料;
            foreach(string value in enum_入庫資料匯出_一般表單.付款金額.GetEnumNames())
            {
                datatable.Columns.Add(value);
            }
            List<object[]> list_匯出表單內容 = this.sqL_DataGridView_入庫資料匯出_匯出表單.GetAllRows();
            foreach (object[] value in list_匯出表單內容)
            {
                array_表單內容 = new object[this.enum_入庫資料匯出_一般表單_Lenth];
                array_表單內容[(int)enum_入庫資料匯出_一般表單.藥品碼] = value[(int)enum_發票資料.藥品碼].ObjectToString();
                list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), array_表單內容[(int)enum_入庫資料匯出_一般表單.藥品碼].ObjectToString(), false);
                if(list_藥品資料.Count > 0)
                {             
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.合約項次] = list_藥品資料[0][(int)enum_藥品資料.合約項次].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.品項名稱] = list_藥品資料[0][(int)enum_藥品資料.藥品名稱].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.健保碼] = list_藥品資料[0][(int)enum_藥品資料.健保碼].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.健保價] = list_藥品資料[0][(int)enum_藥品資料.健保價].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.廠商] = list_藥品資料[0][(int)enum_藥品資料.合約廠商].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.單位] = list_藥品資料[0][(int)enum_藥品資料.包裝單位].ObjectToString();
                    
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.序號] = value[(int)enum_發票資料.序號].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.數量] = value[(int)enum_發票資料.數量].ObjectToString().StringToInt32();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.單價] = value[(int)enum_發票資料.單價].ObjectToString().StringToDouble();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.發票金額] = value[(int)enum_發票資料.總價].ObjectToString().StringToDouble();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.折讓金額] = value[(int)enum_發票資料.折讓金額].ObjectToString().StringToDouble();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.折讓後總價] = (value[(int)enum_發票資料.總價].ObjectToString().StringToDouble() - value[(int)enum_發票資料.折讓金額].ObjectToString().StringToDouble());
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.訂購日期] = value[(int)enum_發票資料.訂購日期].ToDateString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.入庫日期] = value[(int)enum_發票資料.入庫日期].ToDateString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.登錄時間] = value[(int)enum_發票資料.登錄時間].ToDateTimeString();
                    
                    double 逾期罰金 = 0;
                    double.TryParse(value[(int)enum_發票資料.逾期罰金].ObjectToString(), out 逾期罰金);
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.逾期罰金] = 逾期罰金;

                    double 短效罰金 = 0;
                    double.TryParse(value[(int)enum_發票資料.短效罰金].ObjectToString(), out 短效罰金);
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.短效罰金] = 短效罰金;

                    array_表單內容[(int)enum_入庫資料匯出_一般表單.庫存價差] = 0;

                    double 折讓後總價 = array_表單內容[(int)enum_入庫資料匯出_一般表單.折讓後總價].StringToDouble();

                    array_表單內容[(int)enum_入庫資料匯出_一般表單.付款金額] = (折讓後總價 - 逾期罰金 - 短效罰金);



                    array_表單內容[(int)enum_入庫資料匯出_一般表單.發票號碼] = value[(int)enum_發票資料.發票號碼].ObjectToString();
                    array_表單內容[(int)enum_入庫資料匯出_一般表單.發票日期] = value[(int)enum_發票資料.發票日期].ToDateString();


                 
                    datatable.Rows.Add(array_表單內容);
                }
                else
                {
                    MyMessageBox.ShowDialog(string.Format("查無'{0}'藥品碼", value[(int)enum_發票資料.藥品碼].ObjectToString()));
                }
                if (this.plC_CheckBox_入庫資料匯出_設定已異動.GetValue()) value[(int)enum_發票資料.一般匯出] = true.ToString();
                this.sqL_DataGridView_入庫資料匯出_匯出表單.SQL_Replace(new string[] { enum_發票資料.序號.GetEnumName(), enum_發票資料.發票號碼.GetEnumName() }, new string[] { value[(int)enum_發票資料.序號].ObjectToString(), value[(int)enum_發票資料.發票號碼].ObjectToString() }, value, false);

            }
            CSVHelper.SaveFile(datatable, saveFileDialog_SaveExcel.FileName);
            MyMessageBox.ShowDialog("匯出完成!");
            cnt++;
        }
        void cnt_sub_入庫資料匯出_匯出表單_(ref int cnt)
        {
            cnt++;
        }
        #endregion

        #region Function
        private void Function_入庫資料匯出_計算總額()
        {
            
            int 總計額 = 0;
            int 折讓後總計額 = 0;
            int 總價 = 0;
            List<object[]> list_value = this.sqL_DataGridView_入庫資料匯出_匯出表單.GetRowsList();
            foreach (object[] value in list_value)
            {
                總價 = value[(int)enum_發票資料.總價].ObjectToString().StringToInt32();
                總計額 += 總價;
                折讓後總計額 += (value[(int)enum_發票資料.總價].ObjectToString().StringToInt32() - value[(int)enum_發票資料.折讓金額].ObjectToString().StringToInt32());
               
            }

            this.Invoke(new Action(delegate
            {
                this.textBox_入庫資料匯出_總價總計額.Text = 總計額.ToString();
                this.textBox_入庫資料匯出_折讓後總價總計額.Text = 折讓後總計額.ToString();
            }));
        }
        #endregion
        #region Event
        private void plC_Button_入庫資料匯出_已入庫資料搜尋_日期搜尋_btnClick(object sender, EventArgs e)
        {
            string 表單名稱 = this.radioButton_入庫資料匯出_匯出選擇_中榮.Checked ? enum_發票資料.中榮匯出.GetEnumName() : enum_發票資料.一般匯出.GetEnumName();
            string 匯出選擇 = this.radioButton_入庫資料匯出_已入庫資料搜尋_已匯出.Checked ? true.ToString() : "";
            if (this.radioButton_入庫資料匯出_已入庫資料搜尋_全部.Checked) 匯出選擇 = "None";

            string 開始日期, 結束日期;
            dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_起始時間.Format = DateTimePickerFormat.Short;
            dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_結束時間.Format = DateTimePickerFormat.Short;
            開始日期 = dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_起始時間.Value.Date.ToShortDateString();
            結束日期 = dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_結束時間.Value.AddDays(0).Date.ToShortDateString();
            if (DateTime.Compare(dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_起始時間.Value.Date, dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_結束時間.Value.Date) <= 0)
            {
                if(this.radioButton_入庫資料匯出_入庫日期.Checked)
                {
                    this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRowsByBetween(enum_發票資料.入庫日期.GetEnumName(), 開始日期, 結束日期, true);
                }
                else if(this.radioButton_入庫資料匯出_發票日期.Checked)
                {
                    this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRowsByBetween(enum_發票資料.發票日期.GetEnumName(), 開始日期, 結束日期, true);
                }
                else if (this.radioButton_入庫資料匯出_登錄日期.Checked)
                {
                    結束日期 = dateTimePicker_入庫資料匯出_已入庫資料搜尋_日期搜尋_結束時間.Value.AddDays(1).Date.ToShortDateString();
                    this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRowsByBetween(enum_發票資料.登錄時間.GetEnumName(), 開始日期, 結束日期, true);
                }
                if (匯出選擇 != "None")
                {
                    this.sqL_DataGridView_入庫資料匯出_發票資料.GetRows(表單名稱, 匯出選擇, true);
                }
            }
            else
            {
                MyMessageBox.ShowDialog("輸入日期不合法!");
            }
        }
        private void plC_Button_入庫資料匯出_已入庫資料搜尋_訂單編號_btnClick(object sender, EventArgs e)
        {
            string 表單名稱 = this.radioButton_入庫資料匯出_匯出選擇_中榮.Checked ? enum_發票資料.中榮匯出.GetEnumName() : enum_發票資料.一般匯出.GetEnumName();
            string 匯出選擇 = this.radioButton_入庫資料匯出_已入庫資料搜尋_已匯出.Checked ? true.ToString() : "";
            if (this.radioButton_入庫資料匯出_已入庫資料搜尋_全部.Checked) 匯出選擇 = "None";

            this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRows(enum_發票資料.訂單編號.GetEnumName(), this.textBox_入庫資料匯出_已入庫資料搜尋_訂單編號.Text, true);
            if (匯出選擇 != "None")
            {
                this.sqL_DataGridView_入庫資料匯出_發票資料.GetRows(表單名稱, 匯出選擇, true);
            }
        }
        private void plC_Button_入庫資料匯出_已入庫資料搜尋_藥品碼_btnClick(object sender, EventArgs e)
        {
            string 表單名稱 = this.radioButton_入庫資料匯出_匯出選擇_中榮.Checked ? enum_發票資料.中榮匯出.GetEnumName() : enum_發票資料.一般匯出.GetEnumName();
            string 匯出選擇 = this.radioButton_入庫資料匯出_已入庫資料搜尋_已匯出.Checked ? true.ToString() : "";
            if (this.radioButton_入庫資料匯出_已入庫資料搜尋_全部.Checked) 匯出選擇 = "None";

            this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRows(enum_發票資料.藥品碼.GetEnumName(), this.textBox_入庫資料匯出_已入庫資料搜尋_藥品碼.Text, true);
            if (匯出選擇 != "None")
            {
                this.sqL_DataGridView_入庫資料匯出_發票資料.GetRows(表單名稱, 匯出選擇, true);
            }
        }
        private void plC_Button_入庫資料匯出_已入庫資料搜尋_批號_btnClick(object sender, EventArgs e)
        {
            string 表單名稱 = this.radioButton_入庫資料匯出_匯出選擇_中榮.Checked ? enum_發票資料.中榮匯出.GetEnumName() : enum_發票資料.一般匯出.GetEnumName();
            string 匯出選擇 = this.radioButton_入庫資料匯出_已入庫資料搜尋_已匯出.Checked ? true.ToString() : "";
            if (this.radioButton_入庫資料匯出_已入庫資料搜尋_全部.Checked) 匯出選擇 = "None";

            this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRows(enum_發票資料.批號.GetEnumName(), this.textBox_入庫資料匯出_已入庫資料搜尋_批號.Text, true);
            if (匯出選擇 != "None")
            {
                this.sqL_DataGridView_入庫資料匯出_發票資料.GetRows(表單名稱, 匯出選擇, true);
            }
        }
        private void plC_Button_入庫資料匯出_已入庫資料搜尋_藥品名稱_btnClick(object sender, EventArgs e)
        {
            string 表單名稱 = this.radioButton_入庫資料匯出_匯出選擇_中榮.Checked ? enum_發票資料.中榮匯出.GetEnumName() : enum_發票資料.一般匯出.GetEnumName();
            string 匯出選擇 = this.radioButton_入庫資料匯出_已入庫資料搜尋_已匯出.Checked ? true.ToString() : "";
            if (this.radioButton_入庫資料匯出_已入庫資料搜尋_全部.Checked) 匯出選擇 = "None";

            this.sqL_DataGridView_入庫資料匯出_發票資料.SQL_GetRowsByLike(enum_發票資料.藥品名稱.GetEnumName(), this.textBox_入庫資料匯出_已入庫資料搜尋_藥品名稱.Text, true);
            if (匯出選擇 != "None")
            {
                this.sqL_DataGridView_入庫資料匯出_發票資料.GetRows(表單名稱, 匯出選擇, true);
            }
        }
        private void plC_Button_入庫資料匯出_已入庫資料_填入資料_btnClick(object sender, EventArgs e)
        {
            List<object[]> list_value = this.sqL_DataGridView_入庫資料匯出_發票資料.Get_All_Select_RowsValues();
            if (list_value.Count > 0)
            {
                string 發票號碼;
                string 序號;
                foreach (object[] value in list_value)
                {
                    發票號碼 = value[(int)enum_發票資料.發票號碼].ObjectToString();
                    序號 = value[(int)enum_發票資料.序號].ObjectToString();
                    if (!this.sqL_DataGridView_入庫資料匯出_匯出表單.IsHaveMember(new string[] { enum_發票資料.發票號碼.GetEnumName(), enum_發票資料.序號.GetEnumName() }, new string[] { 發票號碼, 序號 }))
                    {
                        this.sqL_DataGridView_入庫資料匯出_匯出表單.AddRow(value, false);
                    }
                }
                this.sqL_DataGridView_入庫資料匯出_匯出表單.RefreshGrid();
            }
        }
        private void plC_Button_入庫資料匯出_匯出表單_btnClick(object sender, EventArgs e)
        {
            saveFileDialog_SaveExcel.OverwritePrompt = false;
            if (saveFileDialog_SaveExcel.ShowDialog(this) == DialogResult.OK)
            {
                if (!PLC_Program_入庫資料匯出_匯出表單.Bool) PLC_Program_入庫資料匯出_匯出表單.Bool = true;
            }
        }
        private void plC_Button_入庫資料匯出_匯出表單內容_刪除選取資料_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否刪除所選取資料?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                this.sqL_DataGridView_入庫資料匯出_匯出表單.Delete(true);
            }
        }

        private void SqL_DataGridView_入庫資料匯出_發票資料_DataGridRefreshEvent()
        {
            string 表單已異動 = "";
            for (int i = 0; i < this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows.Count; i++)
            {
                if(radioButton_入庫資料匯出_匯出選擇_中榮.Checked)
                {
                    表單已異動 = this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows[i].Cells[(int)enum_發票資料.中榮匯出].Value.ObjectToString();
                    if (表單已異動 == true.ToString())
                    {
                        this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                        this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    表單已異動 = this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows[i].Cells[(int)enum_發票資料.一般匯出].Value.ObjectToString();
                    if (表單已異動 == true.ToString())
                    {
                        this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                        this.sqL_DataGridView_入庫資料匯出_發票資料.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
              
               
            }
        }
        private void sqL_DataGridView_入庫資料匯出_匯出表單_DataGridRefreshEvent()
        {
            this.Function_入庫資料匯出_計算總額();
        }
        private void radioButton_入庫資料匯出_匯出選擇_中榮_CheckedChanged(object sender, EventArgs e)
        {
            this.sqL_DataGridView_入庫資料匯出_發票資料.ClearGrid();
            this.sqL_DataGridView_入庫資料匯出_匯出表單.ClearGrid();
            this.Function_入庫資料匯出_計算總額();
        }
        private void radioButton_入庫資料匯出_匯出選擇_一般_CheckedChanged(object sender, EventArgs e)
        {
            this.sqL_DataGridView_入庫資料匯出_發票資料.ClearGrid();
            this.sqL_DataGridView_入庫資料匯出_匯出表單.ClearGrid();
            this.Function_入庫資料匯出_計算總額();
        }
        private void plC_Button_藥品周轉率_計算_btnClick(object sender, EventArgs e)
        {
            double 期初庫存金額 = plC_NumBox_入庫資料匯出_期初庫存金額.Value;
            double 購入金額 = textBox_入庫資料匯出_折讓後總價總計額.Text.StringToDouble();
            double 消耗金額 = 0;
            double 期末庫存金額 = 0;
            if (期初庫存金額 < 0)
            {
                MyMessageBox.ShowDialog("'期初庫存金額'格式不合法!");
                return;
            }
            double 單價 = 0;
            int 消耗量 = 0;
            string 藥品碼 = "";   
            List<object[]> list_value = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(true);
            foreach (object[] value in list_value)
            {
                藥品碼 = value[(int)enum_藥品資料.藥品碼].ObjectToString();
                單價 = value[(int)enum_藥品資料.最新訂購單價].ObjectToString().StringToDouble();
                消耗量 = value[(int)enum_藥品資料.消耗量].ObjectToString().StringToInt32();
                if (單價 > 0 && 消耗量 > 0)
                {
                    消耗金額 += 單價 * 消耗量;
                }
                else
                {
                    // MyMessageBox.ShowDialog();
                }
            }
            //List<object[]> list_value = this.sqL_DataGridView_入庫資料匯出_匯出表單.GetRowsList();
            //List<object[]> list_藥品資訊;
            //List<object[]> list_訂單資訊;
            //foreach (object[] value in list_value)
            //{
            //    藥品碼 = value[(int)enum_發票資料.藥品碼].ObjectToString();
            //    訂單編號 = value[(int)enum_發票資料.訂單編號].ObjectToString();
            //    list_藥品資訊 = this.sqL_DataGridView_藥品資料.GetRows(enum_藥品資料.藥品碼.GetEnumName(), 藥品碼, false);
            //    list_訂單資訊 = this.sqL_DataGridView_訂單資料.GetRows(new string[] { enum_訂單資料.訂單編號.GetEnumName(), enum_藥品資料.藥品碼.GetEnumName() }, new string[] { 訂單編號, 藥品碼 }, false);
            //    if (list_藥品資訊.Count > 0)
            //    {
            //        單價 = list_訂單資訊[0][(int)enum_訂單資料.訂購單價].ObjectToString().StringToDouble();
            //        if (單價 == 0)
            //        {
            //            單價 = list_藥品資訊[0][(int)enum_藥品資料.最新訂購單價].ObjectToString().StringToDouble();
            //        }
            //        消耗量 = list_藥品資訊[0][(int)enum_藥品資料.消耗量].ObjectToString().StringToInt32();
            //        if (單價 > 0 && 消耗量 > 0)
            //        {
            //            消耗金額 += 單價 * 消耗量;
            //        }
            //        else
            //        {
            //           // MyMessageBox.ShowDialog();
            //        }
            //    }

            //}
            期末庫存金額 = 期初庫存金額 + 購入金額 - 消耗金額;
            textBox_入庫資料匯出_期末庫存金額.Text = 期末庫存金額.ToString();
            textBox_入庫資料匯出_消耗金額.Text = 消耗金額.ToString();
            textBox_入庫資料匯出_平均庫存金額.Text = ((期初庫存金額 + 期末庫存金額) / 2).ToString() ;
            textBox_入庫資料匯出_周轉率.Text = ( 消耗金額 / ((期初庫存金額 + 期末庫存金額) / 2)).ToString("0.0000");
            MyMessageBox.ShowDialog("計算完成!");
        }
        #endregion
    }
}
