using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cosmo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // напутал название панелей
        #region SettingForm
        private bool isClickMouse = false;
        private Point currentPosition = new Point(0, 0);


        //button close app
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isClickMouse = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isClickMouse = true;
            currentPosition = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClickMouse) { return; }
            Point buf = new Point(this.Location.X, this.Location.Y);

            buf.X += e.X - currentPosition.X;
            buf.Y += e.Y - currentPosition.Y;
        }
        #endregion

        private bool isPoint = false;
        public bool isNum2 = false;

        private string num1 = null;
        private string num2 = null;

        private string currentOpiration = "";

        private void AddNum(string txt)
        {
            if (isNum2)
            {
                num2 += txt;
                panel.Text = num2;
            }
            else
            {
                num1 += txt;
                panel.Text = num1;
            }
        }


        private void SetNum(string txt)
        {
            if (isNum2)
            {
                num2 = txt;
                panel.Text = num2;
            }
            else
            {
                num1 = txt;
                panel.Text = num1;
            }
        }

        private void ButtonNumberClick(object obj, EventArgs e)
        {
            var txt = ((Button)obj).Text;
            {
                if (isPoint && txt == ",") { return; }
                if (txt == ",") { isPoint = true; }
            }

            if (txt == "+/-")
            {
                if (panel.Text.Length > 0)
                    if (panel.Text[0] == '_')
                    {
                        panel.Text = panel.Text.Substring(1, panel.Text.Length - 1);
                    }
                    else
                    {
                        panel.Text = "_" + panel.Text;
                    }
                SetNum(panel.Text);
                return;
            }
            AddNum(txt);
        }
        private void ButtonOperationClick(object obj, EventArgs e)
        {
            if (num1 == num1) { if (panel.Text.Length > 0) num1 = panel.Text; else return; }

            isNum2 = true;
            currentOpiration = ((Button)obj).Text;
            SetResult(currentOpiration);
        }
        private void SetResult(string operation)
        {
            string result = null;
            switch (operation)
            {
                case "+": { result = MathOperation1.Add(num1, num2); break; }
                case "-": { result = MathOperation1.Sub(num1, num2); break; }
                case "*": { result = MathOperation1.Mul(num1, num2); break; }
                case "/": { result = MathOperation1.Dev(num1, num2); break; }
                case "%": { result = MathOperation1.Proc(num1, num2); break; }
                case "№": { result = MathOperation1.Sqr(num1); isNum2 = false; break; }
                case "X^2": { result = MathOperation1.Pow(num1); isNum2 = false; break; }
                case "1/X": { result = MathOperation1.OneDev(num1); isNum2 = false; break; }


                default: break;
            }
            OutputResult(result, operation);
            if (isNum2) { if (result != null) num1 = result; } else { num1 = null; }
            isPoint = false;
        }

        private void OutputResult(string result, string operation)
        {
            switch (operation)
            {
                case "№": { if (num1 != null) panel.Text = "№" + num1 + " = "; break; }
                case "X^2": { if (num1 != null) panel.Text = "X^2" + num1 + " = "; break; }
                case "1/X": { if (num1 != null) panel.Text = "1/X" + num1 + " = "; break; }
                default:
                    {
                        if (num2 != null)
                        {
                            panel.Text = num1 + " " + operation + " " + num2 + " = ";
                        }
                        else
                        {
                            if (num1 != null)
                            {
                                panel.Text = num1 + " " + operation + " ";
                                break;
                            }
                        }
                    }
                    break;
            }

            num2 = null;
            if (result != null)
            {
                panel.Text = result;
            }
        }

        private void buttonClear(object obj, EventArgs e)
        {
            panel.Text = "";
            panel.Text = "";
            isNum2 = false;
            currentOpiration = null;
            num1 = null;
            num2 = null;
            isPoint = false;

        }

        private void buttonResultClick(object obj, EventArgs e)
        {
            SetResult(currentOpiration);
            isNum2 = false;
            num1 = null;
            num2 = null;
        }

        private void buttonResetNumber(object obj, EventArgs e)
        {
            if (panel.Text.Length <= 0) { return; }
            panel.Text = panel.Text.Substring(0, panel.Text.Length - 1);
            SetNum(panel.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
