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
using System.Device.Location;

namespace GeoPositionWebService
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GeoCoordinateWatcher myWatcher = new GeoCoordinateWatcher();
            var myPosition = myWatcher.Position;

            double latitude = 47.674;
            double longitude = -122.12;

            if (!myPosition.Location.IsUnknown)
            {
                latitude = myPosition.Location.Latitude;
                longitude = myPosition.Location.Longitude;
            }

            myTerraService.TerraServiceSoapClient client = new myTerraService.TerraServiceSoapClient();
            client.ConvertLonLatPtToNearestPlaceCompleted += new EventHandler<myTerraService.ConvertLonLatPtToNearestPlaceCompletedEventArgs>(client_ConvertLonLatPtToNearestPlaceCompleted);

            client.ConvertLonLatPtToNearestPlaceAsync(new myTerraService.LonLatPt { Lat = latitude, Lon = longitude });
        }

        void client_ConvertLonLatPtToNearestPlaceCompleted(object sender, myTerraService.ConvertLonLatPtToNearestPlaceCompletedEventArgs e)
        {
            textBlock1.Text = e.Result;
            //throw new NotImplementedException();
        }
    }
}