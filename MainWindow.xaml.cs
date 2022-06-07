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

namespace Lab_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double a = 0;
        double b = 0;
        char sign;
        bool isLastOperationASign;

        private void button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if(isLastOperationASign == true)
            {
                Display.Text = "0";
                isLastOperationASign = false;
            }
            if (Display.Text == "0" || sign == 'e')
                Display.Text = button.Content.ToString();
            else
                Display.Text += button.Content.ToString();
        }

        private void button_Sign_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            
            if (button.Name == "button_clear_all")
            {
                Display.Text = "0";
                a = 0;
                b = 0;
            }
            else if (button.Name == "button_plus")
            {
                a = double.Parse(Display.Text);
                //Display.Text = "0";
                sign = 'p';
                
            }
            else if (button.Name == "button_minus")
            {
                a = double.Parse(Display.Text);
                //Display.Text = "0";
                sign = 'm';
            }
            else if (button.Name == "button_times")
            {
                a = double.Parse(Display.Text);
                //Display.Text = "0";
                sign = 't';
            }
            else if (button.Name == "button_divides")
            {
                a = double.Parse(Display.Text);
                //Display.Text = "0";
                sign = 'd';
            }
            else if (button.Name == "button_equals")
            {
                if(isLastOperationASign == false)
                {
                    if (sign == 'p')
                    {
                        //b = double.Parse(Display.Text);
                        a = (a + double.Parse(Display.Text));
                        Display.Text = a.ToString();
                    }
                    else if (sign == 'm')
                    {
                        //b = double.Parse(Display.Text);
                        a = (a - double.Parse(Display.Text));
                        Display.Text = a.ToString();
                    }
                    else if (sign == 't')
                    {
                        //b = double.Parse(Display.Text);
                        a = Math.Round(a * double.Parse(Display.Text), 4);
                        Display.Text = a.ToString();
                    }
                    else if (sign == 'd')
                    {
                        //b = double.Parse(Display.Text);
                        if (Display.Text.ToString() != "0")
                        {
                            a = Math.Round(a / double.Parse(Display.Text), 4);
                            Display.Text = a.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Nie dziel przez 0!");
                            Display.Text = "0";
                        }
                    }
                    a = 0;
                    b = 0;
                }
            }
            isLastOperationASign = true;
            if (button.Name == "button_point")
            {
                isLastOperationASign = false;
                if (!Display.Text.Contains(","))
                    Display.Text += ",";
            }
            else if (button.Name == "button_change_sign")
            {
                if (Display.Text[0] == '-')
                    Display.Text = Display.Text.Substring(1);
                else if (Display.Text == "0")
                {
                    
                }
                else
                    Display.Text = "-" + Display.Text;
            }

        }

        /*
        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show(button.Content.ToString());
            
            if(double.TryParse("1.2", out double x))
            {
                // Ma w zasięgu x
            }
        }
        */
    }
}
