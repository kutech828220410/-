namespace 藥品補給系統
{
    partial class Dialog_罰金編輯
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
            this.button_確認 = new System.Windows.Forms.Button();
            this.richTextBox_Comment = new System.Windows.Forms.RichTextBox();
            this.panel166 = new System.Windows.Forms.Panel();
            this.textBox_逾期罰金 = new System.Windows.Forms.TextBox();
            this.panel167 = new System.Windows.Forms.Panel();
            this.label172 = new System.Windows.Forms.Label();
            this.panel166.SuspendLayout();
            this.panel167.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_確認
            // 
            this.button_確認.Location = new System.Drawing.Point(461, 189);
            this.button_確認.Name = "button_確認";
            this.button_確認.Size = new System.Drawing.Size(70, 33);
            this.button_確認.TabIndex = 8;
            this.button_確認.Text = "確認";
            this.button_確認.UseVisualStyleBackColor = true;
            this.button_確認.Click += new System.EventHandler(this.button_確認_Click);
            // 
            // richTextBox_Comment
            // 
            this.richTextBox_Comment.Location = new System.Drawing.Point(12, 48);
            this.richTextBox_Comment.Name = "richTextBox_Comment";
            this.richTextBox_Comment.Size = new System.Drawing.Size(519, 135);
            this.richTextBox_Comment.TabIndex = 9;
            this.richTextBox_Comment.Text = "";
            // 
            // panel166
            // 
            this.panel166.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel166.Controls.Add(this.textBox_逾期罰金);
            this.panel166.Controls.Add(this.panel167);
            this.panel166.Location = new System.Drawing.Point(12, 12);
            this.panel166.Name = "panel166";
            this.panel166.Size = new System.Drawing.Size(209, 26);
            this.panel166.TabIndex = 34;
            // 
            // textBox_逾期罰金
            // 
            this.textBox_逾期罰金.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_逾期罰金.Font = new System.Drawing.Font("新細明體", 12F);
            this.textBox_逾期罰金.Location = new System.Drawing.Point(84, 0);
            this.textBox_逾期罰金.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_逾期罰金.Name = "textBox_逾期罰金";
            this.textBox_逾期罰金.Size = new System.Drawing.Size(121, 27);
            this.textBox_逾期罰金.TabIndex = 4;
            this.textBox_逾期罰金.TabStop = false;
            this.textBox_逾期罰金.Text = "0.0000";
            // 
            // panel167
            // 
            this.panel167.Controls.Add(this.label172);
            this.panel167.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel167.Location = new System.Drawing.Point(0, 0);
            this.panel167.Name = "panel167";
            this.panel167.Size = new System.Drawing.Size(84, 22);
            this.panel167.TabIndex = 1;
            // 
            // label172
            // 
            this.label172.BackColor = System.Drawing.Color.LemonChiffon;
            this.label172.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label172.Font = new System.Drawing.Font("新細明體", 12F);
            this.label172.Location = new System.Drawing.Point(0, 0);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(84, 22);
            this.label172.TabIndex = 0;
            this.label172.Text = "逾期罰金";
            this.label172.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dialog_罰金編輯
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 229);
            this.Controls.Add(this.panel166);
            this.Controls.Add(this.richTextBox_Comment);
            this.Controls.Add(this.button_確認);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_罰金編輯";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "備註";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Dialog_罰金編輯_Load);
            this.panel166.ResumeLayout(false);
            this.panel166.PerformLayout();
            this.panel167.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_確認;
        private System.Windows.Forms.RichTextBox richTextBox_Comment;
        private System.Windows.Forms.Panel panel166;
        private System.Windows.Forms.TextBox textBox_逾期罰金;
        private System.Windows.Forms.Panel panel167;
        private System.Windows.Forms.Label label172;
    }
}