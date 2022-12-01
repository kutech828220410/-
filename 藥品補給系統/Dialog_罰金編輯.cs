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
    public partial class Dialog_罰金編輯 : Form
    {
        public string Text
        {
            get
            {
                return "[逾時罰金編輯 : " + this.richTextBox_Comment.Text + "]";
            }
            private set
            {
                this.richTextBox_Comment.Text = value;
            }
        }
        private double _逾期罰金 = 0;
        public string 逾期罰金
        {
            get
            {
                return this.textBox_逾期罰金.Text;
            }
            set
            {
                if (double.TryParse(value, out this._逾期罰金))
                {
                    this.textBox_逾期罰金.Text = this._逾期罰金.ToString("0.0000");
                }
            }
        }
        public Dialog_罰金編輯()
        {
            InitializeComponent();
        }
        private void Dialog_罰金編輯_Load(object sender, EventArgs e)
        {
            this.richTextBox_Comment.Text = "";
        }

        private void button_確認_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
