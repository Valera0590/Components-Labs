using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LabControls
{
    public partial class RGBTextBox : TextBox
    {
        public enum Type
        {
            Dec, Hex
        }

        private Type curType;

        public Type CurType
        {
            get
            {
                return curType;
            }
            set
            {
                curType = value;
                OnTypeChanged();
            }
        }

        public RGBTextBox()
        {
            TypeChanged += TypeChange;
            Text = @"0";
            TextAlign = HorizontalAlignment.Center;
            CurType = Type.Dec;
            InitializeComponent();
        }

        public RGBTextBox(IContainer container)
        {
            container.Add(this);
            TypeChanged += TypeChange;
            Text = @"0";
            TextAlign = HorizontalAlignment.Center;
            CurType = Type.Dec;
            InitializeComponent();

        }

        public event EventHandler TypeChanged;

        protected void OnTypeChanged()
        {
            if (TypeChanged != null)
                TypeChanged(this, new EventArgs());
        }

        //Изменение CurMode. Перевод в другую систему счисления
        private void TypeChange(object sender, EventArgs e)
        {
            if (DesignMode) return;

            if (curType == Type.Hex)
            {
                if (Text != string.Empty) Text = int.Parse(Text).ToString("X");
            }
            else
            {
                if (Text != string.Empty) Text = Convert.ToInt32(Text, 16).ToString();
            }
        }

        //Проверка символа
        private bool CheckSymbol(char ch)
        {
            return char.IsDigit(ch) || curType == Type.Hex && IsLetterHex(ch);
        }

        //Символ из 16 системы счисления
        private bool IsLetterHex(char ch)
        {
            return ch >= 'A' && ch <= 'F' || ch >= 'a' && ch <= 'f';
        }

        //Проверка вводимого символа
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl((e.KeyChar)) && !CheckSymbol(e.KeyChar))
                e.Handled = true;

            base.OnKeyPress(e);
        }

        //Проверка корректного значения RGB
        bool CheckCorrectValue(String text)
        {
            foreach (var ch in text)
            {
                if (!CheckSymbol(ch)) return false;
            }
            return true;
        }

        //Изменение текста
        protected override void OnTextChanged(EventArgs e)
        {
            if (Text == string.Empty)
            {
                base.OnTextChanged(e);
                return;
            }

            if (!DesignMode && CheckCorrectValue(Text))
            {
                int value;
                Text = Text.ToUpper();
                if (curType == Type.Hex)
                {
                    value = Convert.ToInt32(Text, 16);
                    if (value > 255)
                    {
                        Text = @"FF";
                    }
                    else Text = value.ToString("X");
                }
                else
                {
                    value = Convert.ToInt32(Text);
                    if (value > 255)
                    {
                        Text = @"255";
                    }
                    else Text = value.ToString();
                }
            }
            else Text = @"0";
            base.OnTextChanged(e);

        }
    }
}
