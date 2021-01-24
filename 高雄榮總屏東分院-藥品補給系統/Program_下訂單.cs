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
        PLC_Device PLC_驗收期限 = new PLC_Device("D4000");

        public enum enum_下訂單_訂單內容 : int
        {
            訂單編號,
            訂購人,
            訂購院所別,
            訂購日期,
            訂購數量,
            訂購單價,
            訂購總價,
            應驗收日期,
            藥品碼,
            藥品名稱,
            單位,
            供應商全名,
            包裝單位,
            Email,
            聯絡人,
            前次訂購單價,
            電話,
            已訂購總價,
        }
        string[] 下訂單_訂單內容_Data
        {
            get
            {
                string[] _下訂單_訂單內容_Data = new string[下訂單_訂單內容_Data_Length];
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂單編號] = this.textBox_下訂單_訂單內容_訂單編號.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購人] = this.textBox_下訂單_訂單內容_訂購人.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購院所別] = this.textBox_下訂單_訂單內容_訂購院所別.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購日期] = this.textBox_下訂單_訂單內容_訂購日期.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購數量] = this.textBox_下訂單_訂單內容_訂購數量.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購單價] = this.textBox_下訂單_訂單內容_訂購單價.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購總價] = this.textBox_下訂單_訂單內容_訂購總價.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.應驗收日期] = this.textBox_下訂單_訂單內容_應驗收日期.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.藥品碼] = this.textBox_下訂單_訂單內容_藥品碼.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.藥品名稱] = this.textBox_下訂單_訂單內容_藥品名稱.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.單位] = this.textBox_下訂單_訂單內容_包裝單位.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.供應商全名] = this.textBox_下訂單_訂單內容_供應商全名.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.包裝單位] = this.textBox_下訂單_訂單內容_包裝單位.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.Email] = this.textBox_下訂單_訂單內容_Email.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.聯絡人] = this.textBox_下訂單_訂單內容_聯絡人.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.前次訂購單價] = this.textBox_下訂單_訂單內容_前次訂購單價.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.已訂購總價] = this.textBox_下訂單_訂單內容_已訂購總價.Text;
                _下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.電話] = this.textBox_下訂單_訂單內容_電話.Text;
                return _下訂單_訂單內容_Data;
            }
            set
            {
                this.textBox_下訂單_訂單內容_訂單編號.Text = value[(int)enum_下訂單_訂單內容.訂單編號];
                this.textBox_下訂單_訂單內容_訂購人.Text = value[(int)enum_下訂單_訂單內容.訂購人];
                this.textBox_下訂單_訂單內容_訂購人.Text = this.Function_登入畫面_取得登入姓名();
                this.textBox_下訂單_訂單內容_訂購院所別.Text = value[(int)enum_下訂單_訂單內容.訂購院所別];
                this.textBox_下訂單_訂單內容_訂購院所別.Text = "高雄榮民總醫院屏東分院";
                
                this.textBox_下訂單_訂單內容_訂購日期.Text = value[(int)enum_下訂單_訂單內容.訂購日期];
                this.textBox_下訂單_訂單內容_訂購數量.Text = value[(int)enum_下訂單_訂單內容.訂購數量];
                this.textBox_下訂單_訂單內容_訂購單價.Text = value[(int)enum_下訂單_訂單內容.訂購單價];
                this.textBox_下訂單_訂單內容_訂購總價.Text = value[(int)enum_下訂單_訂單內容.訂購總價];
                this.textBox_下訂單_訂單內容_應驗收日期.Text = value[(int)enum_下訂單_訂單內容.應驗收日期];
                this.textBox_下訂單_訂單內容_藥品碼.Text = value[(int)enum_下訂單_訂單內容.藥品碼];
                this.textBox_下訂單_訂單內容_藥品名稱.Text = value[(int)enum_下訂單_訂單內容.藥品名稱];
                this.textBox_下訂單_訂單內容_包裝單位.Text = value[(int)enum_下訂單_訂單內容.單位];
                this.textBox_下訂單_訂單內容_供應商全名.Text = value[(int)enum_下訂單_訂單內容.供應商全名];
                this.textBox_下訂單_訂單內容_包裝單位.Text = value[(int)enum_下訂單_訂單內容.包裝單位];
                this.textBox_下訂單_訂單內容_Email.Text = value[(int)enum_下訂單_訂單內容.Email];
                this.textBox_下訂單_訂單內容_聯絡人.Text = value[(int)enum_下訂單_訂單內容.聯絡人];
                this.textBox_下訂單_訂單內容_前次訂購單價.Text = value[(int)enum_下訂單_訂單內容.前次訂購單價];
                this.textBox_下訂單_訂單內容_已訂購總價.Text = value[(int)enum_下訂單_訂單內容.已訂購總價];
                this.textBox_下訂單_訂單內容_電話.Text = value[(int)enum_下訂單_訂單內容.電話];
            }
        }
        int 下訂單_訂單內容_Data_Length = Enum.GetValues(typeof(enum_下訂單_訂單內容)).Length;


        public enum enum_下訂單_訂單單筆品項 : int
        {
            藥品碼,
            藥品名稱,
            訂購數量,
            訂購單價,
            訂購總價,
            前次訂購單價,
        }
        int 下訂單_訂單單筆品項_Data_Length = Enum.GetValues(typeof(enum_下訂單_訂單單筆品項)).Length;
        string[] 下訂單_訂單單筆品項_Data
        {
            get
            {
                string[] _下訂單_訂單單筆品項_Data = new string[下訂單_訂單單筆品項_Data_Length];

                _下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.藥品碼] = this.textBox_下訂單_訂單內容_藥品碼.Text;
                _下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.藥品名稱] = this.textBox_下訂單_訂單內容_藥品名稱.Text;
                _下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.訂購數量] = this.textBox_下訂單_訂單內容_訂購數量.Text;
                _下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.訂購單價] = this.textBox_下訂單_訂單內容_訂購單價.Text;
                _下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.訂購總價] = this.textBox_下訂單_訂單內容_訂購總價.Text;
                _下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.前次訂購單價] = this.textBox_下訂單_訂單內容_前次訂購單價.Text;
                return _下訂單_訂單單筆品項_Data;
            }
            set
            {
                this.textBox_下訂單_訂單內容_藥品碼.Text = value[(int)enum_下訂單_訂單單筆品項.藥品碼];
                this.textBox_下訂單_訂單內容_藥品名稱.Text = value[(int)enum_下訂單_訂單單筆品項.藥品名稱];
                this.textBox_下訂單_訂單內容_訂購數量.Text = value[(int)enum_下訂單_訂單單筆品項.訂購數量];
                this.textBox_下訂單_訂單內容_訂購單價.Text = value[(int)enum_下訂單_訂單單筆品項.訂購單價];
                this.textBox_下訂單_訂單內容_訂購總價.Text = value[(int)enum_下訂單_訂單單筆品項.訂購總價];
                this.textBox_下訂單_訂單內容_前次訂購單價.Text = value[(int)enum_下訂單_訂單單筆品項.前次訂購單價];
            }
        }

        private void Program_下訂單_Init()
        {
            this.sqL_DataGridView_下訂單_藥品資料.Init();
            this.sqL_DataGridView_下訂單_供應商資料.Init();
            this.sqL_DataGridView_下訂單_訂單單筆品項.Init();
      //      this.sqL_DataGridView_下訂單_藥品資料.SQL_GetAllRows(true);

        }
        private void sub_Program_下訂單()
        {
            sub_PLC_Program_下訂單_頁面更新();
            sub_PLC_Program_下訂單_日期更新();
            sub_PLC_Program_下訂單_資料確認();
            sub_PLC_Program_下訂單_鎖定訂單內容();
            sub_PLC_Program_下訂單_解鎖訂單內容();
            sub_PLC_Program_下訂單_填入Email表格();
            sub_PLC_Program_下訂單_清除訂單內容();
            sub_PLC_Program_下訂單_清除Email內容();
            sub_PLC_Program_下訂單_發送Email();
            sub_PLC_Program_下訂單_訂單確認();
            sub_PLC_Program_下訂單_搜尋前次訂購價格();
        }

        #region PLC_Program_下訂單_頁面更新
        PLC_Device PLC_Program_下訂單_頁面更新 = new PLC_Device("Y500");
        void sub_PLC_Program_下訂單_頁面更新()
        {
            if(this.PLC_Program_下訂單_頁面更新.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_下訂單_訂單內容_訂購人.Text = this.Function_登入畫面_取得登入姓名();


                   // this.sqL_DataGridView_下訂單_藥品資料.SQL_GetColumnValues(enum_藥品資料.藥品名稱.GetEnumName(), true, comboBox_下訂單_藥品搜尋_藥品名稱);
                    //this.sqL_DataGridView_下訂單_藥品資料.SQL_GetColumnValues(enum_藥品資料.藥品碼.GetEnumName(), true, comboBox_下訂單_藥品搜尋_藥品碼);

                    //this.sqL_DataGridView_下訂單_供應商資料.SQL_GetColumnValues("序號", true, comboBox_下訂單_供應商搜尋_序號);
                   // this.sqL_DataGridView_下訂單_供應商資料.SQL_GetColumnValues("全名", true, comboBox_下訂單_供應商搜尋_全名);
                    this.sqL_DataGridView_下訂單_供應商資料.SQL_GetColumnValues("類別", true, comboBox_下訂單_供應商搜尋_類別);

                    this.sqL_DataGridView_下訂單_藥品資料.ClearGrid();
                    this.sqL_DataGridView_下訂單_供應商資料.ClearGrid();
                }));
                this.PLC_Program_下訂單_頁面更新.Bool = false;
            }
        }

        #endregion
        #region PLC_Program_下訂單_日期更新
        PLC_Device PLC_Program_下訂單_日期更新 = new PLC_Device("Y502");
        void sub_PLC_Program_下訂單_日期更新()
        {
            if (this.PLC_Program_下訂單_日期更新.Bool)
            {
                this.Invoke(new Action(delegate
                {
                  
                    this.textBox_下訂單_訂單內容_訂購日期.Text = DateTime.Now.AddDays(0).ToShortDateString();
                    this.textBox_下訂單_訂單內容_應驗收日期.Text = DateTime.Now.AddDays(PLC_驗收期限.Value).ToShortDateString();
                }));
                this.PLC_Program_下訂單_日期更新.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_資料確認
        PLC_Device PLC_Program_下訂單_資料確認 = new PLC_Device("S4002");
        PLC_Device PLC_Program_下訂單_資料確認完成 = new PLC_Device("S4001");
        int cnt_PLC_Program_下訂單_資料確認 = 65535;
        
        void sub_PLC_Program_下訂單_資料確認()
        {
            if (cnt_PLC_Program_下訂單_資料確認 == 65535) cnt_PLC_Program_下訂單_資料確認 = 1;
            if (cnt_PLC_Program_下訂單_資料確認 == 1) cnt_PLC_Program_下訂單_資料確認_檢查按下(ref cnt_PLC_Program_下訂單_資料確認);
            if (cnt_PLC_Program_下訂單_資料確認 == 2) cnt_PLC_Program_下訂單_資料確認_初始化(ref cnt_PLC_Program_下訂單_資料確認);
            if (cnt_PLC_Program_下訂單_資料確認 == 3) cnt_PLC_Program_下訂單_資料確認_檢查訂單內容(ref cnt_PLC_Program_下訂單_資料確認);
            if (cnt_PLC_Program_下訂單_資料確認 == 4) cnt_PLC_Program_下訂單_資料確認_檢查訂單_單筆內容(ref cnt_PLC_Program_下訂單_資料確認);
            if (cnt_PLC_Program_下訂單_資料確認 == 5) cnt_PLC_Program_下訂單_資料確認 = 65500;

            if (cnt_PLC_Program_下訂單_資料確認 > 1) cnt_PLC_Program_下訂單_資料確認_檢查放開(ref cnt_PLC_Program_下訂單_資料確認);
            if (cnt_PLC_Program_下訂單_資料確認 == 65500)
            {
                PLC_Program_下訂單_資料確認.Bool = false;
                cnt_PLC_Program_下訂單_資料確認 = 65535;
            }
        }
        void cnt_PLC_Program_下訂單_資料確認_檢查按下(ref int cnt)
        {
            if (PLC_Program_下訂單_資料確認.Bool) cnt++;
        }
        void cnt_PLC_Program_下訂單_資料確認_檢查放開(ref int cnt)
        {
            if (!PLC_Program_下訂單_資料確認.Bool) cnt = 65500;
        }
        void cnt_PLC_Program_下訂單_資料確認_初始化(ref int cnt)
        {
            this.PLC_Program_下訂單_資料確認完成.Bool = false;
            cnt++;
        }
        void cnt_PLC_Program_下訂單_資料確認_檢查訂單內容(ref int cnt)
        {
            bool flag_OK = false;
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            this.PLC_Program_下訂單_資料確認完成.Bool = false;
            this.Invoke(new Action(delegate
            {

                if (this.textBox_下訂單_訂單內容_訂單編號.Text == "")
                {
                    List_error_msg.Add("'訂單編號'欄位空白");
                }
                else
                {
                    if (this.sqL_DataGridView_訂單資料.SQL_IsHaveMember("訂單編號", this.textBox_下訂單_訂單內容_訂單編號.Text))
                    {
                        List_error_msg.Add("'訂單編號'已有相同編號訂單");
                    }
                }

                if (this.textBox_下訂單_訂單內容_訂購人.Text == "")
                {
                    List_error_msg.Add("'訂購人'欄位空白");
                }

                if (this.textBox_下訂單_訂單內容_訂購院所別.Text == "")
                {
                    List_error_msg.Add("'訂購院所別'欄位空白");
                }

                if (this.textBox_下訂單_訂單內容_訂購日期.Text == "")
                {
                    List_error_msg.Add("'訂購日期'欄位空白");
                }

                if (this.textBox_下訂單_訂單內容_應驗收日期.Text == "")
                {
                    List_error_msg.Add("'應驗收日期'欄位空白");
                }

                if (this.textBox_下訂單_訂單內容_Email.Text == "")
                {
                    List_error_msg.Add("'Email'欄位空白");
                }
                if (this.textBox_下訂單_訂單內容_聯絡人.Text == "")
                {
                    List_error_msg.Add("'聯絡人'欄位空白");
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
        void cnt_PLC_Program_下訂單_資料確認_檢查訂單_單筆內容(ref int cnt)
        {
            List<object[]> list_value = this.sqL_DataGridView_下訂單_訂單單筆品項.GetAllRows();
            if (list_value.Count == 0)
            {
                MyMessageBox.ShowDialog("未建立品項!");
                cnt = 65500;
                return;
            }
            else
            {
                PLC_Program_下訂單_資料確認完成.Bool = true;
                cnt++;
                return;
            }
           
        }
        void cnt_PLC_Program_下訂單_資料確認_(ref int cnt)
        {
            cnt++;
        }
        #endregion
        #region PLC_Program_下訂單_鎖定訂單內容
        PLC_Device PLC_Program_下訂單_鎖定訂單內容 = new PLC_Device("S4010");
        void sub_PLC_Program_下訂單_鎖定訂單內容()
        {
            if (this.PLC_Program_下訂單_鎖定訂單內容.Bool)
            {
              
                this.Invoke(new Action(delegate
                {
                    this.groupBox_下訂單_訂單內容.Enabled = false;
                }));
                this.PLC_Program_下訂單_鎖定訂單內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_解鎖訂單內容
        PLC_Device PLC_Program_下訂單_解鎖訂單內容 = new PLC_Device("S4011");
        void sub_PLC_Program_下訂單_解鎖訂單內容()
        {
            if (this.PLC_Program_下訂單_解鎖訂單內容.Bool)
            {

                this.Invoke(new Action(delegate
                {
                    this.groupBox_下訂單_訂單內容.Enabled = true;
                }));
                this.PLC_Program_下訂單_解鎖訂單內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_填入Email表格
        PLC_Device PLC_Program_下訂單_填入Email表格 = new PLC_Device("S4017");
        void sub_PLC_Program_下訂單_填入Email表格()
        {
            if (this.PLC_Program_下訂單_填入Email表格.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    string[] _信箱設定_Code_Data = new string[50];
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂單編號] = this.textBox_下訂單_訂單內容_訂單編號.Text;
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂購人] = this.textBox_下訂單_訂單內容_訂購人.Text;
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂購院所別] = this.textBox_下訂單_訂單內容_訂購院所別.Text;
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂購日期] = this.textBox_下訂單_訂單內容_訂購日期.Text;

                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.應驗收日期] = this.textBox_下訂單_訂單內容_應驗收日期.Text;

                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.供應商全名] = this.textBox_下訂單_訂單內容_供應商全名.Text;
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.包裝單位] = this.textBox_下訂單_訂單內容_包裝單位.Text;
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.Email] = this.textBox_下訂單_訂單內容_Email.Text;
                    _信箱設定_Code_Data[(int)enum_信箱設定_Code.聯絡人] = this.textBox_下訂單_訂單內容_聯絡人.Text;
                    this.信箱設定_Code_Data = _信箱設定_Code_Data;

                    this.myEmail_Send_UI.Clear();

                    this.myEmail_Send_UI.Adress_From = this.myEmail_Send_UI.Sender;
                    this.myEmail_Send_UI.Adress_To = this.textBox_下訂單_訂單內容_Email.Text;
                    this.myEmail_Send_UI_信箱設定_文本.LoadSubject(this.Email_Subject_reference_SavePath);
                    this.myEmail_Send_UI.Subject = this.Function_信箱設定_ReplaceCode(this.myEmail_Send_UI_信箱設定_文本.Subject);
                    this.myEmail_Send_UI.Load_To_RTF(this.Email_Body_reference_SavePath);

                    List<object[]> list_value = this.sqL_DataGridView_下訂單_訂單單筆品項.GetAllRows();
                    string 包裝單位;
                    MyEmail.MyEmail_Send_UI.Table_Rtf Table_Rtf = new MyEmail.MyEmail_Send_UI.Table_Rtf(4, list_value.Count + 1);
                    Table_Rtf.AddRow(new string[] { "藥品碼", "名稱", "數量", "包裝單位" });
                    foreach (object[] value in list_value)
                    {
                        List<object[]> list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), value[(int)enum_下訂單_訂單單筆品項.藥品碼].ObjectToString(), false);
                        if (list_藥品資料.Count > 0)
                        {
                            包裝單位 = list_藥品資料[0][(int)enum_藥品資料.包裝單位].ObjectToString();
                        }
                        else
                        {
                            包裝單位 = "None";
                        }
                        Table_Rtf.AddRow(new string[]
                        { 
                           value[(int)enum_下訂單_訂單單筆品項.藥品碼].ObjectToString(),
                           value[(int)enum_下訂單_訂單單筆品項.藥品名稱].ObjectToString(),
                           value[(int)enum_下訂單_訂單單筆品項.訂購數量].ObjectToString(),
                           包裝單位,
                        });
                   
                    }
                    Table_Rtf.Set_ColunmWidth(0, 1000);
                    Table_Rtf.Set_ColunmWidth(1, 4000);
                    Table_Rtf.Set_ColunmWidth(2, 1000);
                    Table_Rtf.Set_ColunmWidth(3, 1500);
         

                    this.Function_信箱設定_ReplaceCode(this.myEmail_Send_UI, Table_Rtf);
                }));
                this.PLC_Program_下訂單_填入Email表格.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_清除訂單內容
        PLC_Device PLC_Program_下訂單_清除訂單內容 = new PLC_Device("S4019");
        void sub_PLC_Program_下訂單_清除訂單內容()
        {
            if (this.PLC_Program_下訂單_清除訂單內容.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.comboBox_下訂單_供應商搜尋_序號.Text = "";
                    this.comboBox_下訂單_藥品搜尋_藥品碼.Text = "";
                    this.sqL_DataGridView_下訂單_訂單單筆品項.ClearGrid();
                    this.sqL_DataGridView_下訂單_藥品資料.ClearGrid();
                    this.sqL_DataGridView_下訂單_供應商資料.ClearGrid();
                    下訂單_訂單內容_Data = new string[下訂單_訂單內容_Data_Length];
                    this.Function_下訂單_訂單內容_更新日期資訊();
                }));
                this.PLC_Program_下訂單_清除訂單內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_清除Email內容
        PLC_Device PLC_Program_下訂單_清除Email內容 = new PLC_Device("S4020");
        void sub_PLC_Program_下訂單_清除Email內容()
        {
            if (this.PLC_Program_下訂單_清除Email內容.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.myEmail_Send_UI.Clear();
                }));
                this.PLC_Program_下訂單_清除Email內容.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_發送Email
        PLC_Device PLC_Program_下訂單_發送Email = new PLC_Device("S4005");
        PLC_Device PLC_Program_下訂單_發送Email完成 = new PLC_Device("S4004");
        int cnt_sub_PLC_Program_下訂單 = 65535;
        void sub_PLC_Program_下訂單_發送Email()
        {
            if (cnt_sub_PLC_Program_下訂單 == 65535) cnt_sub_PLC_Program_下訂單 = 1;
            if (cnt_sub_PLC_Program_下訂單 == 1) cnt_sub_PLC_Program_下訂單_檢查按鈕按下(ref cnt_sub_PLC_Program_下訂單);
            if (cnt_sub_PLC_Program_下訂單 == 2) cnt_sub_PLC_Program_下訂單_開始發送Email(ref cnt_sub_PLC_Program_下訂單);
            if (cnt_sub_PLC_Program_下訂單 == 3) cnt_sub_PLC_Program_下訂單_等待發送完成_Busy(ref cnt_sub_PLC_Program_下訂單);
            if (cnt_sub_PLC_Program_下訂單 == 4) cnt_sub_PLC_Program_下訂單_等待發送完成(ref cnt_sub_PLC_Program_下訂單);
            if (cnt_sub_PLC_Program_下訂單 == 5) cnt_sub_PLC_Program_下訂單_檢查發送結果(ref cnt_sub_PLC_Program_下訂單);
            if (cnt_sub_PLC_Program_下訂單 == 6) cnt_sub_PLC_Program_下訂單 = 65500;

            if (cnt_sub_PLC_Program_下訂單 > 1) cnt_sub_PLC_Program_下訂單_檢查按鈕放開(ref cnt_sub_PLC_Program_下訂單);
            if (cnt_sub_PLC_Program_下訂單 == 65500)
            {
                this.PLC_Program_下訂單_發送Email.Bool = false;
                cnt_sub_PLC_Program_下訂單 = 65535;
            }
        }
        void cnt_sub_PLC_Program_下訂單_檢查按鈕按下(ref int cnt)
        {
            if (this.PLC_Program_下訂單_發送Email.Bool)
            {
                this.PLC_Program_下訂單_發送Email完成.Bool = false;
                cnt++;
            }
        }
        void cnt_sub_PLC_Program_下訂單_檢查按鈕放開(ref int cnt)
        {
            if (!this.PLC_Program_下訂單_發送Email.Bool) cnt = 65500;
        }
        void cnt_sub_PLC_Program_下訂單_開始發送Email(ref int cnt)
        {
            if (this.myEmail_Send_UI.Get_Send_Ready())
            {
                this.myEmail_Send_UI.Send_Email();
                cnt++;
            }
        }
        void cnt_sub_PLC_Program_下訂單_等待發送完成_Busy(ref int cnt)
        {
            if (!this.myEmail_Send_UI.Get_Send_Ready())
            {
                cnt++;
            }
        }
        void cnt_sub_PLC_Program_下訂單_等待發送完成(ref int cnt)
        {
            if (this.myEmail_Send_UI.Get_Send_Ready())
            {
                cnt++;
            }
        }
        void cnt_sub_PLC_Program_下訂單_檢查發送結果(ref int cnt)
        {
            if (this.myEmail_Send_UI.Get_Send_Error())
            {
                MyMessageBox.ShowDialog("發送失敗!");
                this.PLC_Program_下訂單_發送Email完成.Bool = false;
                cnt++;
            }
            else
            {
                MyMessageBox.ShowDialog("發送完成!");
                this.PLC_Program_下訂單_發送Email完成.Bool = true;
                cnt++;
            }
        }
        void cnt_sub_PLC_Program_下訂單_(ref int cnt)
        {
            cnt++;
        }
        #endregion
        #region PLC_Program_下訂單_訂單確認
        PLC_Device PLC_Program_下訂單_訂單確認 = new PLC_Device("S4008");
        PLC_Device PLC_Program_下訂單_訂單確認完成 = new PLC_Device("S4007");
        void sub_PLC_Program_下訂單_訂單確認()
        {
            if (this.PLC_Program_下訂單_訂單確認.Bool)
            {
                string[] _SQL_訂單資料_Data = new string[訂單資料_Data_Length];
                
                _SQL_訂單資料_Data[(int)enum_訂單資料.訂單編號] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂單編號];
                _SQL_訂單資料_Data[(int)enum_訂單資料.訂購人] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購人];
                _SQL_訂單資料_Data[(int)enum_訂單資料.訂購院所別] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購院所別];
                _SQL_訂單資料_Data[(int)enum_訂單資料.訂購日期] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.訂購日期];
                _SQL_訂單資料_Data[(int)enum_訂單資料.訂購時間] = sqL_DataGridView_訂單資料.GetTimeNow(SQLUI.Table.DateType.TIMESTAMP);    
                _SQL_訂單資料_Data[(int)enum_訂單資料.應驗收日期] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.應驗收日期];
                _SQL_訂單資料_Data[(int)enum_訂單資料.單位] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.單位];
                _SQL_訂單資料_Data[(int)enum_訂單資料.供應商全名] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.供應商全名];
                _SQL_訂單資料_Data[(int)enum_訂單資料.包裝單位] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.包裝單位];
                _SQL_訂單資料_Data[(int)enum_訂單資料.供應商電話] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.電話];
                _SQL_訂單資料_Data[(int)enum_訂單資料.供應商聯絡人] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.聯絡人];
                _SQL_訂單資料_Data[(int)enum_訂單資料.供應商Email] = this.下訂單_訂單內容_Data[(int)enum_下訂單_訂單內容.Email];
                _SQL_訂單資料_Data[(int)enum_訂單資料.已入庫數量] = (0).ToString();
                _SQL_訂單資料_Data[(int)enum_訂單資料.確認驗收] = "False";

                List<object[]> list_value = this.sqL_DataGridView_下訂單_訂單單筆品項.GetAllRows();

                for (int i = 0; i < list_value.Count; i++)
                {
                    _SQL_訂單資料_Data[(int)enum_訂單資料.序號] = i.ToString();
                    _SQL_訂單資料_Data[(int)enum_訂單資料.藥品碼] = list_value[i][(int)enum_下訂單_訂單單筆品項.藥品碼].ObjectToString();
                    _SQL_訂單資料_Data[(int)enum_訂單資料.藥品名稱] = list_value[i][(int)enum_下訂單_訂單單筆品項.藥品名稱].ObjectToString();
                    _SQL_訂單資料_Data[(int)enum_訂單資料.訂購數量] = list_value[i][(int)enum_下訂單_訂單單筆品項.訂購數量].ObjectToString();
                    _SQL_訂單資料_Data[(int)enum_訂單資料.訂購單價] = list_value[i][(int)enum_下訂單_訂單單筆品項.訂購單價].ObjectToString();
                    _SQL_訂單資料_Data[(int)enum_訂單資料.訂購總價] = list_value[i][(int)enum_下訂單_訂單單筆品項.訂購總價].ObjectToString();
                    _SQL_訂單資料_Data[(int)enum_訂單資料.前次訂購單價] = list_value[i][(int)enum_下訂單_訂單單筆品項.前次訂購單價].ObjectToString();
                    this.sqL_DataGridView_訂單資料.SQL_AddRow(_SQL_訂單資料_Data, true);
              
                }
     
        

                this.PLC_Program_下訂單_訂單確認完成.Bool = true;
                this.PLC_Program_下訂單_清除Email內容.Bool = true;
                this.PLC_Program_下訂單_清除訂單內容.Bool = true;

                MyMessageBox.ShowDialog("訂單輸入完成!");

                this.PLC_Program_下訂單_訂單確認.Bool = false;
            }
        }
        #endregion
        #region PLC_Program_下訂單_搜尋前次訂購價格
        PLC_Device PLC_Program_下訂單_搜尋前次訂購價格開始 = new PLC_Device("S4015");
        void sub_PLC_Program_下訂單_搜尋前次訂購價格()
        {
            if (this.PLC_Program_下訂單_搜尋前次訂購價格開始.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_下訂單_訂單內容_前次訂購單價.Text = "";
                    List<object[]> list_value = this.sqL_DataGridView_訂單資料.SQL_GetRows(enum_訂單資料.藥品碼.GetEnumName(), this.下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.藥品碼], enum_訂單資料.訂購時間.GetEnumName(), SQLUI.SQLControl.OrderType.UpToLow, false);
                    if(list_value.Count >0)
                    {
                        this.textBox_下訂單_訂單內容_前次訂購單價.Text = list_value[0][(int)enum_訂單資料.訂購單價].ObjectToString();
                    }
                }));
     
                this.PLC_Program_下訂單_搜尋前次訂購價格開始.Bool = false;
            }
        }
        #endregion

        #region Function
        private void Function_下訂單_訂單內容_更新日期資訊()
        {
            string[] 下訂單_訂單內容_Data_buf = this.下訂單_訂單內容_Data;
            下訂單_訂單內容_Data_buf[(int)enum_下訂單_訂單內容.訂購日期] = DateTime.Now.ToShortDateString();
            下訂單_訂單內容_Data_buf[(int)enum_下訂單_訂單內容.應驗收日期] = DateTime.Now.AddDays(10).ToShortDateString();
            this.下訂單_訂單內容_Data = 下訂單_訂單內容_Data_buf;
        }
        #endregion
        #region Event

        private void plC_Button_下訂單_藥品搜尋_藥品碼_btnClick(object sender, EventArgs e)
        {
            this.sqL_DataGridView_下訂單_藥品資料.SQL_GetRows(enum_藥品資料.藥品碼.GetEnumName(), comboBox_下訂單_藥品搜尋_藥品碼.Text, true);
        }
        private void plC_Button_下訂單_藥品搜尋_藥品名稱_btnClick(object sender, EventArgs e)
        {
            this.sqL_DataGridView_下訂單_藥品資料.SQL_GetRowsByLike(enum_藥品資料.藥品名稱.GetEnumName(), comboBox_下訂單_藥品搜尋_藥品名稱.Text, true);
        }
        private void plC_Button_下訂單_藥品搜尋_藥品條碼_btnClick(object sender, EventArgs e)
        {
            if (textBox_下訂單_藥品搜尋_藥品條碼.Text != "")
            {
                this.sqL_DataGridView_下訂單_藥品資料.SQL_GetRows(enum_藥品資料.藥品條碼.GetEnumName(), textBox_下訂單_藥品搜尋_藥品條碼.Text, true);
            }  
        }
        private void textBox_下訂單_藥品搜尋_藥品條碼_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox_下訂單_藥品搜尋_藥品條碼.Text != "")
                {
                    this.sqL_DataGridView_下訂單_藥品資料.SQL_GetRows(enum_藥品資料.藥品條碼.GetEnumName(), textBox_下訂單_藥品搜尋_藥品條碼.Text, true);
                }  
            }
        }
   
        private void plC_Button_下訂單_供應商搜尋_序號_btnClick(object sender, EventArgs e)
        {
            this.sqL_DataGridView_下訂單_供應商資料.SQL_GetRows(enum_供應商資料.序號.GetEnumName(), comboBox_下訂單_供應商搜尋_序號.Text, true);
        }
        private void plC_Button_下訂單_供應商搜尋_類別_btnClick(object sender, EventArgs e)
        {
            this.sqL_DataGridView_下訂單_供應商資料.SQL_GetRows(enum_供應商資料.類別.GetEnumName(), comboBox_下訂單_供應商搜尋_類別.Text, true);
        }
        private void plC_Button_下訂單_供應商搜尋_全名_btnClick(object sender, EventArgs e)
        {
            this.sqL_DataGridView_下訂單_供應商資料.SQL_GetRows(enum_供應商資料.全名.GetEnumName(), comboBox_下訂單_供應商搜尋_全名.Text, true);
        }
        private void plC_Button_下訂單_藥品搜尋_填入訂單_btnClick(object sender, EventArgs e)
        {
            object[] obj =  this.sqL_DataGridView_下訂單_藥品資料.GetRowValues();
            if(obj != null)
            {
                string 藥品碼 = obj[(int)enum_藥品資料.藥品碼].ObjectToString();
                string 藥品名稱 = obj[(int)enum_藥品資料.藥品名稱].ObjectToString();
                string 包裝單位 = obj[(int)enum_藥品資料.包裝單位].ObjectToString();
                string 已訂購總價 = obj[(int)enum_藥品資料.已訂購總價].ObjectToString();
                this.textBox_下訂單_訂單內容_藥品碼.Text = 藥品碼;
                this.textBox_下訂單_訂單內容_藥品名稱.Text = 藥品名稱;
                this.textBox_下訂單_訂單內容_包裝單位.Text = 包裝單位;
                this.textBox_下訂單_訂單內容_已訂購總價.Text = 已訂購總價;

                PLC_Program_下訂單_搜尋前次訂購價格開始.Bool = true;
            }
            else
            {
                MyMessageBox.ShowDialog("藥品資料未選取!");
            }
          
        }
        private void plC_Button_下訂單_供應商搜尋_填入訂單_btnClick(object sender, EventArgs e)
        {
            object[] obj = this.sqL_DataGridView_下訂單_供應商資料.GetRowValues();
            if (obj != null)
            {
                string 全名 = obj[(int)enum_供應商資料.全名].ObjectToString();
                string Email = obj[(int)enum_供應商資料.Email].ObjectToString();
                string 聯絡人 = obj[(int)enum_供應商資料.聯絡人].ObjectToString();
                string 電話 = obj[(int)enum_供應商資料.電話].ObjectToString();
                this.textBox_下訂單_訂單內容_Email.Text = Email;
                this.textBox_下訂單_訂單內容_供應商全名.Text = 全名;
                this.textBox_下訂單_訂單內容_聯絡人.Text = 聯絡人;
                this.textBox_下訂單_訂單內容_電話.Text = 電話;
            }
            else
            {
                MyMessageBox.ShowDialog("供應商資料未選取!");
            }
          
        }

        private void plC_Button_下訂單_訂單內容_新增品項_btnClick(object sender, EventArgs e)
        {
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            this.Invoke(new Action(delegate
            {
                int 訂購數量_temp = 0;
                int 訂購單價_temp = 0;
                if (this.textBox_下訂單_訂單內容_訂購數量.Text == "")
                {
                    List_error_msg.Add("'訂購數量'欄位空白");
                }

                else
                {

                    if (!int.TryParse(this.textBox_下訂單_訂單內容_訂購數量.Text, out 訂購數量_temp))
                    {
                        List_error_msg.Add("'訂購數量'為非法字元");
                    }
                }

                this.textBox_下訂單_訂單內容_訂購單價.Text = "0";
                if (this.textBox_下訂單_訂單內容_訂購單價.Text == "")
                {
                    List_error_msg.Add("'訂購單價'欄位空白");
                }
                else
                {

                    if (!int.TryParse(this.textBox_下訂單_訂單內容_訂購單價.Text, out 訂購單價_temp))
                    {
                        List_error_msg.Add("'訂購單價'為非法字元");
                    }
                }
                if (this.textBox_下訂單_訂單內容_藥品碼.Text == "")
                {
                    List_error_msg.Add("'藥品碼'欄位空白");
                }

                if (this.textBox_下訂單_訂單內容_藥品名稱.Text == "")
                {
                    List_error_msg.Add("'藥品名稱'欄位空白");
                }
                for (int i = 0; i < List_error_msg.Count; i++)
                {
                    str_error_msg += i.ToString("00") + ". " + List_error_msg[i] + "\n\r";
                }
                if (str_error_msg == "")
                {
                    this.textBox_下訂單_訂單內容_訂購總價.Text = (訂購數量_temp * 訂購單價_temp).ToString();

                    if (this.sqL_DataGridView_下訂單_訂單單筆品項.GetRows(enum_下訂單_訂單單筆品項.藥品碼.GetEnumName(), this.下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.藥品碼], false).Count > 0)
                    {
                        this.sqL_DataGridView_下訂單_訂單單筆品項.Replace(enum_下訂單_訂單單筆品項.藥品碼.GetEnumName(), this.下訂單_訂單單筆品項_Data[(int)enum_下訂單_訂單單筆品項.藥品碼], this.下訂單_訂單單筆品項_Data, true);
                    }
                    else
                    {
                        this.sqL_DataGridView_下訂單_訂單單筆品項.AddRow(this.下訂單_訂單單筆品項_Data, true);
                    }
           
                    this.下訂單_訂單單筆品項_Data = new string[this.下訂單_訂單單筆品項_Data.Length];
                    this.textBox_下訂單_訂單內容_已訂購總價.Text = "";
                }
                else MyMessageBox.ShowDialog(str_error_msg);
            }));
        }
        private void plC_Button_下訂單_訂單內容_移除品項_btnClick(object sender, EventArgs e)
        {
            
            DialogResult Result = MyMessageBox.ShowDialog("是否刪除選取欄位資料?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                object[] obj_temp = this.sqL_DataGridView_下訂單_訂單單筆品項.GetRowValues();
                if (obj_temp != null)
                {
                    this.sqL_DataGridView_下訂單_訂單單筆品項.Delete(enum_下訂單_訂單單筆品項.藥品碼.GetEnumName(), obj_temp[(int)enum_下訂單_訂單單筆品項.藥品碼].ObjectToString(), true);
                }

            }
        }
        private void plC_Button_下訂單_訂單內容_取消作業_btnClick(object sender, EventArgs e)
        {
            DialogResult Result = MyMessageBox.ShowDialog("是否清除所有內容?", MyMessageBox.enum_BoxType.Warning , MyMessageBox.enum_Button.Confirm_Cancel);
            if (Result == DialogResult.Yes)
            {
                this.PLC_Program_下訂單_清除訂單內容.Bool = true;
                this.PLC_Program_下訂單_清除Email內容.Bool = true;
            }
        }
        private void textBox_下訂單_訂單內容_訂購單價_TextChanged(object sender, EventArgs e)
        {
            int 訂購數量_temp = 0;
            int 訂購單價_temp = 0;
            if (int.TryParse(textBox_下訂單_訂單內容_訂購單價.Text, out 訂購單價_temp))
            {
                if (int.TryParse(textBox_下訂單_訂單內容_訂購數量.Text, out 訂購數量_temp))
                {
                    this.textBox_下訂單_訂單內容_訂購總價.Text = (訂購單價_temp * 訂購數量_temp).ToString();
                }
            }
        }
        private void textBox_下訂單_訂單內容_訂購數量_TextChanged(object sender, EventArgs e)
        {
            int 訂購數量_temp = 0;
            int 訂購單價_temp = 0;
            if (int.TryParse(textBox_下訂單_訂單內容_訂購單價.Text, out 訂購單價_temp))
            {
                if (int.TryParse(textBox_下訂單_訂單內容_訂購數量.Text, out 訂購數量_temp))
                {
                    this.textBox_下訂單_訂單內容_訂購總價.Text = (訂購單價_temp * 訂購數量_temp).ToString();
                }
            }
        }
        private void button_下訂單_訂單編號_自動生成_Click(object sender, EventArgs e)
        {
            this.textBox_下訂單_訂單內容_訂單編號.Text = "OD" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
        }
        #endregion
    }
}
