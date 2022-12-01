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
        readonly private string Email_Setting_SavePath = @".\\host.pro";
        readonly private string Email_Body_reference_SavePath = @".\\mailref.rtf";
        readonly private string Email_Subject_reference_SavePath = @".\\mailref.sub";

        public string[] 信箱設定_Code_Data
        {
            get
            {
                string[] _信箱設定_Code_Data = new string[50];
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂單編號] = textBox_信箱設定_訂單編號.Text;
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂購人] = textBox_信箱設定_訂購人.Text;
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂購院所別] = textBox_信箱設定_訂購院所別.Text;
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.訂購日期] = textBox_信箱設定_訂購日期.Text;


                _信箱設定_Code_Data[(int)enum_信箱設定_Code.供應商全名] = textBox_信箱設定_供應商全名.Text;
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.包裝單位] = textBox_信箱設定_包裝單位.Text;
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.Email] = textBox_信箱設定_Email.Text;
                _信箱設定_Code_Data[(int)enum_信箱設定_Code.聯絡人] = textBox_信箱設定_聯絡人.Text;

                _信箱設定_Code_Data[(int)enum_信箱設定_Code.應驗收日期] = textBox_信箱設定_應驗收日期.Text;
                return _信箱設定_Code_Data;
            }
            set
            {
                this.Invoke(new Action(delegate
                {
                    textBox_信箱設定_訂單編號.Text = value[(int)enum_信箱設定_Code.訂單編號];
                    textBox_信箱設定_訂購人.Text = value[(int)enum_信箱設定_Code.訂購人];
                    textBox_信箱設定_訂購院所別.Text = value[(int)enum_信箱設定_Code.訂購院所別];
                    textBox_信箱設定_訂購日期.Text = value[(int)enum_信箱設定_Code.訂購日期];


                    textBox_信箱設定_供應商全名.Text = value[(int)enum_信箱設定_Code.供應商全名];
                    textBox_信箱設定_包裝單位.Text = value[(int)enum_信箱設定_Code.包裝單位];
                    textBox_信箱設定_Email.Text = value[(int)enum_信箱設定_Code.Email];
                    textBox_信箱設定_聯絡人.Text = value[(int)enum_信箱設定_Code.聯絡人];

                    textBox_信箱設定_應驗收日期.Text = value[(int)enum_信箱設定_Code.應驗收日期];
                }));
            }
        }
        public enum enum_信箱設定_Code
        {
            訂單編號 = 0,
            訂購人 = 1,
            訂購院所別 = 2,
            訂購日期 = 3,

            藥品內容表格 = 10,

            供應商全名 = 20,
            包裝單位 = 21,
            Email = 22,
            聯絡人 = 23,
            應驗收日期 = 30,
        }

        private void Program_信箱設定_Init()
        {

            this.myEmail_Send_UI.LoadProperties(this.Email_Setting_SavePath);

            this.textBox_信箱設定_伺服器參數_UserName.Text = this.myEmail_Send_UI.UserName;
            this.textBox_信箱設定_伺服器參數_Password.Text = this.myEmail_Send_UI.Password;
            this.textBox_信箱設定_伺服器參數_Host.Text = this.myEmail_Send_UI.Host;
            this.textBox_信箱設定_伺服器參數_Port.Text = this.myEmail_Send_UI.Port;
            this.textBox_信箱設定_伺服器參數_發件者.Text = this.myEmail_Send_UI.Sender;

        }
        private void sub_Program_信箱設定()
        {
            sub_PLC_Program_信箱設定_頁面更新();
        }
        #region PLC_Program_信箱設定_頁面更新
        PLC_Device PLC_Program_信箱設定_頁面更新 = new PLC_Device("Y501");
        void sub_PLC_Program_信箱設定_頁面更新()
        {
            if (this.PLC_Program_信箱設定_頁面更新.Bool)
            {
                this.myEmail_Send_UI_信箱設定_文本.Load_To_RTF(this.Email_Body_reference_SavePath);
                this.myEmail_Send_UI_信箱設定_文本.LoadSubject(this.Email_Subject_reference_SavePath);

                this.myEmail_Send_UI.LoadProperties(this.Email_Setting_SavePath);
                this.Invoke(new Action(delegate
                {
                    this.textBox_信箱設定_伺服器參數_UserName.Text = this.myEmail_Send_UI.UserName;
                    this.textBox_信箱設定_伺服器參數_Password.Text = this.myEmail_Send_UI.Password;
                    this.textBox_信箱設定_伺服器參數_Host.Text = this.myEmail_Send_UI.Host;
                    this.textBox_信箱設定_伺服器參數_Port.Text = this.myEmail_Send_UI.Port;
                    this.textBox_信箱設定_伺服器參數_發件者.Text = this.myEmail_Send_UI.Sender;
                }));
        

                this.PLC_Program_信箱設定_頁面更新.Bool = false;
            }
        }

        #endregion
        #region Function
        public string Function_信箱設定_GetCode(int index)
        {
            return "{" + index.ToString() + "}";
        }
        public string Function_信箱設定_ReplaceCode(string value)
        {
            Array emun_values = Enum.GetValues(typeof(enum_信箱設定_Code));
            foreach (int i in Enum.GetValues(typeof(enum_信箱設定_Code)))
            {
                value = value.Replace(this.Function_信箱設定_GetCode(i), 信箱設定_Code_Data[i]);
            }
            return value;
        }
        public void Function_信箱設定_ReplaceCode(MyEmail.MyEmail_Send_UI MyEmail_Send_UI, MyEmail.MyEmail_Send_UI.Table_Rtf Table_Rtf)
        {
            Array emun_values = Enum.GetValues(typeof(enum_信箱設定_Code));
            foreach (int i in Enum.GetValues(typeof(enum_信箱設定_Code)))
            {
                if (i != (int)enum_信箱設定_Code.藥品內容表格)
                {
                    MyEmail_Send_UI.Replace(this.Function_信箱設定_GetCode(i), 信箱設定_Code_Data[i]);
                }
                else
                {
                    MyEmail_Send_UI.Replace_RTF(this.Function_信箱設定_GetCode(i), Table_Rtf.Get_Table_RTF());
                }
            }
        }
        #endregion
        #region Event
        private void plC_Button_信箱設定_填入預設值_btnClick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string[] 信箱設定_Code_Data_buf = new string[50];
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.訂單編號] = "SN12345678";
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.訂購人] = "王曉明";
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.訂購院所別] = "XXX院所";
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.訂購日期] = date.Date.ToShortDateString();

            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.供應商全名] = "供應商XXX有限公司";
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.包裝單位] = "PCS";
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.Email] = "test@yahoo.com.tw";
            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.聯絡人] = "章大同";

            信箱設定_Code_Data_buf[(int)enum_信箱設定_Code.應驗收日期] = date.Date.AddDays(10).ToShortDateString();


            this.信箱設定_Code_Data = 信箱設定_Code_Data_buf;
        }
        private void plC_Button_信箱設定_信件文本_信件預覽_btnClick(object sender, EventArgs e)
        {
      
            this.myEmail_Send_UI_信箱設定_文本.LoadSubject(this.Email_Subject_reference_SavePath);
            this.myEmail_Send_UI_信箱設定_預覽.Subject = this.Function_信箱設定_ReplaceCode(this.myEmail_Send_UI_信箱設定_文本.Subject);
            this.myEmail_Send_UI_信箱設定_預覽.Load_To_RTF(this.Email_Body_reference_SavePath);

            string 包裝單位 = Function_信箱設定_ReplaceCode("{21}");
            MyEmail.MyEmail_Send_UI.Table_Rtf Table_Rtf = new MyEmail.MyEmail_Send_UI.Table_Rtf(4, 4);
            Table_Rtf.AddRow(new string[] { "藥品碼", "名稱", "數量", "包裝單位" });
            Table_Rtf.AddRow(new string[] { "02721", "藥品001", "5", 包裝單位 });
            Table_Rtf.AddRow(new string[] { "06788", "藥品002", "3", 包裝單位 });
            Table_Rtf.AddRow(new string[] { "09823", "藥品003", "15", 包裝單位 });
            Table_Rtf.Set_ColunmWidth(0, 1000);
            Table_Rtf.Set_ColunmWidth(1, 4000);
            Table_Rtf.Set_ColunmWidth(2, 1000);
            Table_Rtf.Set_ColunmWidth(3, 1500);
            this.Function_信箱設定_ReplaceCode(this.myEmail_Send_UI_信箱設定_預覽, Table_Rtf);
        }
        private void plC_Button_信箱設定_信件文本_設定完成_btnClick(object sender, EventArgs e)
        {
            this.myEmail_Send_UI_信箱設定_文本.Save_To_RTF(this.Email_Body_reference_SavePath);
            this.myEmail_Send_UI_信箱設定_文本.SaveSubject(this.Email_Subject_reference_SavePath);
            MyMessageBox.ShowDialog("設定完成!");
        }
        private void checkBox_信箱設定_伺服器參數_顯示字元_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBox_信箱設定_伺服器參數_顯示字元.Checked) this.textBox_信箱設定_伺服器參數_Password.PasswordChar = '*';
            else this.textBox_信箱設定_伺服器參數_Password.PasswordChar = (char)0;
        }
        private void plC_Button_信箱設定_伺服器參數_設定完成_btnClick(object sender, EventArgs e)
        {
            this.myEmail_Send_UI.UserName = this.textBox_信箱設定_伺服器參數_UserName.Text;
            this.myEmail_Send_UI.Password = this.textBox_信箱設定_伺服器參數_Password.Text;
            this.myEmail_Send_UI.Host = this.textBox_信箱設定_伺服器參數_Host.Text;
            this.myEmail_Send_UI.Port = this.textBox_信箱設定_伺服器參數_Port.Text;
            this.myEmail_Send_UI.Sender = this.textBox_信箱設定_伺服器參數_發件者.Text;


            this.myEmail_Send_UI.SaveProperties(this.Email_Setting_SavePath);

            MyMessageBox.ShowDialog("設定完成!");
        }
        #endregion
    }
}
