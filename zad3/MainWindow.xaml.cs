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

namespace zad3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string goodstring;

        int numLength;

        //bool lastSymb;
        bool first;

        public string Goodstring { get => goodstring; set { goodstring = value; upperText.Text = goodstring; } }

        //actioin 0+ 1- 2* 3/ -1NULL

        public MainWindow()
        {
            InitializeComponent();
            c_click(null, null);
            first = true;
        }


        /// <summary>
        /// Update Upper Text
        /// </summary>
        private void uut()
        {
            upperText.Text = Goodstring;
        }

        private void arrow_click(object sender, RoutedEventArgs e)
        {
            if (first)
            {
                c_click(null, null);
                first = false;
            }
            if (Goodstring.Length != 0)
            {
                Goodstring = Goodstring.Remove(Goodstring.Length - 1);
                numLength--;
            }
        }

        private void action_click(object sender, RoutedEventArgs e)
        {
            if (first)
            {
                c_click(null, null);
                Goodstring += "0";
                first = false;
            }
            if (numLength==0)
            {
                Goodstring = goodstring.Remove(goodstring.Length - 3, 3);
            }
            Goodstring += $" {(sender as Button).Content.ToString()} ";
            numLength = 0;
        }

        private void equal_click(object sender, RoutedEventArgs e)
        {
            if (Goodstring == "") return;
            if (numLength==0) Goodstring = Goodstring.Remove(goodstring.Length - 3, 3);

            //MessageBox.Show($"parsing {Goodstring}");
            List<string> nums = new List<string>(Goodstring.Split(' '));
            double num1;

            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] == "*")
                {
                    nums[i - 1] = (double.Parse(nums[i - 1]) * double.Parse(nums[i + 1])).ToString();
                    MessageBox.Show($"{nums[i - 1]}");
                    nums.RemoveRange(i, 2);
                }
                else if (nums[i] == "/")
                {
                    if (double.Parse(nums[i + 1]) == 0)
                    {
                        result.Text = "Делить на ноль нельзя";
                    }
                    nums[i - 1] = (double.Parse(nums[i - 1]) / double.Parse(nums[i + 1])).ToString();
                    nums.RemoveRange(i, 2);
                }

            }
            num1 = double.Parse(nums[0]);
            for (int i = 0; i < nums.Count() - 2; i += 2)
            {
                if (nums[i + 1] == "-")
                {
                    num1 = num1 - double.Parse(nums[i + 2]);
                }
                else if (nums[i + 1] == "+")
                {
                    num1 = num1 + double.Parse(nums[i + 2]);
                }
            }
            result.Text = num1.ToString();
            first = true;
        }

        private void dot_click(object sender, RoutedEventArgs e)
        {
            if (first)
            {
                c_click(null, null);
                first = false;
            }
            if(numLength==0)
                Goodstring += "0";
            numLength++;
            Goodstring += ",";
        }

        private void num_click(object sender, RoutedEventArgs e)
        {
            if (first)
            {
                c_click(null, null);
                first = false;
            }
            Goodstring += (sender as Button).Content.ToString();
            numLength++;
        }

        private void c_click(object sender, RoutedEventArgs e)
        {
            first = true;
            Goodstring = "";
            numLength = 0;
            result.Text = "";
        }

        private void CE_click(object sender, RoutedEventArgs e)
        {
            if (numLength > 0)
            {
               // MessageBox.Show($"{Goodstring.Length}\n{numLength}");
                Goodstring = Goodstring.Remove(Goodstring.Length - numLength, numLength);
                numLength = 0;
            }
        }
    }
}
