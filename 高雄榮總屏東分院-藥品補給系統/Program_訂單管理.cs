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
        PLC_Device PLC_超出驗收期限警報_黃 = new PLC_Device("D4001");
        PLC_Device PLC_超出驗收期限警報_紅 = new PLC_Device("D4002");

        private void Program_訂單管理_Init()
        {
            this.sqL_DataGridView_訂單管理_訂單列表.Init();
            this.sqL_DataGridView_訂單管理_訂單內容.Init();
            this.sqL_DataGridView_訂單管理_入庫資料.Init();

            this.sqL_DataGridView_訂單管理_訂單列表.RowEnterEvent += sqL_DataGridView_訂單管理_訂單列表_RowEnterEvent;
            this.sqL_DataGridView_訂單管理_訂單列表.DataGridRefreshEvent += sqL_DataGridView_訂單管理_訂單列表_DataGridRefreshEvent;

        }
        private void sub_Program_訂單管理()
        {
            sub_PLC_Program_訂單管理_頁面更新();
            sub_PLC_Program_訂單管理_資料搜尋();
        }
        #region PLC_Program_訂單管理_頁面更新
        PLC_Device PLC_Program_訂單管理_頁面更新 = new PLC_Device("Y504");
        void sub_PLC_Program_訂單管理_頁面更新()
        {
            if (this.PLC_Program_訂單管理_頁面更新.Bool)
            {
                this.Function_訂單管理_ClearDataGrid();
                this.PLC_Program_訂單管理_頁面更新.Bool = false;
            }
        }

        #endregion
        #region PLC_Program_訂單管理_資料搜尋
        enum Enum_Program_訂單管理_資料搜尋_搜尋方式
        {
            全部搜索, 訂單編號,藥品碼, 藥品條碼
        }
        Enum_Program_訂單管理_資料搜尋_搜尋方式 enum_Program_訂單管理_資料搜尋_搜尋方式 = new Enum_Program_訂單管理_資料搜尋_搜尋方式();
        PLC_Device PLC_Program_訂單管理_資料搜尋 = new PLC_Device("S4060");
        List<object[]> List_訂單管理_資料搜尋 = new List<object[]>();
        int cnt_sub_訂單管理_資料搜尋 = 65534;
        void sub_PLC_Program_訂單管理_資料搜尋()
        {
            if (cnt_sub_訂單管理_資料搜尋 == 65534)
            {
                PLC_Program_訂單管理_資料搜尋.Bool = false;
                cnt_sub_訂單管理_資料搜尋 = 65535;
            }
            if (cnt_sub_訂單管理_資料搜尋 == 65535) cnt_sub_訂單管理_資料搜尋 = 1;
            if (cnt_sub_訂單管理_資料搜尋 == 1) cnt_sub_訂單管理_資料搜尋_檢查按鈕按下(ref cnt_sub_訂單管理_資料搜尋);
            if (cnt_sub_訂單管理_資料搜尋 == 2) cnt_sub_訂單管理_資料搜尋_初始化(ref cnt_sub_訂單管理_資料搜尋);
            if (cnt_sub_訂單管理_資料搜尋 == 3) cnt_sub_訂單管理_資料搜尋_開始搜索表單(ref cnt_sub_訂單管理_資料搜尋);
            if (cnt_sub_訂單管理_資料搜尋 == 4) cnt_sub_訂單管理_資料搜尋_檢查驗收條件(ref cnt_sub_訂單管理_資料搜尋);
            if (cnt_sub_訂單管理_資料搜尋 == 5) cnt_sub_訂單管理_資料搜尋_檢查搜尋方式(ref cnt_sub_訂單管理_資料搜尋);         
            if (cnt_sub_訂單管理_資料搜尋 == 6) cnt_sub_訂單管理_資料搜尋_更新DataGridView(ref cnt_sub_訂單管理_資料搜尋);
            if (cnt_sub_訂單管理_資料搜尋 == 7) cnt_sub_訂單管理_資料搜尋 = 65500;

            if (cnt_sub_訂單管理_資料搜尋 > 1) cnt_sub_訂單管理_資料搜尋_檢查按鈕放開(ref cnt_sub_訂單管理_資料搜尋);
            if (cnt_sub_訂單管理_資料搜尋 == 65500)
            {
                this.PLC_Program_訂單管理_資料搜尋.Bool = false;
                cnt_sub_訂單管理_資料搜尋 = 65535;
            }
        }
        void cnt_sub_訂單管理_資料搜尋_檢查按鈕按下(ref int cnt)
        {
            if (PLC_Program_訂單管理_資料搜尋.Bool) cnt++;
        }
        void cnt_sub_訂單管理_資料搜尋_檢查按鈕放開(ref int cnt)
        {
            if (!PLC_Program_訂單管理_資料搜尋.Bool) cnt = 65500;
        }
        void cnt_sub_訂單管理_資料搜尋_初始化(ref int cnt)
        {
            this.sqL_DataGridView_訂單管理_訂單列表.ClearGrid();
            cnt++;
        }
        void cnt_sub_訂單管理_資料搜尋_開始搜索表單(ref int cnt)
        {
            string 開始日期, 結束日期;
            bool flag_ok = true;
            this.Invoke(new Action(delegate
            {
                dateTimePicker_訂單管理_資料搜尋_日期範圍_起始日期.Format = DateTimePickerFormat.Short;
                dateTimePicker_訂單管理_資料搜尋_日期範圍_結束日期.Format = DateTimePickerFormat.Short;
                開始日期 = dateTimePicker_訂單管理_資料搜尋_日期範圍_起始日期.Value.Date.ToShortDateString();
                結束日期 = dateTimePicker_訂單管理_資料搜尋_日期範圍_結束日期.Value.AddDays(0).Date.ToShortDateString();
                if (DateTime.Compare(dateTimePicker_訂單管理_資料搜尋_日期範圍_起始日期.Value.Date, dateTimePicker_訂單管理_資料搜尋_日期範圍_結束日期.Value.Date) <= 0)
                {
                    List_訂單管理_資料搜尋 = this.sqL_DataGridView_訂單資料.SQL_GetRowsByBetween(enum_訂單資料.訂購日期.GetEnumName(), 開始日期, 結束日期, enum_訂單資料.訂購日期.GetEnumName(), SQLUI.SQLControl.OrderType.UpToLow, false);
                    if (List_訂單管理_資料搜尋.Count == 0)
                    {
                        MyMessageBox.ShowDialog("查無資料!");
                        flag_ok = false;
                        return;
                    }
                }
                else
                {
                    MyMessageBox.ShowDialog("輸入日期不合法!");
                    flag_ok = false;
                    return;
                }
            }));
            if (flag_ok) cnt++;
            else cnt = 65500;
           
        }
        void cnt_sub_訂單管理_資料搜尋_檢查驗收條件(ref int cnt)
        {
            List<object[]> List_訂單管理_資料搜尋_buf = new List<object[]>();
            if(radioButton_訂單管理_資料搜尋_已驗收.Checked)
            {
                foreach (object[] value in List_訂單管理_資料搜尋)
                {
                    if (value[(int)enum_訂單資料.確認驗收].ObjectToString() == true.ToString())
                    {
                        List_訂單管理_資料搜尋_buf.Add(value.DeepClone());
                    }
                }
            }
            else if (radioButton_訂單管理_資料搜尋_未驗收.Checked)
            {
                foreach (object[] value in List_訂單管理_資料搜尋)
                {
                    if (value[(int)enum_訂單資料.確認驗收].ObjectToString() == false.ToString())
                    {
                        List_訂單管理_資料搜尋_buf.Add(value.DeepClone());
                    }
                }
            }
            else if (radioButton_訂單管理_資料搜尋_全部.Checked)
            {
                foreach (object[] value in List_訂單管理_資料搜尋)
                {
                    List_訂單管理_資料搜尋_buf.Add(value.DeepClone());                                                   
                }
            }
            List_訂單管理_資料搜尋.Clear();
            bool flag_IsHaveMember = false;
            foreach (object[] value_buf in List_訂單管理_資料搜尋_buf)
            {
                flag_IsHaveMember = false;
                foreach (object[] value in List_訂單管理_資料搜尋)
                {
                    if (value_buf[(int)enum_訂單資料.訂單編號].ObjectToString() == value[(int)enum_訂單資料.訂單編號].ObjectToString()) flag_IsHaveMember = true;
                }
                if(!flag_IsHaveMember)
                {
                    List_訂單管理_資料搜尋.Add(value_buf);
                }
            }
            cnt++;
        }
        void cnt_sub_訂單管理_資料搜尋_檢查搜尋方式(ref int cnt)
        {
            List<object[]> List_訂單管理_資料搜尋_buf = new List<object[]>();
            if(enum_Program_訂單管理_資料搜尋_搜尋方式 == Enum_Program_訂單管理_資料搜尋_搜尋方式.全部搜索)
            {
                List_訂單管理_資料搜尋_buf = List_訂單管理_資料搜尋.DeepClone();
            }
            else if(enum_Program_訂單管理_資料搜尋_搜尋方式 == Enum_Program_訂單管理_資料搜尋_搜尋方式.訂單編號)
            {
                string 訂單編號 = textBox_訂單管理_資料搜尋_訂單編號.Text;
                foreach (object[] value in List_訂單管理_資料搜尋)
                {
                    if (value[(int)enum_訂單資料.訂單編號].ObjectToString() == 訂單編號)
                    {
                        List_訂單管理_資料搜尋_buf.Add(value.DeepClone());
                    }
                }
            }
            else if (enum_Program_訂單管理_資料搜尋_搜尋方式 == Enum_Program_訂單管理_資料搜尋_搜尋方式.藥品碼)
            {
                string 藥品碼 = textBox_訂單管理_資料搜尋_藥品碼.Text;
                foreach (object[] value in List_訂單管理_資料搜尋)
                {
                    if (value[(int)enum_訂單資料.藥品碼].ObjectToString() == 藥品碼)
                    {
                        List_訂單管理_資料搜尋_buf.Add(value.DeepClone());
                    }
                }
            }
            else if (enum_Program_訂單管理_資料搜尋_搜尋方式 == Enum_Program_訂單管理_資料搜尋_搜尋方式.藥品條碼)
            {
                string 藥品條碼 = textBox_訂單管理_資料搜尋_藥品條碼.Text;
                List<object[]> list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品條碼.GetEnumName(), 藥品條碼, false);
                if (list_藥品資料.Count > 0)
                {
                    string 藥品碼 = list_藥品資料[0][(int)enum_藥品資料.藥品碼].ObjectToString();
                    foreach (object[] value in List_訂單管理_資料搜尋)
                    {
                        if (value[(int)enum_訂單資料.藥品碼].ObjectToString() == 藥品碼)
                        {
                            List_訂單管理_資料搜尋_buf.Add(value.DeepClone());
                        }
                    }
                }           
            }
            List_訂單管理_資料搜尋 = List_訂單管理_資料搜尋_buf.DeepClone();
            cnt++;
        }
        void cnt_sub_訂單管理_資料搜尋_更新DataGridView(ref int cnt)
        {
            this.sqL_DataGridView_訂單管理_訂單列表.AddRows(List_訂單管理_資料搜尋, true);
            if (List_訂單管理_資料搜尋.Count == 0)
            {
                MyMessageBox.ShowDialog("查無資料!");
            }
            cnt++;
        }
        void cnt_sub_訂單管理_資料搜尋_(ref int cnt)
        {
            cnt++;
        }
        #endregion
        #region Function
        private void Function_訂單管理_ClearDataGrid()
        {
            this.sqL_DataGridView_訂單管理_訂單列表.ClearGrid();
            this.sqL_DataGridView_訂單管理_訂單內容.ClearGrid();
            this.sqL_DataGridView_訂單管理_入庫資料.ClearGrid();
                           
        }
        #endregion
        #region Event
        private void plC_Button_訂單管理_資料搜尋_訂單編號_btnClick(object sender, EventArgs e)
        {
            if (!PLC_Program_訂單管理_資料搜尋.Bool)
            {
                this.enum_Program_訂單管理_資料搜尋_搜尋方式 = Form1.Enum_Program_訂單管理_資料搜尋_搜尋方式.訂單編號;
                PLC_Program_訂單管理_資料搜尋.Bool = true;
            }
        }
        private void plC_Button_訂單管理_資料搜尋_藥品碼_btnClick(object sender, EventArgs e)
        {
            if (!PLC_Program_訂單管理_資料搜尋.Bool)
            {
                this.enum_Program_訂單管理_資料搜尋_搜尋方式 = Form1.Enum_Program_訂單管理_資料搜尋_搜尋方式.藥品碼;
                PLC_Program_訂單管理_資料搜尋.Bool = true;
            }
        }
        private void plC_Button_訂單管理_資料搜尋_藥品條碼_btnClick(object sender, EventArgs e)
        {
            if (!PLC_Program_訂單管理_資料搜尋.Bool)
            {
                this.enum_Program_訂單管理_資料搜尋_搜尋方式 = Form1.Enum_Program_訂單管理_資料搜尋_搜尋方式.藥品條碼;
                PLC_Program_訂單管理_資料搜尋.Bool = true;
            }
        }
        private void plC_Button_訂單管理_資料搜尋_全部搜索_btnClick(object sender, EventArgs e)
        {
            if (!PLC_Program_訂單管理_資料搜尋.Bool)
            {
                this.enum_Program_訂單管理_資料搜尋_搜尋方式 = Form1.Enum_Program_訂單管理_資料搜尋_搜尋方式.全部搜索;
                PLC_Program_訂單管理_資料搜尋.Bool = true;
            }
        }
        private void plC_Button_訂單管理_刪除選取訂單資料_btnClick(object sender, EventArgs e)
        {
            object[] value = this.sqL_DataGridView_訂單管理_訂單列表.GetRowValues();
            if(value != null)
            {
                string 訂單編號 = value[(int)enum_訂單資料.訂單編號].ObjectToString();
                string Message_str = "確定清除'" + 訂單編號 + "'此筆訂單所有內容?(發票資料及入庫資料)";
                DialogResult Result = MyMessageBox.ShowDialog(Message_str, MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
                if (Result == DialogResult.Yes)
                {
                    this.sqL_DataGridView_訂單管理_訂單列表.Delete(enum_訂單資料.訂單編號.GetEnumName(), 訂單編號, true);
                    this.sqL_DataGridView_訂單資料.SQL_Delete(enum_訂單資料.訂單編號.GetEnumName(), 訂單編號, false);
                    this.sqL_DataGridView_發票資料.SQL_Delete(enum_發票資料.訂單編號.GetEnumName(), 訂單編號, false);

                    this.sqL_DataGridView_訂單管理_訂單內容.ClearGrid();
                    this.sqL_DataGridView_訂單管理_入庫資料.ClearGrid();
                }
            }
         
        }


        private void sqL_DataGridView_訂單管理_訂單列表_DataGridRefreshEvent()
        {
            string 確認驗收 = "";
            int 應驗收日期 = 0;
            int 現在日期 = DateTime.Now.Date.ToShortDateString().Get_DateTINY();
            int 逾時天數 = 0;
            for (int i = 0; i < this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows.Count; i++)
            {
                確認驗收 = this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].Cells[(int)enum_訂單資料.確認驗收].Value.ObjectToString();
                應驗收日期 = this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].Cells[(int)enum_訂單資料.應驗收日期].Value.ObjectToString().Get_DateTINY();
                逾時天數 = 現在日期 - 應驗收日期;
                if (確認驗收 == true.ToString())
                {
                    this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                    this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }   
                else if (逾時天數 > PLC_超出驗收期限警報_紅.Value)
                {
                    this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (逾時天數 > PLC_超出驗收期限警報_黃.Value)
                {
                    this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    this.sqL_DataGridView_訂單管理_訂單列表.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void sqL_DataGridView_訂單管理_訂單列表_RowEnterEvent(object[] RowValue)
        {
            this.sqL_DataGridView_訂單管理_訂單內容.SQL_GetRows(enum_訂單資料.訂單編號.GetEnumName(), RowValue[(int)enum_訂單資料.訂單編號].ObjectToString(), true);
            this.sqL_DataGridView_訂單管理_入庫資料.SQL_GetRows(enum_發票資料.訂單編號.GetEnumName(), RowValue[(int)enum_發票資料.訂單編號].ObjectToString(), true);
        }

        #endregion
    }
}
