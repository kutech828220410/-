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
        int 發票資料_Data_Length = Enum.GetValues(typeof(enum_發票資料)).Length;
        public enum enum_發票資料 : int
        {
            序號,
            訂單編號,
            發票號碼,
            發票日期,
            登錄時間,
            藥品碼,
            藥品名稱,
            數量,
            單價,
            總價,
            折讓金額,
            折讓後單價,
            前次驗收折讓後單價,
            賣方統一編號,
            入庫人,
            效期,
            批號,
            訂購日期,
            已結清,
            一般匯出,
            中榮匯出,
            逾期罰金,
            短效罰金,
            入庫日期,
            備註,
        }

        private void Program_發票資料_Init()
        {

            this.sqL_DataGridView_發票資料.Init();
            if (!this.sqL_DataGridView_發票資料.SQL_IsTableCreat())
            {
                Basic.MyMessageBox.ShowDialog("'發票資料'Table未建立!");
                //this.sqL_DataGridView_發票資料.SQL_CreateTable();
            }
            //this.sqL_DataGridView_發票資料.SQL_GetAllRows(true);
        }

        #region Funtion

        #endregion
        #region Event

        #endregion
    }
}
