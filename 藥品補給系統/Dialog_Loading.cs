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
    public partial class Dialog_Loading : Form
    {
        public int StepValue
        {
            get
            {
                return this.progressBar.Value;
            }
            set
            {
                this.Invoke(new Action(delegate
                {
                    this.progressBar.Value = value;
                    this.label_StepValue.Text = value.ToString();
                    this.label_StepValue.Refresh();
                    this.Refresh_Processbar();
                    Application.DoEvents();
                }));
            }
        }
        private int _StepNum = 0;
        public int StepNum
        {
            get
            {
                return this.progressBar.Maximum;
            }
            set
            {
                this.progressBar.Maximum = value;
                this.Invoke(new Action(delegate { this.label_StepNum.Text = value.ToString(); }));
            }
        }
        public Dialog_Loading()
        {
            InitializeComponent();
        }

        private void Dialog_Loading_Load(object sender, EventArgs e)
        {

        }

        public void Refresh_Processbar()
        {
            progressBar.Refresh();
        }
    }
}
