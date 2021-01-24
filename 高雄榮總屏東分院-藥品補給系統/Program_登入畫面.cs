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
        readonly private string Admin_ID = "admin";
        readonly private string Admoin_Password = "66437068";

        private PLC_Device PLC_畫面登入_已登入權限 = new PLC_Device("S4079");
        private PLC_Device PLC_畫面登入_系統權限 = new PLC_Device("S4077");
        private List<PLC_Device> List_PLC_Device_權限管理 = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_權限管理_登入使用者權限索引 = new List<PLC_Device>();
        private PLC_Device PLC_權限管理_登入使用者權限索引 = new PLC_Device("Z21");
        private enum enum_權限等級
        {
            None = 0 ,Admin = 100, _01 = 1, _02 = 2, _03 = 3, _04 = 4, _05 = 5, _06 = 6, _07 = 7, _08 = 8, _09 = 9
        }

        private void Program_登入畫面_Init()
        {
            this.plC_WordBox_登入畫面_登入ID.SetString("");
            this.plC_WordBox_登入畫面_登入姓名.SetString("");
            for (int i = 0; i < 20; i++)
            {
                this.List_PLC_Device_權限管理.Add(new PLC_Device(string.Format("S{0}", (4080 + i).ToString())));
                this.List_PLC_Device_權限管理_登入使用者權限索引.Add(new PLC_Device(string.Format("S{0}Z21", (5100 + i).ToString())));
            }           
        }
        private void sub_Program_登入畫面()
        {
            sub_PLC_Program_登入畫面_頁面更新();
            sub_PLC_Program_登入畫面_登入();
            sub_PLC_Program_登入畫面_登出();
        }

        #region PLC_Program_登入畫面_頁面更新
        PLC_Device PLC_Program_登入畫面_頁面更新 = new PLC_Device("Y511");
        void sub_PLC_Program_登入畫面_頁面更新()
        {
            if (this.PLC_Program_登入畫面_頁面更新.Bool)
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_登入畫面_帳號.Text = "";
                    this.textBox_登入畫面_密碼.Text = "";
                }));
                this.PLC_Program_登入畫面_頁面更新.Bool = false;
            }
        }
        #endregion

        #region PLC_Program_登入畫面_登入
        int cnt_Program_登入畫面_登入 = 65534;
        void sub_PLC_Program_登入畫面_登入()
        {
            if (cnt_Program_登入畫面_登入 == 65534)
            {
                this.plC_Button_登入畫面_登入.SetValue(false);
                cnt_Program_登入畫面_登入 = 65535;
            }
            if (cnt_Program_登入畫面_登入 == 65535) cnt_Program_登入畫面_登入 = 1;
            if (cnt_Program_登入畫面_登入 == 1) cnt_Program_登入畫面_登入_檢查按下(ref cnt_Program_登入畫面_登入);
            if (cnt_Program_登入畫面_登入 == 2) cnt_Program_登入畫面_登入_檢查是否已登入(ref cnt_Program_登入畫面_登入);           
            if (cnt_Program_登入畫面_登入 == 3) cnt_Program_登入畫面_登入_初始化(ref cnt_Program_登入畫面_登入);
            if (cnt_Program_登入畫面_登入 == 4) cnt_Program_登入畫面_登入 = 100;

            if (cnt_Program_登入畫面_登入 == 100) cnt_Program_登入畫面_登入_100_檢查是否為最高權限(ref cnt_Program_登入畫面_登入);
            if (cnt_Program_登入畫面_登入 == 101) cnt_Program_登入畫面_登入_100_檢查ID及密碼(ref cnt_Program_登入畫面_登入);          
            if (cnt_Program_登入畫面_登入 == 102) cnt_Program_登入畫面_登入 = 65500;

            if (cnt_Program_登入畫面_登入 > 1) cnt_Program_登入畫面_登入_檢查放開(ref cnt_Program_登入畫面_登入);
            if (cnt_Program_登入畫面_登入 == 65500)
            {
                this.plC_Button_登入畫面_登入.SetValue(false);
                cnt_Program_登入畫面_登入 = 65535;
            }
        }
        void cnt_Program_登入畫面_登入_檢查按下(ref int cnt)
        {
            if (this.plC_Button_登入畫面_登入.GetValue()) cnt++;
        }
        void cnt_Program_登入畫面_登入_檢查放開(ref int cnt)
        {
            if (!this.plC_Button_登入畫面_登入.GetValue()) cnt = 65500;
        }
        void cnt_Program_登入畫面_登入_檢查是否已登入(ref int cnt)
        {
            if (this.PLC_畫面登入_已登入權限.Bool)
            {
                MyMessageBox.ShowDialog("權限已登入!");
                cnt = 65500;
            }
            else
            {
                cnt++;
            }
      
        }
        void cnt_Program_登入畫面_登入_初始化(ref int cnt)
        {
            List<string> List_error_msg = new List<string>();
            string str_error_msg = "";
            string ID = this.textBox_登入畫面_帳號.Text;
            string Password = this.textBox_登入畫面_密碼.Text;
            if (ID == "")
            {
                List_error_msg.Add("'帳號'欄位空白");
            }
            else
            {
                if (ID != this.Admin_ID)
                {
                    if (!this.sqL_DataGridView_人員資料.SQL_IsHaveMember(enum_人員資料.ID.GetEnumName(), ID))
                    {
                        List_error_msg.Add("'帳號'不存在");
                    }
                    else
                    {
                        List<object[]> value = this.sqL_DataGridView_人員資料.SQL_GetRows(enum_人員資料.ID.GetEnumName(), ID, false);
                        if (value[0][(int)enum_人員資料.密碼].ObjectToString() != Password)
                        {
                            List_error_msg.Add("密碼錯誤!");
                        }
                    }
                }

            }
            for (int i = 0; i < List_error_msg.Count; i++)
            {
                str_error_msg += i.ToString("00") + ". " + List_error_msg[i] + "\n\r";
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
        void cnt_Program_登入畫面_登入_100_檢查是否為最高權限(ref int cnt)
        {
            string ID = this.textBox_登入畫面_帳號.Text;
            string Password = this.textBox_登入畫面_密碼.Text;
            if (ID == this.Admin_ID)
            {
                if(Password == this.Admoin_Password)
                {
                    MyMessageBox.ShowDialog("最高權限登入成功!");
                    this.Function_登入畫面_登入權限(enum_權限等級.Admin);               
                }
                else
                {
                    MyMessageBox.ShowDialog("密碼錯誤!");
                }
                cnt = 65500;
                return;
            }
            cnt++;
        }
        void cnt_Program_登入畫面_登入_100_檢查ID及密碼(ref int cnt)
        {
            string ID = this.textBox_登入畫面_帳號.Text;
            string Password = this.textBox_登入畫面_密碼.Text;
            List<object[]> List_value = this.sqL_DataGridView_人員資料.SQL_GetRows(enum_人員資料.ID.GetEnumValue(), ID, false);
            if (List_value.Count > 0)
            {
                if (List_value[0][(int)enum_人員資料.密碼].ObjectToString() == Password)
                {
                    int 權限等級 = List_value[0][(int)enum_人員資料.權限等級].StringToInt32();
                    this.Function_登入畫面_登入權限((enum_權限等級)權限等級);
                    this.Function_登入畫面_設定登入ID(ID);
                    this.Function_登入畫面_設定登入姓名(List_value[0][(int)enum_人員資料.姓名].ObjectToString());
                    this.Invoke(new Action(delegate
                    {
                        this.textBox_登入畫面_帳號.Text = "";
                        this.textBox_登入畫面_密碼.Text = "";
                    }));
                    MyMessageBox.ShowDialog("登入成功!");
                }
                else
                {
                    MyMessageBox.ShowDialog("密碼錯誤!");
                    cnt = 65500;
                    return;
                }
            }
            else
            {
                MyMessageBox.ShowDialog("查無此帳號!");
                cnt = 65500;
                return;
            }
            cnt++;
        }
        void cnt_Program_登入畫面_登入_(ref int cnt)
        {
            cnt++;
        }


        #endregion
        #region PLC_Program_登入畫面_登出
        PLC_Device PLC_登入畫面_登出 = new PLC_Device("S4075");
        PLC_Device PLC_登入畫面_登出不詢問 = new PLC_Device("S4076");
        int cnt_Program_登入畫面_登出 = 65534;
        void sub_PLC_Program_登入畫面_登出()
        {
            if (cnt_Program_登入畫面_登出 == 65534)
            {
                PLC_登入畫面_登出.SetComment("PLC_登入畫面_登出");
                PLC_登入畫面_登出不詢問.SetComment("PLC_登入畫面_登出不詢問");
                this.PLC_登入畫面_登出.Bool = false;
                cnt_Program_登入畫面_登出 = 65535;
            }
            if (cnt_Program_登入畫面_登出 == 65535) cnt_Program_登入畫面_登出 = 1;
            if (cnt_Program_登入畫面_登出 == 1) cnt_Program_登入畫面_登出_檢查按下(ref cnt_Program_登入畫面_登出);
            if (cnt_Program_登入畫面_登出 == 2) cnt_Program_登入畫面_登出_初始化(ref cnt_Program_登入畫面_登出);
            if (cnt_Program_登入畫面_登出 == 3) cnt_Program_登入畫面_登出 = 65500;

            if (cnt_Program_登入畫面_登出 > 1) cnt_Program_登入畫面_登出_檢查放開(ref cnt_Program_登入畫面_登出);
            if (cnt_Program_登入畫面_登出 == 65500)
            {
                this.PLC_登入畫面_登出.Bool = false;
                cnt_Program_登入畫面_登出 = 65535;
            }
        }
        void cnt_Program_登入畫面_登出_檢查按下(ref int cnt)
        {
            if (this.PLC_登入畫面_登出.Bool) cnt++;
        }
        void cnt_Program_登入畫面_登出_檢查放開(ref int cnt)
        {
            if (!this.PLC_登入畫面_登出.Bool) cnt = 65500;
        }
        void cnt_Program_登入畫面_登出_初始化(ref int cnt)
        {
            if (!PLC_登入畫面_登出不詢問.Bool)
            {
                DialogResult Result = MyMessageBox.ShowDialog("確認登出?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel);
                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Invoke(new Action(delegate
                    {
                        this.textBox_登入畫面_帳號.Text = "";
                        this.textBox_登入畫面_密碼.Text = "";
                        this.Function_登入畫面_登入權限(enum_權限等級.None);
                    }));
                }
            }
            else
            {
                this.Invoke(new Action(delegate
                {
                    this.textBox_登入畫面_帳號.Text = "";
                    this.textBox_登入畫面_密碼.Text = "";
                    this.Function_登入畫面_登入權限(enum_權限等級.None);
                }));

            }
            PLC_登入畫面_登出不詢問.Bool = false;
            cnt++;
        }
        void cnt_Program_登入畫面_登出_(ref int cnt)
        {
            cnt++;
        }


        #endregion
        #region Function
        void Function_登入畫面_登入權限(enum_權限等級 _enum_權限等級)
        {
            this.Invoke(new Action(delegate
            {
                PLC_畫面登入_系統權限.Bool = false;
                if (_enum_權限等級 == enum_權限等級.None)
                {
                    foreach (PLC_Device value in List_PLC_Device_權限管理)
                    {
                        value.Bool = false;
                    }
                    this.Function_登入畫面_設定登入ID("");
                    this.Function_登入畫面_設定登入姓名("");
                    this.panel_權限設定.Enabled = false;
                }
                else if (_enum_權限等級 == enum_權限等級.Admin)
                {
                    PLC_畫面登入_系統權限.Bool = true;
                    foreach (PLC_Device value in List_PLC_Device_權限管理)
                    {
                        value.Bool = true;
                    }
                    this.Function_登入畫面_設定登入ID("最高管理權限");
                    this.Function_登入畫面_設定登入姓名("Admin");
                    this.panel_權限設定.Enabled = true;
                }
                else
                {
                    this.panel_權限設定.Enabled = false;
                    this.PLC_權限管理_登入使用者權限索引.Value = ((int)_enum_權限等級 - 1) * 20;
                    for (int i = 0; i < 20; i++)
                    {
                        this.List_PLC_Device_權限管理[i].Bool = this.List_PLC_Device_權限管理_登入使用者權限索引[i].Bool;
                        if (i == 19) this.List_PLC_Device_權限管理[i].Bool = true;
                    }
                }
            }));
     
        }
        void Function_登入畫面_設定登入ID(string ID)
        {
            this.plC_WordBox_登入畫面_登入ID.SetString(ID);
        }
        string Function_登入畫面_取得登入ID()
        {
            return this.plC_WordBox_登入畫面_登入ID.GetString();
        }
        void Function_登入畫面_設定登入姓名(string 姓名)
        {
            this.plC_WordBox_登入畫面_登入姓名.SetString(姓名);
        }
        string Function_登入畫面_取得登入姓名()
        {
            return this.plC_WordBox_登入畫面_登入姓名.GetString();
        }
        #endregion
        #region Event
        private void plC_Button_登入畫面_更改密碼_btnClick(object sender, EventArgs e)
        {
            sub_Form_修改密碼 _sub_Form_修改密碼 = new sub_Form_修改密碼();
            _sub_Form_修改密碼.ShowDialog();
            if(_sub_Form_修改密碼.Result == sub_Form_修改密碼.enum_Result.確認)
            {
                string ID = this.Function_登入畫面_取得登入ID();
                if(ID != this.Admin_ID)
                {
                    List<object[]> list_value = this.sqL_DataGridView_人員資料.SQL_GetRows(enum_人員資料.ID.GetEnumValue(), ID, false);
                    if (list_value.Count > 0)
                    {
                        list_value[0][(int)enum_人員資料.密碼] = _sub_Form_修改密碼.Password;
                        this.sqL_DataGridView_人員資料.SQL_Replace(enum_人員資料.ID.GetEnumValue(), ID, list_value[0], false);
                        this.Function_登入畫面_登入權限(enum_權限等級.None);
                        MyMessageBox.ShowDialog("密碼修正成功,請重新登入!");
                    }
                }
           
            }
        }
        #endregion
    }
}
