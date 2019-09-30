using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Op;
        string ShowText;
        double PreviousNum;
        double CurrentNum;
        bool HaveOp;
        bool isTotal;
        Key KS;
        int DecimalPlaces = 12;
        public MainWindow()
        {
            HaveOp = false;
            isTotal = false;
            PreviousNum = 0;
            InitializeComponent();
        }
        private void ShowNum(string NumStr)
        {
            if (HaveOp == false && isTotal == false)
            {
                if (TotalTextBox.Text == "0" && NumStr != ".")
                    ShowText = NumStr;
                else
                    ShowText = TotalTextBox.Text + NumStr;

                if (PreviewTextBox.Text == "" || PreviewTextBox.Text == "0")
                    PreviewTextBox.Text = ShowText;
                else
                    PreviewTextBox.Text += NumStr;
            }
            else if (HaveOp == true)
            {
                HaveOp = false;
                ShowText = NumStr;
                if (PreviewTextBox.Text == "" || PreviewTextBox.Text == "0")
                    PreviewTextBox.Text = ShowText;
                else
                    PreviewTextBox.Text += NumStr;
            }
            else if (isTotal == true)
            {
                isTotal = false;
                ShowText = NumStr;
                if (PreviewTextBox.Text == "" || PreviewTextBox.Text == "0")
                    PreviewTextBox.Text = ShowText;
                else
                    PreviewTextBox.Text += NumStr;
            }
            TotalTextBox.Text = ShowText;
            InvalidTextBox.Visibility = Visibility.Hidden;
            PreviewTextBox.Visibility = Visibility.Visible;
        }
        private void ShowOp(string Op)
        {
            if (InvalidTextBox.Visibility == Visibility.Hidden)
            {
                this.Op = Op;
                HaveOp = true;
                PreviousNum = double.Parse(TotalTextBox.Text);
                OperatorTextBox.Visibility = Visibility.Visible;
                PreviewTextBox.Visibility = Visibility.Visible;
                OperatorTextBox.Text = Op;
                PreviewTextBox.Text = PreviousNum.ToString() + " " + Op + " ";
            }
        }
        private void Calculate()
        {
            if (Op == "+")
            {
                CurrentNum = PreviousNum + double.Parse(TotalTextBox.Text);
                PreviousNum = CurrentNum;
                TotalTextBox.Text = Math.Round(CurrentNum, DecimalPlaces).ToString();
                OperatorTextBox.Clear();
                OperatorTextBox.Visibility = Visibility.Hidden;
                HaveOp = false;
                Op = "";
            }
            if (Op == "-")
            {
                CurrentNum = PreviousNum - double.Parse(TotalTextBox.Text);
                PreviousNum = CurrentNum;
                TotalTextBox.Text = Math.Round(CurrentNum, DecimalPlaces).ToString();
                OperatorTextBox.Clear();
                OperatorTextBox.Visibility = Visibility.Hidden;
                HaveOp = false;
                Op = "";
            }
            if (Op == "x")
            {
                CurrentNum = PreviousNum * double.Parse(TotalTextBox.Text);
                PreviousNum = CurrentNum;
                TotalTextBox.Text = Math.Round(CurrentNum, DecimalPlaces).ToString();
                OperatorTextBox.Clear();
                OperatorTextBox.Visibility = Visibility.Hidden;
                HaveOp = false;
                Op = "";
            }
            if (Op == "÷")
            {
                CurrentNum = PreviousNum / double.Parse(TotalTextBox.Text);
                PreviousNum = CurrentNum;
                TotalTextBox.Text = Math.Round(CurrentNum, DecimalPlaces).ToString();
                OperatorTextBox.Clear();
                OperatorTextBox.Visibility = Visibility.Hidden;
                HaveOp = false;
                Op = "";
            }
            if (Op == "^")
            {
                CurrentNum = Math.Pow(PreviousNum, double.Parse(TotalTextBox.Text));
                PreviousNum = CurrentNum;
                TotalTextBox.Text = Math.Round(CurrentNum, DecimalPlaces).ToString();
                OperatorTextBox.Clear();
                OperatorTextBox.Visibility = Visibility.Hidden;
                HaveOp = false;
                Op = "";
            }
        }
        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("0");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("1");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("3");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("4");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("5");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("6");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("7");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("8");
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            ShowNum("9");
        }
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            for (int i = 0; i < TotalTextBox.Text.Length; i++)
            {
                if (TotalTextBox.Text[i] == '.')
                    count++;
            }
            if (count == 0)
                ShowNum(".");
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            ShowOp("+");
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            ShowOp("-");
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            ShowOp("x");
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            ShowOp("÷");
        }

        private void ButtonTotal_Click(object sender, RoutedEventArgs e)
        {
            PreviewTextBox.Clear();
            Calculate();
            isTotal = true;
            PreviousNum = 0;
            CurrentNum = double.Parse(TotalTextBox.Text);
            DecimalPlaces = 12;
            PreviewTextBox.Visibility = Visibility.Hidden;
            OperatorTextBox.Visibility = Visibility.Hidden;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TotalTextBox.Text = "0";
            Op = "";
            HaveOp = false;
            OperatorTextBox.Clear();
            PreviewTextBox.Clear();
            PreviousNum = 0;
            CurrentNum = 0;
            OperatorTextBox.Visibility = Visibility.Hidden;
            PreviewTextBox.Visibility = Visibility.Hidden;
            InvalidTextBox.Visibility = Visibility.Hidden;
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            if (PreviewTextBox.Text.Length >= 1)
            {
                PreviewTextBox.Text = PreviewTextBox.Text.Remove(PreviewTextBox.Text.Length - TotalTextBox.Text.Length);
                TotalTextBox.Text = "0";
            }
        }

        private void ButtonBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (TotalTextBox.Text.Length >= 1 && PreviewTextBox.Text.Length >= 1 && TotalTextBox.Text != "0")
            {
                PreviewTextBox.Text = PreviewTextBox.Text.Remove(PreviewTextBox.Text.Length - 1);
                TotalTextBox.Text = TotalTextBox.Text.Remove(TotalTextBox.Text.Length - 1);
                if (TotalTextBox.Text.Length <= 0)
                {
                    TotalTextBox.Text = "0";
                }
            }
        }

        private void ButtonPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (PreviewTextBox.Text.Length == TotalTextBox.Text.Length)
                PreviewTextBox.Text = (double.Parse(TotalTextBox.Text) * -1).ToString();
                TotalTextBox.Text = Math.Round(double.Parse(TotalTextBox.Text) * -1, DecimalPlaces).ToString();
            if (PreviewTextBox.Text.Length <= 0)
            {
                PreviousNum = double.Parse(TotalTextBox.Text) * -1;
                TotalTextBox.Text = Math.Round(PreviousNum, DecimalPlaces).ToString();
            }
        }

        private void Windows_KeyDown(object sender, KeyEventArgs e)
        {
            KS = e.Key;
            if (KS == Key.NumPad0)
                Button0_Click(sender, e);
            if (KS == Key.NumPad1)
                Button1_Click(sender, e);
            if (KS == Key.NumPad2)
                Button2_Click(sender, e);
            if (KS == Key.NumPad3)
                Button3_Click(sender, e);
            if (KS == Key.NumPad4)
                Button4_Click(sender, e);
            if (KS == Key.NumPad5)
                Button5_Click(sender, e);
            if (KS == Key.NumPad6)
                Button6_Click(sender, e);
            if (KS == Key.NumPad7)
                Button7_Click(sender, e);
            if (KS == Key.NumPad8)
                Button8_Click(sender, e);
            if (KS == Key.NumPad9)
                Button9_Click(sender, e);
            if (KS == Key.Decimal)
                ButtonDot_Click(sender, e);
            if (KS == Key.Add)
                ButtonAdd_Click(sender, e);
            if (KS == Key.Subtract)
                ButtonSubtract_Click(sender, e);
            if (KS == Key.Multiply)
                ButtonMultiply_Click(sender, e);
            if (KS == Key.Divide)
                ButtonDivide_Click(sender, e);
            if (KS == Key.Enter)
                ButtonTotal_Click(sender, e);
            if (KS == Key.Back)
                ButtonBackSpace_Click(sender, e);
            if (KS == Key.Delete)
                ButtonClear_Click(sender, e);
        }

        private void ButtonPower2_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = Math.Pow(double.Parse(TotalTextBox.Text), 2);
            TotalTextBox.Text = PreviousNum.ToString();
            PreviewTextBox.Clear();
            PreviewTextBox.Visibility = Visibility.Hidden;
        }

        private void ButtonPowerA_Click(object sender, RoutedEventArgs e)
        {
            ShowOp("^");
        }

        private void ButtonSin_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = double.Parse(TotalTextBox.Text);
            double Rad = PreviousNum * (Math.PI / 180);
            CurrentNum = Math.Round(Math.Sin(Rad), 10);
            TotalTextBox.Text = CurrentNum.ToString();
            PreviewTextBox.Text = "sin(" + PreviousNum.ToString() + ")";
            PreviousNum = CurrentNum;
        }

        private void ButtonCos_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = double.Parse(TotalTextBox.Text);
            double Rad = PreviousNum * (Math.PI / 180);
            CurrentNum = Math.Round(Math.Cos(Rad), 10);
            TotalTextBox.Text = CurrentNum.ToString();
            PreviewTextBox.Text = "cos(" + PreviousNum.ToString() + ")";
            PreviousNum = CurrentNum;
        }

        private void ButtonTan_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = double.Parse(TotalTextBox.Text);
            double Rad = PreviousNum * (Math.PI / 180);
            CurrentNum = Math.Round(Math.Tan(Rad), 10);
            if (PreviousNum == 90 || PreviousNum == 270)
            {
                InvalidTextBox.Visibility = Visibility.Visible;
                TotalTextBox.Text = "0";
                PreviousNum = 0;
                PreviewTextBox.Clear();
                PreviewTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                TotalTextBox.Text = CurrentNum.ToString();
                PreviewTextBox.Text = "tan(" + PreviousNum.ToString() + ")";
                PreviousNum = CurrentNum;
            }
        }

        private void ButtonPower3_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = Math.Pow(double.Parse(TotalTextBox.Text), 3);
            TotalTextBox.Text = Math.Round(PreviousNum, 10).ToString();
            PreviewTextBox.Clear();
            PreviewTextBox.Visibility = Visibility.Hidden;
        }

        private void ButtonSqurt_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = Math.Sqrt(double.Parse(TotalTextBox.Text));
            TotalTextBox.Text = Math.Round(PreviousNum, 10).ToString();
            PreviewTextBox.Clear();
            PreviewTextBox.Visibility = Visibility.Hidden;
        }

        private void ButtonPi_Click(object sender, RoutedEventArgs e)
        {
            PreviousNum = Math.PI;
            TotalTextBox.Text = Math.Round(PreviousNum, 8).ToString();
            PreviewTextBox.Text += "π";
            DecimalPlaces = 8;
        }
    }
}
