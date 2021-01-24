using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUI;

namespace 高雄榮總屏東分院_訂單管理系統
{
    public partial class Form1 : Form
    {
        Basic.Keyboard keyboard = new Basic.Keyboard();
        Basic.Mouse mouse = new Basic.Mouse();
        private readonly string DataBaseName = "Order_000";
        private readonly string UserName = "user";
        private readonly string Password = "66437068";
        private readonly string IP = "10.17.9.10";
        private readonly uint Port = 3306;

        private Basic.MyConvert myConvert = new Basic.MyConvert();
        PLC_Device PLC_現在頁面 = new PLC_Device("D0");
        PLC_Device PLC_按下滑鼠左鍵 = new PLC_Device("S4065");
        protected override bool ProcessDialogKey(Keys KeyCode)
        {
            if (KeyCode == Keys.Enter)
            {
                if (!PLC_Program_驗收訂單_掃描發票.Bool && !this.myEmail_Send_UI.IsEdited && !this.myEmail_Send_UI_信箱設定_文本.IsEdited && !this.myEmail_Send_UI_信箱設定_預覽.IsEdited)
                {
                    if (PLC_現在頁面.Value != 5)
                    {
                        SendKeys.Send("{TAB}");
                        return true;
                    }              
                }

            }
            return base.ProcessDialogKey(KeyCode);
        }

       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += "Ver"+this.ProductVersion;
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
            if(e.Button == MouseButtons.Left)
            {
                PLC_按下滑鼠左鍵.Bool = true;
            }
        }

        private void Timer_Init_Tick(object sender, EventArgs e)
        {
            if(this.plC_UI_Init.Init_Finish)
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

                this.licenseUI1.Init();

                this.timer_Init.Enabled = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(keyboard.MouseDown)
            {
                keyboard.MouseDown = false;
            }
        }

        private void plC_Button_系統更新_btnClick(object sender, EventArgs e)
        {
            if(Basic.MyMessageBox.ShowDialog("是否執行系統更新?下載完成,系統將會關閉!","Update",  Basic.MyMessageBox.enum_BoxType.Asterisk, Basic.MyMessageBox.enum_Button.Confirm_Cancel) == DialogResult.Yes)
            {
                if(this.ftp_DounloadUI1.DownloadFile())
                {
                    if(this.ftp_DounloadUI1.SaveFile())
                    {
                        this.ftp_DounloadUI1.RunFile();
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
        }
    }
}
