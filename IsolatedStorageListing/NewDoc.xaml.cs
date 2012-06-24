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
    public partial class NewDoc : PhoneApplicationPage
    {
        public NewDoc()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            string uri = String.Format("/IsolatedStorageListing;component/MainPage.xaml");
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (fileNameTB.Text != "" && contentTB.Text != "")
            {
                createSample(fileNameTB.Text, contentTB.Text);
                var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
                if (appStorage.FileExists(fileNameTB.Text))
                {
                    fileNameTB.Text = "";
                    contentTB.Text = ""; 
                    this.Focus();
                    MessageBox.Show("File created successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to create file!");
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            fileNameTB.Text = "";
            contentTB.Text = ""; 
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
    }
}