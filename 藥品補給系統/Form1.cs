using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUI;
using Basic;
using SQLUI;
using System.Diagnostics;//記得取用 FileVersionInfo繼承
using System.Reflection;//記得取用 Assembly繼承

[assembly: AssemblyVersion("1.0.164")]
[assembly: AssemblyFileVersion("1.0.164")]
namespace 藥品補給系統
{
    public partial class Form1 : Form
    {
        private string FormText = "";
        private LadderConnection.LowerMachine PLC;
        MyTimer MyTimer_TickTime = new MyTimer();
        private Stopwatch stopwatch = new Stopwatch();
        Basic.MyConvert myConvert = new Basic.MyConvert();
        #region DBConfigClass
        private const string DBConfigFileName = "DBConfig.txt";
        public DBConfigClass dBConfigClass = new DBConfigClass();
        public class DBConfigClass
        {
            private SQL_DataGridView.ConnentionClass dB_Basic = new SQL_DataGridView.ConnentionClass();
            private SQL_DataGridView.ConnentionClass dB_person_page = new SQL_DataGridView.ConnentionClass();


            public SQL_DataGridView.ConnentionClass DB_Basic { get => dB_Basic; set => dB_Basic = value; }
            public SQL_DataGridView.ConnentionClass DB_person_page { get => dB_person_page; set => dB_person_page = value; }
        }
        private void LoadDBConfig()
        {
            string jsonstr = MyFileStream.LoadFileAllText($".//{DBConfigFileName}");
            if (jsonstr.StringIsEmpty())
            {

                jsonstr = Basic.Net.JsonSerializationt<DBConfigClass>(new DBConfigClass());
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{DBConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{DBConfigFileName}檔案失敗!");
                }
                MyMessageBox.ShowDialog($"未建立參數文件!請至子目錄設定{DBConfigFileName}");
                Application.Exit();
            }
            else
            {
                dBConfigClass = Basic.Net.JsonDeserializet<DBConfigClass>(jsonstr);

                jsonstr = Basic.Net.JsonSerializationt<DBConfigClass>(dBConfigClass);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{DBConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{DBConfigFileName}檔案失敗!");
                }

            }
        }
        #endregion
        #region MyConfigClass
        private const string MyConfigFileName = "MyConfig.txt";
        public MyConfigClass myConfigClass = new MyConfigClass();
        public class MyConfigClass
        {


        }
        private void LoadMyConfig()
        {
            string jsonstr = MyFileStream.LoadFileAllText($".//{MyConfigFileName}");
            if (jsonstr.StringIsEmpty())
            {
                jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(new MyConfigClass());
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{MyConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
                }
                MyMessageBox.ShowDialog($"未建立參數文件!請至子目錄設定{MyConfigFileName}");
                Application.Exit();
            }
            else
            {
                myConfigClass = Basic.Net.JsonDeserializet<MyConfigClass>(jsonstr);

                jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(myConfigClass);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{MyConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
                }

            }

        }
        #endregion
        #region FtpConfigClass
        private const string FtpConfigFileName = "FtpConfig.txt";
        public FtpConfigClass ftpConfigClass = new FtpConfigClass();
        public class FtpConfigClass
        {
            private string fTP_Server = "";
            private string fTP_username = "";
            private string fTP_password = "";

