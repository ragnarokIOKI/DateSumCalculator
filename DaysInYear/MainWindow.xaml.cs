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

namespace DaysInYear
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbYear.Text, out int year))
            {
                int totalSum = 0;

                for (int month = 1; month <= 12; month++)
                {
                    int daysInMonth;

                    if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(month))
                    {
                        daysInMonth = 31;
                    }
                    else if (new[] { 4, 6, 9, 11 }.Contains(month))
                    {
                        daysInMonth = 30;
                    }
                    else
                    {
                        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                        {
                            daysInMonth = 29;
                        }
                        else
                        {
                            daysInMonth = 28;
                        }
                    }

                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        totalSum += day.ToString().Sum(digit => int.Parse(digit.ToString())) +
                                    month.ToString().Sum(digit => int.Parse(digit.ToString())) +
                                    year.ToString().Sum(digit => int.Parse(digit.ToString()));
                    }
                }

                lblResult.Content = $"Сумма всех дней в году {year}: {totalSum}";
            }
            else
            {
                lblResult.Content = "Введите корректный год!";
            }
        }
    }
}