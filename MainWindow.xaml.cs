using System;
using System.Windows;
using System.Windows.Controls;


namespace _1_pr
{

    public partial class MainWindow : Window
    {
        int Num_Signs = 0;
        string Sign = null, First_Num = "0", Second_Num = "0";
        string Sign_Buff = null, First_Second_Num_Buff = "0";
        bool Dod1 = false, Dod2 = false;



        public MainWindow()
        {
            InitializeComponent();

        }

        public string Calculation(double x, double y, string z)
        {

            if (z == "+")
            {
                x += y;
                return Convert.ToString(x);
            }
            else if (z == "-")
            {
                x -= y;
                return Convert.ToString(x);
            }
            else if (z == "*")
            {
                x *= y;
                return Convert.ToString(x);
            }
            else
            {
                x /= y;
                return Convert.ToString(x);
            }
        }

        private void WindowForm1_TextChanged(object sender, TextChangedEventArgs e) { }

        public void Sign_Determination(object sender, RoutedEventArgs e)
        {
            string Sign_Det = Convert.ToString((sender as Button).Content);

            if (WindowForm1.Text[WindowForm1.Text.Length - 1] == '+' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '-' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '*' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '/')
            {
                Sign = Sign_Det;
                WindowForm1.Text = First_Num + " " + Sign_Det;
                return;
            }

            Num_Signs++;

            if (Num_Signs > 1)
            {
                if (Second_Num == "0" && Sign == "/")
                {
                    WindowForm1.Text = "Error!";
                    First_Num = "0";
                    Second_Num = "0";
                    Num_Signs = 0;
                    Sign = null;
                    Dod1 = false;
                    Dod2 = false;
                }
                else
                {
                    First_Num = Calculation(Convert.ToDouble(First_Num), Convert.ToDouble(Second_Num), Sign);

                    if (Convert.ToDouble(First_Num) % 1 == 0) { Dod1 = false; Dod2 = false; } else { Dod2 = false; }

                    Sign = Sign_Det;
                    WindowForm1.Text = First_Num + " " + Sign;
                    Second_Num = "0";
                    Num_Signs = 1;
                }
            }
            else
            {
                Sign = Sign_Det;
                WindowForm1.Text = First_Num + " " + Sign;
            }
        }

        private void Num_Determination(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString((sender as Button).Content) == ",")
            {
                if ((Dod1 == true && Num_Signs == 0) || Dod2 == true) { return; }

                if (WindowForm1.Text[WindowForm1.Text.Length - 1] == '+' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '-' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '*' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '/')
                {
                    return;
                }

                if (Sign == null) { Dod1 = true; First_Num += ","; } else { Dod2 = true; Second_Num += ","; }

                WindowForm1.Text += ",";
                return;
            }

            string Number = Convert.ToString((sender as Button).Content);

            if (Num_Signs != 0)
            {
                if (Dod2 == true)
                {
                    WindowForm1.Text = Second_Num + Convert.ToString((sender as Button).Content);
                    Second_Num = WindowForm1.Text;
                }
                else
                {
                    if (Second_Num == "0") { Second_Num = Number; } else { Second_Num += Number; }
                    WindowForm1.Text = Second_Num;
                }
            }
            else
            {
                if (Dod1 == true)
                {
                    WindowForm1.Text = First_Num + Convert.ToString((sender as Button).Content);
                    First_Num = WindowForm1.Text;
                }
                else
                {
                    if (First_Num == "0") { First_Num = Number; } else { First_Num += Number; }
                    WindowForm1.Text = First_Num;
                }
            }
        }

        private void Equally(object sender, RoutedEventArgs e)
        {
            if (Second_Num == "0" && Sign == null)
            {
                return;
            }

            if (WindowForm1.Text[WindowForm1.Text.Length - 1] == '+' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '-' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '*' ||
                WindowForm1.Text[WindowForm1.Text.Length - 1] == '/')
            {
                if (Sign_Buff != Sign)
                {
                    First_Second_Num_Buff = First_Num;
                    Sign_Buff = Sign;
                }

                if (Convert.ToDouble(First_Second_Num_Buff) == 0 && Sign == "/")
                {
                    WindowForm1.Text = "Error!";
                    First_Num = "0";
                    Second_Num = "0";
                    Dod1 = false;
                    Dod2 = false;
                }
                else
                {
                    First_Num = Calculation(Convert.ToDouble(First_Num),
                        Convert.ToDouble(First_Second_Num_Buff), Sign);

                    if (Convert.ToDouble(First_Num) % 1 == 0) { Dod1 = false; Dod2 = false; } else { Dod2 = false; }

                    WindowForm1.Text = First_Num + " " + Sign;
                }
                return;
            }

            Sign_Buff = null;
            First_Second_Num_Buff = "0";


            if (Second_Num == "0" && Sign == "/")
            {
                WindowForm1.Text = "Error!";
                First_Num = "0";
                Second_Num = "0";
                Num_Signs = 0;
                Sign = null;
                Dod1 = false;
                Dod2 = false;
            }
            else
            {
                First_Num = Calculation(Convert.ToDouble(First_Num), Convert.ToDouble(Second_Num), Sign);

                if (Convert.ToDouble(First_Num) % 1 == 0) { Dod1 = false; Dod2 = false; } else { Dod2 = false; }

                WindowForm1.Text = First_Num;
                Second_Num = "0";
                Num_Signs = 0;
                Sign = null;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            WindowForm1.Text = "0";
            First_Num = "0";
            Second_Num = "0";
            Sign = null;
            Dod1 = false;
            Dod2 = false;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

            if (Second_Num == "0")
            {
                if (Sign != null)
                {
                    Sign = null;
                    Num_Signs = 0;
                    WindowForm1.Text = First_Num;
                    return;
                }

                int n = First_Num.Length;

                if (n == 1)
                {
                    First_Num = "0";
                    Dod1 = false;
                }
                else
                {
                    if (First_Num[n - 1] == ',')
                    {
                        Dod1 = false;
                    }
                    First_Num = First_Num.Remove(n - 1);
                }

                WindowForm1.Text = First_Num;
            }
            else
            {

                int n = Second_Num.Length;

                if (n == 1)
                {
                    Second_Num = "0";
                    WindowForm1.Text = First_Num + " " + Sign;
                    Dod2 = false;
                }
                else
                {
                    if (Second_Num[n - 1] == ',')
                    {
                        Dod2 = false;
                    }
                    Second_Num = Second_Num.Remove(n - 1);
                    WindowForm1.Text = Second_Num;
                }
            }
        }

        private void Documentation(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Сделал Юрчук Григорий\nСтудент 1-го курса ПМИ\nМне 18 лет\n" +
                "Мой ящик: iurchuk.ga@students.dvfu.ru",
                "About me",
                MessageBoxButton.OK,
                MessageBoxImage.Exclamation
                );
        }

        private void Close_event(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}