            public string FTP_Server { get => fTP_Server; set => fTP_Server = value; }
            public string FTP_username { get => fTP_username; set => fTP_username = value; }
            public string FTP_password { get => fTP_password; set => fTP_password = value; }
        }
        private void LoadFtpConfig()
        {
            string jsonstr = MyFileStream.LoadFileAllText($".//{FtpConfigFileName}");
            if (jsonstr.StringIsEmpty())
            {
                jsonstr = Basic.Net.JsonSerializationt<FtpConfigClass>(new FtpConfigClass(), true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{FtpConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{FtpConfigFileName}檔案失敗!");
                }
                MyMessageBox.ShowDialog($"未建立參數文件!請至子目錄設定{FtpConfigFileName}");
                Application.Exit();
            }
            else
            {
                ftpConfigClass = Basic.Net.JsonDeserializet<FtpConfigClass>(jsonstr);

                jsonstr = Basic.Net.JsonSerializationt<FtpConfigClass>(ftpConfigClass, true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($".//{FtpConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{FtpConfigFileName}檔案失敗!");
                }

            }

            this.ftp_DounloadUI.FTP_Server = ftpConfigClass.FTP_Server;
            this.ftp_DounloadUI.Username = ftpConfigClass.FTP_username;
            this.ftp_DounloadUI.Password = ftpConfigClass.FTP_password;
            string updateVersion = this.ftp_DounloadUI.GetFileVersion();
            if (this.ftp_DounloadUI.CheckUpdate(this.ProductVersion, updateVersion))
            {
                if (Basic.MyMessageBox.ShowDialog(string.Format("有新版本是否更新? (Ver : {0})", updateVersion), "Update", Basic.MyMessageBox.enum_BoxType.Asterisk, Basic.MyMessageBox.enum_Button.Confirm_Cancel) == DialogResult.Yes)
                {
                    this.Invoke(new Action(delegate { this.Update(); }));
                }
            }
        }
        #endregion

        bool Form_Focuse = false;
        Basic.Keyboard keyboard = new Basic.Keyboard();
        Basic.Mouse mouse = new Basic.Mouse();

        private readonly string DataBaseName = "Order_000";
        private readonly string UserName = "user";
        private readonly string Password = "66437068";
        private string IP = "10.17.9.10";
        private readonly uint Port = 3306;
        //"10.18.1.146";
        PLC_Device PLC_現在頁面 = new PLC_Device("D0");
        PLC_Device PLC_按下滑鼠左鍵 = new PLC_Device("S4065");

        private string _訂購院所別 = "";
        private string 訂購院所別
        {
            get
            {
                return this.textBox_下訂單_訂單內容_訂購院所別.Text;
            }
            set
            {
                this.Invoke(new Action(delegate 
                {
                    this.textBox_下訂單_訂單內容_訂購院所別.Text = value;
                    _訂購院所別 = value;
                }));
      
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadDBConfig();
            //LoadMyConfig();
            MyMessageBox.form = this.FindForm();
            LoadFtpConfig();


            dBConfigClass.DB_person_page.IP = "10.18.1.146";
            dBConfigClass.DB_person_page.DataBaseName = DataBaseName;
            dBConfigClass.DB_person_page.UserName = UserName;
            dBConfigClass.DB_person_page.Password = Password;
            dBConfigClass.DB_person_page.Port = Port;


            Dialog_院區選擇.form = this.FindForm();
            Dialog_院區選擇 dialog_院區選擇 = new Dialog_院區選擇();
            if (dialog_院區選擇.ShowDialog() != DialogResult.Yes)
            {
                Application.Exit();
                return;
            }
            if (dialog_院區選擇.Value == Dialog_院區選擇.enum_院區種類.龍泉院區)
            {
                IP = "10.17.9.10";
                this.訂購院所別 = "屏東榮民總醫院龍泉分院";
            }
            if (dialog_院區選擇.Value == Dialog_院區選擇.enum_院區種類.大武院區)
            {
                IP = "10.18.1.146";
                this.訂購院所別 = "屏東榮民總醫院";
            }
            MyMessageBox.音效 = false;
            this.Text =$"{this.Text} Ver {this.ProductVersion} [{this.訂購院所別}]";

            SQLUI.SQL_DataGridView.SQL_Set_Properties(UserName, Password, IP, Port, this.FindForm());

            //this.TopMost = true;
        

            string ProcessName = "WINWORD";//換成想要結束的進程名字
            System.Diagnostics.Process[] MyProcess = System.Diagnostics.Process.GetProcessesByName(ProcessName);
            for (int i = 0; i < MyProcess.Length; i++)
            {
                MyProcess[i].Kill();
            }

            this.plC_UI_Init.Run(this.FindForm(), this.lowerMachine_Panel);
            this.mouse.MouseEvent += new MouseEventHandler(Mouse_MouseEvent);
        }
        private void Mouse_MouseEvent(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && this.plC_UI_Init.Init_Finish && this.Form_Focuse)
            //{
            //    PLC_按下滑鼠左鍵.Bool = true;
            //}
        }
        private void Timer_Init_Tick(object sender, EventArgs e)
        {
            if (this.plC_UI_Init.Init_Finish)
            {
               

                this.PLC_按下滑鼠左鍵.SetComment("PLC_按下滑鼠左鍵");

                this.WindowState = FormWindowState.Maximized;

                this.Program_下訂單_Init();
                this.Program_訂單資料_Init();
                this.Program_供應商資料_Init();
                this.Program_藥品資料_Init();
                this.Program_信箱設定_Init();
                this.Program_驗收訂單_Init();
                this.Program_發票資料_Init();
                this.Program_入庫資料匯出_Init();
                this.Program_訂單管理_Init();
                this.Program_人員資料_Init();
                this.Program_登入畫面_Init();
                this.Program_登入權限資料_Init();
                this.Program_參數資料_Init();
                this.plC_UI_Init.Add_Method(this.sub_Prgram_MainForm);

                this.plC_UI_Init.Add_Method(this.sub_Program_下訂單);
                this.plC_UI_Init.Add_Method(this.sub_Program_驗收訂單);
                this.plC_UI_Init.Add_Method(this.sub_Program_信箱設定);
                this.plC_UI_Init.Add_Method(this.sub_Program_訂單資料);
                this.plC_UI_Init.Add_Method(this.sub_Program_入庫資料匯出);
                this.plC_UI_Init.Add_Method(this.sub_Program_供應商資料);
                this.plC_UI_Init.Add_Method(this.sub_Program_藥品資料);
                this.plC_UI_Init.Add_Method(this.sub_Program_訂單管理);
                this.plC_UI_Init.Add_Method(this.sub_Program_人員資料);
                this.plC_UI_Init.Add_Method(this.sub_Program_登入畫面);
                this.plC_UI_Init.Add_Method(this.sub_Program_登入權限資料);
                this.plC_UI_Init.Add_Method(this.sub_Program_參數資料);

                //this.licenseUI1.Init();

                this.timer_Init.Enabled = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (keyboard.MouseDown)
            {
                keyboard.MouseDown = false;
            }
        }

        private void plC_Button_系統更新_btnClick(object sender, EventArgs e)
        {
            this.Update();
            
        }
        private void button_匯入已入庫異動資料_Click(object sender, EventArgs e)
        {
            if (openFileDialog_LoadExcel.ShowDialog(this) == DialogResult.OK)
            {
                int count = 0;
                DataTable datatable_buf = new DataTable();
                DataTable datatable = new DataTable();
                datatable = MyOffice.ExcelClass.LoadFile(openFileDialog_LoadExcel.FileName);

                if (datatable.Columns.Count != enum_入庫資料匯出_中榮表單_Lenth)
                {
                    MyMessageBox.ShowDialog("匯入資料格式錯誤!");
                    return;
                }
                string[] ColumnsName = new string[] {enum_發票資料.訂購日期.GetEnumName(), enum_發票資料.藥品碼.GetEnumName(), enum_發票資料.數量.GetEnumName()};
                string[] ColumnValue;
                string Date;
                string Year;
                string Month;
                string Day;
                List<object[]> list_value;
                foreach (System.Data.DataRow dr in datatable.Rows)
                {
                    string[] str_來源資料 = new string[dr.ItemArray.Length];
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        str_來源資料[i] = dr.ItemArray[i].ObjectToString();
                    }
                    Date = str_來源資料[(int)enum_入庫資料匯出_中榮表單.訂購日期];
                    Year = (Date.Substring(0, 3).StringToInt32() + 1911).ToString("0000");
                    Month = Date.Substring(3, 2);
                    Day = Date.Substring(5, 2);
                    Date = string.Format("{0}-{1}-{2}", Year, Month, Day);
                    ColumnValue = new string[] { Date, str_來源資料[(int)enum_入庫資料匯出_中榮表單.新藥碼], str_來源資料[(int)enum_入庫資料匯出_中榮表單.入庫數量] };
                    list_value = this.sqL_DataGridView_發票資料.SQL_GetRows(ColumnsName, ColumnValue, false);
                    if (list_value.Count > 0 )
                    {
                        for (int i = 0; i < list_value.Count; i++)
                        {
                            list_value[i][(int)enum_發票資料.中榮匯出] = true.ToString();
                            this.sqL_DataGridView_發票資料.SQL_Replace(ColumnsName, ColumnValue, list_value[i], false);
                            count++;
                        }
                      
                    }
                }
                MyMessageBox.ShowDialog(string.Format("修正完成,共{0}筆資料!", count.ToString()));
            }
        }
        private void button_檢查發票重覆資料_Click(object sender, EventArgs e)
        {
            int count = 0;
            List<object[]> list_value_replace = new List<object[]>();
            List<object[]> list_value = this.sqL_DataGridView_發票資料.SQL_GetAllRows(true);
            string[] colnames = new string[] {enum_發票資料.發票號碼.GetEnumName(), enum_發票資料.藥品碼.GetEnumName(), enum_發票資料.數量.GetEnumName() };
            object[] colvalues;
            foreach (object[] value in list_value)
            {
                colvalues = new object[] { value[(int)enum_發票資料.發票號碼], value[(int)enum_發票資料.藥品碼], value[(int)enum_發票資料.數量] };
                if (this.sqL_DataGridView_發票資料.GetRows(colnames, colvalues, false).Count >= 2)
                {
                    this.sqL_DataGridView_發票資料.Delete(colnames, colvalues, false);
                    this.sqL_DataGridView_發票資料.AddRow(value, false);
                    list_value_replace.Add(value);
                }
            }

            foreach (object[] value in list_value_replace)
            {
                colvalues = new object[] { value[(int)enum_發票資料.發票號碼], value[(int)enum_發票資料.藥品碼], value[(int)enum_發票資料.數量] };
                this.sqL_DataGridView_發票資料.SQL_Delete(colnames, colvalues, false);
                this.sqL_DataGridView_發票資料.SQL_AddRow(value, false);
               
            }
            MyMessageBox.ShowDialog(string.Format("修正完成,共{0}筆資料!", list_value_replace.Count.ToString()));
        }
        private void button_重新修正已訂購總價_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.ShowDialog("是否重新計算'已訂購總價?'", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel) != DialogResult.Yes) return;
            List<object[]> list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(false);
            string Serchcolname = "藥品碼";
            List<string> Serchvalue = new List<string>();

