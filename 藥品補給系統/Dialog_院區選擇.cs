using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 藥品補給系統
{
    public partial class Dialog_院區選擇 : Form
    {
        public static Form form;
        public DialogResult ShowDialog()
        {
            if (form == null)
            {
                base.ShowDialog();
            }
            else
            {
                form.Invoke(new Action(delegate
                {
                    base.ShowDialog();
                }));
            }

            return this.DialogResult;
        }
        public enum_院區種類 Value = enum_院區種類.龍泉院區;
        public enum enum_院區種類
        {
            大武院區,
            龍泉院區,
        }
        public Dialog_院區選擇()
        {
            InitializeComponent();
        }

        private void Dialog_院區選擇_Load(object sender, EventArgs e)
        {
            this.button_大武院區.Click += Button_大武院區_Click;
            this.button_龍泉院區.Click += Button_龍泉院區_Click;
        }

        private void Button_龍泉院區_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Value = enum_院區種類.龍泉院區;
        }
        private void Button_大武院區_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Value = enum_院區種類.大武院區;
        }
    }
}
