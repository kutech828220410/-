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
using SQLUI;
namespace 藥品補給系統
{
    public partial class Form1 : Form
    {
        PLC_Device PLC_Device_訂單管理權限 = new PLC_Device("S4083");
        int 登入權限資料_Data_Length = Enum.GetValues(typeof(enum_登入權限資料)).Length;
        public enum enum_登入權限資料 : int
        {
            權限等級, 下訂單 , 驗收訂單, 入庫資料匯出, 供應商資料, 藥品資料, 訂單管理 , 人員資料, 信箱設定, 刪除訂單, 訂單匯出異動
        }
        private void Program_登入權限資料_Init()
        {
            SQL_DataGridView.SQL_Set_Properties(this.sqL_DataGridView_登入權限資料, dBConfigClass.DB_person_page);
            this.sqL_DataGridView_登入權限資料.Init();
            if (!this.sqL_DataGridView_登入權限資料.SQL_IsTableCreat())
            {
                Basic.MyMessageBox.ShowDialog("'登入權限資料'Table未建立!");
                //this.sqL_DataGridView_登入權限資料.SQL_CreateTable();
            }
            this.sqL_DataGridView_登入權限資料.SQL_GetAllRows(true);
            this.Function_登入權限資料_檢查表格合理性();
        }
        private void Function_登入權限資料_檢查表格合理性()
        {
            bool flag_OK = true;
            List<object[]> list_value = this.sqL_DataGridView_登入權限資料.GetAllRows();
            if (list_value.Count != 9)
            {
                flag_OK = false;
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (list_value[i][(int)enum_登入權限資料.權限等級].ObjectToString() != (i + 1).ToString("00")) flag_OK = false;
                }
            }
            if (!flag_OK)
            {
                this.sqL_DataGridView_登入權限資料.SQL_CreateTable();
                for (int i = 0; i < 9; i++)
                {
                    object[] value = new object[this.登入權限資料_Data_Length];
                    for (int k = 0; k < this.登入權限資料_Data_Length; k++)
                    {
                        if (k == 0) value[k] = (i + 1).ToString("00");
                        else
                        {
                            value[k] = false.ToString();
                        }
                    }
                    this.sqL_DataGridView_登入權限資料.SQL_AddRow(value, false);
                }
                this.sqL_DataGridView_登入權限資料.SQL_GetAllRows(true);
            }
        }

