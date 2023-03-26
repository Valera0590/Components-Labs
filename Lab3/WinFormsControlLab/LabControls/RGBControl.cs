using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabControls
{
    public partial class RGBControl : UserControl
    {

        private RGBTextBox.Type curType;

        private Color curColor;

        public event EventHandler ColorChanged;

        public Color CurColor
        {
            get
            {
                return curColor;
            }
            set
            {
                curColor = value;
                OnColorChanged();
            }
        }

        public RGBControl()
        {
            InitializeComponent();
            ColorChanged += ChangeColor;
            curColor = Color.FromArgb(int.Parse(rgbTBRed.Text), int.Parse(rgbTBGreen.Text), int.Parse(rgbTBBlue.Text));
            rbDec.Checked = true;
        }

        //Событие изменение цвета
        protected void OnColorChanged()
        {
            if (ColorChanged != null)
                ColorChanged(this, new EventArgs());
        }

        //Изменение Color
        private void ChangeColor(object sender, EventArgs e)
        {
            (String R, String G, String B) color;

            if (curType == RGBTextBox.Type.Hex)
                color = (curColor.R.ToString("X"), curColor.G.ToString("X"), curColor.B.ToString("X"));
            else
                color = (curColor.R.ToString(), curColor.G.ToString(), curColor.B.ToString());

            rgbTBRed.Text = color.R;
            rgbTBGreen.Text = color.G;
            rgbTBBlue.Text = color.B;

            Invalidate();
        }

        //Отрисовка прямоугольника
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (DesignMode)
                e.Graphics.DrawRectangle(new Pen(curColor, 2), 160, 15, 120, 130);
            else
                e.Graphics.FillRectangle(new SolidBrush(curColor), 160, 15, 120, 130);
        }

        private void rbDec_CheckedChanged(object sender, EventArgs e)
        {
            if (curType == RGBTextBox.Type.Dec)
                return;

            curType = RGBTextBox.Type.Dec;
            rgbTBRed.CurType = curType;
            rgbTBGreen.CurType = curType;
            rgbTBBlue.CurType = curType;
        }

        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            if (curType == RGBTextBox.Type.Hex)
                return;

            curType = RGBTextBox.Type.Hex;
            rgbTBRed.CurType = curType;
            rgbTBGreen.CurType = curType;
            rgbTBBlue.CurType = curType;
        }

        private int StrConvertToInt(String text)
        {
            if (text == string.Empty) return 0;
            if (curType == RGBTextBox.Type.Hex) return Convert.ToInt32(text, 16);
            return int.Parse(text);
        }

        //Изменение цвета в текстовых полях
        private void ChangeTextColor()
        {
            if (!rgbTBRed.Focused && !rgbTBGreen.Focused && !rgbTBBlue.Focused)
                return;

            curColor = Color.FromArgb(StrConvertToInt(rgbTBRed.Text), StrConvertToInt(rgbTBGreen.Text), StrConvertToInt(rgbTBBlue.Text));

            Invalidate();
        }

        private void rgbTBRed_TextChanged(object sender, EventArgs e)
        {
            ChangeTextColor();
        }

        private void rgbTBGreen_TextChanged(object sender, EventArgs e)
        {
            ChangeTextColor();
        }

        private void rgbTBBlue_TextChanged(object sender, EventArgs e)
        {
            ChangeTextColor();
        }
    }
}
