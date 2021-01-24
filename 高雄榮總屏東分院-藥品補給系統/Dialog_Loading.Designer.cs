namespace 高雄榮總屏東分院_訂單管理系統
{
    partial class Dialog_Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_StepValue = new System.Windows.Forms.Label();
            this.label_StepNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(8, 14);
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(239, 36);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // label_StepValue
            // 
            this.label_StepValue.AutoSize = true;
            this.label_StepValue.Location = new System.Drawing.Point(258, 30);
            this.label_StepValue.Name = "label_StepValue";
            this.label_StepValue.Size = new System.Drawing.Size(11, 12);
            this.label_StepValue.TabIndex = 1;
            this.label_StepValue.Text = "0";
            // 
            // label_StepNum
            // 
            this.label_StepNum.AutoSize = true;
            this.label_StepNum.Location = new System.Drawing.Point(288, 30);
            this.label_StepNum.Name = "label_StepNum";
            this.label_StepNum.Size = new System.Drawing.Size(11, 12);
            this.label_StepNum.TabIndex = 2;
            this.label_StepNum.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "/";
            // 
            // Dialog_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 63);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_StepNum);
            this.Controls.Add(this.label_StepValue);
            this.Controls.Add(this.progressBar);
            this.Name = "Dialog_Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Dialog_Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_StepValue;
        private System.Windows.Forms.Label label_StepNum;
        private System.Windows.Forms.Label label3;
    }
}