        void sub_Program_登入權限資料()
        {
            sub_Program_設定SQL登入權限();
            sub_Program_取得SQL登入權限();
        }
        #region 設定SQL登入權限
        PLC_Device PLC_Device_設定SQL登入權限 = new PLC_Device("S7000");
        int cnt_Program_設定SQL登入權限 = 65534;
        void sub_Program_設定SQL登入權限()
        {
            if (cnt_Program_設定SQL登入權限 == 65534)
            {
                PLC_Device_設定SQL登入權限.SetComment("PLC_設定SQL登入權限");
                PLC_Device_設定SQL登入權限.Bool = false;
                cnt_Program_設定SQL登入權限 = 65535;
            }
            if (cnt_Program_設定SQL登入權限 == 65535) cnt_Program_設定SQL登入權限 = 1;
            if (cnt_Program_設定SQL登入權限 == 1) cnt_Program_設定SQL登入權限_檢查按下(ref cnt_Program_設定SQL登入權限);
            if (cnt_Program_設定SQL登入權限 == 2) cnt_Program_設定SQL登入權限_初始化(ref cnt_Program_設定SQL登入權限);
            if (cnt_Program_設定SQL登入權限 == 3) cnt_Program_設定SQL登入權限_開始設置(ref cnt_Program_設定SQL登入權限);
            if (cnt_Program_設定SQL登入權限 == 4) cnt_Program_設定SQL登入權限 = 65500;
            if (cnt_Program_設定SQL登入權限 > 1) cnt_Program_設定SQL登入權限_檢查放開(ref cnt_Program_設定SQL登入權限);

            if (cnt_Program_設定SQL登入權限 == 65500)
            {
                PLC_Device_設定SQL登入權限.Bool = false;
                cnt_Program_設定SQL登入權限 = 65535;
            }
        }
        void cnt_Program_設定SQL登入權限_檢查按下(ref int cnt)
        {
            if (PLC_Device_設定SQL登入權限.Bool) cnt++;
        }
        void cnt_Program_設定SQL登入權限_檢查放開(ref int cnt)
        {
            if (!PLC_Device_設定SQL登入權限.Bool) cnt = 65500;
        }
        void cnt_Program_設定SQL登入權限_初始化(ref int cnt)
        {
            if (MyMessageBox.ShowDialog("確認將'權限資料'更新至Server?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel) == DialogResult.Yes)
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
        void cnt_Program_設定SQL登入權限_開始設置(ref int cnt)
        {
            object[] value;
            for (int i = 0; i < 9; i++)
            {
                value = new object[this.登入權限資料_Data_Length];
                value[(int)enum_登入權限資料.權限等級] = (i + 1).ToString("00");
                this.PLC_權限管理_登入使用者權限索引.Value = i * 20;
                for (int k = 0; k < 20; k++)
                {
                    if (k == 0) value[(int)enum_登入權限資料.下訂單] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 1) value[(int)enum_登入權限資料.驗收訂單] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 2) value[(int)enum_登入權限資料.入庫資料匯出] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 3) value[(int)enum_登入權限資料.訂單管理] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 4) value[(int)enum_登入權限資料.供應商資料] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 5) value[(int)enum_登入權限資料.藥品資料] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 6) value[(int)enum_登入權限資料.人員資料] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 7) value[(int)enum_登入權限資料.信箱設定] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 8) value[(int)enum_登入權限資料.刪除訂單] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                    else if (k == 9) value[(int)enum_登入權限資料.訂單匯出異動] = this.List_PLC_Device_權限管理_登入使用者權限索引[k].Bool.ToString();
                }
                this.sqL_DataGridView_登入權限資料.SQL_Replace(enum_登入權限資料.權限等級.GetEnumName(), value[(int)enum_登入權限資料.權限等級].ObjectToString(), value, false);
            }
            this.sqL_DataGridView_登入權限資料.SQL_GetAllRows(true);
            MyMessageBox.ShowDialog("權限設置完成!");
            cnt++;
        }
        #endregion
        #region 取得SQL登入權限
        PLC_Device PLC_Device_取得SQL登入權限 = new PLC_Device("S7010");
        int cnt_Program_取得SQL登入權限 = 65534;
        void sub_Program_取得SQL登入權限()
        {
            if (cnt_Program_取得SQL登入權限 == 65534)
            {
                PLC_Device_取得SQL登入權限.SetComment("PLC_取得SQL登入權限");
                PLC_Device_取得SQL登入權限.Bool = false;
                cnt_Program_取得SQL登入權限 = 65535;
            }
            if (cnt_Program_取得SQL登入權限 == 65535) cnt_Program_取得SQL登入權限 = 1;
            if (cnt_Program_取得SQL登入權限 == 1) cnt_Program_取得SQL登入權限_檢查按下(ref cnt_Program_取得SQL登入權限);
            if (cnt_Program_取得SQL登入權限 == 2) cnt_Program_取得SQL登入權限_初始化(ref cnt_Program_取得SQL登入權限);
            if (cnt_Program_取得SQL登入權限 == 3) cnt_Program_取得SQL登入權限_開始取得SQL資料(ref cnt_Program_取得SQL登入權限);           
            if (cnt_Program_取得SQL登入權限 == 4) cnt_Program_取得SQL登入權限 = 65500;
            if (cnt_Program_取得SQL登入權限 > 1) cnt_Program_取得SQL登入權限_檢查放開(ref cnt_Program_取得SQL登入權限);

            if (cnt_Program_取得SQL登入權限 == 65500)
            {
                PLC_Device_取得SQL登入權限.Bool = false;
                cnt_Program_取得SQL登入權限 = 65535;
            }
        }
        void cnt_Program_取得SQL登入權限_檢查按下(ref int cnt)
        {
            if (PLC_Device_取得SQL登入權限.Bool) cnt++;
        }
        void cnt_Program_取得SQL登入權限_檢查放開(ref int cnt)
        {
            if (!PLC_Device_取得SQL登入權限.Bool) cnt = 65500;
        }
        void cnt_Program_取得SQL登入權限_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_Program_取得SQL登入權限_開始取得SQL資料(ref int cnt)
        {
            List<object[]> list_value = this.sqL_DataGridView_登入權限資料.SQL_GetAllRows(false);
            int 權限等級;
            for (int i = 0; i < 9; i++)
            {
                權限等級 = list_value[i][(int)enum_登入權限資料.權限等級].StringToInt32();
                this.PLC_權限管理_登入使用者權限索引.Value = (權限等級 - 1) * 20;
                this.List_PLC_Device_權限管理_登入使用者權限索引[0].Bool = list_value[i][(int)enum_登入權限資料.下訂單].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[1].Bool = list_value[i][(int)enum_登入權限資料.驗收訂單].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[2].Bool = list_value[i][(int)enum_登入權限資料.入庫資料匯出].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[3].Bool = list_value[i][(int)enum_登入權限資料.供應商資料].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[4].Bool = list_value[i][(int)enum_登入權限資料.訂單管理].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[5].Bool = list_value[i][(int)enum_登入權限資料.藥品資料].StringToBool(); 
                this.List_PLC_Device_權限管理_登入使用者權限索引[6].Bool = list_value[i][(int)enum_登入權限資料.人員資料].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[7].Bool = list_value[i][(int)enum_登入權限資料.信箱設定].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[8].Bool = list_value[i][(int)enum_登入權限資料.刪除訂單].StringToBool();
                this.List_PLC_Device_權限管理_登入使用者權限索引[9].Bool = list_value[i][(int)enum_登入權限資料.訂單匯出異動].StringToBool();
            }
            cnt++;
        }
        #endregion
    }
}
