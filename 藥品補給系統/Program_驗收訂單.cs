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
using MyInvoiceUI;
namespace 藥品補給系統
{
    public partial class Form1 : Form
    {

        string[] 驗收訂單_訂單內容_Data
        {
            get
            {
                string[] _驗收訂單_訂單內容_Data = new string[驗收訂單_訂單內容_Data_Length];
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂單編號] = this.textBox_驗收訂單_訂單內容_訂單編號.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購人] = this.textBox_驗收訂單_訂單內容_訂購人.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購院所別] = this.textBox_驗收訂單_訂單內容_訂購院所別.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購日期] = this.textBox_驗收訂單_訂單內容_訂購日期.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.應驗收日期] = this.textBox_驗收訂單_訂單內容_應驗收日期.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.驗收日期] = this.textBox_驗收訂單_訂單內容_驗收日期.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.供應商全名] = this.textBox_驗收訂單_訂單內容_供應商全名.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.Email] = this.textBox_驗收訂單_訂單內容_Email.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.聯絡人] = this.textBox_驗收訂單_訂單內容_聯絡人.Text;
                _驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.電話] = this.textBox_驗收訂單_訂單內容_電話.Text;
                return _驗收訂單_訂單內容_Data;
            }
            set
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_驗收訂單_訂單內容_訂單編號.Text = value[(int)enum_驗收訂單_訂單內容.訂單編號];
                    this.textBox_驗收訂單_訂單內容_訂購人.Text = value[(int)enum_驗收訂單_訂單內容.訂購人];
                    this.textBox_驗收訂單_訂單內容_訂購院所別.Text = value[(int)enum_驗收訂單_訂單內容.訂購院所別];
                    this.textBox_驗收訂單_訂單內容_訂購日期.Text = value[(int)enum_驗收訂單_訂單內容.訂購日期];
                    this.textBox_驗收訂單_訂單內容_應驗收日期.Text = value[(int)enum_驗收訂單_訂單內容.應驗收日期];
                    this.textBox_驗收訂單_訂單內容_驗收日期.Text = value[(int)enum_驗收訂單_訂單內容.驗收日期];
                    this.textBox_驗收訂單_訂單內容_供應商全名.Text = value[(int)enum_驗收訂單_訂單內容.供應商全名];
                    this.textBox_驗收訂單_訂單內容_Email.Text = value[(int)enum_驗收訂單_訂單內容.Email];
                    this.textBox_驗收訂單_訂單內容_聯絡人.Text = value[(int)enum_驗收訂單_訂單內容.聯絡人];
                    this.textBox_驗收訂單_訂單內容_電話.Text = value[(int)enum_驗收訂單_訂單內容.電話];
                }));
            }
        }
        int 驗收訂單_訂單內容_Data_Length = Enum.GetValues(typeof(enum_驗收訂單_訂單內容)).Length;
        public enum enum_驗收訂單_訂單內容 : int
        {
            訂單編號,
            訂購人,
            訂購院所別,
            訂購日期,
            訂購數量,
            訂購單價,
            訂購總價,
            應驗收日期,
            驗收日期,
            藥品碼,
            藥品名稱,
            單位,
            供應商全名,
            Email,
            聯絡人,
            電話,
        }

        List<string[]> List_驗收訂單_發票內容_Data = new List<string[]>();
        int 驗收訂單_發票內容_Data_Length = Enum.GetValues(typeof(enum_驗收訂單_發票內容)).Length;
        public enum enum_驗收訂單_發票內容 : int
        {
            發票號碼,
            賣方統一編號,
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
            訂單編號,
            入庫人,
            效期,
            批號,
            已結清,
            合約廠商,
            折讓後總價,
            一般匯出,
            中榮匯出,
            逾期罰金,
            短效罰金,
            入庫日期,
            備註,
        }
        string[] 驗收訂單_發票內容_Data
        {
            get
            {
                string[] _驗收訂單_發票內容_Data = new string[驗收訂單_發票內容_Data_Length];

                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼] = this.textBox_驗收訂單_發票內容_發票號碼.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.賣方統一編號] = this.textBox_驗收訂單_發票內容_賣方統一編號.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期] = this.textBox_驗收訂單_發票內容_發票日期.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間] = this.sqL_DataGridView_驗收訂單_訂單搜尋.GetTimeNow(SQLUI.Table.DateType.DATETIME);
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼] = this.textBox_驗收訂單_發票內容_藥品碼.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品名稱] = this.textBox_驗收訂單_發票內容_藥品名稱.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量] = this.textBox_驗收訂單_發票內容_數量.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價] = this.textBox_驗收訂單_發票內容_單價.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價] = this.textBox_驗收訂單_發票內容_總價.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓金額] = this.textBox_驗收訂單_發票內容_折讓金額.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後單價] = this.textBox_驗收訂單_發票內容_折讓後單價.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.前次驗收折讓後單價] = this.textBox_驗收訂單_發票內容_前次驗收折讓後單價.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號] = this.textBox_驗收訂單_發票內容_訂單編號.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人] = this.Function_登入畫面_取得登入姓名();
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期] = this.textBox_驗收訂單_發票內容_效期.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.批號] = this.textBox_驗收訂單_發票內容_批號.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.已結清] = this.CheckBox_驗收訂單_發票內容_已結清.Checked.ToString();
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.合約廠商] = this.textBox_驗收訂單_發票內容_合約廠商.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後總價] = this.textBox_驗收訂單_發票內容_折讓後總價.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金] = this.textBox_驗收訂單_發票內容_逾期罰金.Text;
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金] = this.textBox_驗收訂單_發票內容_短效罰金.Text;
                return _驗收訂單_發票內容_Data;
            }
            set
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_驗收訂單_發票內容_發票號碼.Text = value[(int)enum_驗收訂單_發票內容.發票號碼];
                    this.textBox_驗收訂單_發票內容_賣方統一編號.Text = value[(int)enum_驗收訂單_發票內容.賣方統一編號];
                    this.textBox_驗收訂單_發票內容_發票日期.Text = value[(int)enum_驗收訂單_發票內容.發票日期];
                    this.textBox_驗收訂單_發票內容_藥品碼.Text = value[(int)enum_驗收訂單_發票內容.藥品碼];
                    this.textBox_驗收訂單_發票內容_藥品名稱.Text = value[(int)enum_驗收訂單_發票內容.藥品名稱];
                    this.textBox_驗收訂單_發票內容_數量.Text = value[(int)enum_驗收訂單_發票內容.數量];
                    this.textBox_驗收訂單_發票內容_單價.Text = value[(int)enum_驗收訂單_發票內容.單價];
                    this.textBox_驗收訂單_發票內容_總價.Text = value[(int)enum_驗收訂單_發票內容.總價];
                    this.textBox_驗收訂單_發票內容_折讓金額.Text = value[(int)enum_驗收訂單_發票內容.折讓金額];
                    this.textBox_驗收訂單_發票內容_折讓後單價.Text = value[(int)enum_驗收訂單_發票內容.折讓後單價];
                    this.textBox_驗收訂單_發票內容_前次驗收折讓後單價.Text = value[(int)enum_驗收訂單_發票內容.前次驗收折讓後單價];
                    this.textBox_驗收訂單_發票內容_訂單編號.Text = value[(int)enum_驗收訂單_發票內容.訂單編號];
                    this.textBox_驗收訂單_發票內容_入庫人.Text = value[(int)enum_驗收訂單_發票內容.入庫人];
                    this.textBox_驗收訂單_發票內容_入庫人.Text = this.Function_登入畫面_取得登入姓名();

                    this.textBox_驗收訂單_發票內容_效期.Text = value[(int)enum_驗收訂單_發票內容.效期];
                    this.textBox_驗收訂單_發票內容_批號.Text = value[(int)enum_驗收訂單_發票內容.批號];
                    if (value[(int)enum_驗收訂單_發票內容.已結清] == true.ToString())
                    {
                        this.CheckBox_驗收訂單_發票內容_已結清.Checked = true;
                    }
                    else
                    {
                        this.CheckBox_驗收訂單_發票內容_已結清.Checked = false;
                    }
                    this.textBox_驗收訂單_發票內容_合約廠商.Text = "";
                    if (this.textBox_驗收訂單_發票內容_藥品碼.Text != "")
                    {
                        List<object[]> list_value = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), this.textBox_驗收訂單_發票內容_藥品碼.Text, false);
                        if (list_value.Count > 0) this.textBox_驗收訂單_發票內容_合約廠商.Text = list_value[0][(int)enum_藥品資料.合約廠商].ObjectToString();
                    }
                    this.textBox_驗收訂單_發票內容_折讓後總價.Text = value[(int)enum_驗收訂單_發票內容.折讓後總價];
                    this.textBox_驗收訂單_發票內容_逾期罰金.Text = value[(int)enum_驗收訂單_發票內容.逾期罰金];
                    this.textBox_驗收訂單_發票內容_短效罰金.Text = value[(int)enum_驗收訂單_發票內容.短效罰金];
                }));
            }
        }

        private void Program_驗收訂單_Init()
        {
            this.sqL_DataGridView_驗收訂單_訂單搜尋.Init();
            this.sqL_DataGridView_驗收訂單_訂單搜尋.DataGridRefreshEvent += sqL_DataGridView_驗收訂單_訂單搜尋_DataGridRefreshEven;
            this.textBox_驗收訂單_發票內容_藥品碼.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_藥品名稱.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_數量.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_單價.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_總價.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_折讓金額.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_訂單編號.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_效期.LostFocus += this.textBox_驗收訂單_發票內容_Leave;
            this.textBox_驗收訂單_發票內容_批號.LostFocus += this.textBox_驗收訂單_發票內容_Leave;

            this.sqL_DataGridView_驗收訂單_未結清發票.Init();
            this.sqL_DataGridView_驗收訂單_已結清發票.Init();
        }
        private void sub_Program_驗收訂單()
        {
            sub_Program_驗收訂單_鎖定訂單搜尋();

            sub_PLC_Program_驗收訂單_頁面更新();
            sub_PLC_Program_驗收訂單_掃描發票();
            sub_PLC_Program_驗收訂單_資料確認();
            sub_PLC_Program_驗收訂單_鎖定訂單內容();
            sub_PLC_Program_驗收訂單_解鎖訂單內容();
            sub_PLC_Program_驗收訂單_清除訂單內容();
            sub_PLC_Program_驗收訂單_確認入庫();
            sub_PLC_Program_驗收訂單_搜尋前次驗收折讓後單價();
            sub_PLC_Program_驗收訂單_未結清發票_編輯();

            sub_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged();
            sub_PLC_Program_驗收訂單_訂單搜尋_藥品碼();
            sub_PLC_Program_驗收訂單_訂單搜尋_訂單編號();
            sub_PLC_Program_驗收訂單_訂單搜尋_藥品條碼();
            sub_PLC_Program_驗收訂單_訂單搜尋_訂購日期();
            sub_PLC_Program_驗收訂單_訂單搜尋_藥品名稱();
        }

        #region PLC_Program_驗收訂單_頁面更新
        PLC_Device PLC_Program_驗收訂單_頁面更新 = new PLC_Device("Y503");
        void sub_PLC_Program_驗收訂單_頁面更新()
        {
            if (this.PLC_Program_驗收訂單_頁面更新.Bool)
            {
                //this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetColumnValues("藥品碼", true, comboBox_驗收訂單_訂單搜尋_藥品碼);
                this.Invoke(new Action(delegate
                {
                    this.textBox_驗收訂單_發票內容_入庫人.Text = this.Function_登入畫面_取得登入姓名();
                    this.textBox_驗收訂單_訂單內容_驗收日期.Text = DateTime.Now.AddDays(0).ToShortDateString();
                    this.CheckBox_驗收訂單_發票內容_已結清.Checked = false;
                }));




                this.PLC_Program_驗收訂單_頁面更新.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_驗收訂單_掃描發票
        PLC_Device PLC_Program_驗收訂單_掃描發票 = new PLC_Device("S4027");
        string str_Program_驗收訂單_狀態
        {
            get
            {
                return this.label_驗收訂單_掃描發票_狀態.Text;
            }
            set
            {
                this.Invoke(new Action(delegate
                {
                    this.label_驗收訂單_掃描發票_狀態.Text = value;
                }));
            }
        }
        bool flag_驗收訂單_掃描發票_已掃描 = false;
        int cnt_Program_驗收訂單_掃描發票 = 65534;
        void sub_PLC_Program_驗收訂單_掃描發票()
        {
            if (cnt_Program_驗收訂單_掃描發票 == 65534)
            {
                this.PLC_Program_驗收訂單_掃描發票.Bool = false;
                cnt_Program_驗收訂單_掃描發票 = 65535;
            }
            if (cnt_Program_驗收訂單_掃描發票 == 65535) cnt_Program_驗收訂單_掃描發票 = 1;
            if (cnt_Program_驗收訂單_掃描發票 == 1) cnt_Program_驗收訂單_掃描發票_檢查按下(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 2) cnt_Program_驗收訂單_掃描發票_初始化(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 3) cnt_Program_驗收訂單_掃描發票 = 100;


            if (cnt_Program_驗收訂單_掃描發票 == 100) cnt_Program_驗收訂單_掃描發票_100_Left_QrCode_初始化(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 101) cnt_Program_驗收訂單_掃描發票_100_Left_QrCode_等待掃描(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 102) cnt_Program_驗收訂單_掃描發票_100_Left_QrCode_寫入UI(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 103) cnt_Program_驗收訂單_掃描發票 = 200;

            if (cnt_Program_驗收訂單_掃描發票 == 200) cnt_Program_驗收訂單_掃描發票_200_Right_QrCode_初始化(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 201) cnt_Program_驗收訂單_掃描發票_200_Right_QrCode_等待掃描(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 202) cnt_Program_驗收訂單_掃描發票_200_Right_QrCode_寫入UI(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 203) cnt_Program_驗收訂單_掃描發票 = 300;

            if (cnt_Program_驗收訂單_掃描發票 == 300) cnt_Program_驗收訂單_掃描發票_300_資料填入(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 301) cnt_Program_驗收訂單_掃描發票_300_顯示掃描完成(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 302) cnt_Program_驗收訂單_掃描發票 = 65500;

            if (cnt_Program_驗收訂單_掃描發票 > 1) cnt_Program_驗收訂單_掃描發票_檢查放開(ref cnt_Program_驗收訂單_掃描發票);
            if (cnt_Program_驗收訂單_掃描發票 == 65500)
            {
                str_Program_驗收訂單_狀態 = "閒置中";
                this.PLC_Program_驗收訂單_掃描發票.Bool = false;
                cnt_Program_驗收訂單_掃描發票 = 65535;
            }
        }
        void cnt_Program_驗收訂單_掃描發票_檢查按下(ref int cnt)
        {
            if (PLC_Program_驗收訂單_掃描發票.Bool) cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_檢查放開(ref int cnt)
        {
            if (!PLC_Program_驗收訂單_掃描發票.Bool) cnt = 65500;
        }
        void cnt_Program_驗收訂單_掃描發票_初始化(ref int cnt)
        {
            flag_驗收訂單_掃描發票_已掃描 = false;
            this.Invoke(new Action(delegate
            {
                this.richTextBox_驗收訂單_掃描發票.Focus();
                this.richTextBox_驗收訂單_掃描發票.Text = "";
                this.myInvoiceUI.Clear();
                str_Program_驗收訂單_狀態 = "掃描發票'左側'QRcode!";
            }));

            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_100_Left_QrCode_初始化(ref int cnt)
        {
            flag_驗收訂單_掃描發票_已掃描 = false;
            this.Invoke(new Action(delegate
            {
                this.richTextBox_驗收訂單_掃描發票.Focus();
                this.richTextBox_驗收訂單_掃描發票.Text = "";
                this.myInvoiceUI.Left_QrCode = "";
                str_Program_驗收訂單_狀態 = "掃描發票'左側'QRcode!........";
            }));

            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_100_Left_QrCode_等待掃描(ref int cnt)
        {
            if (flag_驗收訂單_掃描發票_已掃描)
            {
                this.Invoke(new Action(delegate
                {
                    this.myInvoiceUI.Left_QrCode = this.richTextBox_驗收訂單_掃描發票.Text;
                }));
                try
                {
                    if (this.myInvoiceUI.Get_Invoice_Contents())
                    {
                        cnt++;
                        return;
                    }
                    else
                    {
                        MyMessageBox.ShowDialog("解碼異常,請重新掃描!#001");
                        cnt = 100;
                        return;
                    }
                }
                catch
                {
                    MyMessageBox.ShowDialog("解碼異常,請重新掃描!#002");
                    cnt = 65500;
                    return;
                }
            }
        }
        void cnt_Program_驗收訂單_掃描發票_100_Left_QrCode_寫入UI(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                this.myInvoiceUI.Left_QrCode = this.richTextBox_驗收訂單_掃描發票.Text;
            }));
            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_200_Right_QrCode_初始化(ref int cnt)
        {
            cnt++;
            return;
            flag_驗收訂單_掃描發票_已掃描 = false;
            this.Invoke(new Action(delegate
            {
                this.richTextBox_驗收訂單_掃描發票.Focus();
                this.richTextBox_驗收訂單_掃描發票.Text = "";
                this.myInvoiceUI.Right_QrCode = "";
                str_Program_驗收訂單_狀態 = "掃描發票'右側'QRcode!........";
            }));

            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_200_Right_QrCode_等待掃描(ref int cnt)
        {
            cnt++;
            return;
            if (flag_驗收訂單_掃描發票_已掃描)
            {
                this.Invoke(new Action(delegate
                {

                    this.myInvoiceUI.Right_QrCode = this.richTextBox_驗收訂單_掃描發票.Text;
                }));
                if (this.myInvoiceUI.Get_Invoice_Index())
                {
                    cnt++;
                }
                else
                {
                    MyMessageBox.ShowDialog("解碼異常,請重新掃描!");
                    cnt = 200;
                }
            }
        }
        void cnt_Program_驗收訂單_掃描發票_200_Right_QrCode_寫入UI(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                this.myInvoiceUI.Right_QrCode = this.richTextBox_驗收訂單_掃描發票.Text;
            }));
            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_300_資料填入(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                string str_交易筆數 = "";
                int 交易筆數 = 0;
                double 單價_temp = 0;
                int 數量_temp = 0;


                try
                {
                    str_交易筆數 = this.myInvoiceUI.Get_Invoice_Contents(MyInvoiceUI.MyInvoiceUI.enum_發票內容.二維碼交易筆數);
                    if (int.TryParse(str_交易筆數, out 交易筆數))
                    {
                        string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼] = this.myInvoiceUI.Get_Invoice_Contents(MyInvoiceUI.MyInvoiceUI.enum_發票內容.發票字軌);
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.賣方統一編號] = this.myInvoiceUI.Get_Invoice_Contents(MyInvoiceUI.MyInvoiceUI.enum_發票內容.賣方統一編號);
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期] = this.myInvoiceUI.Get_Invoice_Contents(MyInvoiceUI.MyInvoiceUI.enum_發票內容.發票開立日期);
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間];
                        this.驗收訂單_發票內容_Data = _驗收訂單_發票內容_Data;
                        //for (int i = 0; i < 交易筆數; i++)
                        //{
                        //    if (i < this.List_驗收訂單_發票內容_Data.Count)
                        //    {
                        //        string[] _List_驗收訂單_發票內容_Data = this.List_驗收訂單_發票內容_Data[i];
                        //        _List_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價] = this.myInvoiceUI.Get_Invoice_Index(i, MyInvoiceUI.MyInvoiceUI.enum_單筆內容.單價);
                        //        //if (_List_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量] != "") _List_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量] = this.myInvoiceUI.Get_Invoice_Index(i, MyInvoiceUI.MyInvoiceUI.enum_單筆內容.數量);
                        //        _List_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價] = this.myInvoiceUI.Get_Invoice_Contents(MyInvoiceUI.MyInvoiceUI.enum_發票內容.總計額);

                        //        this.List_驗收訂單_發票內容_Data[i] = _List_驗收訂單_發票內容_Data;
                        //    }

                        //}
                        //this.Function_驗收訂單_發票內容更新(0);
                    }
                }
                catch
                {
                    MyMessageBox.ShowDialog("發票筆數資料有異常,部分資料未完善!");
                }
            }));

            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_300_顯示掃描完成(ref int cnt)
        {
            MyMessageBox.ShowDialog("掃描完成!");
            cnt++;
        }
        void cnt_Program_驗收訂單_掃描發票_(ref int cnt)
        {
            cnt++;
        }


        #endregion
        #region PLC_Program_驗收訂單_資料確認
        PLC_Device PLC_Program_驗收訂單_資料確認開始 = new PLC_Device("S4031");
        PLC_Device PLC_Program_驗收訂單_資料確認完成 = new PLC_Device("S4032");
        int cnt_PLC_Program_驗收訂單_資料確認 = 65535;

        void sub_PLC_Program_驗收訂單_資料確認()
        {
            if (cnt_PLC_Program_驗收訂單_資料確認 == 65535) cnt_PLC_Program_驗收訂單_資料確認 = 1;
            if (cnt_PLC_Program_驗收訂單_資料確認 == 1) cnt_PLC_Program_驗收訂單_資料確認_檢查按下(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 2) cnt_PLC_Program_驗收訂單_資料確認_初始化(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 3) cnt_PLC_Program_驗收訂單_資料確認_檢查訂單內容(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 4) cnt_PLC_Program_驗收訂單_資料確認_檢查訂單_發票內容(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 5) cnt_PLC_Program_驗收訂單_資料確認_檢查訂單_發票單筆內容(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 6) cnt_PLC_Program_驗收訂單_資料確認_入庫數量檢查(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 7) cnt_PLC_Program_驗收訂單_資料確認_完成確認(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 8) cnt_PLC_Program_驗收訂單_資料確認 = 65500;

            if (cnt_PLC_Program_驗收訂單_資料確認 > 1) cnt_PLC_Program_驗收訂單_資料確認_檢查放開(ref cnt_PLC_Program_驗收訂單_資料確認);
            if (cnt_PLC_Program_驗收訂單_資料確認 == 65500)
            {
                PLC_Program_驗收訂單_資料確認開始.Bool = false;
                cnt_PLC_Program_驗收訂單_資料確認 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_資料確認_檢查按下(ref int cnt)
        {
            if (PLC_Program_驗收訂單_資料確認開始.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_檢查放開(ref int cnt)
        {
            if (!PLC_Program_驗收訂單_資料確認開始.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_初始化(ref int cnt)
        {
            this.PLC_Program_驗收訂單_資料確認完成.Bool = false;
            SendKeys.SendWait("{TAB}");
            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_檢查訂單內容(ref int cnt)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            string[] _驗收訂單_訂單內容_Data = this.驗收訂單_訂單內容_Data;
            this.Invoke(new Action(delegate
            {

                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂單編號] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂單編號.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購人] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂購人.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購院所別] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂購院所別.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購日期] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂購日期.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購數量] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂購數量.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購單價] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂購單價.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.訂購總價] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.訂購總價.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.應驗收日期] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.應驗收日期.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.驗收日期] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.驗收日期.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.供應商全名] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.供應商全名.GetEnumName() + "'" + "欄位空白");
                }

                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.Email] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.Email.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.聯絡人] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.聯絡人.GetEnumName() + "'" + "欄位空白");
                }
                if (_驗收訂單_訂單內容_Data[(int)enum_驗收訂單_訂單內容.電話] == string.Empty)
                {
                    List_error_msg.Add("'" + enum_驗收訂單_訂單內容.電話.GetEnumName() + "'" + "欄位空白");
                }

                for (int i = 0; i < List_error_msg.Count; i++)
                {
                    str_error_msg += i.ToString("00") + ". " + List_error_msg[i] + "\n\r";
                }
                if (str_error_msg == "")
                {
                    flag_OK = true;
                }
                else MyMessageBox.ShowDialog(str_error_msg);
            }));
            if (flag_OK) cnt++;
            else cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_檢查訂單_發票內容(ref int cnt)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
            this.Invoke(new Action(delegate
            {
                if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.已結清] == true.ToString())
                {
                    if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼] == string.Empty)
                    {
                        List_error_msg.Add("'" + enum_驗收訂單_發票內容.發票號碼.GetEnumName() + "'" + "欄位空白");
                    }
                    else
                    {
                        if (this.sqL_DataGridView_發票資料.SQL_IsHaveMember(enum_驗收訂單_發票內容.發票號碼.GetEnumName(), _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼]))
                        {
                            List_error_msg.Add("此發票號碼已登入過");
                        }
                    }
                    if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.賣方統一編號] == string.Empty)
                    {
                        List_error_msg.Add("'" + enum_驗收訂單_發票內容.賣方統一編號.GetEnumName() + "'" + "欄位空白");
                    }
                    if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期] == string.Empty)
                    {
                        List_error_msg.Add("'" + enum_驗收訂單_發票內容.發票日期.GetEnumName() + "'" + "欄位空白");
                    }
                    else
                    {
                        if (!_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期].Check_Date_String())
                        {
                            List_error_msg.Add("'" + enum_驗收訂單_發票內容.發票日期.GetEnumName() + "'" + "欄位為非有效日期(XXXX/XX/XX)");
                        }
                    }

                    if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間] == string.Empty)
                    {
                        List_error_msg.Add("'" + enum_驗收訂單_發票內容.登錄時間.GetEnumName() + "'" + "欄位空白");
                    }
                    if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人] == string.Empty)
                    {
                        List_error_msg.Add("'" + enum_驗收訂單_發票內容.入庫人.GetEnumName() + "'" + "欄位空白");
                    }
                }
                else
                {
                    this.textBox_驗收訂單_發票內容_發票號碼.Text = "IV" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    this.textBox_驗收訂單_發票內容_發票日期.Text = DateTime.Now.AddDays(0).ToShortDateString();
                }
                for (int i = 0; i < List_error_msg.Count; i++)
                {
                    str_error_msg += i.ToString("00") + ". " + List_error_msg[i] + "\n\r";
                }
                if (str_error_msg == "")
                {
                    flag_OK = true;
                }
                else MyMessageBox.ShowDialog(str_error_msg);
            }));
            if (flag_OK) cnt++;
            else cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_檢查訂單_發票單筆內容(ref int cnt)
        {
            if (this.List_驗收訂單_發票內容_Data.Count == 0)
            {
                MyMessageBox.ShowDialog("請輸入至少1筆發票內容!");
                cnt = 65500;
                return;
            }
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            List<string> List_error_msg_temp = new List<string>();
            string str_error_msg = "";
            string[] _驗收訂單_發票內容_Data;
            this.Invoke(new Action(delegate
            {
                for (int i = 0; i < this.List_驗收訂單_發票內容_Data.Count; i++)
                {
                    _驗收訂單_發票內容_Data = this.List_驗收訂單_發票內容_Data[i];
                    List_error_msg_temp.Clear();
                    if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼]))
                    {
                        List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.藥品碼.GetEnumName() + "'" + "欄位空白");
                    }
                    if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品名稱]))
                    {
                        List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.藥品名稱.GetEnumName() + "'" + "欄位空白");
                    }
                    if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量]))
                    {
                        List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.數量.GetEnumName() + "'" + "欄位空白");
                    }
                    else
                    {
                        int temp = 0;
                        if (!int.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量], out temp))
                        {
                            List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.數量.GetEnumName() + "'" + "為非法字元");
                        }

                    }
                    //
                    if (this.CheckBox_驗收訂單_發票內容_已結清.Checked)
                    {
                        if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價]))
                        {
                            List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.單價.GetEnumName() + "'" + "欄位空白");
                        }
                        else
                        {
                            double temp = 0;
                            if (!double.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價], out temp))
                            {
                                List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.單價.GetEnumName() + "'" + "為非法字元");
                            }
                        }
                        //
                        if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價]))
                        {
                            List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.總價.GetEnumName() + "'" + "欄位空白");
                        }
                        else
                        {
                            double temp = 0;
                            if (!double.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價], out temp))
                            {
                                List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.總價.GetEnumName() + "'" + "為非法字元");
                            }
                        }
                        //
                        if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓金額]))
                        {
                            List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.折讓金額.GetEnumName() + "'" + "欄位空白");
                        }
                        else
                        {
                            double temp = 0;
                            if (!double.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓金額], out temp))
                            {
                                List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.折讓金額.GetEnumName() + "'" + "為非法字元");
                            }
                        }
                        //
                        if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後單價]))
                        {
                            List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.折讓後單價.GetEnumName() + "'" + "欄位空白");
                        }
                        else
                        {
                            double temp = 0;
                            if (!double.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後單價], out temp))
                            {
                                List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.折讓後單價.GetEnumName() + "'" + "為非法字元");
                            }
                        }
                        //
                        
                        if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金]))
                        {
                            if (!plC_CheckBox_逾時罰金計算.Bool) _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金] = "0";
                            else List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.逾期罰金.GetEnumName() + "'" + "欄位空白");
    
                        }
                        else
                        {
                            double temp = 0;
                            if (!double.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金], out temp))
                            {
                                if (!plC_CheckBox_逾時罰金計算.Bool) _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金] = "0";
                                else List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.逾期罰金.GetEnumName() + "'" + "為非法字元");
                            }
                        }

                        if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金]))
                        {
                            if (!plC_CheckBox_短效罰金計算.Bool) _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金] = "0";
                            else List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.短效罰金.GetEnumName() + "'" + "欄位空白");
                        }
                        else
                        {
                            double temp = 0;
                            if (!double.TryParse(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金], out temp))
                            {
                                if (!plC_CheckBox_短效罰金計算.Bool) _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金] = "0";
                                else List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.短效罰金.GetEnumName() + "'" + "為非法字元");
                            }
                        }
                    }

                    //

                    if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號]))
                    {
                        List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.訂單編號.GetEnumName() + "'" + "欄位空白");
                    }
                    else
                    {
                        if (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號] != textBox_驗收訂單_訂單內容_訂單編號.Text)
                        {
                            List_error_msg_temp.Add("此筆資料非本訂單貨品");
                        }
                    }
                    if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期]))
                    {
                        List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.效期.GetEnumName() + "'" + "欄位空白");
                    }
                    else
                    {
                        if (!_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期].Check_Date_String())
                        {
                            List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.效期.GetEnumName() + "'" + "欄位為非有效日期(XXXX/XX/XX)");
                        }
                        else
                        {
                            if(!this.PLC_Device_訂單管理權限.Bool)
                            {
                                DateTime date_Now = DateTime.Now;
                                int Year = 0;
                                int Month = 0;
                                int Day = 0;
                                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期].ObjectToString().Get_Date(ref Year, ref Month, ref Day, TypeConvert.Enum_Year_Type.Anno_Domini);
                                DateTime date_效期 = new DateTime(Year, Month, Day);
                                int 有效天數 = new TimeSpan(date_效期.Ticks - date_Now.Ticks).Days;
                                if (有效天數 < 365)
                                {
                                    List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.效期.GetEnumName() + "'" + "欄位為有效年份小於1年");
                                }
                            }
                
                        }
                    }
                    if (string.IsNullOrEmpty(_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.批號]))
                    {
                        List_error_msg_temp.Add("'" + enum_驗收訂單_發票內容.批號.GetEnumName() + "'" + "欄位空白");
                    }
                    if (List_error_msg_temp.Count > 0)
                    {
                        List_error_msg.Add("-----------------------------------------------");
                        List_error_msg.Add("發票內容-第" + i.ToString() + "筆資料未妥善");

                        for (int k = 0; k < List_error_msg_temp.Count; k++)
                        {
                            List_error_msg.Add((k + 1).ToString("00") + " : " + List_error_msg_temp[k]);
                        }
                        List_error_msg.Add("-----------------------------------------------");
                    }

                }

                for (int i = 0; i < List_error_msg.Count; i++)
                {
                    str_error_msg += List_error_msg[i] + "\n\r";
                }
                if (str_error_msg == "")
                {
                    flag_OK = true;
                }
                else MyMessageBox.ShowDialog(str_error_msg);
            }));
            if (flag_OK) cnt++;
            else cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_入庫數量檢查(ref int cnt)
        {
            string str_error_msg = "";
            List<string> List_error_msg = new List<string>();
            string str_訂單編號 = "";
            string str_藥品碼 = "";
            string str_已入庫數量 = "";
            string str_訂購數量 = "";
            string str_驗收入庫數量 = "";
            int 已入庫數量_temp = 0;
            int 訂購數量_temp = 0;
            int 驗收入庫數量_temp = 0;
            List<object[]> list_訂單內容_obj;
            string[] _驗收訂單_發票內容_Data;


            for (int i = 0; i < this.List_驗收訂單_發票內容_Data.Count; i++)
            {
                _驗收訂單_發票內容_Data = this.List_驗收訂單_發票內容_Data[i];
                str_訂單編號 = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號];
                str_藥品碼 = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼];
                str_驗收入庫數量 = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量];
                list_訂單內容_obj = this.sqL_DataGridView_訂單資料.SQL_GetRows(new string[] { enum_驗收訂單_發票內容.訂單編號.GetEnumName(), enum_驗收訂單_發票內容.藥品碼.GetEnumName() }, new string[] { str_訂單編號, str_藥品碼 }, false);

                str_已入庫數量 = list_訂單內容_obj[0][(int)enum_訂單資料.已入庫數量].ObjectToString();
                str_訂購數量 = list_訂單內容_obj[0][(int)enum_訂單資料.訂購數量].ObjectToString();
                int.TryParse(str_已入庫數量, out 已入庫數量_temp);
                int.TryParse(str_訂購數量, out 訂購數量_temp);
                int.TryParse(str_驗收入庫數量, out 驗收入庫數量_temp);
                if (!this.PLC_Program_驗收訂單_未結清發票_編輯開始.Bool)
                {
                    if ((已入庫數量_temp + 驗收入庫數量_temp) > 訂購數量_temp)
                    {
                        List_error_msg.Add("發票內容-第" + i.ToString() + "筆'入庫數量'超過'應驗收入庫數量'");
                    }
                }
            }


            for (int i = 0; i < List_error_msg.Count; i++)
            {
                str_error_msg += List_error_msg[i] + "\n\r";
            }
            if (str_error_msg == "")
            {
                cnt++;
            }
            else
            {
                MyMessageBox.ShowDialog(str_error_msg);
                cnt = 65500;
            }

        }
        void cnt_PLC_Program_驗收訂單_資料確認_完成確認(ref int cnt)
        {
            PLC_Program_驗收訂單_掃描發票.Bool = false;
            PLC_Program_驗收訂單_資料確認完成.Bool = true;

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_資料確認_(ref int cnt)
        {
            cnt++;
        }
        #endregion
        #region PLC_Program_驗收訂單_鎖定訂單內容
        PLC_Device PLC_Program_驗收訂單_鎖定訂單內容 = new PLC_Device("S4035");
        void sub_PLC_Program_驗收訂單_鎖定訂單內容()
        {
            if (this.PLC_Program_驗收訂單_鎖定訂單內容.Bool)
            {

                this.Invoke(new Action(delegate
                {
                    this.groupBox_驗收訂單_訂單內容.Enabled = false;
                    this.groupBox_驗收訂單_掃描發票.Enabled = false;
                    this.groupBox_驗收訂單_發票內容.Enabled = false;
                    this.groupBox_驗收訂單_未結清發票.Enabled = false;
                }));
                this.PLC_Program_驗收訂單_鎖定訂單內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_驗收訂單_解鎖訂單內容
        PLC_Device PLC_Program_驗收訂單_解鎖訂單內容 = new PLC_Device("S4036");
        void sub_PLC_Program_驗收訂單_解鎖訂單內容()
        {
            if (this.PLC_Program_驗收訂單_解鎖訂單內容.Bool)
            {

                this.Invoke(new Action(delegate
                {
                    this.groupBox_驗收訂單_訂單內容.Enabled = true;
                    this.groupBox_驗收訂單_掃描發票.Enabled = true;
                    this.groupBox_驗收訂單_發票內容.Enabled = true;
                    this.groupBox_驗收訂單_未結清發票.Enabled = true;
                }));
                this.PLC_Program_驗收訂單_解鎖訂單內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_驗收訂單_清除訂單內容
        PLC_Device PLC_Program_驗收訂單_清除訂單內容 = new PLC_Device("S4040");
        void sub_PLC_Program_驗收訂單_清除訂單內容()
        {
            if (this.PLC_Program_驗收訂單_清除訂單內容.Bool)
            {

                this.Invoke(new Action(delegate
                {
                    this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Clear();
                    this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = "";
                    this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = "";
                    this.sqL_DataGridView_驗收訂單_訂單搜尋.ClearGrid();
                    this.驗收訂單_訂單內容_Data = new string[this.驗收訂單_訂單內容_Data.Length];

                    this.comboBox_驗收訂單_發票內容_資料筆數.Items.Clear();
                    this.驗收訂單_發票內容_Data = new string[this.驗收訂單_發票內容_Data_Length];
                    this.List_驗收訂單_發票內容_Data.Clear();

                    this.sqL_DataGridView_驗收訂單_未結清發票.ClearGrid();
                    this.sqL_DataGridView_驗收訂單_已結清發票.ClearGrid();

                    this.CheckBox_驗收訂單_前日入庫.Checked = false;

                    this.PLC_Program_驗收訂單_頁面更新.Bool = true;
                }));
                this.PLC_Program_驗收訂單_清除訂單內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_驗收訂單_確認入庫
        PLC_Device PLC_Program_驗收訂單_確認入庫開始 = new PLC_Device("S4042");

        int cnt_Program_驗收訂單_確認入庫 = 65534;
        void sub_PLC_Program_驗收訂單_確認入庫()
        {
            if (cnt_Program_驗收訂單_確認入庫 == 65534)
            {
                this.PLC_Program_驗收訂單_確認入庫開始.Bool = false;
                cnt_Program_驗收訂單_確認入庫 = 65535;
            }
            if (cnt_Program_驗收訂單_確認入庫 == 65535) cnt_Program_驗收訂單_確認入庫 = 1;
            if (cnt_Program_驗收訂單_確認入庫 == 1) cnt_Program_驗收訂單_確認入庫_檢查按下(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 2) cnt_Program_驗收訂單_確認入庫_初始化(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 3) cnt_Program_驗收訂單_確認入庫_發票內容寫入SQL(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 4) cnt_Program_驗收訂單_確認入庫_更新訂單庫存資訊開始(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 5) cnt_Program_驗收訂單_確認入庫_等待更新訂單庫存資訊結束(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 6) cnt_Program_驗收訂單_確認入庫_確認可否驗收(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 7) cnt_Program_驗收訂單_確認入庫_清除訂單內容(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 8) cnt_Program_驗收訂單_確認入庫_等待清除訂單內容結束(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 9) cnt_Program_驗收訂單_確認入庫 = 65500;

            if (cnt_Program_驗收訂單_確認入庫 > 1) cnt_Program_驗收訂單_確認入庫_檢查放開(ref cnt_Program_驗收訂單_確認入庫);
            if (cnt_Program_驗收訂單_確認入庫 == 65500)
            {
                PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool = false;
                PLC_Program_驗收訂單_未結清發票_編輯開始.Bool = false;
                PLC_Program_驗收訂單_確認入庫開始.Bool = false;
                cnt_Program_驗收訂單_確認入庫 = 65535;
            }
        }
        void cnt_Program_驗收訂單_確認入庫_檢查按下(ref int cnt)
        {
            if (PLC_Program_驗收訂單_確認入庫開始.Bool) cnt++;
        }
        void cnt_Program_驗收訂單_確認入庫_檢查放開(ref int cnt)
        {
            if (!PLC_Program_驗收訂單_確認入庫開始.Bool) cnt = 65500;
        }
        void cnt_Program_驗收訂單_確認入庫_初始化(ref int cnt)
        {


            cnt++;
        }
        void cnt_Program_驗收訂單_確認入庫_發票內容寫入SQL(ref int cnt)
        {
            string[] 發票內容 = new string[this.發票資料_Data_Length];
            string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
            for (int i = 0; i < this.List_驗收訂單_發票內容_Data.Count; i++)
            {
                發票內容[(int)enum_發票資料.序號] = i.ToString();
                發票內容[(int)enum_發票資料.發票號碼] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼];
                發票內容[(int)enum_發票資料.賣方統一編號] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.賣方統一編號];
                發票內容[(int)enum_發票資料.發票日期] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期];
                發票內容[(int)enum_發票資料.登錄時間] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間];
                發票內容[(int)enum_發票資料.入庫人] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人];
                發票內容[(int)enum_發票資料.已結清] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.已結清];
                if(!this.CheckBox_驗收訂單_發票內容_已結清.Checked)
                {
                    if (this.CheckBox_驗收訂單_前日入庫.Checked)
                    {
                        this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期] = this.Function_計算前日入庫日期(DateTime.Now).ToDateString();
                    }
                    else
                    {
                        this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期] = DateTime.Now.ToDateString();
                    }
                }
                //if (發票內容[(int)enum_發票資料.已結清].ObjectToString() == false.ToString())
                //{
                //    if(this.CheckBox_驗收訂單_前日入庫.Checked)
                //    {
                //        this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期] = this.Function_計算前日入庫日期(DateTime.Now).ToDateString();
                //    }
                //    else
                //    {
                //        this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期] = DateTime.Now.ToDateString();
                //    }  
                //}
                if (this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期].ObjectToString() == "") this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期] = DateTime.Now.ToDateString();

                發票內容[(int)enum_發票資料.入庫日期] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.入庫日期];
                發票內容[(int)enum_發票資料.藥品碼] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.藥品碼];
                發票內容[(int)enum_發票資料.藥品名稱] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.藥品名稱];
                發票內容[(int)enum_發票資料.數量] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.數量];
                發票內容[(int)enum_發票資料.單價] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.單價];
                發票內容[(int)enum_發票資料.總價] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.總價];
                發票內容[(int)enum_發票資料.折讓金額] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.折讓金額];
                發票內容[(int)enum_發票資料.折讓後單價] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.折讓後單價];
                發票內容[(int)enum_發票資料.前次驗收折讓後單價] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.前次驗收折讓後單價];
                發票內容[(int)enum_發票資料.訂單編號] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.訂單編號];
                發票內容[(int)enum_發票資料.效期] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.效期];
                發票內容[(int)enum_發票資料.批號] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.批號];
                發票內容[(int)enum_發票資料.一般匯出] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.一般匯出].ObjectToString();
                發票內容[(int)enum_發票資料.中榮匯出] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.中榮匯出].ObjectToString();
                發票內容[(int)enum_發票資料.逾期罰金] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.逾期罰金].ObjectToString();
                發票內容[(int)enum_發票資料.短效罰金] = this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.短效罰金].ObjectToString();
                發票內容[(int)enum_發票資料.訂購日期] = textBox_驗收訂單_訂單內容_訂購日期.Text;
                if (!this.PLC_Program_驗收訂單_未結清發票_編輯開始.Bool)
                {
                    string[] ColumnName = new string[] { enum_發票資料.發票號碼.GetEnumName(), enum_發票資料.藥品碼.GetEnumName() };
                    string[] ColumnValue = new string[] { 發票內容[(int)enum_發票資料.發票號碼], 發票內容[(int)enum_發票資料.藥品碼] };

                    if (this.sqL_DataGridView_發票資料.SQL_GetRows(ColumnName, ColumnValue,false).Count > 0 )
                    {
                        this.sqL_DataGridView_發票資料.SQL_Replace(ColumnName, ColumnValue, 發票內容, true);
                    }
                    else
                    {
                        this.sqL_DataGridView_發票資料.SQL_AddRow(發票內容, true);
                    }
             
                }
                else
                {
                    string[] ColumnName = new string[] { enum_發票資料.序號.GetEnumName(), enum_發票資料.發票號碼.GetEnumName() };
                    string[] ColumnValue = new string[] { 發票內容[(int)enum_發票資料.序號], this.str_未結清發票_發票號碼 };
                    this.sqL_DataGridView_發票資料.SQL_Replace(ColumnName, ColumnValue, 發票內容, true);

                    List<object[]> list_藥品value = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), 發票內容[(int)enum_發票資料.藥品碼], false);
                    if (list_藥品value.Count > 0)
                    {
                        list_藥品value[0][(int)enum_藥品資料.已採購總價] = (list_藥品value[0][(int)enum_藥品資料.已採購總價].ObjectToString().StringToDouble() + 發票內容[(int)enum_發票資料.總價].StringToDouble()).ToString("0.000");
                        list_藥品value[0][(int)enum_藥品資料.已採購總量] = (list_藥品value[0][(int)enum_藥品資料.已採購總量].ObjectToString().StringToDouble() + 發票內容[(int)enum_發票資料.數量].StringToDouble()).ToString("0.000");
                        list_藥品value[0][(int)enum_藥品資料.最新訂購單價] = (發票內容[(int)enum_發票資料.折讓後單價].ObjectToString());
                        this.sqL_DataGridView_藥品資料.SQL_Replace(enum_藥品資料.藥品碼.GetEnumName(), 發票內容[(int)enum_發票資料.藥品碼], list_藥品value[0], true);
                    }
                }

            }
            cnt++;
        }
        void cnt_Program_驗收訂單_確認入庫_更新訂單庫存資訊開始(ref int cnt)
        {
            if (!this.PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool)
            {
                this.str_訂單資料_更新指定訂單入庫資料_訂單號碼 = this.textBox_驗收訂單_訂單內容_訂單編號.Text;
                PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_驗收訂單_確認入庫_等待更新訂單庫存資訊結束(ref int cnt)
        {
            if (!this.PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_驗收訂單_確認入庫_確認可否驗收(ref int cnt)
        {
            List<object[]> List_訂單內容 = new List<object[]>();
            if (Funcuin_驗收訂單_確認訂單可否驗收(this.textBox_驗收訂單_訂單內容_訂單編號.Text,ref List_訂單內容))
            {
                string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
                string[] serch_column = new string[] { enum_訂單資料.訂單編號.GetEnumName(), enum_訂單資料.藥品碼.GetEnumName() };
                string[] value_column;
                foreach (object[] value_訂單內容 in List_訂單內容)
                {
                    value_訂單內容[(int)enum_訂單資料.驗收人] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人];
                    value_訂單內容[(int)enum_訂單資料.驗收日期] = DateTime.Now.AddDays(0).ToShortDateString();
                    value_訂單內容[(int)enum_訂單資料.驗收時間] = this.sqL_DataGridView_訂單資料.GetTimeNow(SQLUI.Table.DateType.TIMESTAMP);
                    value_訂單內容[(int)enum_訂單資料.確認驗收] = true.ToString();

                    value_column = new string[] { value_訂單內容[(int)enum_訂單資料.訂單編號].ObjectToString(), value_訂單內容[(int)enum_訂單資料.藥品碼].ObjectToString() };
                    this.sqL_DataGridView_訂單資料.SQL_Replace(serch_column, value_column, value_訂單內容, false);
                }
                this.Play_WAV(Resource1.yisell_sound_L);
                MyMessageBox.ShowDialog("此訂單已驗收完成!");

            }
            else
            {
                MyMessageBox.ShowDialog("入庫完成!");
            }
            cnt++;
        }
        void cnt_Program_驗收訂單_確認入庫_清除訂單內容(ref int cnt)
        {
            if (!PLC_Program_驗收訂單_清除訂單內容.Bool)
            {
                PLC_Program_驗收訂單_清除訂單內容.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_驗收訂單_確認入庫_等待清除訂單內容結束(ref int cnt)
        {
            if (!PLC_Program_驗收訂單_清除訂單內容.Bool)
            {
                cnt++;
            }
        }
        #endregion
        #region PLC_Program_驗收訂單_搜尋前次驗收折讓後單價
        PLC_Device PLC_Program_驗收訂單_搜尋前次驗收折讓後單價開始 = new PLC_Device("S4047");
        void sub_PLC_Program_驗收訂單_搜尋前次驗收折讓後單價()
        {
            if (this.PLC_Program_驗收訂單_搜尋前次驗收折讓後單價開始.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_下訂單_訂單內容_前次訂購單價.Text = "";
                    List<object[]> list_value = this.sqL_DataGridView_發票資料.SQL_GetRows(enum_發票資料.藥品碼.GetEnumName(), textBox_驗收訂單_發票內容_藥品碼.Text, enum_發票資料.登錄時間.GetEnumName(), SQLUI.SQLControl.OrderType.UpToLow, false);
                    if (list_value.Count > 0)
                    {
                        if (this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex >= 0)
                        {
                            this.textBox_驗收訂單_發票內容_前次驗收折讓後單價.Text = list_value[0][(int)enum_發票資料.折讓後單價].ObjectToString();
                            this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.前次驗收折讓後單價] = this.textBox_驗收訂單_發票內容_前次驗收折讓後單價.Text;
                        }
                    }
                }));

                this.PLC_Program_驗收訂單_搜尋前次驗收折讓後單價開始.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_驗收訂單_未結清發票_編輯
        string str_未結清發票_發票號碼 = "";
        PLC_Device PLC_Program_驗收訂單_未結清發票_編輯開始 = new PLC_Device("S4070");
        int cnt_PLC_Program_驗收訂單_未結清發票_編輯 = 65534;

        void sub_PLC_Program_驗收訂單_未結清發票_編輯()
        {
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 65534)
            {
                this.PLC_Program_驗收訂單_未結清發票_編輯開始.Bool = false;
                cnt_PLC_Program_驗收訂單_未結清發票_編輯 = 65535;
            }
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 65535) cnt_PLC_Program_驗收訂單_未結清發票_編輯 = 1;
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 1) cnt_PLC_Program_驗收訂單_未結清發票_編輯_檢查按下(ref cnt_PLC_Program_驗收訂單_未結清發票_編輯);
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 2) cnt_PLC_Program_驗收訂單_未結清發票_編輯_檢查有無選取資料(ref cnt_PLC_Program_驗收訂單_未結清發票_編輯);
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 3) cnt_PLC_Program_驗收訂單_未結清發票_編輯_初始化(ref cnt_PLC_Program_驗收訂單_未結清發票_編輯);
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 4) cnt_PLC_Program_驗收訂單_未結清發票_編輯_寫入發票內容(ref cnt_PLC_Program_驗收訂單_未結清發票_編輯);
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 5) cnt_PLC_Program_驗收訂單_未結清發票_編輯 = 60000;

            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 > 1) cnt_PLC_Program_驗收訂單_未結清發票_編輯_檢查放開(ref cnt_PLC_Program_驗收訂單_未結清發票_編輯);
            if (cnt_PLC_Program_驗收訂單_未結清發票_編輯 == 65500)
            {
                this.Invoke(new Action(delegate
                {
                    this.plC_Button_驗收訂單_未結清發票_刪除.Enabled = true;
                    this.plC_Button_驗收訂單_發票內容_清除發票內容.Enabled = true;
                    this.plC_Button_驗收訂單_發票內容_增加品項.Enabled = true;
                    this.CheckBox_驗收訂單_發票內容_已結清.Checked = false;
                    this.CheckBox_驗收訂單_發票內容_已結清.Enabled = true;
                    this.textBox_驗收訂單_發票內容_數量.Enabled = true;
                    this.textBox_驗收訂單_發票內容_單價.Enabled = true;

                    this.comboBox_驗收訂單_發票內容_資料筆數.Items.Clear();
                    this.驗收訂單_發票內容_Data = new string[this.驗收訂單_發票內容_Data_Length];
                    this.textBox_驗收訂單_發票內容_入庫人.Text = this.Function_登入畫面_取得登入姓名();
                    this.List_驗收訂單_發票內容_Data.Clear();

                }));

                PLC_Program_驗收訂單_未結清發票_編輯開始.Bool = false;
                cnt_PLC_Program_驗收訂單_未結清發票_編輯 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_未結清發票_編輯_檢查按下(ref int cnt)
        {
            if (PLC_Program_驗收訂單_未結清發票_編輯開始.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_未結清發票_編輯_檢查放開(ref int cnt)
        {
            if (!PLC_Program_驗收訂單_未結清發票_編輯開始.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_未結清發票_編輯_檢查有無選取資料(ref int cnt)
        {
            if (this.sqL_DataGridView_驗收訂單_未結清發票.GetSelectRow() == -1)
            {
                MyMessageBox.ShowDialog("請選取資料欄位");
                cnt = 65500;
                return;
            }
            cnt++;

        }
        void cnt_PLC_Program_驗收訂單_未結清發票_編輯_初始化(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                this.str_未結清發票_發票號碼 = "";
                this.plC_Button_驗收訂單_未結清發票_刪除.Enabled = false;
                this.plC_Button_驗收訂單_發票內容_清除發票內容.Enabled = false;
                this.plC_Button_驗收訂單_發票內容_增加品項.Enabled = false;
                this.textBox_驗收訂單_發票內容_數量.Enabled = false;
            }));

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_未結清發票_編輯_寫入發票內容(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                object[] value = this.sqL_DataGridView_驗收訂單_未結清發票.GetRowValues();
                this.str_未結清發票_發票號碼 = value[(int)enum_發票資料.發票號碼].ObjectToString();

                this.comboBox_驗收訂單_發票內容_資料筆數.Items.Clear();
                this.驗收訂單_發票內容_Data = new string[this.驗收訂單_發票內容_Data_Length];
                this.List_驗收訂單_發票內容_Data.Clear();

                List<object[]> list_value = this.sqL_DataGridView_驗收訂單_未結清發票.SQL_GetRows(enum_發票資料.發票號碼.GetEnumName(), str_未結清發票_發票號碼, false);
                if (list_value.Count > 0)
                {
                    for (int i = 0; i < list_value.Count; i++)
                    {
                        this.comboBox_驗收訂單_發票內容_資料筆數.Items.Add(this.comboBox_驗收訂單_發票內容_資料筆數.Items.Count);
                        string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼] = list_value[i][(int)enum_發票資料.藥品碼].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品名稱] = list_value[i][(int)enum_發票資料.藥品名稱].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量] = list_value[i][(int)enum_發票資料.數量].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價] = list_value[i][(int)enum_發票資料.單價].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價] = list_value[i][(int)enum_發票資料.總價].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓金額] = list_value[i][(int)enum_發票資料.折讓金額].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後單價] = list_value[i][(int)enum_發票資料.折讓後單價].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.前次驗收折讓後單價] = list_value[i][(int)enum_發票資料.前次驗收折讓後單價].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號] = list_value[i][(int)enum_發票資料.訂單編號].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期] = list_value[i][(int)enum_發票資料.效期].ToDateString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.批號] = list_value[i][(int)enum_發票資料.批號].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.一般匯出] = list_value[i][(int)enum_發票資料.一般匯出].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.中榮匯出] = list_value[i][(int)enum_發票資料.中榮匯出].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金] = list_value[i][(int)enum_發票資料.逾期罰金].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金] = list_value[i][(int)enum_發票資料.短效罰金].ObjectToString();
                        _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫日期] = list_value[i][(int)enum_發票資料.入庫日期].ToDateString();
                        
                        this.List_驗收訂單_發票內容_Data.Add(_驗收訂單_發票內容_Data);
                        if(list_value[i][(int)enum_發票資料.入庫日期] is DateTime)
                        {
                            this.dateTimePicker_驗收訂單_發票內容_逾期罰金計算_截止日期.Value = (DateTime)list_value[i][(int)enum_發票資料.入庫日期];
                        }
                        
                    }
                    this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex = 0;
                    this.CheckBox_驗收訂單_發票內容_已結清.Checked = true;
                    this.CheckBox_驗收訂單_發票內容_已結清.Enabled = false;
                }

               
            }));
            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_未結清發票_編輯_(ref int cnt)
        {
            cnt++;
        }
        #endregion

        #region PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged
        PLC_Device PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged = new PLC_Device("S4500");
        int cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged = 65534;
        void sub_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged()
        {
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 65534)
            {
                PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged.SetComment("PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged");
                PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged.Bool = false;
                cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged = 65535;
            }
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 65535) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged = 1;
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 1) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_檢查按下(ref cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged);
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 2) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_初始化(ref cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged);
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 3) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_更新入庫資訊開始(ref cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged);
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 4) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_更新入庫資訊結束(ref cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged);
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 5) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_更新訂單資訊(ref cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged);
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 6) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged = 65500;
            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged > 1) cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_檢查放開(ref cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged);

            if (cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged == 65500)
            {
                PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged.Bool = false;
                cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged = 65535;
            }
        }
        void cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_檢查按下(ref int cnt)
        {
            if (PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged.Bool) cnt++;
        }
        void cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_檢查放開(ref int cnt)
        {
            if (!PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_初始化(ref int cnt)
        {
            cnt++;
        }
        void cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_更新入庫資訊開始(ref int cnt)
        {
            if (!PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.str_訂單資料_更新指定訂單入庫資料_訂單號碼 = this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Text;
                }));
                PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool = true;
                cnt++;
            }
        }
        void cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_更新入庫資訊結束(ref int cnt)
        {
            if (!PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool)
            {
                cnt++;
            }
        }
        void cnt_PLC_Program_訂單搜尋內容_訂單編號_SelectedIndexChanged_更新訂單資訊(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                List<object[]> list_value = this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRows(new string[] { enum_訂單資料.訂單編號.GetEnumName() }, new string[] { this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Text }, true);

                if (list_value.Count > 0)
                {

                    this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = list_value[0][(int)enum_訂單資料.供應商全名].ObjectToString();
                    this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = list_value[0][(int)enum_訂單資料.訂購日期].ToDateString();



                    this.sqL_DataGridView_驗收訂單_未結清發票.SQL_GetRows(new string[] { enum_發票資料.訂單編號.GetEnumName(), enum_發票資料.已結清.GetEnumName() }, new string[] { this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Text, false.ToString() }, true);
                    this.sqL_DataGridView_驗收訂單_已結清發票.SQL_GetRows(new string[] { enum_發票資料.訂單編號.GetEnumName(), enum_發票資料.已結清.GetEnumName() }, new string[] { this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Text, true.ToString() }, true);
                }
            }));
            cnt++;
        }
        #endregion
        #region PLC_Program_驗收訂單_訂單搜尋_藥品碼
        PLC_Device PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品碼 = new PLC_Device("S4525");
        int cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 = 65534;
        void sub_PLC_Program_驗收訂單_訂單搜尋_藥品碼()
        {
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 65534)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品碼.SetComment("PLC_Program_驗收訂單_訂單搜尋_藥品碼");
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品碼.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 = 65535;
            }
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 65535) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 = 1;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 1) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_檢查按下(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 2) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_初始化(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 3) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_開始搜尋(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 4) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_更新ComboBox訂單開始(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 5) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 = 65500;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 > 1) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_檢查放開(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼);

            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 == 65500)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品碼.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_檢查按下(ref int cnt)
        {
            if (PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品碼.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_檢查放開(ref int cnt)
        {
            if (!PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品碼.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_開始搜尋(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                List<object[]> list_value = this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRows(new string[] { enum_訂單資料.藥品碼.GetEnumName(), enum_訂單資料.確認驗收.GetEnumName() }, new string[] { this.comboBox_驗收訂單_訂單搜尋_藥品碼.Text.ToUpper(), false.ToString() }, false);
                if (list_value.Count > 0)
                {
                    this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Clear();
                    this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = "";
                    this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = "";

                    for (int i = 0; i < list_value.Count; i++)
                    {
                        if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.IndexOf(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString()) == -1)
                        {
                            this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Add(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString());
                        }
                    }
                }
            }));
        
            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品碼_更新ComboBox訂單開始(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Count > 0) this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.SelectedIndex = 0;
            }));
            cnt++;
        }
        #endregion
        #region PLC_Program_驗收訂單_訂單搜尋_訂單編號
        PLC_Device PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂單編號 = new PLC_Device("S4545");
        int cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 = 65534;
        void sub_PLC_Program_驗收訂單_訂單搜尋_訂單編號()
        {
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 65534)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂單編號.SetComment("PLC_Program_驗收訂單_訂單搜尋_訂單編號");
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂單編號.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 = 65535;
            }
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 65535) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 = 1;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 1) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_檢查按下(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 2) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_初始化(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 3) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_開始搜尋(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 4) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_更新ComboBox訂單開始(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 5) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 = 65500;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 > 1) cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_檢查放開(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號);

            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 == 65500)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂單編號.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_檢查按下(ref int cnt)
        {
            if (PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂單編號.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_檢查放開(ref int cnt)
        {
            if (!PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂單編號.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_開始搜尋(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                this.Function_訂單搜尋_訂單編號(this.textBox_驗收訂單_訂單搜尋_訂單編號.Text.ToUpper());
            }));

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂單編號_更新ComboBox訂單開始(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Count > 0) this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.SelectedIndex = 0;
                else
                {
                    MyMessageBox.ShowDialog("查無訂單號!");
                }
            }));
            cnt++;
        }
        #endregion
        #region PLC_Program_驗收訂單_訂單搜尋_藥品條碼
        PLC_Device PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 = new PLC_Device("S4565");
        int cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 = 65534;
        void sub_PLC_Program_驗收訂單_訂單搜尋_藥品條碼()
        {
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 65534)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼.SetComment("PLC_Program_驗收訂單_訂單搜尋_藥品條碼");
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 = 65535;
            }
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 65535) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 = 1;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 1) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_檢查按下(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 2) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_初始化(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 3) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_開始搜尋(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 4) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_更新ComboBox訂單開始(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 5) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 = 65500;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 > 1) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_檢查放開(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼);

            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 == 65500)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_檢查按下(ref int cnt)
        {
            if (PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_檢查放開(ref int cnt)
        {
            if (!PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_開始搜尋(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.textBox_驗收訂單_訂單搜尋_藥品條碼.Text != "")
                {
                    string 藥品碼 = this.Function_藥品資料_從藥品條碼取得藥品碼(this.textBox_驗收訂單_訂單搜尋_藥品條碼.Text);
                    if (藥品碼 != null)
                    {
                        List<object[]> list_value = this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRows(new string[] { enum_訂單資料.藥品碼.GetEnumName(), enum_訂單資料.確認驗收.GetEnumName() }, new string[] { 藥品碼, false.ToString() }, false);
                        if (list_value.Count > 0)
                        {
                            this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Clear();
                            this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = "";
                            this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = "";
                            for (int i = 0; i < list_value.Count; i++)
                            {
                                if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.IndexOf(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString()) == -1)
                                {
                                    this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Add(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString());
                                }
                            }
                        }
                    }
                }
            }));

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品條碼_更新ComboBox訂單開始(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Count > 0) this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.SelectedIndex = 0;
                else
                {
                    MyMessageBox.ShowDialog("查無訂單號!");
                }
            }));
            cnt++;
        }
        #endregion
        #region PLC_Program_驗收訂單_訂單搜尋_訂購日期
        PLC_Device PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂購日期 = new PLC_Device("S4585");
        int cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 = 65534;
        void sub_PLC_Program_驗收訂單_訂單搜尋_訂購日期()
        {
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 65534)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂購日期.SetComment("PLC_Program_驗收訂單_訂單搜尋_訂購日期");
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂購日期.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 = 65535;
            }
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 65535) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 = 1;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 1) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_檢查按下(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 2) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_初始化(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 3) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_開始搜尋(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 4) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_更新ComboBox訂單開始(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 5) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 = 65500;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 > 1) cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_檢查放開(ref cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期);

            if (cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 == 65500)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂購日期.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_檢查按下(ref int cnt)
        {
            if (PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂購日期.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_檢查放開(ref int cnt)
        {
            if (!PLC_Device_PLC_Program_驗收訂單_訂單搜尋_訂購日期.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_開始搜尋(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                string 開始日期, 結束日期;
                dateTimePicker_驗收訂單_訂單搜尋_起始時間.Format = DateTimePickerFormat.Short;
                dateTimePicker_驗收訂單_訂單搜尋_結束時間.Format = DateTimePickerFormat.Short;
                開始日期 = dateTimePicker_驗收訂單_訂單搜尋_起始時間.Value.Date.ToShortDateString();
                結束日期 = dateTimePicker_驗收訂單_訂單搜尋_結束時間.Value.AddDays(1).Date.ToShortDateString();
                if (DateTime.Compare(dateTimePicker_驗收訂單_訂單搜尋_起始時間.Value.Date, dateTimePicker_驗收訂單_訂單搜尋_結束時間.Value.Date) <= 0)
                {
                    this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRowsByBetween(enum_訂單資料.訂購日期.GetEnumName(), 開始日期, 結束日期, true);
                    List<object[]> list_value = this.sqL_DataGridView_驗收訂單_訂單搜尋.GetRows(enum_訂單資料.確認驗收.GetEnumName(), false.ToString(), false);
                    this.sqL_DataGridView_驗收訂單_訂單搜尋.ClearGrid();
                    this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Clear();
                    this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = "";
                    this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = "";
                    if (list_value.Count > 0)
                    {
                        for (int i = 0; i < list_value.Count; i++)
                        {
                            if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.IndexOf(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString()) == -1)
                            {
                                this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Add(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString());
                            }
                        }

                    }
                }
                else
                {
                    MyMessageBox.ShowDialog("輸入日期不合法!");
                }
            }));

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_訂購日期_更新ComboBox訂單開始(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Count > 0) this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.SelectedIndex = 0;
                else
                {
                    MyMessageBox.ShowDialog("查無訂單號!");
                }
            }));
            cnt++;
        }
        #endregion
        #region PLC_Program_驗收訂單_訂單搜尋_藥品名稱
        PLC_Device PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 = new PLC_Device("S4625");
        int cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 = 65534;
        void sub_PLC_Program_驗收訂單_訂單搜尋_藥品名稱()
        {
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 65534)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品名稱.SetComment("PLC_Program_驗收訂單_訂單搜尋_藥品名稱");
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品名稱.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 = 65535;
            }
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 65535) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 = 1;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 1) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_檢查按下(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 2) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_初始化(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 3) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_開始搜尋(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 4) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_更新ComboBox訂單開始(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱);
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 5) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 = 65500;
            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 > 1) cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_檢查放開(ref cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱);

            if (cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 == 65500)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品名稱.Bool = false;
                cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱 = 65535;
            }
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_檢查按下(ref int cnt)
        {
            if (PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品名稱.Bool) cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_檢查放開(ref int cnt)
        {
            if (!PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品名稱.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_開始搜尋(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.textBox_驗收訂單_訂單搜尋_藥品名稱.Text != "")
                {

                    List<object[]> list_value_buf = this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRowsByLike(enum_訂單資料.藥品名稱.GetEnumName(), this.textBox_驗收訂單_訂單搜尋_藥品名稱.Text, false);
                    List<object[]> list_value = new List<object[]>();
                    foreach (object[] value in list_value_buf)
                    {
                        if (value[(int)enum_訂單資料.確認驗收].ObjectToString() == false.ToString())
                        {
                            list_value.Add(value);
                        }
                    }
                    if (list_value.Count > 0)
                    {
                        this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Clear();
                        this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = "";
                        this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = "";
                        for (int i = 0; i < list_value.Count; i++)
                        {
                            if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.IndexOf(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString()) == -1)
                            {
                                this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Add(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString());
                            }
                        }
                    }

                }
            }));

            cnt++;
        }
        void cnt_PLC_Program_驗收訂單_訂單搜尋_藥品名稱_更新ComboBox訂單開始(ref int cnt)
        {
            this.Invoke(new Action(delegate
            {
                if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Count > 0) this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.SelectedIndex = 0;
                else
                {
                    MyMessageBox.ShowDialog("查無訂單號!");
                }
            }));
            cnt++;
        }
        #endregion

        #region Program_驗收訂單_鎖定訂單搜尋
        bool flag_Program_驗收訂單_鎖定訂單搜尋_Enable = false;
        bool flag_Program_驗收訂單_鎖定訂單搜尋_Enable_buf = false;
        void sub_Program_驗收訂單_鎖定訂單搜尋()
        {
            if (textBox_驗收訂單_訂單內容_訂單編號.Text != "")
            {
                flag_Program_驗收訂單_鎖定訂單搜尋_Enable = false;
            }
            else
            {
                flag_Program_驗收訂單_鎖定訂單搜尋_Enable = true;
            }

            if (flag_Program_驗收訂單_鎖定訂單搜尋_Enable_buf != flag_Program_驗收訂單_鎖定訂單搜尋_Enable)
            {
                this.Invoke(new Action(delegate
                {
                    if (!flag_Program_驗收訂單_鎖定訂單搜尋_Enable)
                    {
                        PLC_Program_驗收訂單_掃描發票.Bool = true;
                        comboBox_驗收訂單_訂單搜尋內容_訂單編號.Enabled = false;
                        plC_Button_驗收訂單_訂單搜尋_藥品碼.Enabled = false;
                        plC_Button_驗收訂單_訂單搜尋_訂單編號.Enabled = false;
                        plC_Button_驗收訂單_訂單搜尋_藥品條碼.Enabled = false;
                    }
                    else
                    {
                        comboBox_驗收訂單_訂單搜尋內容_訂單編號.Enabled = true;
                        plC_Button_驗收訂單_訂單搜尋_藥品碼.Enabled = true;
                        plC_Button_驗收訂單_訂單搜尋_訂單編號.Enabled = true;
                        plC_Button_驗收訂單_訂單搜尋_藥品條碼.Enabled = true;
                    }
                    flag_Program_驗收訂單_鎖定訂單搜尋_Enable_buf = flag_Program_驗收訂單_鎖定訂單搜尋_Enable;
                }));
            }



        }
        #endregion


        #region Function
        private DateTime Function_計算前日入庫日期(DateTime date)
        {
            date = date.AddDays(-1);
            return date;
            while (true)
            {
                date = date.AddDays(-1);
                if (!Basic.TypeConvert.IsHolidays(date))
                {
                    break;
                }
            }
            return date;
        }
        PLC_Device PLC_Device_逾期罰金比例 = new PLC_Device("D4045");
        PLC_Device PLC_Device_逾期罰金比例上限 = new PLC_Device("D4046");
        private double Function_計算逾期罰金比例(string 訂單編號)
        {
            if (!plC_CheckBox_逾時罰金計算.Bool)
            {
                return 0;
            }
            double 罰金比例 = 0;
            double 罰金比例基準 = PLC_Device_逾期罰金比例.Value / 1000D;
            double 罰金比例上限 = PLC_Device_逾期罰金比例上限.Value / 1000D;
            List<object[]> list_訂單資料 = this.sqL_DataGridView_訂單資料.SQL_GetRows(enum_訂單資料.訂單編號.GetEnumName(), 訂單編號, false);
            if (list_訂單資料.Count > 0)
            {
                string str_截止日期 = dateTimePicker_驗收訂單_發票內容_逾期罰金計算_截止日期.Value.Date.ToDateString();
                string str_應驗收日期 = list_訂單資料[0][(int)enum_訂單資料.應驗收日期].ToDateString();
                int Year = 0;
                int Month = 0;
                int Day = 0;
                int 截止日期 = str_截止日期.Get_DateTINY();
                int 應驗收日期 = str_應驗收日期.Get_DateTINY();
                str_應驗收日期.Get_Date(ref Year, ref Month, ref Day, TypeConvert.Enum_Year_Type.Anno_Domini);
                DateTime date_應驗收日期 = new DateTime(Year, Month, Day);
                DateTime date_截止日期 = dateTimePicker_驗收訂單_發票內容_逾期罰金計算_截止日期.Value.Date;
                int 天數 = new TimeSpan(date_截止日期.Ticks - date_應驗收日期.Ticks).Days;
                if (天數 > 0)
                {
                    int 逾時天數 = this.Function_扣除假日天數(天數, date_應驗收日期);
                    罰金比例 = 逾時天數 * 罰金比例基準;
                    if (罰金比例 > 罰金比例上限) 罰金比例 = 罰金比例上限;
                }
            }
            return 罰金比例;
        }
        private void Function_訂單搜尋_訂單編號(string 訂單編號)
        {
            this.Invoke(new Action(delegate
            {
                List<object[]> list_value = this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRows(new string[] { enum_訂單資料.訂單編號.GetEnumName(), enum_訂單資料.確認驗收.GetEnumName() }, new string[] { 訂單編號, false.ToString() }, false);
                if (list_value.Count > 0)
                {
                    this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Clear();
                    this.textBox_驗收訂單_訂單搜尋內容_供應商全名.Text = "";
                    this.textBox_驗收訂單_訂單搜尋內容_訂購日期.Text = "";
                    for (int i = 0; i < list_value.Count; i++)
                    {
                        if (this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.IndexOf(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString()) == -1)
                        {
                            this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.Items.Add(list_value[i][(int)enum_訂單資料.訂單編號].ObjectToString());
                        }
                    }
                    this.comboBox_驗收訂單_訂單搜尋內容_訂單編號.SelectedIndex = 0;
                }
            }));
        }
        private void Function_驗收訂單_新增一筆發票()
        {
            this.comboBox_驗收訂單_發票內容_資料筆數.Items.Add(this.comboBox_驗收訂單_發票內容_資料筆數.Items.Count);
            string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
            _驗收訂單_發票內容_Data[(int)enum_發票資料.藥品碼] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.藥品名稱] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.數量] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.單價] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.總價] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.折讓金額] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.折讓後單價] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.前次驗收折讓後單價] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.訂單編號] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.效期] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.批號] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.逾期罰金] = "";
            _驗收訂單_發票內容_Data[(int)enum_發票資料.短效罰金] = "";
            this.List_驗收訂單_發票內容_Data.Add(_驗收訂單_發票內容_Data);
            this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex = this.comboBox_驗收訂單_發票內容_資料筆數.Items.Count - 1;
        }
        private void Function_驗收訂單_發票內容更新(int index)
        {
            string[] _驗收訂單_發票內容_Data = new string[this.驗收訂單_發票內容_Data_Length];
            this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex = index;
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票號碼];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.已結清] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.已結清];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.賣方統一編號] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.賣方統一編號];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.發票日期];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.登錄時間];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人] = this.驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.藥品碼];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品名稱] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.藥品名稱];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.數量];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.單價];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.總價];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓金額] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.折讓金額];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後單價] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.折讓後單價];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.訂單編號];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.效期];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.批號] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.批號];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.逾期罰金] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.逾期罰金];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.短效罰金] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.短效罰金];
            _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.前次驗收折讓後單價] = this.List_驗收訂單_發票內容_Data[index][(int)enum_驗收訂單_發票內容.前次驗收折讓後單價];
            this.驗收訂單_發票內容_Data = _驗收訂單_發票內容_Data;
        }
        private bool Funcuin_驗收訂單_確認訂單可否驗收(string 訂單編號 ,ref List<object[]> List_訂單內容)
        {
            bool flag_可驗收 = true;
            List_訂單內容 = this.sqL_DataGridView_驗收訂單_訂單搜尋.SQL_GetRows(enum_訂單資料.訂單編號.GetEnumName(), this.textBox_驗收訂單_訂單內容_訂單編號.Text, true);
            if (List_訂單內容.Count > 0)
            {
                foreach (object[] value_訂單內容 in List_訂單內容)
                {
                    if (value_訂單內容[(int)enum_訂單資料.訂購數量].StringToInt32() != value_訂單內容[(int)enum_訂單資料.已入庫數量].StringToInt32())
                    {
                        flag_可驗收 = false;
                    }
                }
            }

            List<object[]> list_發票資料 = this.sqL_DataGridView_發票資料.SQL_GetRows(enum_發票資料.訂單編號.GetEnumName(), this.textBox_驗收訂單_訂單內容_訂單編號.Text, false);
            if (list_發票資料.Count > 0)
            {
                foreach (object[] value_發票資料 in list_發票資料)
                {
                    if (value_發票資料[(int)enum_發票資料.已結清].ObjectToString() == false.ToString()) flag_可驗收 = false;
                }
            }
            else
            {
                flag_可驗收 = false;
            }
            return flag_可驗收;
        }
        private void Function_驗收訂單_計算折讓後單價()
        {
            double 數量_temp = 0;
            double 單價_temp = 0;
            double 折讓金額_temp = 0;
            double 折讓後單價_temp = 0;
            if (double.TryParse(textBox_驗收訂單_發票內容_數量.Text, out 數量_temp))
            {
                if (double.TryParse(textBox_驗收訂單_發票內容_單價.Text, out 單價_temp))
                {
                    //textBox_驗收訂單_發票內容_總價.Text = (單價_temp * 數量_temp).ToString();
                    if (double.TryParse(textBox_驗收訂單_發票內容_折讓金額.Text, out 折讓金額_temp))
                    {
                        折讓後單價_temp = ((單價_temp * 數量_temp) - 折讓金額_temp) / (double)數量_temp;
                        textBox_驗收訂單_發票內容_折讓後單價.Text = Math.Round(折讓後單價_temp, 2).ToString("0.00");
                    }
                }
            }
        }
        private void Function_驗收訂單_計算折讓後總價()
        {
            double 總價_temp = 0;
            double 折讓金額_temp = 0;
            if (double.TryParse(textBox_驗收訂單_發票內容_總價.Text, out 總價_temp))
            {
                if (double.TryParse(textBox_驗收訂單_發票內容_折讓金額.Text, out 折讓金額_temp))
                {
                    this.textBox_驗收訂單_發票內容_折讓後總價.Text = Math.Round((總價_temp - 折讓金額_temp), 0).ToString();
                }
            }
        }
        private void Function_驗收訂單_計算短效罰金()
        {
            if(!plC_CheckBox_短效罰金計算.Bool)
            {
                textBox_驗收訂單_發票內容_短效罰金.Text = 0.ToString("0");
                return;
            }
            if(this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex == -1 )
            {
                return;
            }
            string 入庫日期 = this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.入庫日期];

            string 效期 = textBox_驗收訂單_發票內容_效期.Text;
            string 藥品碼 = textBox_驗收訂單_發票內容_藥品碼.Text;
            string 數量 = textBox_驗收訂單_發票內容_數量.Text;
            double 短效罰金 = 0;
            if (!效期.Check_Date_String())
            {
                return;
            }
            if (!入庫日期.Check_Date_String())
            {
                return;
            }

            List<object[]> list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), 藥品碼, false);
            if (list_藥品資料.Count > 0)
            {
                double 契約價金 = list_藥品資料[0][(int)enum_藥品資料.契約價金].StringToDouble();
                int int_數量 = 數量.StringToInt32();
                if (契約價金 == -1)
                {
                    return;
                }
                if (int_數量 == -1)
                {
                    return;
                }
                DateTime date_Now = DateTime.Now;
                int Year = 0;
                int Month = 0;
                int Day = 0;
                效期.ObjectToString().Get_Date(ref Year, ref Month, ref Day, TypeConvert.Enum_Year_Type.Anno_Domini);
                DateTime date_效期 = new DateTime(Year, Month, Day);
                入庫日期.ObjectToString().Get_Date(ref Year, ref Month, ref Day, TypeConvert.Enum_Year_Type.Anno_Domini);
                DateTime date_入庫日期 = new DateTime(Year, Month, Day);
                int 有效天數 = new TimeSpan(date_效期.Ticks - date_入庫日期.Ticks).Days;
                有效天數 = 有效天數 - 360;
                if (有效天數 < 0 && 有效天數 > -30) 有效天數 = -30;
                if (有效天數 < 0)
                {
                    短效罰金 = (double)(契約價金 * int_數量) * (0.06 * ((int)(有效天數 / 30)));
                    短效罰金 *= -1;
                    textBox_驗收訂單_發票內容_短效罰金.Text = Math.Round(短效罰金).ToString("0");
                }
                else
                {
                    textBox_驗收訂單_發票內容_短效罰金.Text = 0.ToString("0");
                }
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.短效罰金] = this.textBox_驗收訂單_發票內容_短效罰金.Text;

            }
            else
            {
                return;
            }
        }
        #endregion
        #region Event
        private void plC_Button_驗收訂單_訂單搜尋_藥品碼_btnClick(object sender, EventArgs e)
        {
  
        }
        private void plC_Button_驗收訂單_訂單搜尋_訂單編號_btnClick(object sender, EventArgs e)
        {
        }
        private void plC_Button_驗收訂單_訂單搜尋_藥品條碼_btnClick(object sender, EventArgs e)
        {
          
        }
        private void plC_Button_驗收訂單_訂單搜尋_訂購日期_btnClick(object sender, EventArgs e)
        {
           
        }
        private void plC_Button_驗收訂單_訂單內容_訂購人重新簽入_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("'訂購人'資訊重新簽入?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                string[] _驗收訂單_訂單內容 = this.驗收訂單_訂單內容_Data;
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購人] = this.Function_登入畫面_取得登入姓名();
                this.驗收訂單_訂單內容_Data = _驗收訂單_訂單內容;
            }
        }
        private void comboBox_驗收訂單_訂單搜尋內容_訂單編號_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PLC_Device_訂單搜尋內容_訂單編號_SelectedIndexChanged.Bool = true;
        }
        private void textBox_驗收訂單_訂單搜尋_藥品條碼_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PLC_Device_PLC_Program_驗收訂單_訂單搜尋_藥品條碼.Bool = true;
            }
        }
        private void plC_Button_驗收訂單_訂單搜尋_填入訂單_btnClick(object sender, EventArgs e)
        {
            string[] _驗收訂單_發票內容_Data;
            if (this.sqL_DataGridView_驗收訂單_訂單搜尋.GetSelectRow() == -1)
            {
                this.sqL_DataGridView_驗收訂單_訂單搜尋.SetSelectRow(0);
            }
            object[] obj = this.sqL_DataGridView_驗收訂單_訂單搜尋.GetRowValues();
            if (obj != null)
            {
                string[] _驗收訂單_訂單內容 = this.驗收訂單_訂單內容_Data;
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂單編號] = obj[(int)enum_訂單資料.訂單編號].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購人] = obj[(int)enum_訂單資料.訂購人].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購院所別] = obj[(int)enum_訂單資料.訂購院所別].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購日期] = obj[(int)enum_訂單資料.訂購日期].ToDateString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購數量] = obj[(int)enum_訂單資料.訂購數量].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購單價] = obj[(int)enum_訂單資料.訂購單價].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.訂購總價] = obj[(int)enum_訂單資料.訂購總價].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.應驗收日期] = obj[(int)enum_訂單資料.應驗收日期].ToDateString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.供應商全名] = obj[(int)enum_訂單資料.供應商全名].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.Email] = obj[(int)enum_訂單資料.供應商Email].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.聯絡人] = obj[(int)enum_訂單資料.供應商聯絡人].ObjectToString();
                _驗收訂單_訂單內容[(int)enum_驗收訂單_訂單內容.電話] = obj[(int)enum_訂單資料.供應商電話].ObjectToString();
                this.驗收訂單_訂單內容_Data = _驗收訂單_訂單內容;
                for (int i = 0; i < this.List_驗收訂單_發票內容_Data.Count; i++)
                {
                    if (this.List_驗收訂單_發票內容_Data[i][(int)enum_驗收訂單_發票內容.藥品碼] == obj[(int)enum_訂單資料.藥品碼].ObjectToString())
                    {
                        //MyMessageBox.ShowDialog("發票內容已有相同藥品!");
                        return;
                    }
                }


                if (obj[(int)enum_訂單資料.訂購數量].StringToInt32() == obj[(int)enum_訂單資料.已入庫數量].StringToInt32())
                {
                    MyMessageBox.ShowDialog("此藥品驗收數量已到達!");

                    List<object[]> List_訂單內容 = new List<object[]>();
                    if (Funcuin_驗收訂單_確認訂單可否驗收(this.textBox_驗收訂單_訂單內容_訂單編號.Text, ref List_訂單內容))
                    {
                        if (MyMessageBox.ShowDialog("是否重新簽入驗收訂單?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel) == DialogResult.Yes)
                        {
                            _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;
                            string[] serch_column = new string[] { enum_訂單資料.訂單編號.GetEnumName(), enum_訂單資料.藥品碼.GetEnumName() };
                            string[] value_column;
                            foreach (object[] value_訂單內容 in List_訂單內容)
                            {
                                value_訂單內容[(int)enum_訂單資料.驗收人] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.入庫人];
                                value_訂單內容[(int)enum_訂單資料.驗收日期] = DateTime.Now.AddDays(0).ToShortDateString();
                                value_訂單內容[(int)enum_訂單資料.驗收時間] = this.sqL_DataGridView_訂單資料.GetTimeNow(SQLUI.Table.DateType.TIMESTAMP);
                                value_訂單內容[(int)enum_訂單資料.確認驗收] = true.ToString();
                                value_column = new string[] { value_訂單內容[(int)enum_訂單資料.訂單編號].ObjectToString(), value_訂單內容[(int)enum_訂單資料.藥品碼].ObjectToString() };
                                this.sqL_DataGridView_訂單資料.SQL_Replace(serch_column, value_column, value_訂單內容, false);
                            }
                            this.plC_Button_驗收訂單_未結清發票_編輯.SetValue(false);
                            this.PLC_Program_驗收訂單_清除訂單內容.Bool = true;
                        }
                    }
 


                    return;
                }
                this.Function_驗收訂單_新增一筆發票();
                _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;

                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.藥品碼] = obj[(int)enum_訂單資料.藥品碼].ObjectToString();
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.藥品名稱] = obj[(int)enum_訂單資料.藥品名稱].ObjectToString();
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.訂單編號] = obj[(int)enum_訂單資料.訂單編號].ObjectToString();
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.單價] = obj[(int)enum_訂單資料.訂購單價].ObjectToString();
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.數量] = obj[(int)enum_訂單資料.訂購數量].ObjectToString();
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼] = this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.藥品碼];
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品名稱] = this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.藥品名稱];
                _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號] = this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.訂單編號];
                //_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價] = this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.單價];
                //_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量] = this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.數量];
                //_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價] = (_驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價].StringToInt32() * _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量].StringToInt32()).ToString();
                this.驗收訂單_發票內容_Data = _驗收訂單_發票內容_Data;


                PLC_Program_驗收訂單_搜尋前次驗收折讓後單價開始.Bool = true;


            }
        }
        private void plC_Button_驗收訂單_訂單內容_取消作業_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否清除所有內容?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == DialogResult.Yes)
            {
                this.plC_Button_驗收訂單_未結清發票_編輯.SetValue(false);
                this.PLC_Program_驗收訂單_清除訂單內容.Bool = true;
            }
        }

        private void textBox_驗收訂單_發票內容_數量_TextChanged(object sender, EventArgs e)
        {
            this.Function_驗收訂單_計算折讓後單價();

        }
        private void textBox_驗收訂單_發票內容_單價_TextChanged(object sender, EventArgs e)
        {
            this.Function_驗收訂單_計算折讓後單價();
        }
        private void textBox_驗收訂單_發票內容_折讓金額_TextChanged(object sender, EventArgs e)
        {
            this.Function_驗收訂單_計算折讓後單價();
            this.Function_驗收訂單_計算折讓後總價();

        }
        private void textBox_驗收訂單_發票內容_總價_TextChanged(object sender, EventArgs e)
        {
            this.Function_驗收訂單_計算折讓後單價();
            this.Function_驗收訂單_計算折讓後總價();
            this.Function_驗收訂單_計算短效罰金();
        }
        private void textBox_驗收訂單_發票內容_效期_TextChanged(object sender, EventArgs e)
        {
            this.Function_驗收訂單_計算短效罰金();
        }
        private void textBox_驗收訂單_發票內容_短效罰金_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox_驗收訂單_發票內容_總價_Leave(object sender, EventArgs e)
        {
            //double 總價 = this.textBox_驗收訂單_發票內容_總價.Text.StringToDouble();
            //int 數量 = this.textBox_驗收訂單_發票內容_數量.Text.StringToInt32();
            //if (數量 == -1 || 總價 == -1) return;
            //textBox_驗收訂單_發票內容_單價.Text = ((double)(總價 / 數量)).ToString("0.0000");
        }
        private void textBox_驗收訂單_發票內容_總價_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    double 總價 = this.textBox_驗收訂單_發票內容_總價.Text.StringToDouble();
            //    int 數量 = this.textBox_驗收訂單_發票內容_數量.Text.StringToInt32();
            //    if (數量 == -1 || 總價 == -1) return;
            //    textBox_驗收訂單_發票內容_單價.Text = ((double)(總價 / 數量)).ToString("0.0000"); 
            //}
        }

        private void plC_Button_驗收訂單_發票內容_增加品項_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否新增資料筆數?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Function_驗收訂單_新增一筆發票();
            }
        }
        private void comboBox_驗收訂單_發票內容_資料筆數_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Function_驗收訂單_發票內容更新(this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex);
        }
        private void plC_Button_驗收訂單_發票內容_清除發票內容_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否移除所有發票內容?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                this.comboBox_驗收訂單_發票內容_資料筆數.Items.Clear();
                this.驗收訂單_發票內容_Data = new string[this.驗收訂單_發票內容_Data_Length];
                this.List_驗收訂單_發票內容_Data.Clear();
            }
        }
        private void richTextBox_驗收訂單_掃描發票_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                flag_驗收訂單_掃描發票_已掃描 = true;
            }
            if (cnt_Program_驗收訂單_掃描發票 > 1)
            {
                if (str_Program_驗收訂單_狀態.Contains("........"))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace("........", "....... ");
                }
                else if (str_Program_驗收訂單_狀態.Contains("....... "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace("....... ", "......  ");
                }
                else if (str_Program_驗收訂單_狀態.Contains("......  "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace("......  ", ".....   ");
                }
                else if (str_Program_驗收訂單_狀態.Contains(".....   "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace(".....   ", "....    ");
                }
                else if (str_Program_驗收訂單_狀態.Contains("....    "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace("....    ", "...     ");
                }
                else if (str_Program_驗收訂單_狀態.Contains("...     "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace("...     ", "..      ");
                }
                else if (str_Program_驗收訂單_狀態.Contains("..      "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace("..      ", ".       ");
                }
                else if (str_Program_驗收訂單_狀態.Contains(".       "))
                {
                    str_Program_驗收訂單_狀態 = str_Program_驗收訂單_狀態.Replace(".       ", "........");
                }
            }
        }

        private void textBox_驗收訂單_發票內容_Leave(object sender, EventArgs e)
        {
            if (this.comboBox_驗收訂單_發票內容_資料筆數.Text != "")
            {
                string[] _驗收訂單_發票內容_Data = this.驗收訂單_發票內容_Data;

                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.藥品碼] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品碼];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.藥品名稱] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.藥品名稱];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.數量] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.數量];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.單價] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.單價];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.總價] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.總價];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.折讓金額] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓金額];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.折讓後單價] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.折讓後單價];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.訂單編號] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.訂單編號];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.效期] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.效期];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.批號] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.批號];
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.前次驗收折讓後單價] = _驗收訂單_發票內容_Data[(int)enum_驗收訂單_發票內容.前次驗收折讓後單價];
            }
        }

        private void sqL_DataGridView_驗收訂單_訂單搜尋_DataGridRefreshEven()
        {
            string str_已入庫數量_temp = "";
            string str_訂購數量_temp = "";
            int 已入庫數量_temp = 0;
            int 訂購數量_temp = 0;
            for (int i = 0; i < this.sqL_DataGridView_驗收訂單_訂單搜尋.dataGridView.Rows.Count; i++)
            {
                str_訂購數量_temp = this.sqL_DataGridView_驗收訂單_訂單搜尋.dataGridView.Rows[i].Cells[(int)enum_訂單資料.訂購數量].Value.ObjectToString();
                str_已入庫數量_temp = this.sqL_DataGridView_驗收訂單_訂單搜尋.dataGridView.Rows[i].Cells[(int)enum_訂單資料.已入庫數量].Value.ObjectToString();

                if (int.TryParse(str_訂購數量_temp, out 訂購數量_temp))
                {
                    if (int.TryParse(str_已入庫數量_temp, out 已入庫數量_temp))
                    {
                        if (已入庫數量_temp >= 訂購數量_temp)
                        {
                            this.sqL_DataGridView_驗收訂單_訂單搜尋.dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Lime;
                            this.sqL_DataGridView_驗收訂單_訂單搜尋.dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }

                    }
                }
            }
        }
        private void button_驗收訂單_自動生成發票號碼_Click(object sender, EventArgs e)
        {
            this.textBox_驗收訂單_發票內容_發票號碼.Text = "IV" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
            this.textBox_驗收訂單_發票內容_發票日期.Text = DateTime.Now.AddDays(0).ToShortDateString();
        }

        private void CheckBox_驗收訂單_發票內容_已結清_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.textBox_驗收訂單_發票內容_發票號碼.Text = "";

                this.textBox_驗收訂單_發票內容_發票號碼.Enabled = true;
                this.textBox_驗收訂單_發票內容_賣方統一編號.Enabled = true;
                this.textBox_驗收訂單_發票內容_發票日期.Enabled = true;
                this.textBox_驗收訂單_發票內容_入庫人.Enabled = true;
            }
            else
            {

                this.textBox_驗收訂單_發票內容_發票號碼.Enabled = false;
                this.textBox_驗收訂單_發票內容_賣方統一編號.Enabled = false;
                this.textBox_驗收訂單_發票內容_發票日期.Enabled = false;
                this.textBox_驗收訂單_發票內容_入庫人.Enabled = false;
            }

            this.textBox_驗收訂單_發票內容_賣方統一編號.Text = "";
            this.textBox_驗收訂單_發票內容_發票日期.Text = "";
            this.textBox_驗收訂單_發票內容_入庫人.Text = this.Function_登入畫面_取得登入姓名();

            if (!this.CheckBox_驗收訂單_發票內容_已結清.Checked)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(delegate
                    {
                        this.textBox_驗收訂單_發票內容_發票號碼.Text = "IV" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                        this.textBox_驗收訂單_發票內容_發票日期.Text = DateTime.Now.AddDays(0).ToShortDateString();
                    }));
                }
            }
        }
        private void plC_Button_驗收訂單_未結清發票_刪除_btnClick(object sender, EventArgs e)
        {
            if (this.sqL_DataGridView_驗收訂單_未結清發票.GetSelectRow() == -1)
            {
                MyMessageBox.ShowDialog("請選取資料!");
                return;
            }
            DialogResult Result = MyMessageBox.ShowDialog("是否刪除此筆資料?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                object[] value = this.sqL_DataGridView_驗收訂單_未結清發票.GetRowValues();
                string 訂單編號 = value[(int)enum_發票資料.訂單編號].ObjectToString();
                this.sqL_DataGridView_發票資料.SQL_Delete(enum_發票資料.發票號碼.GetEnumName(), value[(int)enum_發票資料.發票號碼].ObjectToString(), false);
                this.sqL_DataGridView_驗收訂單_未結清發票.SQL_GetRows(new string[] { enum_發票資料.訂單編號.GetEnumName(), enum_發票資料.已結清.GetEnumName() }, new string[] { 訂單編號, false.ToString() }, true);
                this.str_訂單資料_更新指定訂單入庫資料_訂單號碼 = 訂單編號;
                this.PLC_Program_訂單資料_更新指定訂單入庫資料開始.Bool = true;

            }
        }
        private void button_驗收訂單_計算逾時罰金_Click(object sender, EventArgs e)
        {
            string 訂單編號 = textBox_驗收訂單_發票內容_訂單編號.Text;
            string 藥品碼 = textBox_驗收訂單_發票內容_藥品碼.Text;
            string 數量 = textBox_驗收訂單_發票內容_數量.Text;
            if (訂單編號.StringIsEmpty())
            {
                MyMessageBox.ShowDialog("'訂單編號'空白!");
                return;
            }
            if (藥品碼.StringIsEmpty())
            {
                MyMessageBox.ShowDialog("'藥品碼'空白!");
                return;
            }
            List<object[]> list_發票資料 = this.sqL_DataGridView_發票資料.SQL_GetRows(new string[] { enum_發票資料.訂單編號.GetEnumName(), enum_發票資料.藥品碼.GetEnumName() }, new string[] { 訂單編號, 藥品碼 }, false);
            if (list_發票資料.Count <= 0)
            {
                MyMessageBox.ShowDialog("查無發票資訊!");
                return;
            }
            List<object[]> list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), 藥品碼, false);
            if (list_藥品資料.Count > 0)
            {
                double 總價 = list_藥品資料[0][(int)enum_藥品資料.契約價金].StringToDouble();
                int int_數量 = 數量.StringToInt32();
                if (總價 == -1)
                {
                    MyMessageBox.ShowDialog("藥品資料'契約價金'未填寫!");
                    return;
                }
                if(int_數量 == -1)
                {
                    MyMessageBox.ShowDialog("'入庫數量'未填寫!");
                    return;
                }
                double 罰金比例 = this.Function_計算逾期罰金比例(訂單編號);
                this.textBox_驗收訂單_發票內容_逾期罰金.Text =Math.Round((總價 * int_數量 * 罰金比例)).ToString("0");
                this.List_驗收訂單_發票內容_Data[this.comboBox_驗收訂單_發票內容_資料筆數.SelectedIndex][(int)enum_驗收訂單_發票內容.逾期罰金] = this.textBox_驗收訂單_發票內容_逾期罰金.Text;
            }
            else
            {
                MyMessageBox.ShowDialog("查無此藥品!");
                return;
            }
            

        }
        private void textBox_驗收訂單_發票內容_短效罰金_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {

                this.Function_驗收訂單_計算短效罰金();

            }
        }
        #endregion
    }
}
