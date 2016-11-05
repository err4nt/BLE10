using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BLE10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private BLEScanner scanner;

        public MainPage()
        {
            this.InitializeComponent();

            scanner = new BLEScanner();
            DeviceListView.ItemsSource = scanner.Results;
            scanner.Start();
        }

        /*private async void Results_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                DeviceListView.ItemsSource
                DeviceListView.ItemsSource = scanner.Results;
            });
        }*/

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
