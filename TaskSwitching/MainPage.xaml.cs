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
using Microsoft.Phone.Shell;

namespace TaskSwitching
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        PhoneApplicationService phoneAppService = PhoneApplicationService.Current;

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            phoneAppService.State["MyValue"] = MyTextBox.Text;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            object myValue;
            if (phoneAppService.State.ContainsKey("MyValue"))
            {
                if (phoneAppService.State.TryGetValue("MyValue", out myValue))
                {
                    MyTextBox.Text = myValue.ToString();
                }
            }
        }
    }
}