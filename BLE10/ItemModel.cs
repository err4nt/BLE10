using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Enumeration;

namespace BLE10
{
    class ItemModel
    {
        public ItemModel(BluetoothLEAdvertisementReceivedEventArgs deviceInformation)
        {
            MAC = deviceInformation.BluetoothAddress;
            rssi = deviceInformation.RawSignalStrengthInDBm;
        }

        public void Update(BluetoothLEAdvertisementReceivedEventArgs deviceInformation)
        {
            rssi = deviceInformation.RawSignalStrengthInDBm;
        }

        public ulong MAC { get; set; }
        public int rssi { get; set; }
    }
}
