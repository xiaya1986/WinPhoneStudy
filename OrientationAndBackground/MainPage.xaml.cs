using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace OrientationAndBackground
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Visibility == System.Windows.Visibility.Visible)
            {
                myButton.Content = "Edit";
                textBlock1.Text = textBox1.Text;
                textBox1.Visibility = System.Windows.Visibility.Collapsed;
                textBlock1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                myButton.Content = "Save";
                textBox1.Text = textBlock1.Text;
                textBox1.Visibility = System.Windows.Visibility.Visible;
                textBlock1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}