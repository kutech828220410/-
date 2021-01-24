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
        int 訂單資料_Data_Length = Enum.GetValues(typeof(enum_訂單資料)).Length;
        public enum enum_訂單資料 : int
        {
            序號,
            訂單編號,
            藥品碼,
            藥品名稱,
            單位,
            供應商全名,
            供應商Email,
            供應商聯絡人,
            供應商電話,
            包裝單位,
            訂購日期,
            訂購時間,
            訂購人,
            訂購院所別,
            訂購數量,
            已入庫數量,
            訂購單價,
            訂購總價,
            前次訂購單價,
            驗收人,
            驗收院所別,
            驗收日期,
            驗收時間,
            驗收單價,
            驗收總價,
            前次驗收單價,
            應驗收日期,
            發票日期,
            發票金額,
            折讓金額,
            效期,
            批號,
            確認驗收,
            備註,
        }

   

        private void Program_訂單資料_Init()
        {
            this.sqL_DataGridView_訂單資料.Init();
            if (!this.sqL_DataGridView_訂單資料.SQL_IsTableCreat())
            {
                this.sqL_DataGridView_訂單資料.SQL_CreateTable();
            }
            //this.sqL_DataGridView_訂單資料.RowDoubleClickEvent += sqL_DataGridView_訂單資料_RowDoubleClickEvent;
            //this.sqL_DataGridView_訂單資料.DataGridRefreshEvent += sqL_DataGridView_訂單資料_DataGridRefreshEvent;
            this.sqL_DataGridView_訂單資料.SQL_GetAllRows(true);
        }
        private void sub_Program_訂單資料()
        {
            sub_PLC_Program_訂單資料_更新指定訂單入庫資料();
        }

        #region PLC_Program_訂單資料_更新指定訂單入庫資料
        PLC_Device PLC_Program_訂單資料_更新指定訂單入庫資料開始 = new PLC_Device("S4045");
        string str_訂單資料_更新指定訂單入庫資料_訂單號碼 = "SN0001";
        int cnt_Program_訂單資料_更新指定訂單入庫資料 = 65534;
        void sub_PLC_Program_訂單資料_更新指定訂單入庫資料()
        {
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 65534)
            {
                this.PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool = false;
                cnt_Program_訂單資料_更新指定訂單入庫資料 = 65535;
            }
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 65535) cnt_Program_訂單資料_更新指定訂單入庫資料 = 1;
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 1) cnt_Program_訂單資料_更新指定訂單入庫資料_檢查按下(ref cnt_Program_訂單資料_更新指定訂單入庫資料);
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 2) cnt_Program_訂單資料_更新指定訂單入庫資料_初始化(ref cnt_Program_訂單資料_更新指定訂單入庫資料);
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 3) cnt_Program_訂單資料_更新指定訂單入庫資料_開始更新(ref cnt_Program_訂單資料_更新指定訂單入庫資料);
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 4) cnt_Program_訂單資料_更新指定訂單入庫資料 = 65500;

            if (cnt_Program_訂單資料_更新指定訂單入庫資料 > 1) cnt_Program_訂單資料_更新指定訂單入庫資料_檢查放開(ref cnt_Program_訂單資料_更新指定訂單入庫資料);
            if (cnt_Program_訂單資料_更新指定訂單入庫資料 == 65500)
            {
                this.PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool = false;
                cnt_Program_訂單資料_更新指定訂單入庫資料 = 65535;
            }
        }
        void cnt_Program_訂單資料_更新指定訂單入庫資料_檢查按下(ref int cnt)
        {
            if (PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool) cnt++;
        }
        void cnt_Program_訂單資料_更新指定訂單入庫資料_檢查放開(ref int cnt)
        {
            if (!PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool) cnt = 65500;
        }
        void cnt_Program_訂單資料_更新指定訂單入庫資料_初始化(ref int cnt)
        {


            cnt++;
        }
        void cnt_Program_訂單資料_更新指定訂單入庫資料_開始更新(ref int cnt)
        {
            string str_藥品碼 = "";
            string str_訂單編號 = "";
            string str_發票入庫數量 = "";
            List<string[]> list_藥品庫存 = new List<string[]>();

            str_訂單編號 = str_訂單資料_更新指定訂單入庫資料_訂單號碼;
            List<object[]> list_訂單資料 = this.sqL_DataGridView_訂單資料.SQL_GetRows(enum_發票資料.訂單編號.GetEnumName(), str_訂單編號, false);
            if (list_訂單資料.Count > 0)
            {
                foreach (object[] value_訂單資料 in list_訂單資料)
                {
                    str_藥品碼 = value_訂單資料[(int)enum_訂單資料.藥品碼].ObjectToString();
                    list_藥品庫存.Add(new string[] { str_藥品碼, "0" });
                }

                List<object[]> list_發票資料 = this.sqL_DataGridView_發票資料.SQL_GetRows(enum_發票資料.訂單編號.GetEnumName(), str_訂單資料_更新指定訂單入庫資料_訂單號碼, false);
                if (list_發票資料.Count > 0)
                {         
                    foreach (object[] value_發票資料 in list_發票資料)
                    {
                        str_藥品碼 = value_發票資料[(int)enum_發票資料.藥品碼].ObjectToString();
                        str_發票入庫數量 = value_發票資料[(int)enum_發票資料.數量].ObjectToString();

                        foreach (string[] value_藥品庫存 in list_藥品庫存)
                        {
                            if (str_藥品碼 == value_藥品庫存[0])
                            {
                                value_藥品庫存[1] = (value_藥品庫存[1].StringToInt32() + str_發票入庫數量.StringToInt32()).ToString();
                            }
                        }
                                        
                    }
                }

                foreach (object[] value_訂單資料 in list_訂單資料)
                {
                    str_藥品碼 = value_訂單資料[(int)enum_訂單資料.藥品碼].ObjectToString();
              
                    foreach (string[] value_藥品庫存 in list_藥品庫存)
                    {
                        if (str_藥品碼 == value_藥品庫存[0])
                        {
                            value_訂單資料[(int)enum_訂單資料.已入庫數量] = value_藥品庫存[1];
                            this.sqL_DataGridView_訂單資料.SQL_Replace(new string[] { enum_訂單資料.訂單編號.GetEnumName(), enum_訂單資料.藥品碼.GetEnumName() }, new string[] { str_訂單編號, str_藥品碼 }, value_訂單資料, false);
                        }
                    }
                }
            }

            this.Function_訂單搜尋_訂單編號(str_訂單編號);
            cnt++;
        }
        #endregion
    }
}
