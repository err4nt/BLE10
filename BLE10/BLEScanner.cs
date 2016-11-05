using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Core;

namespace BLE10
{
    class BLEScanner
    {
        private BluetoothLEAdvertisementWatcher watcher;
        private ObservableCollection<ItemModel> _resultCollection = new ObservableCollection<ItemModel>();

        public ObservableCollection<ItemModel> Results { get { return _resultCollection; } }

        public BLEScanner()
        {
            watcher = new BluetoothLEAdvertisementWatcher();

            watcher.Received += Watcher_Received;
        }

        public void Start()
        {
            watcher.Start();
        }

        private async void Watcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            var result = FindDeviceByID(args.BluetoothAddress);
            if (result == null)
            {
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                 {
                     _resultCollection.Add(new ItemModel(args));
                 });
            }
            else
            {
                result.Update(args);
            }
        }

        public ItemModel FindDeviceByID(ulong id)
        {
            var result = from item in _resultCollection where item.MAC == id select item;
            return result.FirstOrDefault<ItemModel>();
        }
    }
}
