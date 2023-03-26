namespace LabControls
{
    partial class RGBControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRed = new System.Windows.Forms.Label();
            this.lbGreen = new System.Windows.Forms.Label();
            this.lbBlue = new System.Windows.Forms.Label();
            this.rbDec = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rgbTBBlue = new LabControls.RGBTextBox();
            this.rgbTBGreen = new LabControls.RGBTextBox();
            this.rgbTBRed = new LabControls.RGBTextBox();
            this.SuspendLayout();
            // 
            // lbRed
            // 
            this.lbRed.AutoSize = true;
            this.lbRed.Location = new System.Drawing.Point(22, 19);
            this.lbRed.Name = "lbRed";
            this.lbRed.Size = new System.Drawing.Size(52, 13);
            this.lbRed.TabIndex = 3;
            this.lbRed.Text = "Красный";
            // 
            // lbGreen
            // 
            this.lbGreen.AutoSize = true;
            this.lbGreen.Location = new System.Drawing.Point(22, 53);
            this.lbGreen.Name = "lbGreen";
            this.lbGreen.Size = new System.Drawing.Size(52, 13);
            this.lbGreen.TabIndex = 4;
            this.lbGreen.Text = "Зеленый";
            // 
            // lbBlue
            // 
            this.lbBlue.AutoSize = true;
            this.lbBlue.Location = new System.Drawing.Point(22, 92);
            this.lbBlue.Name = "lbBlue";
            this.lbBlue.Size = new System.Drawing.Size(38, 13);
            this.lbBlue.TabIndex = 5;
            this.lbBlue.Text = "Синий";
            // 
            // rbDec
            // 
            this.rbDec.AutoSize = true;
            this.rbDec.Location = new System.Drawing.Point(25, 126);
            this.rbDec.Name = "rbDec";
            this.rbDec.Size = new System.Drawing.Size(45, 17);
            this.rbDec.TabIndex = 6;
            this.rbDec.TabStop = true;
            this.rbDec.Text = "Dec";
            this.rbDec.UseVisualStyleBackColor = true;
            this.rbDec.CheckedChanged += new System.EventHandler(this.rbDec_CheckedChanged);
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(85, 126);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(44, 17);
            this.rbHex.TabIndex = 7;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
            // 
            // rgbTBBlue
            // 
            this.rgbTBBlue.CurType = LabControls.RGBTextBox.Type.Dec;
            this.rgbTBBlue.Location = new System.Drawing.Point(85, 90);
            this.rgbTBBlue.Name = "rgbTBBlue";
            this.rgbTBBlue.Size = new System.Drawing.Size(64, 20);
            this.rgbTBBlue.TabIndex = 2;
            this.rgbTBBlue.Text = "0";
            this.rgbTBBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rgbTBBlue.TextChanged += new System.EventHandler(this.rgbTBBlue_TextChanged);
            // 
            // rgbTBGreen
            // 
            this.rgbTBGreen.CurType = LabControls.RGBTextBox.Type.Dec;
            this.rgbTBGreen.Location = new System.Drawing.Point(85, 51);
            this.rgbTBGreen.Name = "rgbTBGreen";
            this.rgbTBGreen.Size = new System.Drawing.Size(64, 20);
            this.rgbTBGreen.TabIndex = 1;
            this.rgbTBGreen.Text = "0";
            this.rgbTBGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rgbTBGreen.TextChanged += new System.EventHandler(this.rgbTBGreen_TextChanged);
            // 
            // rgbTBRed
            // 
            this.rgbTBRed.CurType = LabControls.RGBTextBox.Type.Dec;
            this.rgbTBRed.Location = new System.Drawing.Point(85, 16);
            this.rgbTBRed.Name = "rgbTBRed";
            this.rgbTBRed.Size = new System.Drawing.Size(64, 20);
            this.rgbTBRed.TabIndex = 0;
            this.rgbTBRed.Text = "0";
            this.rgbTBRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rgbTBRed.TextChanged += new System.EventHandler(this.rgbTBRed_TextChanged);
            // 
            // RGBControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbHex);
            this.Controls.Add(this.rbDec);
            this.Controls.Add(this.lbBlue);
            this.Controls.Add(this.lbGreen);
            this.Controls.Add(this.lbRed);
            this.Controls.Add(this.rgbTBBlue);
            this.Controls.Add(this.rgbTBGreen);
            this.Controls.Add(this.rgbTBRed);
            this.Name = "RGBControl";
            this.Size = new System.Drawing.Size(319, 159);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RGBTextBox rgbTBRed;
        private RGBTextBox rgbTBGreen;
        private RGBTextBox rgbTBBlue;
        private System.Windows.Forms.Label lbRed;
        private System.Windows.Forms.Label lbGreen;
        private System.Windows.Forms.Label lbBlue;
        private System.Windows.Forms.RadioButton rbDec;
        private System.Windows.Forms.RadioButton rbHex;
    }
}