            List<object[]> list_藥品資料_buf = new List<object[]>();
            List<object[]> list_訂單資料 = this.sqL_DataGridView_訂單資料.SQL_GetAllRows(false);
            for (int i = 0; i < list_藥品資料.Count; i++)
            {
                list_藥品資料[i][(int)enum_藥品資料.已訂購總價] = "0";
                list_藥品資料[i][(int)enum_藥品資料.已訂購數量] = "0";
                Serchvalue.Add(list_藥品資料[i][(int)enum_藥品資料.藥品碼].ObjectToString());
            }
            for(int i = 0; i < list_訂單資料.Count; i++)
            {
                string 藥品碼 = list_訂單資料[i][(int)enum_訂單資料.藥品碼].ObjectToString();
                list_藥品資料_buf = list_藥品資料.GetRows((int)enum_藥品資料.藥品碼, 藥品碼);
                if(list_藥品資料_buf.Count > 0)
                {
                    int 已訂購數量 = list_藥品資料_buf[0][(int)enum_藥品資料.已訂購數量].StringToInt32();
                    已訂購數量 = 已訂購數量 + list_訂單資料[i][(int)enum_訂單資料.訂購數量].StringToInt32();
                    list_藥品資料_buf[0][(int)enum_藥品資料.已訂購數量] = 已訂購數量.ToString();

                    double 已訂購總價 = list_藥品資料_buf[0][(int)enum_藥品資料.已訂購總價].StringToDouble();
                    double 訂購總價 = list_訂單資料[i][(int)enum_訂單資料.訂購總價].StringToDouble();
                    if (訂購總價 > 0)
                    {
                        已訂購總價 = 已訂購總價 + 訂購總價;
                        list_藥品資料_buf[0][(int)enum_藥品資料.已訂購總價] = 已訂購總價.ToString("0.000");
                    }
               
                }
            }
            this.sqL_DataGridView_藥品資料.SQL_ReplaceExtra(Serchcolname, Serchvalue, list_藥品資料, false);
            MyMessageBox.ShowDialog("更新完成!");
        }
        private void button_重新修正已採購總價_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.ShowDialog("是否重新計算'已採購總價?'", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel) != DialogResult.Yes) return;
            List<object[]> list_藥品資料 = this.sqL_DataGridView_藥品資料.SQL_GetAllRows(false);
            string Serchcolname = "藥品碼";
            List<string> Serchvalue = new List<string>();

            List<object[]> list_藥品資料_buf = new List<object[]>();
            List<object[]> list_發票資料 = this.sqL_DataGridView_發票資料.SQL_GetAllRows(false);
            for (int i = 0; i < list_藥品資料.Count; i++)
            {
                list_藥品資料[i][(int)enum_藥品資料.已採購總價] = "0";
                list_藥品資料[i][(int)enum_藥品資料.已採購總量] = "0";
                Serchvalue.Add(list_藥品資料[i][(int)enum_藥品資料.藥品碼].ObjectToString());
            }
            for (int i = 0; i < list_發票資料.Count; i++)
            {
                string 藥品碼 = list_發票資料[i][(int)enum_發票資料.藥品碼].ObjectToString();
                list_藥品資料_buf = list_藥品資料.GetRows((int)enum_藥品資料.藥品碼, 藥品碼);
                if (list_藥品資料_buf.Count > 0)
                {
                    int 已採購數量 = list_藥品資料_buf[0][(int)enum_藥品資料.已採購總量].StringToInt32();
                    已採購數量 = 已採購數量 + list_發票資料[i][(int)enum_發票資料.數量].StringToInt32();
                    list_藥品資料_buf[0][(int)enum_藥品資料.已採購總量] = 已採購數量.ToString();

                    double 已採購總價 = list_藥品資料_buf[0][(int)enum_藥品資料.已採購總價].StringToDouble();
                    double 總價 = list_發票資料[i][(int)enum_發票資料.總價].StringToDouble();
                    if (總價 > 0)
                    {
                        已採購總價 = 已採購總價 + 總價;
                        list_藥品資料_buf[0][(int)enum_藥品資料.已採購總價] = 已採購總價.ToString("0.000");
                    }

                }
            }
            this.sqL_DataGridView_藥品資料.SQL_ReplaceExtra(Serchcolname, Serchvalue, list_藥品資料, false);
            MyMessageBox.ShowDialog("更新完成!");
        }
        #region Method
        PLC_Device PLC_Device_Method = new PLC_Device("");
        int cnt_Program_Method = 65534;
        void sub_Program_Method()
        {
            if (cnt_Program_Method == 65534)
            {
                PLC_Device_Method.SetComment("PLC_Method");
                PLC_Device_Method.Bool = false;
                cnt_Program_Method = 65535;
            }
            if (cnt_Program_Method == 65535) cnt_Program_Method = 1;
            if (cnt_Program_Method == 1) cnt_Program_Method_檢查按下(ref cnt_Program_Method);
            if (cnt_Program_Method == 2) cnt_Program_Method_初始化(ref cnt_Program_Method);
            if (cnt_Program_Method == 3) cnt_Program_Method = 65500;
            if (cnt_Program_Method > 1) cnt_Program_Method_檢查放開(ref cnt_Program_Method);

            if (cnt_Program_Method == 65500)
            {
                PLC_Device_Method.Bool = false;
                cnt_Program_Method = 65535;
            }
        }
        void cnt_Program_Method_檢查按下(ref int cnt)
        {
            if (PLC_Device_Method.Bool) cnt++;
        }
        void cnt_Program_Method_檢查放開(ref int cnt)
        {
            if (!PLC_Device_Method.Bool) cnt = 65500;
        }
        void cnt_Program_Method_初始化(ref int cnt)
        {

            cnt++;
        }






        #endregion

        void sub_Prgram_MainForm()
        {
            sub_Program_系統更新();
        }
        #region 系統更新
        PLC_Device PLC_Device_系統更新 = new PLC_Device("M8001");
        int cnt_Program_系統更新 = 65534;
        void sub_Program_系統更新()
        {
            if (cnt_Program_系統更新 == 65534)
            {
                PLC_Device_系統更新.SetComment("PLC_系統更新");
                PLC_Device_系統更新.Bool = false;
                cnt_Program_系統更新 = 65535;
            }
            if (cnt_Program_系統更新 == 65535) cnt_Program_系統更新 = 1;
            if (cnt_Program_系統更新 == 1) cnt_Program_系統更新_檢查按下(ref cnt_Program_系統更新);
            if (cnt_Program_系統更新 == 2) cnt_Program_系統更新_初始化(ref cnt_Program_系統更新);
            if (cnt_Program_系統更新 == 3) cnt_Program_系統更新_檢查更新(ref cnt_Program_系統更新);
            if (cnt_Program_系統更新 == 4) cnt_Program_系統更新 = 65500;
            if (cnt_Program_系統更新 > 1) cnt_Program_系統更新_檢查放開(ref cnt_Program_系統更新);

            if (cnt_Program_系統更新 == 65500)
            {
                PLC_Device_系統更新.Bool = false;
                cnt_Program_系統更新 = 65535;
            }
        }
        void cnt_Program_系統更新_檢查按下(ref int cnt)
        {
            if (PLC_Device_系統更新.Bool) cnt++;
        }
        void cnt_Program_系統更新_檢查放開(ref int cnt)
        {
            if (!PLC_Device_系統更新.Bool) cnt = 65500;
        }
        void cnt_Program_系統更新_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_Program_系統更新_檢查更新(ref int cnt)
        {
            string updateVersion = this.ftp_DounloadUI.GetFileVersion();
            if (this.ftp_DounloadUI.CheckUpdate(this.ProductVersion, updateVersion))
            {
                if (Basic.MyMessageBox.ShowDialog(string.Format("有新版本是否更新? (Ver : {0})", updateVersion), "Update", Basic.MyMessageBox.enum_BoxType.Asterisk, Basic.MyMessageBox.enum_Button.Confirm_Cancel) == DialogResult.Yes)
                {
                    this.Invoke(new Action(delegate { this.Update(); }));               
                }
            }
            cnt++;
        }





        #endregion
        private void Update()
        {
            if (this.ftp_DounloadUI.DownloadFile())
            {
                if (this.ftp_DounloadUI.SaveFile())
                {
                    this.ftp_DounloadUI.RunFile(this.FindForm());
                }
                else
                {
                    Basic.MyMessageBox.ShowDialog("安裝檔存檔失敗!");
                }
            }
            else
            {
                Basic.MyMessageBox.ShowDialog("下載失敗!");
            }

        }

        private void Play_WAV(System.IO.UnmanagedMemoryStream Media)
        {
            this.BeginInvoke(new Action(delegate
            {
                System.Media.SoundPlayer sp = null;
                try
                {
                    sp = new System.Media.SoundPlayer();
                    sp.Stop();
                    sp.Stream = Media;
                    sp.Play();
                }
                finally
                {
                    if (sp != null) sp.Dispose();
                }
            }));
        }

        public string Function_藥品碼檢查(string Code)
        {
            if (Code.Length < 5) Code = $"0{Code}";
            if (Code.Length < 5) Code = $"0{Code}";
            if (Code.Length < 5) Code = $"0{Code}";
            if (Code.Length < 5) Code = $"0{Code}";
            if (Code.Length < 5) Code = $"0{Code}";
            return Code;
        }

   
    }
}
