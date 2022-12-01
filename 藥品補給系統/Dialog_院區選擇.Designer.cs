
namespace 藥品補給系統
{
    partial class Dialog_院區選擇
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_大武院區 = new System.Windows.Forms.Button();
            this.button_龍泉院區 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "院區選擇";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_大武院區
            // 
            this.button_大武院區.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_大武院區.Location = new System.Drawing.Point(97, 92);
            this.button_大武院區.Name = "button_大武院區";
            this.button_大武院區.Size = new System.Drawing.Size(612, 128);
            this.button_大武院區.TabIndex = 1;
            this.button_大武院區.Text = "屏東榮民總醫院";
            this.button_大武院區.UseVisualStyleBackColor = true;
            // 
            // button_龍泉院區
            // 
            this.button_龍泉院區.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_龍泉院區.Location = new System.Drawing.Point(97, 237);
            this.button_龍泉院區.Name = "button_龍泉院區";
            this.button_龍泉院區.Size = new System.Drawing.Size(612, 128);
            this.button_龍泉院區.TabIndex = 2;
            this.button_龍泉院區.Text = "屏東榮總龍泉分院";
            this.button_龍泉院區.UseVisualStyleBackColor = true;
            // 
            // Dialog_院區選擇
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button_龍泉院區);
            this.Controls.Add(this.button_大武院區);
            this.Controls.Add(this.label1);
            this.Name = "Dialog_院區選擇";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Dialog_院區選擇_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_大武院區;
        private System.Windows.Forms.Button button_龍泉院區;
    }
}