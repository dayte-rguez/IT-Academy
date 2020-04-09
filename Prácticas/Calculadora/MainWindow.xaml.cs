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

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double FirstNum { get; set; }
        /* Allow CurrentOperation to be nullable, so when any math operation sign is pressed, 
         * it will be possible to know wheter there is an operation in progress (CurrentOperation not null) 
         * or not (CurrentOperation is null)*/
        public Operations? CurrentOperation { get; set; }

        public bool RunningOp { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            /* Initialize operation status flag*/
            RunningOp = false;
        }

        #region Math Functions

        private bool TryReadCurrentNumber (out double input)
        {
            if (double.TryParse(TbResult.Text, out input))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Input is not a number");
                input = 0;
                return false;
            }
        }
        public void ApplyCurrentOp(double aSecondNum)
        {
            switch (CurrentOperation)
            {
                case Operations.Add:
                    /* Add and get ready for next operation*/
                    FirstNum += aSecondNum;
                    TbResult.Text = FirstNum.ToString();
                    break;
                case Operations.Subs:
                    /* Substract and get ready for next operation*/
                    FirstNum -= aSecondNum;
                    TbResult.Text = FirstNum.ToString();
                    break;
                case Operations.Mult:
                    /* Multiply and get ready for next operation*/
                    FirstNum *= aSecondNum;
                    TbResult.Text = FirstNum.ToString();
                    break;
                case Operations.Div:
                    /* Divide and get ready for next operation 
                     * Result is double since the operation involves doubles */
                    FirstNum /= aSecondNum;
                    TbResult.Text = FirstNum.ToString();
                    break;
                default:
                    break;
            }
        }
        public void Calc()
        {
            if (TryReadCurrentNumber(out double secondNum))
            {
                /* Prepare for next operation: flag a brand new calculation can take place*/
                RunningOp = false;
                /* Update label with operation progress */
                LbOperation.Content += " " + secondNum.ToString() + " = ";
                /* Calculate */
                ApplyCurrentOp(secondNum);
                /* Clean current operation since operation is finished */
                CurrentOperation = null;
            }
        }
        public void CalcInProgress()
        {
            if (TryReadCurrentNumber(out double secondNum))
            {
                /* Keep calculating conditions*/
                RunningOp = true;
                /* Update label with operation progress */
                LbOperation.Content += secondNum.ToString();
                /* Calculate */
                ApplyCurrentOp(secondNum);
            }
        }
        public void DoTheMath(string aOperation)
        {
            if (TryReadCurrentNumber(out double firstNum))
            {
                FirstNum = firstNum;
                switch (aOperation)
                {
                    case "add":
                        CurrentOperation = Operations.Add;
                        break;
                    case "subs":
                        CurrentOperation = Operations.Subs;
                        break;
                    case "mult":
                        CurrentOperation = Operations.Mult;
                        break;
                    case "div":
                        CurrentOperation = Operations.Div;
                        break;
                    default:
                        break;
                }
                /* Update label with first number */
                LbOperation.Content = firstNum.ToString();

                /* Flag operation in progress */
                RunningOp = true;
            }
        }
        public void Sum()
        {
            DoTheMath("add");
        }

        public void Substraction()
        {
            DoTheMath("subs");
        }

        public void Multiplication()
        {
            DoTheMath("mult");
        }

        public void Division()
        {
            DoTheMath("div");
        }

        #endregion Math Functions

        #region Calculator number buttons

        public void TypeNumber(string aValue)
        {
            /* When calculating, clean the textbox to receive the digits of second number */
            if (RunningOp)
            {
                TbResult.Text = aValue;
                RunningOp = false; //Allow to add more digits
            }
            else
            {
                TbResult.Text += aValue; //
            }
        }
        private void btPress7_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("7");
        }

        private void btPress8_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("8");
        }

        private void btPress9_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("9");
        }

        private void btPress4_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("4");
        }

        private void btPress5_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("5");
        }

        private void btPress6_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("6");
        }

        private void btPress1_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("1");
        }

        private void btPress2_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("2");
        }

        private void btPress3_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("3");
        }

        private void btPress0_Click(object sender, RoutedEventArgs e)
        {
            TypeNumber("0");
        }

        #endregion Calculator number buttons

        #region Calculator function buttons

        private void btPressCalc_Click(object sender, RoutedEventArgs e)
        {
            Calc();
        }

        private void btPressAdd_Click(object sender, RoutedEventArgs e)
        {
            /* If an operation is in progress, get the previous result and store it in FirstNumber */
            if (CurrentOperation.HasValue)
            {
                CalcInProgress();
                CurrentOperation = Operations.Add;
            }
            else
            {
                Sum();
            }
            /* Update label with the operation */
            LbOperation.Content += " + ";
        }

        private void btPressSubstract_Click(object sender, RoutedEventArgs e)
        {
            /* If an operation is in progress, get the previous result and store it in FirstNumber */
            if (CurrentOperation.HasValue)
            {
                CalcInProgress();
                CurrentOperation = Operations.Subs;
            }
            else
            {
                Substraction();
            }
            /* Update label with the operation */
            LbOperation.Content += " - ";
        }

        private void btPressMultiply_Click(object sender, RoutedEventArgs e)
        {
            /* If an operation is in progress, get the previous result and store it in FirstNumber */
            if (CurrentOperation.HasValue)
            {
                CalcInProgress();
                CurrentOperation = Operations.Mult;
            }
            else
            {
                Multiplication();
            }
            /* Update label with the operation */
            LbOperation.Content += " * ";
        }

        private void btPressDivide_Click(object sender, RoutedEventArgs e)
        {
            /* If an operation is in progress, get the previous result and store it in FirstNumber */
            if (CurrentOperation.HasValue)
            {
                CalcInProgress();
                CurrentOperation = Operations.Div;
            }
            else
            {
                Division();
            }
            /* Update label with the operation */
            LbOperation.Content += " / ";
        }

        #endregion Calculator function buttons
    }
}

public enum Operations
{
    Add,
    Subs,
    Mult,
    Div
    /* The same as 
    Add  = 0,
    Subs = 1,
    Mult = 2,
    Div  = 3 
    By default, the associated constant values of enum members start 
    with zero and increase by one. 
    Any other integral numeric type can be explicitly specified.
    Also, explicitly specified constant values are accepted as well
    */
}
