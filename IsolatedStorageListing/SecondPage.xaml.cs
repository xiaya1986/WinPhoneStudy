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
using System.IO.IsolatedStorage;
using System.IO;

namespace IsolatedStorageListing
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            string fileName = NavigationContext.QueryString["id"];
            using (StreamReader sr = new StreamReader(appStorage.OpenFile(fileName,FileMode.Open)))
            {
                displayTextBlock.Text = sr.ReadToEnd();
            }
        }
    }
}