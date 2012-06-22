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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void fileNameLinkButton_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton clickedLink = (HyperlinkButton)sender;
            string uri = String.Format("/IsolatedStorageListing;component/SecondPage.xaml?id={0}",clickedLink.Content);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void loadSamplesButton_Click(object sender, RoutedEventArgs e)
        {
            createSample("text1.txt", "This is the 1 test");
            createSample("text2.txt", "This is the 2 test");
            createSample("text3.txt", "This is the 3 test");
            createSample("text4.txt", "This is the 4 test");

            bindList();
        }

        private void createSample(string fileName, string fileContent)
        {
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            if (!appStorage.FileExists(fileName))
            {
                using (var file = appStorage.CreateFile(fileName))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        writer.WriteLine(fileContent);
                    }
                }
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            bindList();
        }

        private void bindList()
        {
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            string[] fileList = appStorage.GetFileNames();
            fileListBox.ItemsSource = fileList;

            freeTextBlock.Text = String.Format("Free: {0,25} Bytes",appStorage.AvailableFreeSpace.ToString());
            quotaTextBlock.Text = String.Format("Quota: {0,25} Bytes", appStorage.Quota.ToString());
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            string uri = String.Format("/IsolatedStorageListing;component/NewDoc.xaml");
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
    }
}