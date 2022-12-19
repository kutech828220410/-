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
        PLC_Device PLC_Device_設定編號 = new PLC_Device("D4040");
        PLC_Device PLC_Device_期初庫存金額 = new PLC_Device("D4050");
        PLC_Device PLC_Device_驗收期限 = new PLC_Device("D4000");
        PLC_Device PLC_Device_超時訂單警報_紅 = new PLC_Device("D4002");
        PLC_Device PLC_Device_超時訂單警報_黃 = new PLC_Device("D4001");
        PLC_Device PLC_Device_自動登出時間_分 = new PLC_Device("D4020");
        PLC_Device PLC_Device_自動登出時間_秒 = new PLC_Device("D4021");
        int 參數資料_Data_Length = Enum.GetValues(typeof(enum_參數資料)).Length;
        public enum enum_參數資料 : int
        {
           GUID,名稱,數值
        }
        public enum enum_參數名稱 : int
        {
            PLC_設定編號,
            伺服器參數_UserName, 伺服器參數_Password, 伺服器參數_Host, 伺服器參數_Port, 伺服器參數_發件者,
            PLC_驗收期限, PLC_超時訂單警報_黃, PLC_超時訂單警報_紅, PLC_自動登出時間_分, PLC_自動登出時間_秒,
            PLC_期初庫存金額,
            短效罰金計算,
            逾時罰金計算,

        }
   

        private void Program_參數資料_Init()
        {
            this.sqL_DataGridView_參數資料.Init();
            if (!this.sqL_DataGridView_參數資料.SQL_IsTableCreat())
            {
                Basic.MyMessageBox.ShowDialog("'參數資料'Table未建立!");
                //this.sqL_DataGridView_參數資料.SQL_CreateTable();
            }
            enum_參數名稱 _enum_參數名稱 = enum_參數名稱.PLC_自動登出時間_分;
            foreach (string value in _enum_參數名稱.GetEnumNames())
            {
                if(!this.sqL_DataGridView_參數資料.SQL_IsHaveMember(enum_參數資料.名稱.GetEnumName(), value))
                {
                    this.sqL_DataGridView_參數資料.SQL_AddRow(new object[] { value, "" }, true);
                }
            }
            

            //this.sqL_DataGridView_參數資料.RowDoubleClickEvent += sqL_DataGridView_參數資料_RowDoubleClickEvent;
            //this.sqL_DataGridView_參數資料.DataGridRefreshEvent += sqL_DataGridView_參數資料_DataGridRefreshEvent;
             this.sqL_DataGridView_參數資料.SQL_GetAllRows(true);
            this.button_參數資料設定GUID.Click += Button_參數資料設定GUID_Click;
        }

   

        private void sub_Program_參數資料()
        {
            sub_Program_設定SQL參數設定();
            sub_Program_取得SQL參數設定();
        }

        #region 設定SQL參數設定
        PLC_Device PLC_Device_設定SQL參數設定 = new PLC_Device("S7020");
        int cnt_Program_設定SQL參數設定 = 65534;
        void sub_Program_設定SQL參數設定()
        {
            if (cnt_Program_設定SQL參數設定 == 65534)
            {
                PLC_Device_設定SQL參數設定.SetComment("PLC_設定SQL參數設定");
                PLC_Device_設定SQL參數設定.Bool = false;
                cnt_Program_設定SQL參數設定 = 65535;
            }
            if (cnt_Program_設定SQL參數設定 == 65535) cnt_Program_設定SQL參數設定 = 1;
            if (cnt_Program_設定SQL參數設定 == 1) cnt_Program_設定SQL參數設定_檢查按下(ref cnt_Program_設定SQL參數設定);
            if (cnt_Program_設定SQL參數設定 == 2) cnt_Program_設定SQL參數設定_初始化(ref cnt_Program_設定SQL參數設定);
            if (cnt_Program_設定SQL參數設定 == 3) cnt_Program_設定SQL參數設定_開始設置(ref cnt_Program_設定SQL參數設定);
            if (cnt_Program_設定SQL參數設定 == 4) cnt_Program_設定SQL參數設定 = 65500;
            if (cnt_Program_設定SQL參數設定 > 1) cnt_Program_設定SQL參數設定_檢查放開(ref cnt_Program_設定SQL參數設定);

            if (cnt_Program_設定SQL參數設定 == 65500)
            {
                PLC_Device_設定SQL參數設定.Bool = false;
                cnt_Program_設定SQL參數設定 = 65535;
            }
        }
        void cnt_Program_設定SQL參數設定_檢查按下(ref int cnt)
        {
            if (PLC_Device_設定SQL參數設定.Bool) cnt++;
        }
        void cnt_Program_設定SQL參數設定_檢查放開(ref int cnt)
        {
            if (!PLC_Device_設定SQL參數設定.Bool) cnt = 65500;
        }
        void cnt_Program_設定SQL參數設定_初始化(ref int cnt)
        {
            if (MyMessageBox.ShowDialog("確認將'參數資料'更新至Server?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel) == DialogResult.Yes)
            {
                cnt++;
                return;
            }
            else
            {
                cnt = 65500;
                return;
            }

        }
        void cnt_Program_設定SQL參數設定_開始設置(ref int cnt)
        {
            object[] value;
            string colname = enum_參數資料.名稱.GetEnumName();
            string serchColname;

            serchColname = enum_參數名稱.伺服器參數_UserName.GetEnumName();
            value = new object[] { serchColname, this.textBox_信箱設定_伺服器參數_UserName.Text };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.伺服器參數_Password.GetEnumName();
            value = new object[] { serchColname, this.textBox_信箱設定_伺服器參數_Password.Text };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.伺服器參數_Host.GetEnumName();
            value = new object[] { serchColname, this.textBox_信箱設定_伺服器參數_Host.Text };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.伺服器參數_Port.GetEnumName();
            value = new object[] { serchColname, this.textBox_信箱設定_伺服器參數_Port.Text };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.伺服器參數_發件者.GetEnumName();
            value = new object[] { serchColname, this.textBox_信箱設定_伺服器參數_發件者.Text };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.PLC_驗收期限.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_驗收期限.GetValue()).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.PLC_超時訂單警報_紅.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_超時訂單警報_紅.GetValue()).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.PLC_超時訂單警報_黃.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_超時訂單警報_黃.GetValue()).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.PLC_自動登出時間_分.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_自動登出時間_分.GetValue()).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.PLC_自動登出時間_秒.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_自動登出時間_秒.GetValue()).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.PLC_設定編號.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_設定編號.Value + 1).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);


            serchColname = enum_參數名稱.PLC_期初庫存金額.GetEnumName();
            value = new object[] { serchColname, (this.PLC_Device_期初庫存金額.Value).ToString() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.短效罰金計算.GetEnumName();
            value = new object[] { serchColname, (plC_CheckBox_短效罰金計算.Bool).ToString().ToUpper() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            serchColname = enum_參數名稱.逾時罰金計算.GetEnumName();
            value = new object[] { serchColname, (plC_CheckBox_逾時罰金計算.Bool).ToString().ToUpper() };
            this.sqL_DataGridView_參數資料.SQL_Replace(colname, serchColname, value, false);

            this.sqL_DataGridView_參數資料.SQL_GetAllRows(true);

            MyMessageBox.ShowDialog("參數設置完成!");
            cnt++;
        }
        #endregion
        #region 取得SQL參數設定
        PLC_Device PLC_Device_取得SQL參數設定 = new PLC_Device("S7030");
        PLC_Device PLC_Device_開機取得SQL參數設定 = new PLC_Device("S7033");
        int cnt_Program_取得SQL參數設定 = 65534;
        void sub_Program_取得SQL參數設定()
        {
            if (cnt_Program_取得SQL參數設定 == 65534)
            {
                PLC_Device_取得SQL參數設定.SetComment("PLC_取得SQL參數設定");
                PLC_Device_開機取得SQL參數設定.SetComment("開機取得SQL參數設定");
                PLC_Device_取得SQL參數設定.Bool = false;
                cnt_Program_取得SQL參數設定 = 65535;
            }
            if (cnt_Program_取得SQL參數設定 == 65535) cnt_Program_取得SQL參數設定 = 1;
            if (cnt_Program_取得SQL參數設定 == 1) cnt_Program_取得SQL參數設定_檢查按下(ref cnt_Program_取得SQL參數設定);
            if (cnt_Program_取得SQL參數設定 == 2) cnt_Program_取得SQL參數設定_初始化(ref cnt_Program_取得SQL參數設定);
            if (cnt_Program_取得SQL參數設定 == 3) cnt_Program_取得SQL參數設定_取得設定編號(ref cnt_Program_取得SQL參數設定);
            if (cnt_Program_取得SQL參數設定 == 4) cnt_Program_取得SQL參數設定_開始設置(ref cnt_Program_取得SQL參數設定);
            if (cnt_Program_取得SQL參數設定 == 5) cnt_Program_取得SQL參數設定 = 65500;
            if (cnt_Program_取得SQL參數設定 > 1) cnt_Program_取得SQL參數設定_檢查放開(ref cnt_Program_取得SQL參數設定);

            if (cnt_Program_取得SQL參數設定 == 65500)
            {
                PLC_Device_取得SQL參數設定.Bool = false;
                cnt_Program_取得SQL參數設定 = 65535;
            }
        }
        void cnt_Program_取得SQL參數設定_檢查按下(ref int cnt)
        {
            if (PLC_Device_取得SQL參數設定.Bool) cnt++;
        }
        void cnt_Program_取得SQL參數設定_檢查放開(ref int cnt)
        {
            if (!PLC_Device_取得SQL參數設定.Bool) cnt = 65500;
        }
        void cnt_Program_取得SQL參數設定_初始化(ref int cnt)
        {
            cnt++;

        }
        void cnt_Program_取得SQL參數設定_取得設定編號(ref int cnt)
        {
            int 設定編號 = 0;
            string colname = enum_參數資料.名稱.GetEnumName();
            string serchColname = enum_參數名稱.PLC_設定編號.GetEnumName();
            List<object[]> list_value = this.sqL_DataGridView_參數資料.SQL_GetRows(colname, serchColname, false);
            if (list_value.Count > 0)
            {
                設定編號 = list_value[0][(int)enum_參數資料.數值].StringToInt32();
                if (this.PLC_Device_設定編號.Value < 設定編號 || PLC_Device_開機取得SQL參數設定.Bool)
                {
                    this.PLC_Device_設定編號.Value = 設定編號;
                    PLC_Device_開機取得SQL參數設定.Bool = false;
                    cnt++;
                    return;
                }
                else
                {
                    cnt = 65500;
                    return;
                }
            }
            cnt = 65500;

        }
        void cnt_Program_取得SQL參數設定_開始設置(ref int cnt)
        {
            this.sqL_DataGridView_參數資料.SQL_GetAllRows(true);

            List<object[]> value;
            string colname = enum_參數資料.名稱.GetEnumName();
            string serchColname;

            this.Invoke(new Action(delegate {
                serchColname = enum_參數名稱.伺服器參數_UserName.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.textBox_信箱設定_伺服器參數_UserName.Text = value[0][(int)enum_參數資料.數值].ObjectToString();

                serchColname = enum_參數名稱.伺服器參數_Password.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.textBox_信箱設定_伺服器參數_Password.Text = value[0][(int)enum_參數資料.數值].ObjectToString();

                serchColname = enum_參數名稱.伺服器參數_Host.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.textBox_信箱設定_伺服器參數_Host.Text = value[0][(int)enum_參數資料.數值].ObjectToString();

                serchColname = enum_參數名稱.伺服器參數_Port.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.textBox_信箱設定_伺服器參數_Port.Text = value[0][(int)enum_參數資料.數值].ObjectToString();

                serchColname = enum_參數名稱.伺服器參數_發件者.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.textBox_信箱設定_伺服器參數_發件者.Text = value[0][(int)enum_參數資料.數值].ObjectToString();


                serchColname = enum_參數名稱.PLC_驗收期限.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.PLC_Device_驗收期限.Value = value[0][(int)enum_參數資料.數值].StringToInt32();

                serchColname = enum_參數名稱.PLC_超時訂單警報_紅.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.PLC_Device_超時訂單警報_紅.Value = value[0][(int)enum_參數資料.數值].StringToInt32();

                serchColname = enum_參數名稱.PLC_超時訂單警報_黃.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.PLC_Device_超時訂單警報_黃.Value = value[0][(int)enum_參數資料.數值].StringToInt32();

                serchColname = enum_參數名稱.PLC_自動登出時間_分.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.PLC_Device_自動登出時間_分.Value = value[0][(int)enum_參數資料.數值].StringToInt32();

                serchColname = enum_參數名稱.PLC_自動登出時間_秒.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.PLC_Device_自動登出時間_秒.Value = value[0][(int)enum_參數資料.數值].StringToInt32();

                serchColname = enum_參數名稱.PLC_期初庫存金額.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0) this.PLC_Device_期初庫存金額.Value = value[0][(int)enum_參數資料.數值].StringToInt32();

                serchColname = enum_參數名稱.短效罰金計算.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0)
                {
                    if(!value[0][(int)enum_參數資料.數值].ObjectToString().StringIsEmpty())
                    {
                        if (value[0][(int)enum_參數資料.數值].ObjectToString().ToUpper() == true.ToString().ToUpper()) plC_CheckBox_短效罰金計算.Bool = true;
                        else plC_CheckBox_短效罰金計算.Bool = false;
                    }                 
                }
                serchColname = enum_參數名稱.逾時罰金計算.GetEnumName();
                value = this.sqL_DataGridView_參數資料.GetRows(colname, serchColname, false);
                if (value.Count > 0)
                {
                    if (!value[0][(int)enum_參數資料.數值].ObjectToString().StringIsEmpty())
                    {
                        if (value[0][(int)enum_參數資料.數值].ObjectToString().ToUpper() == true.ToString().ToUpper()) plC_CheckBox_逾時罰金計算.Bool = true;
                        else plC_CheckBox_逾時罰金計算.Bool = false;
                    }
                }
            }));
            

            //MyMessageBox.ShowDialog("線上更新參數已設定至本機!");
            cnt++;
        }
        #endregion

        private void Button_參數資料設定GUID_Click(object sender, EventArgs e)
        {
            List<object[]> list_value = this.sqL_DataGridView_參數資料.SQL_GetAllRows(false);
            for (int i = 0; i < list_value.Count; i++)
            {
                list_value[i][(int)enum_參數資料.GUID] = Guid.NewGuid().ToString();
            }
            this.sqL_DataGridView_參數資料.SQL_CreateTable();
            this.sqL_DataGridView_參數資料.SQL_AddRows(list_value, true);

        }
    }
}
